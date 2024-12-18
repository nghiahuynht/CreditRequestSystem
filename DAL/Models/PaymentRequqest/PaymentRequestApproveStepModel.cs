using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.PaymentRequqest
{
    public class PaymentRequestApproveStepModel
    {
        public long RequestId { get; set; }
        public int ProfileAttachId { get; set; }
        public int StepChecklistId { get; set; }
        
    }
}
