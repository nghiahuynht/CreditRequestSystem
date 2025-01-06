using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.PaymentRequqest
{
    public class PaymentRequestAttachUNCModel
    {
        public long Id { get; set; }
        public long PaymentRequestId { get; set; }
        public string AttachFileName { get; set; }
        public string AttachFileURL { get; set; }
        public DateTime? AttachDate { get; set; }
        public string AttachByUser { get; set; }
    }
}
