﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class AuthenticatedModel
    {
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
        public string DepartmentId { get; set; }
        public int UserId { get; set; }
       
    }
}
