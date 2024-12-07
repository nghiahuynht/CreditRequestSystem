using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.PaymentRequqest
{
    public  class RequestViewModel
    {
        public RequestViewModel()
        {
            RequestHeader = new PaymentRequestModel();
            ListRequestItems = new List<PaymentRequestItemModel>();
        }

        public PaymentRequestModel RequestHeader { get; set; }
        public List<PaymentRequestItemModel> ListRequestItems { get; set; } 
    }
}
