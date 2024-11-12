using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Text.RegularExpressions;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Data.OleDb;


/// <summary>
/// Summary description for DAOBASE
/// </summary>
public class Common
{
    

    public static string ReCorectDomainName(string domainName)
    {
        domainName = Slug(domainName).ToLower();
        domainName = domainName.Replace("-", string.Empty);
        return domainName;
    }

    public static string FirtDayOfYear() { 

        return string.Format("01/01/{0}", DateTime.Now.Year);
    }
    public static string FirtDayOfMonth()
    {
        int monthNow = DateTime.Now.Month;
        string month = monthNow.ToString().Length == 1 ? "0" + monthNow : monthNow.ToString();
        return string.Format("01/{0}/{1}", month,DateTime.Now.Year.ToString());
    }

    
    public static string NumToText(string str)
    {
        string[] word = { "", " một", " hai", " ba", " bốn", " năm", " sáu", " bảy", " tám", " chín" };
        string[] million = { "", " mươi", " trăm", "" };
        string[] billion = { "", "", "", " nghìn", "", "", " triệu", "", "" };
        string result = "{0}";
        int count = 0;
        for (int i = str.Length - 1; i >= 0; i--)
        {
            if (count > 0 && count % 9 == 0)
                result = string.Format(result, "{0} tỷ");
            if (!(count < str.Length - 3 && count > 2 && str[i].Equals('0') && str[i - 1].Equals('0') && str[i - 2].Equals('0')))
                result = string.Format(result, "{0}" + billion[count % 9]);
            if (!str[i].Equals('0'))
                result = string.Format(result, "{0}" + million[count % 3]);
            else if (count % 3 == 1 && count > 1 && !str[i - 1].Equals('0') && !str[i + 1].Equals('0'))
                result = string.Format(result, "{0} lẻ");
            var num = Convert.ToInt16(str[i].ToString());
            result = string.Format(result, "{0}" + word[num]);
            count++;
        }
        result = result.Replace("{0}", "");
        if (result.IndexOf("một mươi") > -1)
        {
            result = result.Replace("một mươi", "mười");
        }
        if (result.IndexOf("mươi năm") > -1)
        {
            result = result.Replace("mươi năm", "mươi lăm");
        }
        if (result.IndexOf("mười năm") > -1)
        {
            result = result.Replace("mười năm", "mười lăm");
        }
        return result.ToUpperInvariant().Trim();
    }


