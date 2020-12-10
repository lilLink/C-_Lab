using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_CSharp
{
    class Person
    {
        private string _firstName;
        private string _lastName;
        private DateTime _birthDate;

        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public DateTime BirthDate { get => _birthDate; set => _birthDate = value; }
        public int Year { get => BirthDate.Year; set => BirthDate = new DateTime(value, BirthDate.Month, BirthDate.Day); }

        public Person()
        {
            _firstName = "Misha";
            _lastName = "Morarash";
            _birthDate = new DateTime(1999, 10, 23);
        }

        public Person(string f_name, string l_name, DateTime birthday)
        {
            _firstName = f_name;
            _lastName = l_name;
            _birthDate = birthday;
        }

        public override string ToString()
        {
            return _lastName + " " + _firstName + " " + _birthDate.ToLongDateString();
        }

        public virtual string ToShortString()
        {
            return _lastName + " " + _firstName;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            Person person = obj as Person;
            return person.FirstName == this.FirstName && person.LastName == this.LastName && person.BirthDate == this.BirthDate;
        }

        public static bool operator ==(Person p1, Person p2)
        {
            return p1.FirstName == p2.FirstName && p1.LastName == p2.LastName && p1.BirthDate == p2.BirthDate;
        }

        public static bool operator !=(Person p1, Person p2)
        {
            return p1.FirstName != p2.FirstName && p1.LastName != p2.LastName && p1.BirthDate != p2.BirthDate;
        }

        public override int GetHashCode()
        {
            int hashCode = 0;
            char[] charName = FirstName.ToCharArray();
            char[] charSurname = LastName.ToCharArray();

            for (int i = 0; i < FirstName.Length; i++)
                hashCode += (int)(charName[i]);

            for (int i = 0; i < LastName.Length; i++)
                hashCode += (int)(charSurname[i]);

            return hashCode += (int)BirthDate.Ticks;
        }

        // change
        public virtual object DeepCopy()
        {
            Person personCopy = new Person(this.FirstName, this.LastName, this.BirthDate);
            return personCopy as object;
        }
    }
}
