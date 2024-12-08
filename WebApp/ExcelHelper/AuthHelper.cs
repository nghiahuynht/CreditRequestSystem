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
            // Tách chuỗi input theo dấu phẩy và trả về List<string>
            List<string> resultList = new List<string>(input.Split(','));
            return resultList;
        }
    }
}
