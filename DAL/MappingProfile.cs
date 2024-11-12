using AutoMapper;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
           //reateMap<List<InvoiceDetailGridModel>,List<InvoiceItem>> ();
        }
    }
}
