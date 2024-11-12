using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.CreditRequest
{
   public class CreditRequestViewModel
    {
        public long Id { get; set; }
        public string Code { get; set; } 
        public string CreaditType { get; set; } 
        public string Status { get; set; } 
        public string UserRequest { get; set; }
        public DateTime? DateRequest { get; set; } 
        public decimal? RequestedAmount { get; set; } 
        public decimal? ApprovedAmount { get; set; } 
        public decimal? RemainAmount { get; set; }
        public string ActionBy { get; set; } // Duyệt by user
        public DateTime? ActionDate { get; set; }
        public string Reason { get; set; } // lý do
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string ReferRequestCode { get; set; }
        public string RejectNote { get; set; }
    }
}
