using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ExcelHelper
{
    public static class AuthHelper
    {
        public static List<string> GetPermissionHelper(string input)
        {
            // Split the input string by commas and trim each element
            List<string> resultList = input
                .Split(',')
                .Select(item => item.Trim()) // Trim each string
                .ToList();
            return resultList;
        }
    }
}
