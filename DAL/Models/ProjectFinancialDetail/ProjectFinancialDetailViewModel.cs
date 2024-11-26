using DAL.Models.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.ProjectFinancialDetail
{
   public class ProjectFinancialDetailViewModel
    {
        public ProjectFinancialDetailModel data { get; set; }
        public List<CategoryActiveGroupViewModel> DM_NhomHoatDong { get; set; }
        public List<CategoryPaymentProfileViewModel> DM_HSThanhToan { get; set; }
        public List<PaymentInfoProjectDetailModel> HSThanhToan { get; set; }
    }
}
