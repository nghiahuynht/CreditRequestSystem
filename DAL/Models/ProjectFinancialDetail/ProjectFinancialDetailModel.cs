using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.ProjectFinancialDetail
{
   public class ProjectFinancialDetailModel
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int ActivityGroupId { get; set; }
        public string ActivityGroupName { get; set; }
        public string ExpenseItem { get; set; }
        public string Standard { get; set; }
        public int? Quantity { get; set; }
        public string Unit { get; set; }
        public decimal? Price { get; set; }
        public decimal? TotalAmount { get; set; }
        public string Notes { get; set; }
    }

    public class PaymentInfoProjectDetailModel
    {
        public long Id { get; set; }
        public int ProjectDetailId { get; set; }
        public int ActiveGroupId { get; set; }
        public long ProfileId { get; set; }
        public string PaymentInfoCode { get; set; }
        public string PaymentInfoName { get; set; }
        public string Notes { get; set; }
    }
}
