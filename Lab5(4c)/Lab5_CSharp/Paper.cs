using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_CSharp
{
    [DataContract]
    class Paper
    {
        private string _name;
        private Person _author;
        private DateTime _date;

        [DataMember]
        public string Name { get => _name; set => _name = value; }
        [DataMember]
        public DateTime Date { get => _date; set => _date = value; }
        [DataMember]
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
