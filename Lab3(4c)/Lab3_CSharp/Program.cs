using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Cтворити об'єкт типу ResearchTeamCollection. Додати в колекцію декілька елементрів тику ResearchTeam з різними значеннями та вивести створений об'єкт.\n");
            ResearchTeamCollection researchTeamCollection = new ResearchTeamCollection();

            researchTeamCollection.AddDefaults();

            ResearchTeam[] teams = new ResearchTeam[3];
            teams[0] = new ResearchTeam("topic43", "name563", 123456, TimeFrame.TWO_YEARS);
            teams[1] = new ResearchTeam("topic463", "name45", 654123, TimeFrame.YEAR);
            teams[2] = new ResearchTeam("topic", "name", 6563, TimeFrame.LONG);

            Paper[] papers = new Paper[3];
            papers[0] = new Paper();
            papers[1] = new Paper("title1", new Person("Person", "Person", new DateTime(1986, 12, 12)), new DateTime(2020, 10, 10));
            papers[2] = new Paper("title2", new Person("Person0", "Person0", new DateTime(1987, 12, 12)), new DateTime(2020, 11, 25));

            teams[1].AddPapers(papers);


            researchTeamCollection.AddResearchTeams(teams);

            Console.WriteLine(researchTeamCollection.ToString());
            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("2. Для створеного об'єкту ResearchTeamCollection викликати методи, що сортують список List<ResearchTeam> за різними критеріями та після кожного сортування вивести дані об'єкту.\n");
            Console.WriteLine(" Сортування за номером реєстрації.\n");
            researchTeamCollection.SortByTeamNumber();
            Console.WriteLine(researchTeamCollection.ToString() + "\n\n");

            Console.WriteLine(" Сортування за назвою та теми дослідження.\n");
            researchTeamCollection.SortByTopic();
            Console.WriteLine(researchTeamCollection.ToString() + "\n\n");

            Console.WriteLine(" Сортування за кількістю публікацій.\n");
            researchTeamCollection.SortByCountPapers();
            Console.WriteLine(researchTeamCollection.ToShortList() + "\n\n");

            Console.WriteLine("\n\n\n\n\n");
            Console.WriteLine("3. Викликати методи класу ResearchTeamCollection, що виконують операції зі списком List<ResearchTeam> та після кожної операції вивести результат.\n");
            Console.WriteLine(" Знаходження мінімального значення номера реєстрації для елементів списку, вивести мінімальне значення.\n");
            Console.WriteLine(researchTeamCollection.MinNumber + "\n\n");

            Console.WriteLine(" Фільтрацію проектів з тривалістю дослідження TwoYears, вивести результат фільтрації.\n");
            List<ResearchTeam> res1 = new List<ResearchTeam>();
            res1 = researchTeamCollection.ResearchTeamsGroup.ToList<ResearchTeam>();
            foreach (ResearchTeam team in res1)
            {
                Console.WriteLine(team.ToString());
            }


            Console.WriteLine(" Вивести проекти з заданою к-стю учасників(5).\n");
            List<ResearchTeam> res2 = new List<ResearchTeam>();
            res2 = researchTeamCollection.NGroup(5);
            foreach (ResearchTeam team in res2)
            {
                Console.WriteLine(team.ToString());
            }


            Console.WriteLine("3. Створити об'єкт типу  TestCollection. Викликати метод для пошуку в колекціях першого, центрального, останнього та елемнта, що не входить а колекцію. Вивести час пошуку для всіх чотирьох випадків.\n");
            TestColections test = new TestColections(100);

            test.timeSearchInListStrings();
            test.timeSearchInListKeys();
            test.timeSearchInDictStringsByValue();
            test.timeSearchInDictStrings();
            test.timeSearchInDictKeysByValue();
            test.timeSearchInDictKeys();

            Console.Read();
        }
    }
}
