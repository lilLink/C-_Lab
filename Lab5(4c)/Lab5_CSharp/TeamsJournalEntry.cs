using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_CSharp
{
    class TeamsJournalEntry
    {
        public string CollectionName { get; set; }
        public string TypeOfChange { get; set; }
        public int NewElementNumber { get; set; }

        public TeamsJournalEntry(string name, string type, int num)
        {
            CollectionName = name;
            TypeOfChange = type;
            NewElementNumber = num;
        }

        public override string ToString()
        {
            return "CollectionName : " + CollectionName + "; " + "TypeOfChange : " + TypeOfChange + "; " + "NewElementNumber " + NewElementNumber + ";\n";
        }
    }
}
