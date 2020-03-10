using System;
using System.Collections.Generic;
using System.Text;

namespace DOJO_EntityFramework_LINQ
{
    public class Appointment
    {
        public Guid AppointmentID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Room Room { get; set; }
        public Person Person { get; set; }
    }
}
