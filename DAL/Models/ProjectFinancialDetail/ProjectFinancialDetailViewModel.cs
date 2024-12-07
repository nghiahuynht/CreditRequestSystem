using DAL.Models.Category;
using DAL.Models.ProjectFinancialSummar;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.ProjectFinancialDetail
{
   public class ProjectFinancialDetailViewModel
    {
        public ProjectFinancialDetailModel data { get; set; }
        public List<ProjectFinancialSummarDLLModel> LstProject { get; set; }
        public List<CategoryActiveGroupViewModel> DM_NhomHoatDong { get; set; }
        public List<CategoryExpenseViewModel> DM_MucChi { get; set; }
        public List<PaymentInfoProjectDetailModel> DM_HSThanhToan { get; set; }
        public List<PaymentInfoProjectDetailModel> HSThanhToan { get; set; }
    }
}
