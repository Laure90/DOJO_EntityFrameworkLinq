using System;
using System.Collections.Generic;
using System.Linq;

namespace DOJO_EntityFramework_LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            using( var context = new AppointmentContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var address1 = new Address
                {
                    StreetName = "Baker Street",
                    StreetNumber = 221,
                    Zipcode = 22345
                };

                var address2 = new Address
                {
                    StreetName = "Wolf Street",
                    StreetNumber = 36,
                    Zipcode = 1983
                };

                var address3 = new Address
                {
                    StreetName = "Inanc Street",
                    StreetNumber = 25,
                    Zipcode = 1995
                };

                var structure1 = new Structure
                {
                    Address = address1
                };

                var structure2 = new Structure
                {
                    Address = address2
                };

                var structure3 = new Structure
                {
                    Address = address3
                };
                List<Structure> structureList = new List<Structure>
                {
                    structure1, structure2, structure3
                };

                foreach(Structure currentStructure in structureList)
                {
                    currentStructure.RoomList = GenerateRoom(currentStructure, 3);
                    currentStructure.PersonList = GeneratePerson(currentStructure, 5);
                    foreach(Room currentRoom in currentStructure.RoomList)
                    {
                        currentRoom.AppointmentList = GenerateFuturAppointment(currentRoom, 5);
                        currentRoom.AppointmentList.AddRange(GeneratePastAppointment(currentRoom, 5));
                    }

                    foreach(Person currentPerson in currentStructure.PersonList)
                    {
                        currentPerson.Agenda = GetRandomRDV(currentStructure);
                    }
                }
                context.AddRange(structureList);
                context.SaveChanges();

                //StatisticCalculator.GetPastAppointmentByRoom(structure1.RoomList[0]);
                Console.WriteLine(StatisticCalculator.GetFuturRdvByEmployee(structure1.PersonList[0]));

            }
            //Console.WriteLine("Nombre d'employés ayant eu ou allant avoir un rendez-vous : ");
            //Console.WriteLine(StatisticCalculator.GetNumberEmployeeWithRDV());

            StatisticCalculator.GetRDVByStructure();



        }

        static List<Room> GenerateRoom(Structure structure, int numberRoom)
        {
            List<Room> roomList = new List<Room>();
            for(int i = 0; i<numberRoom; i++)
            {
                var newRoom = new Room();
                newRoom.Name = "Room" + i;
                newRoom.Structure = structure;
                roomList.Add(newRoom);
            }
            return roomList;
        }

        static List<Person> GeneratePerson(Structure structure, int numberPerson)
        {
            List<Person> personList = new List<Person>();
            for (int i = 0; i < numberPerson; i++)
            {
                var newPerson = new Person();
                newPerson.Name = "Person" + i;
                newPerson.BirthDate = DateTime.Now.AddYears(-30);
                newPerson.IsEmployee = true;
                personList.Add(newPerson);
            }
            return personList;
        }

        static List<Appointment> GenerateFuturAppointment(Room room, int numberAppointment)
        {
            List<Appointment> AppointmentList = new List<Appointment>();
            for (int i = 0; i < numberAppointment; i++)
            {
                var newAppointment = new Appointment();
                newAppointment.StartDate = DateTime.Now.AddDays(i+1);
                newAppointment.EndDate = DateTime.Now.AddDays(i+2);
                newAppointment.Room = room;
                AppointmentList.Add(newAppointment);
            }
            return AppointmentList;
        }

        static List<Appointment> GeneratePastAppointment(Room room, int numberAppointment)
        {
            List<Appointment> AppointmentList = new List<Appointment>();
            for (int i = 0; i < numberAppointment; i++)
            {
                var newAppointment = new Appointment();
                newAppointment.StartDate = DateTime.Now.AddDays(-6);
                newAppointment.EndDate = DateTime.Now.AddDays(-5);
                newAppointment.Room = room;
                AppointmentList.Add(newAppointment);
            }
            return AppointmentList;
        }

        static List<Appointment> GetRandomRDV (Structure structure)
        {
            List<Appointment> resultRdvList = new List<Appointment>();
            List<Appointment> rdvStructures = new List<Appointment>();
            foreach(Room room in structure.RoomList)
            {
                rdvStructures.AddRange(room.AppointmentList);
            }
            List<Appointment> rdvPast = rdvStructures.Where(rdv => DateTime.Compare(rdv.EndDate, DateTime.Now) > 0).ToList();
            Random aleatoire = new Random();
            int rdvNumber = aleatoire.Next(rdvPast.Count-1);
            resultRdvList.Add(rdvPast[rdvNumber]);

            List<Appointment> rdvFutur = rdvStructures.Where(rdv => DateTime.Compare(rdv.StartDate, DateTime.Now) < 0).ToList();
            rdvNumber = aleatoire.Next(rdvFutur.Count-1);
            resultRdvList.Add(rdvFutur[rdvNumber]);
            return resultRdvList;
        }
    }
}
