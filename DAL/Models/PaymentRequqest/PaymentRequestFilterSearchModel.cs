using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.PaymentRequqest
{
    public class PaymentRequestFilterSearchModel:DataTableDefaultParamModel
    {
        public string ProjectId { get; set; }
        public string ActivityId { get; set; }
        public int Department { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string Status { get; set; }

    }
}
