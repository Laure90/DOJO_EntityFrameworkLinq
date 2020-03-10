using System;
using System.Collections.Generic;
using System.Text;

namespace DOJO_EntityFramework_LINQ
{
    public class Room
    {
        public Guid RoomID { get; set; }
        public String Name { get; set; }
        public Structure Structure { get; set; }
        public List<Appointment> AppointmentList { get; set; }
    }
}
