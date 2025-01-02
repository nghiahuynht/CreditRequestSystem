using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class ImportCounterResultModel
    {
        public ImportCounterResultModel()
        {
            QuantiImport = 0;
            QuantiSuccess = 0;
            QuantiFail = 0;
        }

        public int QuantiImport { get; set; }
        public int QuantiSuccess { get; set; }
        public int QuantiFail { get; set; }
    }
}
