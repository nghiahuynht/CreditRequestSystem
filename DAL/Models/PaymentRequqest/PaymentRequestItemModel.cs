using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.PaymentRequqest
{
    public class PaymentRequestItemModel
    {
        public long Id { get; set; }
        public long RequestId { get; set; }
        public int ProjectId { get; set; }
        public int ActivityId { get; set; }
        public int ExpenseId { get; set; }
        public decimal? Quanti { get; set; }
        public decimal? Price { get; set; }
        public decimal? Total { get; set; }
        public string Note { get; set; } /* tiêu chuẩn gì gì đó các loại*/


    }
}
