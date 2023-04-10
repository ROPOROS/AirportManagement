using AM.ApplicationCore.Domain;
using AM.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure
{
    public class AMContext : DbContext
    {
        //Entities => Tables?
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Passanger> Passangers { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Traveller> Travellers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<ReservationTicket> Reservations { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
            Initial Catalog=AirportManagementDB;Integrated Security=true");
            base.OnConfiguring(optionsBuilder);


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlaneConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            //fleunt api
            modelBuilder.Entity<Passanger>().OwnsOne(f => f.fullName,
                full =>
                {
                    full.Property(f1 => f1.FirstName)
                    .HasColumnName("PassFirstName")
                    .HasMaxLength(30);
                    full.Property(f1 => f1.LastName)
                    .IsRequired()
                    .HasColumnName("PassLastName");
                });
            //Config TPH
            //.HasDiscriminator<int>("PassangerType")
            //.HasValue<Passanger>(0)
            //.HasValue<Traveller>(1)
            //.HasValue<Staff>(2);

            //Config TPT
            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Traveller>().ToTable("Travelllers");

            //Config clé composé
            modelBuilder.Entity<ReservationTicket>().HasKey(p => new
            {
                p.TicketFk,
                p.PassangerFk,
                p.DateReservation
            });
        }


        protected override void ConfigureConventions(ModelConfigurationBuilder modelConfigurationBuilder)
        {
            modelConfigurationBuilder.Properties<DateTime>().HaveColumnType("Date");
        }

    }
}
