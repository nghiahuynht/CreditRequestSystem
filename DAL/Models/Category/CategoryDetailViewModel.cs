using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.Category
{
    public class CategoryDetailViewModel
    {
        public CategoryDetailViewModel()
        {
            ListParent = new List<Entities.Category>();
        }
        public DAL.Entities.Category Category { get; set; }
        public List<DAL.Entities.Category> ListParent { get; set; }
    }

    public class CategoryActiveGroupViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
    }

    public class CategoryPaymentProfileViewModel
    {
        public int Id { get; set; }
        public int FileAttachId { get; set; }
        public string FileAttachName { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string URLPath { get; set; }
    }

    public class CategoryFilterModel : DataTableDefaultParamModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class CategoryExpenseViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
    }

    public class PaymentProfileModel
    {
        public CategoryExpenseViewModel MucChi { get; set; }
        public List<CategoryPaymentProfileViewModel> TTHoSoThanhToan { get; set; }
    }


    public class CategoryPaymentInfoModel
    {
        public int Id { get; set; }
        public int ExpenseId { get; set; }
        public int FileAttachId { get; set; }
        public string PaymentInfoCode { get; set; }
        public string PaymentInfoName { get; set; }
        public string Notes { get; set; }
       
    }
}
