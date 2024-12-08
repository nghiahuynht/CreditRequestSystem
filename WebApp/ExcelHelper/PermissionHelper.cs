using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.ExcelHelper
{
    public static class PermissionHelper
    {
        public static class DanhSachNhanVien
        {
            public const string Add = "DSNV_ADD";
            public const string Edit = "DSNV_EDIT";
            public const string Delete = "DSNV_DELETE";
            public const string Approve = "DSNV_APPROVE";
        }
          public static class KhaiBaoDuAn
        {
            public const string Add = "DA_ADD";
            public const string Edit = "DA_EDIT";
            public const string Delete = "DA_DELETE";
            public const string Approve = "DA_APPROVE";
        }

    }
}
