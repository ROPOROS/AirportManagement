using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    //[Owned] annotation type complex 
    public class FullName
    {
        [StringLength(25, ErrorMessage = "Invvalid"), MinLength(3, ErrorMessage = "Inwalid")]
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
