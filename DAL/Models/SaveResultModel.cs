using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class SaveResultModel<T>
    {
        public SaveResultModel()
        {
            ValueReturn = 0;
            LongValReturn = 0;
            IsSuccess = true;

        }
        public int ValueReturn { get; set; }
        public bool IsSuccess { get; set; }
        public string ErrorMessage { get; set; }
        public long LongValReturn { get; set; }
        public T Data { get; set; }
    }
}
