using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsManager.Models
{
    public class ContactCompany : Contact
    {
        public string CompanyName { get; set; }
        public string VatNumber { get; set; }
    }
}
