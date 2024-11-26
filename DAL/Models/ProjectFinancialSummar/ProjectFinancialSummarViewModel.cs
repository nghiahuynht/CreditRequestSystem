using DAL.Models.Category;
using DAL.Models.ProjectFinancialDetail;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.ProjectFinancialSummar
{
   public class ProjectFinancialSummarViewModel
    {
        public List<CategoryActiveGroupViewModel> DM_NhomHoatDong { get; set; }
        public ProjectFinancialSummarGridModel ProjectInfo { get; set; }
        public List<ProjectFinancialDetailModel> ListProjectDetail { get; set; }
        public List<AttactFileModel> ListFileAttach { get; set; }
    }

    
}
