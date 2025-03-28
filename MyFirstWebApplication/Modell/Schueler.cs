using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Test_2
{

    public class Schueler : Person
    {
        public string ClassName { get; set; }

        public Schueler(string name, string gender, DateTime birthDate, string className)
            : base(name, gender, birthDate)
        {
            ClassName = className;
        }
    }
}