    public static string Domain = ConfigurationManager.AppSettings["DOMAIN"];
    public static string PasswordKey = "sf@vn2012";
    public static String[] allowedExtPic = { ".gif", ".png", ".jpeg", ".jpg" };
    public static string Lang = ConfigurationManager.AppSettings["LANGUAGES_DEFAULT"];
    public Common()
    {

    }
    public static bool checkDate(object year, object month, object day)
    {
        bool validate = true;
        try
        {
            DateTime dt = new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), Convert.ToInt32(day));

        }
        catch (Exception ex)
        {
            validate = false;
        }

        return validate;
    }
   


    public static decimal ObjectToDecimal(object obj)
    {
        decimal _decimal = 0;
        try
        {
            _decimal = decimal.Parse(obj.ToString(), System.Globalization.NumberStyles.Currency);
        }
        catch
        {
        }
        return _decimal;
    }
  
    public static bool CheckEmail(object email)
    {
        try
        {
            string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                                @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                                @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
            Regex check = new Regex(strRegex, RegexOptions.IgnorePatternWhitespace);
            return check.IsMatch(email.ToString());
        }
        catch (Exception ex)
        {

        }
        return false;
    }
    public static bool CheckPhone(object phone)
    {
        string strRegex = "[0-9 .,]{7,20}";
        Regex check = new Regex(strRegex, RegexOptions.IgnorePatternWhitespace);
        return check.IsMatch(phone.ToString());
    }
    public static bool isNumber(string number)
    {
        bool result = false;
        try
        {
            decimal num = Convert.ToDecimal(number);
            result = true;
        }
        catch (Exception ex)
        {
            result = false;
        }
        return result;
        //string strRegex = "[0-9]";
        //Regex check = new Regex(strRegex, RegexOptions.IgnoreCase);
        //return check.IsMatch(number.ToString());
    }
    public static bool isValidUrl(object url, bool ishttp)
    {
        try
        {
            string pattern = ishttp ? @"^(http|https|ftp)\:\/\/(\w+:{0,1}\w*@)?(\S+)(:[0-9]+)?(\/|\/([\w#!:.?+=&%@!\-\/]))*" : @"^([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
            Regex reg = new Regex(pattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
            return reg.IsMatch(url.ToString());
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    static double ConvertToUnixTimestamp(DateTime date)
    {
        DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        TimeSpan diff = date - origin;
        return Math.Floor(diff.TotalSeconds);
    }
   

    public static string FilterWord(object strcomment)
    {
        try
        {
            string[] arrBadWords = { "vcl", "vkl", "lồn", "cặc", "kac", "lon", "fuck", "con cac", "con kac", "nhu cac", "khùng", "điên", "khung", "dien", "cứt", "vl", "ngu", "dit me", "dit con me", "địt mẹ", "đủ má", "du ma", "dis me", "cuc cut", "con cho", "chó", "djen", "dit", "nhu cho", "loz", "cac", "shit", "kut", "cut", "lo^n", "l o n^", "kạc", "dis", "chim", "buồi", "buoi", "mất dạy", "mat day", "dkm", "phân", "anti", "tẩy chay", "tay chay", "xl", "to cha", "mat day", "de tien", "xeo di", "gay", "admin", "administrator", "xhcn", "xa hoi chu nghia", "xã hội chủ nghĩa", "địt", "dog", "pede", "bede" };

            bool isBad = false;
            string search = strcomment.ToString().ToLower();
            foreach (string word in arrBadWords)
            {
                if (search.IndexOf(word) != -1)
                {
                    isBad = true;
                    break;
                }
            }
            if (!isBad)
                return strcomment.ToString();
            return "";
        }
        catch (Exception ex)
        {
            return "";
        }
    }
    public static string Slug(object strTxt, int maxLength = 200, string sperator = "-")
    {
        string str = strTxt.ToString().ToLower();
        for (int i = 1; i < VietNamChar.Length; i++)
        {
            for (int j = 0; j < VietNamChar[i].Length; j++)
                str = str.Replace(VietNamChar[i][j], VietNamChar[0][i - 1]);
        }
        str = Regex.Replace(str, @"[^a-z0-9\s-./_]", "");
        str = Regex.Replace(str, @"[\s-]+", " ").Trim();
        if (maxLength > 0)
            str = str.Substring(0, str.Length <= maxLength ? str.Length : maxLength).Trim();

        str = Regex.Replace(str, @"\s", sperator);
        return str;
    }
    private static readonly string[] VietNamChar = new string[]
    {
	        "aAeEoOuUiIdDyY",
	        "ăáàạảãâấầậẩẫăắằặẳẵ",
	        "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",            
	        "éèẹẻẽêếềệểễ",
	        "ÉÈẸẺẼÊẾỀỆỂỄ",
	        "óòọỏõôốồộổỗơớờợởỡ",
	        "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
	        "úùụủũưứừựửữ",
	        "ÚÙỤỦŨƯỨỪỰỬỮ",
	        "íìịỉĩ",
	        "ÍÌỊỈĨ",
	        "đ",
	        "Đ",
	        "ýỳỵỷỹ",
	        "ÝỲỴỶỸ"
    };
    public static string Substring(object strss, int maxLength = 100, string FINISH_TEXT_STRING = "")
    {
        string str = "";
        try
        {
            str = Regex.Replace(strss.ToString(), "<.*?>", string.Empty).Trim();
            string[] chars = new string[] { ",", ".", "/", "!", "@", "#", "$", "%", "^", "*", "'", "\"", "-", "_", "(", ")", ":", "|", "[", "]" };
            for (int i = 0; i < chars.Length; i++)
            {
                if (str.Contains(chars[i]))
                {
                    str = str.Replace(chars[i], "");
                }
            }
            if (!String.IsNullOrEmpty(str) && str.Length > maxLength)
            {
                if (str.Length > maxLength - FINISH_TEXT_STRING.Length)
                    str = str.Substring(0, maxLength - FINISH_TEXT_STRING.Length);
                int i = str.LastIndexOf(" ");
                if (i > 0)
                    str = str.Substring(0, i);
                str += FINISH_TEXT_STRING;
            }
            str = System.Net.WebUtility.HtmlDecode(str);
        }
        catch (Exception ex)
        {
        }
        return str;
    }
   
    public static bool CheckExtension(string f, String[] allowedExtensions)
    {

        bool fileOK = false;
        if (f != null && f != "")
        {
            String fileExtension = System.IO.Path.GetExtension(f).ToLower();
            for (int i = 0; i < allowedExtensions.Length; i++)
            {
                if (fileExtension == allowedExtensions[i].ToLower())
                {
                    fileOK = true;
                    break;
                }
            }
        }
        return fileOK;
    }
    public static int ParseInt(object str)
    {
        try
        {
            return Convert.ToInt32(str);
        }
        catch (Exception ex)
        {
            return 0;
        }
    }
   
    public static string ParseToString(object obj)
    {
        try
        {
            return obj.ToString().TrimEnd().TrimStart();
        }
        catch (Exception ex)
        {

        }
        return "";
    }
    public static string ParseToString(string text, bool RemoveHtml)
    {
        try
        {
            return Regex.Replace(text, @"<(.|\n)*?>", string.Empty);
        }
        catch (Exception ex)
        {
        }
        return "";
    }
   
    public static string ParseDateToString(object dateinput, string format)
    {
        string sMsg = "";
        try
        {
            DateTime date = (DateTime)dateinput;
            return date.ToString(format);
        }
        catch (Exception ex)
        {
        }
        return sMsg;
    }
    public static DateTime GetStartOfLastWeek()
    {
        int DaysToSubtract = (int)DateTime.Now.DayOfWeek + 7;
        DateTime dt = DateTime.Now.Subtract(TimeSpan.FromDays(DaysToSubtract));
        return new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
    }
    public static DateTime GetEndOfLastWeek()
    {
        DateTime dt = GetStartOfLastWeek().AddDays(6);
        return new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
    }

    public static string ParseDateToString(object dateinput, string format = "dd/MM/yyyy h:mm", string sMsg = "Cách đây ")
    {
        try
        {
            DateTime date = (DateTime)dateinput;
            TimeSpan diff = DateTime.Now - date;
            if (diff.Days != 0 && diff.Days < 7)
            {
                sMsg += diff.Days + " ngày.";
            }
            else if (diff.Days > 7)
            {
                sMsg = date.ToString(format);
            }
            else if (diff.Hours != 0)
            {
                sMsg += diff.Hours + " giờ.";
            }
            else if (diff.Minutes != 0)
            {
                sMsg += diff.Minutes + " phút.";
            }
            else if (diff.Seconds != 0)
            {
                sMsg += diff.Seconds + " giây.";
            }
            else if (diff.Seconds == 0)
            {
                sMsg = "Mới đây.";
            }
            else
            {
                sMsg = "";
            }
        }
        catch (Exception ex)
        {
            sMsg = "";
        }

        return sMsg;
    }
    public static string GetYoutubeID(string youtube)
    {
        return "";
    }
    public static bool FilterDomain(object strstr)
    {
        string[] arrBadDomain = { "@dispostable", "@yopmail", "@mailcatch", "@emailthe", "@guerrillamail", "@mailinator" };
        try
        {
            string search = strstr.ToString().ToLower();
            foreach (string word in arrBadDomain)
            {
                if (search.IndexOf(word) != -1)
                {
                    return true;
                }
            }
        }
        catch (Exception ex)
        {

        }
        return false;
    }
    
    public static string ConvertMoney(string _money, string _text)
    {
        string _result_content = "Liên hệ";
        try
        {
            if (_money != string.Empty)
            {
                _result_content = _text + String.Format("{0:#,###}", Convert.ToDecimal(_money)) + "";
            }
        }
        catch { }
        if (string.IsNullOrEmpty(_result_content))
        {
            _result_content = "0";
        }
        return _result_content;
    }
    

    public static bool _validSpecailChar(string mStr)
    {
        string[] arrStrSpecial = { ".", ",", "<", ">", ":", "?", "\"", "/", "{", "[", "}", "]", "`", "~", "!", "@", "#", "$", "%", "^", "&", "*", "(", ")", "_", "-", "+", "=", "|", "\\", "'" };

        foreach (string myStr in arrStrSpecial)
        {
            if (mStr.Contains(myStr))
            {
                return false;
            }
        }

        return true;

    }
    //=============== nghia=========================================
    public static string _ChangeFormatDate(string oldformant)
    {
        if (!string.IsNullOrEmpty(oldformant) && oldformant.IndexOf("/") > 0)
        {
            string[] arr = oldformant.Split('/');
            string newformat = arr[2] + "/" + arr[1] + "/" + arr[0];
            return newformat;
        }
        else
        {
            return "";
        }

    }

    public static string _RechangeFormatDate(string oldformant)
    {
        string[] arr = oldformant.Split('/');
        string newformat = arr[0] + "/" + arr[1] + "/" + arr[2];
        return newformat;
    }
    public static string AlerDangerBox(string message)
    {
        string htm = @"<div style='width:99%;height:40px;border:1px solid #EB7153;background:#FCD9C4;float:left;border-radius:5px;'>
                            <span style='width:95%;font-size:11pt;font-weight:bold;color:#EB7153;float:left;margin:15px;'>" + message + "</span>" +
                       "</div>";
        return htm;
    }
    public static string AlerSuccessBox(string message)
    {
        string htm = @"<div style='width:99%;height:40px;border:1px solid #00A6AD;background:#CAE5E8;float:left;border-radius:5px;'>
                            <span style='width:95%;font-size:11pt;font-weight:bold;color:#00A6AD;float:left;margin:15px;'>" + message + "</span>" +
                       "</div>";
        return htm;
    }
    public static string EncrypMD5(string pass)
    {
        MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(pass));
        byte[] result = md5.Hash;
        StringBuilder str = new StringBuilder();
        for (int i = 0; i < result.Length; i++)
        {
            str.Append(result[i].ToString("x2"));
        }
        return str.ToString();
    }
    /// <summary>
    /// sttSheet: bắt đầu từ 0
    /// </summary>
    /// <param name="fileupload"></param>
    /// <param name="path"></param>
    /// <param name="filename"></param>
    /// <param name="sttSheet"></param>
    /// <returns></returns>
    
    public static string[] decodeCookiesLogin(string cookies)
    {
        var base64EncodedBytes = Convert.FromBase64String(cookies);
        string decode = Encoding.UTF8.GetString(base64EncodedBytes);
        return decode.Split(',');
    }
    
}
