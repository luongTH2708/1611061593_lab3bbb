﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _1611061593_lab3.Common
{
    public class Helper
    {
        public static string RemoveIllegalCharacters(object input)
        {
            string data = input.ToString();
            //Xóa các ký tự đặc biệt, gây lỗi trong XML             
            data = data.Replace("&", "&amp;");             
            data = data.Replace("\"", "&quot;");             
            data = data.Replace("'", "&apos;");             
            data = data.Replace("<", "&lt;");             
            data = data.Replace(">", "&gt;"); 
            return data;
        }
    }
}