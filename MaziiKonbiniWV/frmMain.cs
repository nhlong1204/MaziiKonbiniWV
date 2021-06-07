using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;
using AngleSharp;
using AngleSharp.Html.Parser;
using AngleSharp.Dom;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Win32;

namespace MaziiKonbiniWV
{
    public partial class frmMain : Form
    {  
        private static readonly HttpClient client = new HttpClient(new HttpClientHandler { UseProxy = false });
        private static readonly RegistryKey regKey = Registry.CurrentUser.OpenSubKey(CONSTANT.registryStartUpPath, true);
        private static string searchText = string.Empty;
        private static string previousText = string.Empty;

        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;
        private static frmMain frmInterChange;
        public frmMain()
        {
            client.Timeout = TimeSpan.FromSeconds(CONSTANT.TIME_OUT);
            frmInterChange = this;
            _hookID = SetHook(_proc);
            InitializeComponent();
            //Check de hien thi icon check o menustrip item
            startWithWindowsToolStripMenuItem.CheckState = regKey.GetValueNames().Contains(Application.ProductName) ? CheckState.Checked : CheckState.Unchecked;
        }      

        private async void Form1_Load(object sender, EventArgs e)
        {
            await wvMain.EnsureCoreWebView2Async();
            wvMain.NavigateToString(CONSTANT.templateHTML);
        }

        private static HttpResponseMessage RequestKanji()
        {
            var payLoadKanji = new
            {
                dict = "javi",
                page = 1,
                query = searchText, 
                type = CONSTANT.PayloadType.KANJI
            };

            var jsonData = JsonSerializer.Serialize(payLoadKanji);
            var data = new StringContent(jsonData, Encoding.UTF8, System.Net.Mime.MediaTypeNames.Application.Json.ToString());
            var response = client.PostAsync(CONSTANT.baseURL, data).Result;

            return response;
        }

