using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class StatusHistoryModel
    {
        public long id { get; set; }
        public string objectType { get; set; }
        public long objectId { get; set; }
        public string status { get; set; }
        public string actionBy { get; set; }
        public string actionName { get; set; }
        public DateTime? actionDate { get; set; }
    }
}
