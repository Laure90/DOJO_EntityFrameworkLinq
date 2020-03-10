using System;
using System.Collections.Generic;
using System.Text;

namespace DOJO_EntityFramework_LINQ
{
    public class Person
    {
        public Guid PersonID { get; set; }
        public String Name { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsEmployee { get; set; }
        public List<Appointment> Agenda { get; set; }
        public Structure Structure { get; set; }
    }
}
