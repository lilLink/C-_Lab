using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_CSharp
{
    [DataContract]
    class Team : System.IComparable
    {
        protected string name; 
        protected int teamNum; 

        public Team(string name, int teamNum)
        {
            this.name = name;
            this.teamNum = teamNum;
        }

        public Team()
        {
            this.name = "Name";
            this.teamNum = 404;
        }

        [DataMember]
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        [DataMember]
        public int TeamNum
        {
            get
            {
                return teamNum;
            }
            set
            {
                try
                {
                    teamNum = value;
                    if (value <= 0)
                        throw new ArgumentOutOfRangeException();
                }
                catch
                {
                    Console.WriteLine("Виникла виключна ситуація!");
                }
            }
        }

        public Team DeepCopy()
        {
            Team teamCopy = new Team(this.name, this.teamNum);
            return teamCopy;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Team team = obj as Team;
            return this.name == team.name
                && this.teamNum == team.teamNum;
        }

        public static bool operator ==(Team t1, Team t2)
        {
            return t1.name == t2.name && t1.teamNum == t2.teamNum;
        }

        public static bool operator !=(Team t1, Team t2)
        {
            return t1.name != t2.name && t1.teamNum != t2.teamNum;
        }

        public override int GetHashCode()
        {
            int hashCode = 0;
            char[] arr;
            arr = name.ToCharArray();

            for (int index = 0; index < name.Length; index++)
                hashCode += (int)(arr[index]);
            hashCode += teamNum;
            return hashCode;

        }

        public override string ToString()
        {
            return name + " " + teamNum;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
                return 0;
            Team team = obj as Team;
            return teamNum.CompareTo(team.TeamNum);
        }
    }
}
