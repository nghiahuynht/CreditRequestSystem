﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class Helper
    {
        public static string FirtDayOfYear()
        {

            return string.Format("01/01/{0}", DateTime.Now.Year);
        }
        public static string FirtDayOfMonth()
        {
            int monthNow = DateTime.Now.Month;
            string month = monthNow.ToString().Length == 1 ? "0" + monthNow : monthNow.ToString();
            return string.Format("01/{0}/{1}", month, DateTime.Now.Year.ToString());
        }


        public static List<ComboBoxModel> LstAllTranWHType()
        {
            return new List<ComboBoxModel>
            {
                new ComboBoxModel {Value="WT1",Text="Xuất theo đơn"},
                new ComboBoxModel {Value="WT2",Text="Nhập theo đơn"},
                new ComboBoxModel {Value="WT3",Text="Xuất chuyển kho"},
                new ComboBoxModel {Value="WT4",Text="Nhập chuyển kho"},
            };
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
            return result.ToUpperInvariant().Trim() + " đồng chẵn";
        }




    }
}
