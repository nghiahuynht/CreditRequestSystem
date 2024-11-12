using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.CreditRequest
{
    public class CreditPdfViewModel
    {
        public CreditPdfViewModel()
        {
            RequestHeader = new CreditRequestViewModel();
            RequestItems = new List<CreditRequestItemModel>();
        }

        public CreditRequestViewModel RequestHeader { get; set; }
        public List<CreditRequestItemModel> RequestItems { get; set; }
        public string AmountRequestText { get; set; }
        public string AmountApprovedText { get; set; }
        public decimal? TotalTURefer { get; set; } // dành cho hoàn ưngs



        
       
    }
}
