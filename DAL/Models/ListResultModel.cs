using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class ListResultModel<T>
    {
        public List<T> Results { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
    }
}
