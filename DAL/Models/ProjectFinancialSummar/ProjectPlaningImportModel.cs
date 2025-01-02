using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.ProjectFinancialSummar
{
    public class ProjectPlaningImportModel
    {
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string ActivitiCode { get; set; }
        public string ActivitiName { get; set; }
        public string ExpenseCode { get; set; }
        public string ExpenseName { get; set; }
        public string TieuMuc { get; set; }
        public string TieuChuan { get; set; }
        public string DonVi { get; set; }
        public int? Quanti { get; set; }
        public decimal? Price { get; set; }
    }
}
