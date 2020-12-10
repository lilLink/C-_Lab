using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_CSharp
{
    class TestColections
    {
        List<Team> keys;
        List<string> strings;
        Dictionary<Team, ResearchTeam> keysDictionary;
        Dictionary<string, ResearchTeam> stringDictionary;

        public TestColections(int count)
        {
            if (count < 0) throw new ArgumentException("Number of elements can`t be negative");

            keys = new List<Team>();
            strings = new List<string>();
            keysDictionary = new Dictionary<Team, ResearchTeam>();
            stringDictionary = new Dictionary<string, ResearchTeam>();

            for (int id = 1; id < count; id++)
            {
                keys.Add(createTeam(id));
                strings.Add(createTeam(id).ToString());
                keysDictionary.Add(createTeam(id), createResearchTeam(id));
                stringDictionary.Add(createTeam(id).ToString(), createResearchTeam(id));
            }
        }

        public static Team createTeam(int id)
        {
            Random random = new Random();
            string name = "Name" + random.Next().ToString();
            return new Team(name, id);
        }

        public static ResearchTeam createResearchTeam(int id)
        {
            Random random = new Random();
            string topic = "Topic" + random.Next().ToString();
            string name = "Name" + random.Next().ToString();
            TimeFrame timeFrame;

            switch(random.Next(3))
            {
                case 0:
                    timeFrame = TimeFrame.YEAR;
                    break;
                case 1:
                    timeFrame = TimeFrame.TWO_YEARS;
                    break;
                default:
                    timeFrame = TimeFrame.LONG;
                    break;
            }

            return new ResearchTeam(topic, name, id, timeFrame);
        }

        
        private long searchTimeForList<T>(List<T> list, T item)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            list.Contains(item);
            sw.Stop();

            return sw.ElapsedTicks;
        }

        public void timeSearchInListKeys()
        {
            Team first = keys[0];
            Team center = keys[keys.Count / 2];
            Team last = keys[keys.Count - 1];
            Team another = new Team("timeSearchInListKeys", 10);

            Console.WriteLine("In List<Team>:\n\tFor the first element: " + searchTimeForList<Team>(keys, first));
            Console.WriteLine("\tFor the central element:  " + searchTimeForList<Team>(keys, center));
            Console.WriteLine("\tFor the last element:  " + searchTimeForList<Team>(keys, last));
            Console.WriteLine("\tFor a non-existent element:  " + searchTimeForList<Team>(keys, another) + "\n");
        }

        public void timeSearchInListStrings()
        {
            string first = strings[0];
            string center = strings[keys.Count / 2];
            string last = strings[keys.Count - 1];
            string another = "another text";

            Console.WriteLine("In List<string>:\n\tFor the first element: " + searchTimeForList<string>(strings, first));
            Console.WriteLine("\tFor the central element:  " + searchTimeForList<string>(strings, center));
            Console.WriteLine("\tFor the last element:  " + searchTimeForList<string>(strings, last));
            Console.WriteLine("\tFor a non-existent element:  " + searchTimeForList<string>(strings, another) + "\n");
        }

        private long searchTimeForDictionary<T>(Dictionary<T, ResearchTeam> dictionary, T item)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            dictionary.ContainsKey(item);
            sw.Stop();

            return sw.ElapsedTicks;
        }

        public void timeSearchInDictKeys()
        {
            var first = keysDictionary.ElementAt(0).Key;
            var center = keysDictionary.ElementAt(keysDictionary.Count / 2).Key;
            var last = keysDictionary.ElementAt(keysDictionary.Count - 1).Key;
            var another = new Team("another_team", 11);

            Console.WriteLine("In Dictionary<Team, ResearchTeam>:\n\tFor the first element: " + searchTimeForDictionary<Team>(keysDictionary, first));
            Console.WriteLine("\tFor the central element:  " + searchTimeForDictionary<Team>(keysDictionary, center));
            Console.WriteLine("\tFor the last element:  " + searchTimeForDictionary<Team>(keysDictionary, last));
            Console.WriteLine("\tFor a non-existent element:  " + searchTimeForDictionary<Team>(keysDictionary, another) + "\n");
        }

        public void timeSearchInDictStrings()
        {
            var first = stringDictionary.ElementAt(0).Key;
            var center = stringDictionary.ElementAt(stringDictionary.Count / 2).Key;
            var last = stringDictionary.ElementAt(stringDictionary.Count - 1).Key;
            var another = "dict_string";

            Console.WriteLine("In Dictionary<string, ResearchTeam>:\n\tFor the first element: " + searchTimeForDictionary<string>(stringDictionary, first));
            Console.WriteLine("\tFor the central element:  " + searchTimeForDictionary<string>(stringDictionary, center));
            Console.WriteLine("\tFor the last element:  " + searchTimeForDictionary<string>(stringDictionary, last));
            Console.WriteLine("\tFor a non-existent element:  " + searchTimeForDictionary<string>(stringDictionary, another) + "\n");
        }

        private long searchTimeForDictionaryByValue<T>(Dictionary<T, ResearchTeam> dictionary, ResearchTeam item)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            dictionary.ContainsValue(item);
            sw.Stop();

            return sw.ElapsedTicks;
        }

        public void timeSearchInDictKeysByValue()
        {
            var first = keysDictionary.ElementAt(0).Value;
            var center = keysDictionary.ElementAt(keysDictionary.Count / 2).Value;
            var last = keysDictionary.ElementAt(keysDictionary.Count - 1).Value;
            var another = new ResearchTeam("unused", "unused", 1, TimeFrame.LONG);

            Console.WriteLine("In Dictionary<Team, ResearchTeam> by value:\n\tFor the first element: " + searchTimeForDictionaryByValue<Team>(keysDictionary, first));
            Console.WriteLine("\tFor the central element:  " + searchTimeForDictionaryByValue<Team>(keysDictionary, center));
            Console.WriteLine("\tFor the last element:  " + searchTimeForDictionaryByValue<Team>(keysDictionary, last));
            Console.WriteLine("\tFor a non-existent element:  " + searchTimeForDictionaryByValue<Team>(keysDictionary, another) + "\n");
        }

        public void timeSearchInDictStringsByValue()
        {
            var first = stringDictionary.ElementAt(0).Value;
            var center = stringDictionary.ElementAt(stringDictionary.Count / 2).Value;
            var last = stringDictionary.ElementAt(stringDictionary.Count - 1).Value;
            var another = new ResearchTeam("unused", "unused", 1, TimeFrame.LONG);

            Console.WriteLine("In Dictionary<string, ResearchTeam> by value:\n\tFor the first element: " + searchTimeForDictionaryByValue<string>(stringDictionary, first));
            Console.WriteLine("\tFor the central element:  " + searchTimeForDictionaryByValue<string>(stringDictionary, center));
            Console.WriteLine("\tFor the last element:  " + searchTimeForDictionaryByValue<string>(stringDictionary, last));
            Console.WriteLine("\tFor a non-existent element:  " + searchTimeForDictionaryByValue<string>(stringDictionary, another) + "\n");
        }

    }
}
