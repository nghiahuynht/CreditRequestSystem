using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.CreditRequest
{
    public class ChangeStatusRequestParamModel
    {
        public long requestId { get; set; }
        public string status { get; set; }
        public string userName { get; set; } 
        public decimal? amountApprove { get; set; }// trường này chỉ khi nào là approve mới phải điền, mặc định gợi ý  = với số tiền tạm ứng
        public string rejectNote { get; set; } // trường này dành cho note khi reject
    }
}

