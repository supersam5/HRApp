using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRApp.Central;

namespace HRApp.Models
{
    public  enum Level
    {
        GL01=1,GL02=2,GL03=3,GL04=4,GL05=5,GL06=6,GL07=7
    }


    public class Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public int Age { get; set; }

        public int GradeLevel { get; set; }

        public string JobTitle { get; set; }

        public int ID { get; set; }


    }
}
