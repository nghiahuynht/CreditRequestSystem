using DAL.Models.Category;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.PaymentRequqest
{
    public class PaymentAttachCheckistModel
    {
        public PaymentAttachCheckistModel()
        {
            LstAttachments = new List<PaymentListAttachmentsModel>();
            LstApproveChecklist = new List<PaymentCheckListHistoryModel>();
        }

        public List<PaymentListAttachmentsModel> LstAttachments { get; set; }
        public List<PaymentCheckListHistoryModel> LstApproveChecklist { get; set; }
    }
}
