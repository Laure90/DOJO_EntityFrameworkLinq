using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DOJO_EntityFramework_LINQ
{
    public class StatisticCalculator
    {
        public static int GetNumberEmployeeWithRDV()
        {
            using (var context = new AppointmentContext())
            {
                var numberOfEmployeeRDV = (from p in context.People
                                          where p.IsEmployee == true && p.Agenda.Count > 0
                                          select p).Count();
                return numberOfEmployeeRDV;
            }
        }

        public static int GetPastAppointmentByRoom(Room desiredRoom)
        {
            using (var context = new AppointmentContext())
            {
                var numberOfFutureAppointment = (from appt in context.Appointments
                                                join r in context.Rooms
                                                on appt.Room.RoomID equals r.RoomID
                                                where appt.Room == desiredRoom && appt.EndDate < DateTime.Now
                                                select appt).Count();
                return numberOfFutureAppointment;
            }
        }

        public static int GetFuturRdvByEmployee(Person employee)
        {
            using (var context = new AppointmentContext())
            {
                var countOfFuturRdv = (from appt in context.Appointments
                                      join pers in context.People
                                      on appt.Person.PersonID equals pers.PersonID                                    
                                      where pers.IsEmployee == true && appt.StartDate > DateTime.Now && appt.Person == employee
                                      select appt).Count();

                return countOfFuturRdv;
            }
           
        }

        public static void GetRDVByStructure()
        {
            using(var context = new AppointmentContext())
            {

                    //Le nombre de rendez-vous appointmentspar structure
                //SELECT * FROM APPT INNER JOIN ROOM OINNER JOIN STRUCTURE GROUP BY STRUCTURE
                var rdbByStruct = from appt in context.Appointments
                                  join r in context.Rooms
                                  on appt.Room.RoomID equals r.RoomID
                                  join s in context.Structures
                                  on r.Structure.StructureID equals s.StructureID
                                  select s;


                //group s by s.StructureID;


                foreach (var current in rdbByStruct)
                {
                    Console.WriteLine(current.StructureID);
                }
                                  
            }
        }
            
    }
}
