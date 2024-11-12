using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.CreditRequest
{
   public class CreditRequestFilterModel : DataTableDefaultParamModel
    {
        public string Status { get; set; }
        public string CreditType { get; set; }
        public string ContentCredit { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string UserName { get; set; }
    }
}
