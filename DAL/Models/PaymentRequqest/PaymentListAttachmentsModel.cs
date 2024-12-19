using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.PaymentRequqest
{
    public class PaymentListAttachmentsModel
    {
        public long Id { get; set; }/*SuggestId*/
        public string SuggestName { get; set; }
        public string SuggestFileName { get; set; }
        public string SuggestFileURL { get; set; }
        public string SuggestNote { get; set; }
        public string AttachFileName { get; set; }
        public string AttachURL { get; set; }
        public long? AttachId { get; set; }
        public long ProfileId { get; set; }
    }
}
