using System;
using System.Collections.Generic;
using System.Text;

namespace DOJO_EntityFramework_LINQ
{
    class AppointmentPerson
    {
        public Guid AppointmentPersonID { get; set; }
        public Person Person { get; set; }
        public Appointment Appointment { get; set; }
    }
}
