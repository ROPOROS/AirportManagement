using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passanger
    {
        public int id { get; set; }
        public string PassportNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int TelNumber { get; set; }
        public string EmailAdress { get; set; }

        //polymorfisme par signature
        public bool checkProfile (string firstName, string lastName, string email)
        {

            return FirstName.Equals(firstName) && LastName.Equals(lastName) && EmailAdress.Equals(email);
        }
        public bool checkProfile(string firstName, string lastName)
        {

            return FirstName.Equals(firstName) && LastName.Equals(lastName);
        }

        public bool Login(string firstName,string lastName,string email = null)
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
