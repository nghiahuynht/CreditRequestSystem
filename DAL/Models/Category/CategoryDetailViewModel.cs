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
        public string Code { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
    }

    public class CategoryFilterModel : DataTableDefaultParamModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}
