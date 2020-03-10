using System;
using System.Collections.Generic;
using System.Text;

namespace DOJO_EntityFramework_LINQ
{
    public class Address
    {
        public Guid AddressID { get; set; }
        public String StreetName { get; set; }
        public int StreetNumber { get; set; }
        public int Zipcode { get; set; }
    }
}
