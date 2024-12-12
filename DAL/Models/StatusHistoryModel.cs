using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class StatusHistoryModel
    {
        public long Id { get; set; }
        public string ObjectType { get; set; }
        public long ObjectId { get; set; }
        public string Status { get; set; }
        public string ActionBy { get; set; }
        public string ActionName { get; set; }
        public DateTime? ActionDate { get; set; }
        public string Note { get; set; }
       
       
    }
}
