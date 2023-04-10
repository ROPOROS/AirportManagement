using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passanger
    {
        //public int id { get; set; }
        [Key]
        [StringLength(7)]
        public string PassportNumber { get; set; }
        //[StringLength(25, ErrorMessage = "Invvalid"), MinLength(3, ErrorMessage = "Inwalid")]
        //public string FirstName { get; set; }

        //public string LastName { get; set; }
        public FullName fullName { get; set; }

        [Display(Name = "Date of Birth")]
        //or [DisplayName("")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        //[DataType(DataType.PhoneNumber)]
        //or [Phone]
        [RegularExpression(@"^[0-9]{8}$", ErrorMessage = "Invalid Phone Number!")]
        public int TelNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        //or [EmailAdress]
        public string EmailAdress { get; set; }

        public IList<Flight> Flights { get; set; }

        public IList<ReservationTicket> Reservations { get; set; }

        //polymorfisme par signature
        public bool checkProfile(string firstName, string lastName, string email)
        {

            return fullName.FirstName== firstName && fullName.LastName ==lastName && EmailAdress.Equals(email);
        }
        public bool checkProfile(string firstName, string lastName)
        {

            return fullName.FirstName == firstName && fullName.LastName == lastName;
        }

        public bool Login(string firstName, string lastName, string email = null)
        {
            /* if (email != null)
             {
                 return checkProfile(firstName, lastName, email);
                 return FirstName.Equals(firstName) && LastName.Equals(lastName);
             }*/

            return (email != null) ? checkProfile(firstName, lastName, email) : checkProfile(firstName, lastName);

        }

        //polymofisme par heritage 
        //cwl bech thel console
        public virtual void PassangerType()
        {
            Console.WriteLine("I am a passanger");

        }
    }

}
