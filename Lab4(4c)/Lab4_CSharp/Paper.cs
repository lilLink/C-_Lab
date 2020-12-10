using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_CSharp
{
    class Paper
    {
        private string _name;
        private Person _author;
        private DateTime _date;

        public string Name { get => _name; set => _name = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public Person Author { get => _author; set => _author = value; }

        public Paper()
        {
            Name = "Publication";
            Author = new Person();
            Date = DateTime.Now;
        }

        public Paper(string name, Person author, DateTime date)
        {
            Name = name;
            Author = author;
            Date = date;
        }

        public override string ToString()
        {
            return Name + " " + Author + " " + Date;
        }
    }
}
