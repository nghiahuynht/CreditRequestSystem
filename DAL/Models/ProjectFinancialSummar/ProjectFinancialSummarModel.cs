using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.ProjectFinancialSummar
{
    public class ProjectFinancialSummarModel
    {
        public int Id { get; set; }  // ID của dự án
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string LegalBasis { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public decimal TotalAmount { get; set; }
        public string StatusText { get; set; }
        public string Notes { get; set; }
        public List<string> FileAttach { get; set; }

    }



    public class ProjectFinancialSummarGridModel
    {
        public int Id { get; set; }  // ID của dự án
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string LegalBasis { get; set; }
        public DateTime?TimeStart { get; set; }
        public DateTime?TimeEnd { get; set; }
        public decimal? TotalAmount { get; set; }
        public string StatusText { get; set; }
        public string Notes { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }


    }

    public class ProjectFinancialSummarFilterModel : DataTableDefaultParamModel
    {
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
    }
    public class ProjectFinancialSummarDLLModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class ProjectOverviewModel
    {
        public int Id { get; set; }
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalAllocatedAmount { get; set; }
    }

    public class ResImportProjectFinancialSummarModel
    {
        public ProjectFinancialSummarModel item { get; set; }
        public string message { get; set; }
    }
}
