using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.CreditRequest
{
    public class CreditRequestMatrixModel
    {
        public int Id { get; set; }
        public string UserCreate { get; set; }
        public string UserCheck { get; set; }
        public string UserApprove { get; set; }
    }
}
