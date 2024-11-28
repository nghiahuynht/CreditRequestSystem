using DAL.Models.Category;
using DAL.Models.ProjectFinancialSummar;
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
        public int ExpenseId { get; set; }
        public string Standard { get; set; }
        public int? Quantity { get; set; }
        public string Unit { get; set; }
        public decimal? Price { get; set; }
        public decimal? TotalAmount { get; set; }
        public string Notes { get; set; }
    }
    public class ProjectFinancialDetailTableModel
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        public int ActiveGroupId { get; set; }
        public string ActiveGroupName { get; set; }
        public int ExpenseId { get; set; }
        public string ExpenseName { get; set; }
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
        public int? FileAttach { get; set; }
        public string PaymentInfoCode { get; set; }
        public string PaymentInfoName { get; set; }
        public string Notes { get; set; }
        public string FileName { get; set; }
        public string URLPath { get; set; }
    }

    public class ProjectFinancialDetailParamModel
    {
        public List<ProjectFinancialSummarDLLModel> LstProject { get; set; }
        public List<CategoryActiveGroupViewModel> LstActiveGroup { get; set; }
        public List<CategoryExpenseViewModel> LstExpense { get; set; }
    }

    public class ProjectFinancialDetailFilterModel : DataTableDefaultParamModel
    {
        public int ProjectId { get; set; }
        public int ActiveGroupId { get; set; }
        public int ExpenseId { get; set; }
    }

    public class ProjectFinancialDetailAddModel
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int ActivityGroupId { get; set; }
        public string ActivityGroupName { get; set; }
        public int ExpenseId { get; set; }
        public string Standard { get; set; }
        public int? Quantity { get; set; }
        public string Unit { get; set; }
        public decimal? Price { get; set; }
        public decimal? TotalAmount { get; set; }
        public string Notes { get; set; }
        public List<PaymentInfoProjectDetailModel> PaymentInfo { get; set; }
    }
}
