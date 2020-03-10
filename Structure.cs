using System;
using System.Collections.Generic;
using System.Text;

namespace DOJO_EntityFramework_LINQ
{
    public class Structure
    {
        public Guid StructureID { get; set; }
        public Address Address { get; set; }
        public List<Room> RoomList { get; set; }
        public List<Person> PersonList { get; set; }
        
    }
}
