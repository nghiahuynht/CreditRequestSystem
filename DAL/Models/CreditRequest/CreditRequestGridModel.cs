using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.CreditRequest
{
   public class CreditRequestGridModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string UserRequest { get; set; }
        public string Reason { get; set; }
        public string CreaditType { get; set; }
        public string DateRequest { get; set; }
        public string Status { get; set; }
        public string ActionBy { get; set; }
        public DateTime? ActionDate { get; set; }
        public decimal? RequestedAmount { get; set; }
        public decimal? ApprovedAmount { get; set; }
        public string ReferRequestCode { get; set; }
    }
}
