﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Staff : Passanger
    {
        public DateTime EmploymentDate { get; set; }

        public double Salary { get; set; }

        public string Function { get; set; }

        public override void PassangerType()
        {
            Console.WriteLine("Je suis un membre du Staff");
        }
    }
}
