using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.PaymentRequqest
{
    public class PaymentCheckListHistoryModel
    {
        public long Id { get; set; }
        public long PaymentProfileId { get; set; }
        public string Name { get; set; }
        public bool Approved { get; set; }
    }
}
