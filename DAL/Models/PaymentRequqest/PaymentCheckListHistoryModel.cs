using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.PaymentRequqest
{
    public class PaymentCheckListHistoryModel
    {
        public int Id { get; set; }
        public int PaymentProfileId { get; set; }
        public string Name { get; set; }
        public bool Approved { get; set; }
    }
}
