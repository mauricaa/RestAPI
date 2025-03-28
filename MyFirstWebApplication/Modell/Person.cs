using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_2
{
    public class Person
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }

        public Person(string name, string gender, DateTime birthDate)
        {
            Name = name;
            Gender = gender;
            BirthDate = birthDate;
        }
    }
}