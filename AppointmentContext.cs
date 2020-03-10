using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DOJO_EntityFramework_LINQ
{
    class AppointmentContext : DbContext
    {
        public virtual DbSet<Person> People { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<AppointmentPerson> AppointmentPeople { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Structure> Structures { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=LOCALHOST\SQLEXPRESS;Database=Appointment;Integrated Security=True");
        }
    }
}
