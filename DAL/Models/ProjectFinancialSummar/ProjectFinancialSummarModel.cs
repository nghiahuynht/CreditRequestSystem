using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.ProjectFinancialSummar
{
    public class ProjectFinancialSummarModel
    {
        public int Id { get; set; }  // ID của dự án
        public string ProjectName { get; set; }  
        public string LegalBasis { get; set; }  
        public string ExecutionPeriod { get; set; }  
        public decimal TotalAmount { get; set; }  
        public string StatusText { get; set; }  
        public string Notes { get; set; }  
        
    }
}
