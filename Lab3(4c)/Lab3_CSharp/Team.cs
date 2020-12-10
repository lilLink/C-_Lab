using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_CSharp
{
    class Team: IComparable
    {
        protected string _organizationNameTeam;
        protected int _registerNumberTeam;

        public string OrganizationNameTeam { get => _organizationNameTeam; set => _organizationNameTeam = value; }
        public int RegisterNumberTeam
        {
            get => _registerNumberTeam;
            set
            {
                try
                {
                    _registerNumberTeam = value;
                    if (value <= 0) throw new ArgumentOutOfRangeException();
                }
                catch
                {
                    Console.WriteLine("Реєстраційний номер менше 0!");
                }
            }
        }

        public Team()
        {
            OrganizationNameTeam = "Team_Sleentex";
            RegisterNumberTeam = 1999;
        }

        public Team(string name, int registerNumber)
        {
            OrganizationNameTeam = name;
            RegisterNumberTeam = registerNumber;
        }

        public virtual object DeepCopy()
        {
            Team teamCopy = new Team(this.OrganizationNameTeam, this.RegisterNumberTeam);
            return teamCopy as object;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;

            Team team = obj as Team;
            return team.OrganizationNameTeam == this.OrganizationNameTeam && team.RegisterNumberTeam == this.RegisterNumberTeam;
        }

        public static bool operator ==(Team t1, Team t2)
        {
            return t1.OrganizationNameTeam == t2.OrganizationNameTeam && t1.RegisterNumberTeam == t2.RegisterNumberTeam;
        }

        public static bool operator !=(Team t1, Team t2)
        {
            return t1.OrganizationNameTeam != t2.OrganizationNameTeam && t1.RegisterNumberTeam != t2.RegisterNumberTeam;
        }

        public override int GetHashCode()
        {
            int hashCode = 0;
            char[] charName = OrganizationNameTeam.ToCharArray();

            for (int i = 0; i < OrganizationNameTeam.Length; i++)
                hashCode += (int)(charName[i]);

            hashCode += RegisterNumberTeam;
            return hashCode;
        }

        public override string ToString()
        {
            return "Назва органiзацiї: " + OrganizationNameTeam + "\n" + "Реєстрацiйний номер: " + RegisterNumberTeam + "\n";
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 0;
            Team team = obj as Team;
            return RegisterNumberTeam.CompareTo(team.RegisterNumberTeam);
        }
    }
}
