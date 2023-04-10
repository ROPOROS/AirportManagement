using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configuration
{
    public class FlightConfiguration : IEntityTypeConfiguration<Flight>
    {
        public void Configure(EntityTypeBuilder<Flight> builder)
        {
            builder.HasMany(flight => flight.Passangers)
                .WithMany(flight => flight.Flights)
                .UsingEntity(flight => flight.ToTable("MyFlight"));

            builder.HasOne(flight => flight.Plane)
                .WithMany(flight => flight.Flights)
                //.HasForeignKey(flight => flight.PlaneFk);
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
