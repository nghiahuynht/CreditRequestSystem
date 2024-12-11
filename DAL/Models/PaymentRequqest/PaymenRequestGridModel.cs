using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.PaymentRequqest
{
    public class PaymenRequestGridModel
    {
        public long Id { get; set; }
        public string RequestCode { get; set; }
        public string RequestDate { get; set; }
        public string RequestByName { get; set; }
        public string Status { get; set; }
        public decimal? RequestTotal { get; set; }
        public string RequestByDepartment { get; set; }
        public string ProjectName { get; set; }
        public string ActivityName { get; set; }
        public string ExpenseName { get; set; }

    }
}
