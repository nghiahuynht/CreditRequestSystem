using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.PaymentRequqest
{
    public class ChangeStatusRequestParamModel
    {
        public long requestId { get; set; }
        public string status { get; set; }
        public string userName { get; set; }
        public string note { get; set; } // trường này dành cho note khi reject
    }
}
