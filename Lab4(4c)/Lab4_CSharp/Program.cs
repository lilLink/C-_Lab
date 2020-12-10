using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Створити 2 колекції ResearchTeamCollection
            ResearchTeamCollection rcol1 = new ResearchTeamCollection();
            ResearchTeamCollection rcol2 = new ResearchTeamCollection();
            rcol1.CollectionName = "Collection 1";
            rcol2.CollectionName = "Collection 2";

            //2. Створити 2 oб'єкти типу TeamsJournal
            TeamsJournal tj1 = new TeamsJournal();
            TeamsJournal tj2 = new TeamsJournal();

            rcol1.ResearchTeamAdded += tj1.EventHandler;
            rcol1.ResearchTeamInserted += tj1.EventHandler;

            rcol2.ResearchTeamAdded += tj1.EventHandler;
            rcol2.ResearchTeamAdded += tj2.EventHandler;
            rcol2.ResearchTeamInserted += tj1.EventHandler;
            rcol2.ResearchTeamInserted += tj2.EventHandler;

            //3. Внести зміни в колекції
            rcol1.AddDefaults();
            rcol2.AddDefaults();

            ResearchTeam r1 = new ResearchTeam("topic1", "organization1", 100, TimeFrame.TWO_YEARS);
            ResearchTeam r2 = new ResearchTeam("topic2", "organization2", 101, TimeFrame.TWO_YEARS);
            ResearchTeam r3 = new ResearchTeam("topic3", "organzation3", 102, TimeFrame.LONG);
            ResearchTeam r4 = new ResearchTeam("topic4", "organzation4", 103, TimeFrame.YEAR);

            rcol1.InsertAt(1, r1);
            rcol2.InsertAt(2, r2);

            rcol1.InsertAt(40, r3);
            rcol2.InsertAt(167, r4);

            Console.Write("Дані обох об'єктів TeamsJournal. \n\n");
            Console.Write("Перший об'єкт TeamsJournal:\n");
            Console.WriteLine(tj1.ToString());
            Console.Write("Другий об'єкт TeamsJournal:\n");
            Console.WriteLine(tj2.ToString());

            Console.ReadKey();
        }
    }
}
