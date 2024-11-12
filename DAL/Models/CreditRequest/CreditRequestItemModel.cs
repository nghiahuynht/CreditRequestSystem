using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.CreditRequest
{
    public class CreditRequestItemModel
    {
        public long Id { get; set; } // auto number
        public long CreditRequestId { get; set; } 
        public string Name { get; set; } // user input free text
        public string Unit { get; set; } // user input free text
        public int? Quanti { get; set; } // user input free text
        public decimal? Price { get; set; } // user input free text
        public decimal? Total { get; set; } // auto calculate by store SQL
        public string Note { get; set; }// user input free text
    }
}
