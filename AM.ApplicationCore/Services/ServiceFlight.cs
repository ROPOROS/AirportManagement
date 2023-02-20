using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ServiceFlight : IServiceFlight
    {
        public IList<Flight> Flights { get; set; } = new List<Flight>();

        public IEnumerable<IGrouping<string, Flight>> DestinationGroupedFlights()
        {
            var lambda = Flights.GroupBy(p => p.Destination);
            foreach (var flight in lambda)
            {
                Console.WriteLine("Destionation=" + flight.Key);

                foreach (var item in flight)
                {
                    Console.WriteLine("The date is :" + item.FlightDate);
                }
            }
            return lambda;
        }

        public double DurationAverage(string destination)

        {
            ////linq
            //var query = from F in Flights where F.Destination == destination select F.EstimatedDuration;
            //return query.Average();


            //lambda
            //return Flights.Where(F => F.Destination == destination).Select(F => F.EstimatedDuration).Average();
            return Flights.Where(F => F.Destination == destination).Average(F => F.EstimatedDuration);
        }


        public IList<DateTime> GetFlightDates(string destination)
        {
            //linq
            //List<DateTime> flightDates = new List<DateTime>();

            //foreach (var flight in Flights)
            //{
            //    if (flight.Destination == destination)
            //    {
            //        flightDates.Add(flight.FlightDate);
            //    }
            //}
            //return flightDates;

            //var query = from flight in Flights where flight.Destination == destination select flight.FlightDate;
            //return query.ToList();

            //lambda
            return Flights.Where(f => f.Destination == destination).Select(f => f.FlightDate).ToList();

        }

        public IEnumerable<Flight> OrderedDurationFlights()
        {
            //par default acending : linq
            //var query = from F in Flights orderby F.EstimatedDuration descending select F;
            //return query;

            //lambda
            return Flights.OrderByDescending(F => F.EstimatedDuration);
        }

        public int ProgrammedFlightNumber(DateTime startDate)
        {
            //return (from A in Flights
            //        where A.FlightDate > startDate /*&& (A.FlightDate - startDate).TotalDays < 7*/
            //        && startDate.AddDays(7) < A.FlightDate
            //        select A).Count();

            //lambda
            // return Flights.Where(A=>A.FlightDate > startDate && (A.FlightDate - startDate).TotalDays <7).Count();
            return Flights.Count(A => A.FlightDate > startDate && (A.FlightDate - startDate).TotalDays < 7);
        }

        public IEnumerable<Traveller> SeniorTravellers(Flight flight)
        {
            //linq 
            //var query = from T in flight.Passangers.OfType<Traveller>() orderby T.BirthDate select T;
            //return query.Take(3);

            //lambda
            return flight.Passangers.OfType<Traveller>().OrderBy(t => t.BirthDate).Take(3);
        }

        public void ShowFlightDetails(Plane plane)
        {
            //linq
            //foreach (var flight in Flights)
            //{
            //    if (flight.Plane == plane)
            //    {
            //        Console.WriteLine("Destination: {0}, Date: {1}", flight.Destination, flight.FlightDate);
            //    }
            //}
            /*var query = from B in Flights where B.Plane == plane*/
            var query = from flight in Flights where flight.Plane == plane select new { flight.FlightDate, flight.Destination };
            //lambda
            //var query = plane.Flights.Select(B => new { B.FlightDate, B.Destination });
            //foreach (var flight in query)
            //{
            //    Console.WriteLine(flight.FlightDate + flight.Destination);
            //}
        }



    }
}
