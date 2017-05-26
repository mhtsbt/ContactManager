using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsManager.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public string Street { get; set; }
        public string HouseNumber { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        [NotMapped]
        public int Age { get; set; }


    }
}
