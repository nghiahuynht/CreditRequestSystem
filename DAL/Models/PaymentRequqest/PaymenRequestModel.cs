using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.PaymentRequqest
{
    public class PaymentRequestModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public DateTime DateRequest { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public string CreatedByDepartment { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdateDate { get; set; }
 
    }
}
