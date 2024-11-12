using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class DataTableResultModel<T>
    {
        public long recordsTotal { get; set; }
        public long recordsFiltered { get; set; }
        public List<T> data { get; set; }
    }
}
