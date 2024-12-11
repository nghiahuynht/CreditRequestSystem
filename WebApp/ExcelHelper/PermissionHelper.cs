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
            public const string PERMISSION = "DSNV_PERMISSION";
        }
          public static class KhaiBaoDuAn
        {
            public const string Add = "DA_ADD";
            public const string Edit = "DA_EDIT";
            public const string Delete = "DA_DELETE";
            public const string Approve = "DA_APPROVE";
        }
        public static class NhomHoatDong
        {
            public const string Add = "NHD_ADD";
            public const string Edit = "NHD_EDIT";
            public const string Delete = "NHD_DELETE";
            public const string Approve = "NHD_APPROVE";
        }

        public static class MucChi
        {
            public const string Add = "MC_ADD";
            public const string Edit = "MC_EDIT";
            public const string Delete = "MC_DELETE";
            public const string Approve = "MC_APPROVE";
        }

        public static class PhanBoKinhPhi
        {
            public const string Add = "MC_ADD";
            public const string Edit = "MC_EDIT";
            public const string Delete = "MC_DELETE";
            public const string Approve = "MC_APPROVE";
        }
        public static class PhanQuyenNhanVienPhuTrach
        {
            public const string Add = "NVPT_ADD";
            public const string Edit = "NVPT_EDIT";
            public const string Delete = "NVPT_DELETE";
            public const string Approve = "NVPT_APPROVE";
        }  
        public static class PhanQuyenNhanVienTaoYeuCau
        {
            public const string Add = "NVTYC_ADD";
            public const string Edit = "NVTYC_EDIT";
            public const string Delete = "NVTYC_DELETE";
            public const string Approve = "NVTYC_APPROVE";
        }

    }
}
