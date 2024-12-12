using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class AttactFileModel
    {
        public long Id { get; set; }
        public long ObjectId { get; set; }
        public string ObjectType { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string URLPath { get; set; }
        public int? Size { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? SuggestId { get; set; }
    }
}
