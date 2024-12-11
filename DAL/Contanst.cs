using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class Contanst
    {
        public static string InvoiceStatus_ChoDuyet = "ChoDuyet";
        public static string InvoiceStatus_DaDuyet = "DaDuyet";
        public static string InvoiceStatus_Huy = "Huy";

        public static string InvoiceType_SO = "SO";
        public static string InvoiceType_PO = "PO";


        public static string NPPType_1 = "Đại lý cấp 1";
        public static string NPPType_2= "Đại lý cấp 2";


        public static string WHTran_Status_Draft = "ChoThucHien";
        public static string WHTran_Status_Completed = "DaThucHien";
        public static string WHTran_Status_Cancel = "Huy";

        public static string DiscountType_Money = "GiamTien";
        public static string DiscountType_Percent = "PhanTram";



        public static string VisitRes_Visited = "Visited";
        public static string VisitRes_NotYet = "NotYet";


        public static string ContractStatus_Nhap = "draft";
        public static string ContractStatus_ChoDuyet = "waiting";
        public static string ContractStatus_DaDuyet = "approved";
        public static string ContractStatus_TuChoi = "rejected";
        public static string ContractStatus_Huy = "canceled";

        public static string Template_KNS_TheoTiet = "KNS_TheoTiet.docx";
        public static string Template_KNS_TheoThang = "KNS_TheoThang.docx";
        public static string Template_STEM_TheoTiet = "STEM_TheoTiet.docx";
        public static string Template_STEM_TheoThang = "STEM _TheoThang.docx";


        public static string CreditType_TamUng = "TU";
        public static string CreditType_HoanUng = "HU";


        public static string CreditRequestStatus_Draft = "draft"; /* badge badge-secondary */
        public static string CreditRequestStatus_Waiting = "waiting"; /* badge badge-warning */
        public static string CreditRequestStatus_Reviewed = "reviewed"; /* badge badge-primary */
        public static string CreditRequestStatus_Approved = "approved"; /* badge badge-success */
        public static string CreditRequestStatus_Rejected = "rejected";  /* badge badge-danger */
        public static string CreditRequestStatus_Canceled = "canceled"; /* badge badge-danger */
        public static string CreditRequestStatus_WaitingAccountant = "waitacc";
        public static string CreditRequestStatus_Completed = "completed";



        public static string Role_BGD = "BGD";
        public static string Role_QuanLy = "QuanLy";
        public static string Role_Sale = "Sale";
        public static string Role_KeToan = "KeToan";
        public static string Role_GiaoVien = "GV";





        public static string PaymentRequesStatus_Draft = "draft";
        public static string PaymentRequesStatus_Waiting= "waiting";
        public static string PaymentRequesStatus_Approved = "approved";
        public static string PaymentRequesStatus_Unc = "unc";
        public static string PaymentRequesStatus_Completed = "completed";// lasted success
        public static string PaymentRequesStatus_Rejected = "rejected";
        public static string PaymentRequesStatus_Canceled = "canceled";
       



    }
}