        private static string GetMeanHanViet()
        {
            var responseKanji = RequestKanji();
            JsonDocument doc = JsonDocument.Parse(responseKanji.Content.ReadAsStringAsync().Result);

            if (doc.RootElement.GetProperty("status").GetInt16() == ((int)System.Net.HttpStatusCode.Found))
            {
                return string.Empty;
            }

            if (doc.RootElement.GetProperty("results").GetArrayLength() != 0)
            {
                //Search lan 1, neu tim thay nghia co san thi lay ra
                foreach (JsonElement eachResult in doc.RootElement.GetProperty("results").EnumerateArray())
                {
                    if (eachResult.GetProperty("examples").GetArrayLength() != 0)
                    {
                        foreach (JsonElement eachElemExample in eachResult.GetProperty("examples").EnumerateArray())
                        {
                            if (eachElemExample.GetProperty("w").GetString().CompareTo(searchText) == 0)
                            {
                                return eachElemExample.GetProperty("h").GetString();
                            }

                        }
                    }
                }

                //Search lan 2, neu khong tim thay nghia co san thi search lam luot tung chu Han roi ghep lai
                string resultHanViet = string.Empty;
                foreach (char eachKanjiChar in searchText.ToCharArray())
                {
                    foreach (JsonElement eachResult in doc.RootElement.GetProperty("results").EnumerateArray())
                    {
                        if (eachResult.GetProperty("kanji").GetString().CompareTo(eachKanjiChar.ToString()) == 0)
                        {
                            resultHanViet += eachResult.GetProperty("mean").GetString() + " ";
                        }
                    }
                }
                return resultHanViet.Trim();
            }
            else
            {
                return string.Empty;
            }

            return string.Empty;
        }
        private void DisplayResult()
        {            
            //Create html skeleton
            var config = Configuration.Default;
            var context = BrowsingContext.New(config);
            var source = CONSTANT.templateHTML;
            var document = context.OpenAsync(req => req.Content(source));

            //Set mean Han Viet
            string resultMeanHanViet = string.Empty;

            var payLoadWord = new
            {
                dict = "javi",
                limit = 20, //Limit so kq tra ve bao gom nghia chinh(neu co) va tu goi y
                page = 1,
                query = searchText, //"価値",
                type = CONSTANT.PayloadType.WORD
            };

            try
            {
                var jsonData = JsonSerializer.Serialize(payLoadWord);
                var data = new StringContent(jsonData, Encoding.UTF8, System.Net.Mime.MediaTypeNames.Application.Json.ToString());
                var response = client.PostAsync(CONSTANT.baseURL, data).Result;

                JsonDocument doc = JsonDocument.Parse(response.Content.ReadAsStringAsync().Result);

                JsonElement dataElementZero = doc.RootElement.GetProperty("data")[0];
                searchText = dataElementZero.GetProperty("word").GetString();

                //Neu request word ma tim thay thi moi tim kanji tiep
                if (doc.RootElement.GetProperty("found").GetBoolean())
                {
                    //Truong hop copy tieng Viet thi check label, neu dung thi moi request
                    if (dataElementZero.GetProperty("label").GetString().CompareTo("ja_vi") == 0)
                    {
                        resultMeanHanViet = GetMeanHanViet();
                        if (resultMeanHanViet != string.Empty)
                        {
                            resultMeanHanViet = "「" + resultMeanHanViet + "」";
                        }
                    }
                }

                //Add search text to body
                var searchTextElem = document.Result.CreateElement("h2");
                searchTextElem.Id = "search-text";
                searchTextElem.TextContent = searchText;
                document.Result.Body.AppendChild(searchTextElem);

                //Add furigana text to body
                if (!string.IsNullOrEmpty(dataElementZero.GetProperty("phonetic").GetString()))
                {
                    var furiganaElem = document.Result.CreateElement("p");
                    furiganaElem.Id = "furigana";
                    furiganaElem.ClassName = "phonetic";
                    furiganaElem.TextContent = dataElementZero.GetProperty("phonetic").GetString();

                    var hanvietElem = document.Result.CreateElement("p");
                    hanvietElem.Id = "hanviet";
                    hanvietElem.ClassName = "phonetic";
                    hanvietElem.TextContent = resultMeanHanViet;
                    document.Result.Body.AppendChild(furiganaElem).AppendChild(hanvietElem);                    
                }

                foreach (JsonElement eachMeanArrElement in dataElementZero.GetProperty("means").EnumerateArray())
                {
                    //Get kind
                    string wordType = string.Empty;
                    if (!string.IsNullOrEmpty(eachMeanArrElement.GetProperty("kind").GetString()))
                    {
                        foreach (string wordKey in eachMeanArrElement.GetProperty("kind").GetString().Split(','))
                        {
                            if (CONSTANT.WordType.ContainsKey(wordKey.Trim()))
                            {
                                wordType += CONSTANT.WordType[wordKey.Trim()] + ", ";
                            }
                            else
                            {
                                wordType += wordKey.Trim() + ", ";
                            }
                        }
                        wordType = wordType.Remove(wordType.Length - 2);
                    }

                    //Set to label then add to body
                    //Add kind
                    var eachKindElem = document.Result.CreateElement("p");
                    eachKindElem.ClassName = "each-kind";
                    eachKindElem.TextContent = (char)CONSTANT.SymbolCode.Kind + " " + wordType;

                    var eachMeanElem = document.Result.CreateElement("p");
                    eachMeanElem.ClassName = "each-mean";
                    eachMeanElem.TextContent = (char)CONSTANT.SymbolCode.MainMean + " " + eachMeanArrElement.GetProperty("mean").GetString();
                    document.Result.Body.AppendChild(eachKindElem).AppendChild(eachMeanElem);

                    //Set each example
                    if (eachMeanArrElement.GetProperty("examples").ValueKind == JsonValueKind.Array &&
                        eachMeanArrElement.GetProperty("examples").GetArrayLength() > 0) 
                    {
                        foreach (JsonElement eachExample in eachMeanArrElement.GetProperty("examples").EnumerateArray())
                        {
                            var eachExampleJPElem = document.Result.CreateElement("p");
                            eachExampleJPElem.ClassName = "example-jp";
                            eachExampleJPElem.TextContent = eachExample.GetProperty("content").GetString();

                            var eachExampleVNElem = document.Result.CreateElement("p");
                            eachExampleVNElem.ClassName = "example-vn";
                            eachExampleVNElem.TextContent = eachExample.GetProperty("mean").GetString();

                            document.Result.Body.AppendChild(eachExampleJPElem).AppendChild(eachExampleVNElem);
                            
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException is TaskCanceledException)
                {
                    var errorMessageTimeOut = document.Result.CreateElement("p");
                    errorMessageTimeOut.TextContent = "TIME OUT!" + Environment.NewLine + CONSTANT.baseURL + " took too long to respond";
                    document.Result.Body.AppendChild(errorMessageTimeOut);
                }
                else
                {  
                    var errorMessageElem = document.Result.CreateElement("p");
                    errorMessageElem.TextContent = "Search text: " + searchText + Environment.NewLine + "Message: " + ex.Message;
                    document.Result.Body.AppendChild(errorMessageElem);
                }
            }

            wvMain.NavigateToString(document.Result.DocumentElement.OuterHtml);
            showMainScreen();
        }

        private void showMainScreen()
        {
            /*this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Visible = true;
            this.Activate();*/

            this.TopMost = true;
            this.WindowState = FormWindowState.Normal;
            this.Show();
            this.Activate();
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(CONSTANT.WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)CONSTANT.WM_KEYUP) //(IntPtr)WM_KEYDOWN
            {
                int vkCode = Marshal.ReadInt32(lParam);
                if (Keys.C == (Keys)vkCode && Keys.Control == Control.ModifierKeys)
                {
                    if (Clipboard.ContainsText())
                    {
                        Debug.WriteLine(Clipboard.GetText());
                        searchText = Clipboard.GetText().Trim();
                        if (string.Compare(searchText, previousText) != 0)
                        {
                            Debug.WriteLine(">>>> call");
                            frmInterChange.ShowSpinner();
                            frmInterChange.DisplayResult();
                            previousText = searchText;
                        }
                        else
                        {
                            frmInterChange.showMainScreen();
                        }
                    }
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        #region DLLImport
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        #endregion

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void startWithWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //RegistryKey regKey = Registry.CurrentUser.OpenSubKey(CONSTANT.registryStartUpPath, true);
            if (startWithWindowsToolStripMenuItem.Checked)
            {
                if (!regKey.GetValueNames().Contains(Application.ProductName))
                {
                    regKey.SetValue(Application.ProductName, Application.ExecutablePath);
                }
                
            }
            else
            {
                regKey.DeleteValue(Application.ProductName, false);
            }
        }

        private void ShowSpinner()
        {
            pbMain.Location = new Point((this.Width / 2) - (pbMain.Width / 2), (this.Height / 2) - (pbMain.Height / 2));
            pbMain.Visible = true;
        }
        private void wvMain_NavigationCompleted(object sender, Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs e)
        {
            pbMain.Visible = false;
        }
    }
}
