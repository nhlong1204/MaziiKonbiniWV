using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MaziiKonbiniWV
{
    static class CONSTANT
    {
        public const string baseURL = @"https://mazii.net/api/search";
        public const int TIME_OUT = 5;
        public const string templateHTML = @"<!DOCTYPE html><html><head><style>html{font-family:Helvetica Neue,Helvetica,Arial,sans-serif}body{padding:10px;border:1px solid;border-color:#dddfe2}h2{color:#e53c20;padding:0;margin:5px}p.phonetic{display:inline;margin:5px}.each-kind{color:#d22f0f;margin:5px 0px 0px 0px;font-size:15px}.each-mean{color:#3367d6;margin:5px 0px 0px 0px;font-size:18px}.example-jp{color:#d22f0f;margin:5px 0px 0px 20px}.example-vn{color:#4f4f4f;margin:5px 0px 0px 20px}</style></head><body></body></html>";
        public const string registryStartUpPath = @"SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";

        #region HotKeys
        //WinProc
        public const int WH_KEYBOARD_LL = 13;
        public const int WM_KEYUP = 0x0101;
        #endregion

        //Word type key
        public static ReadOnlyDictionary<string, string> WordType = new(
            new Dictionary<string, string>
            {
                {"abbr", "từ viết tắt"},
                {"adj", "tính từ"},
                {"adj-na", "tính từ đuôi な"},
                {"adj-no", "danh từ sở hữu cách thêm の"},
                {"adj-pn", "tính từ đứng trước danh từ"},
                {"adj-s", "tính từ đặc biệt"},
                {"adj-t", "tính từ đuổi tara"},
                {"adv", "trạng từ"},
                {"adv-n", "danh từ làm phó từ"},
                {"adv-to", "trạng từ thêm と"},
                {"arch", "từ cổ"},
                {"ateji", "ký tự thay thế"},
                {"aux", "trợ từ"},
                {"aux-v", "trợ động từ"},
                {"aux-adj", "tính từ phụ trợ"},
                {"Buddh", "thuật ngữ phật giáo"},
                {"chn", "ngôn ngữ trẻ em"},
                {"col", "thân mật ngữ"},
                {"comp", "thuật ngữ tin học"},
                {"conj", "liên từ"},
                {"derog", "xúc phạm ngữ"},
                {"ek", "hán tự đặc trưng"},
                {"exp", "cụm từ"},
                {"fam", "từ ngữ thân thuộc"},
                {"fem", "phụ nữ hay dùng"},
                {"food", "thuật ngữ thực phẩm"},
                {"geom", "thuật ngữ hình học"},
                {"gikun", "gikun"},
                {"gram", "thuộc về ngữ pháp"},
                {"hon", "tôn kính ngữ"},
                {"hum", "khiêm nhường ngữ"},
                {"id", "thành ngữ"},
                {"int", "thán từ"},
                {"iK", "từ chứa kanji bất quy tắc"},
                {"ik", "từ chứa kana bất quy tắc"},
                {"io", "okurigana bất quy tắc"},
                {"iv", "động từ bất quy tắc"},
                {"kyb", "giọng Kyoto"},
                {"ksb", "giọng Kansai"},
                {"ktb", "giọng Kantou"},
                {"ling", "thuật ngữ ngôn ngữ học"},
                {"MA", "thuật ngữ nghệ thuật"},
                {"male", "tiếng lóng của nam giới"},
                {"math", "thuật ngữ toán học"},
                {"mil", "thuật ngữ quân sự"},
                {"m-sl", "thuật ngữ truyện tranh"},
                {"n", "danh từ"},
                {"n-adv", "danh từ làm phó từ"},
                {"n-pref", "danh từ làm tiền tố"},
                {"n-suf", "danh từ làm hậu tố"},
                {"n-t", "danh từ chỉ thời gian"},
                {"neg", "thể phủ định"},
                {"neg-v", "động từ mang nghĩa phủ định"},
                {"ng", "từ trung tính"},
                {"obs", "từ cổ"},
                {"obsc", "từ tối nghĩa"},
                {"oK", "từ chứa kanji cổ"},
                {"ok", "từ chứa kana cổ"},
                {"osk", "Giọng Osaka"},
                {"physics", "thuật ngữ vật lý"},
                {"pol", "thể lịch sự"},
                {"pref", "tiếp đầu ngữ"},
                {"prt", "giới từ"},
                {"qv", "tham khảo mục khác"},
                {"rare", "từ hiếm gặp"},
                {"sl", "tiếng lóng"},
                {"suf", "hậu tố"},
                {"tsb", "giọng Tosa"},
                {"uK", "từ sử dụng kanji đứng một mình"},
                {"uk", "từ sử dụng kana đứng một mình"},
                {"v", "động từ"},
                {"v1", "động từ nhóm 2"},
                {"v5", "động từ nhóm 1"},
                {"v5aru", "động từ nhóm 1 -aru"},
                {"v5b", "động từ nhóm 1 -bu"},
                {"v5g", "động từ nhóm 1 -ku"},
                {"v5k", "động từ nhóm 1 -ku"},
                {"v5k-s", "động từ nhóm 1 -iku/yuku"},
                {"v5m", "động từ nhóm 1 -mu"},
                {"v5n", "động từ nhóm 1 -nu"},
                {"v5r", "Động từ nhóm 1 -ru"},
                {"v5r-i", "Động từ nhóm 1 bất quy tắc -ru"},
                {"v5s", "động từ nhóm 1 -su"},
                {"v5t", "động từ nhóm 1 -tsu"},
                {"v5u", "động từ nhóm 1 -u"},
                {"v5u-s", "động từ nhóm 1 -u (đặc biệt)"},
                {"v5uru", "động từ nhóm 1 -uru"},
                {"vi", "tự động từ"},
                {"vk", "động từ kuru (đặc biệt)"},
                {"vs", "danh từ hoặc giới từ làm trợ từ cho động từ suru"},
                {"vs-i", "động từ bất quy tắc -suru"},
                {"vt", "tha động từ"},
                {"vulg", "thuật ngữ thô tục"},
                {"vz", "tha động từ"},
                {"X", "thuật ngữ thô tục"}
            });

        //Payload type
        public static class PayloadType
        {
            public const string WORD = "word";
            public const string KANJI = "kanji";
        }

        public static class SymbolCode 
        {
            public static readonly int Kind = 9734;
            public static readonly int MainMean = 9670;
        }

        
    }
}
