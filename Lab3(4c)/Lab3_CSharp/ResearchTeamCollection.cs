using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_CSharp
{
    class ResearchTeamCollection
    {
        private List<ResearchTeam> _researchTeamList = new List<ResearchTeam>();


        public void AddDefaults()
        {
            for (int i = 0; i < 5; i++)
            {
                ResearchTeam researchTeam = new ResearchTeam($"Topic{i}", $"Name{i}", 1 + i * 5, TimeFrame.TWO_YEARS);
                for (int j = 0; j < 5; j++)
                {
                    Person person = new Person($"Person{j}", $"Personov{j}", new DateTime(1980 + i + j, 1, 1, 1, 1, 1));
                    Paper paper = new Paper($"Paper{j}", person, new DateTime(2000 + i + j, 1, 1, 1, 1, 1));
                    researchTeam.AddPapers(paper);
                    researchTeam.AddPersons(person);
                }
                _researchTeamList.Add(researchTeam);
            }
        }

        public void AddResearchTeams(params ResearchTeam[] researchTeams)
        {
            _researchTeamList.AddRange(researchTeams);
        }

        public override string ToString()
        {
            string strData = "";
            foreach (ResearchTeam researchTeam in _researchTeamList)
            {
                strData += researchTeam.ToString() + "\n";
            }
            return strData;
        }

        public virtual string ToShortList()
        {
            string data = "";
            foreach (ResearchTeam researchTeam in _researchTeamList)
            {
                data += researchTeam.ToShorString()
                    + "К-сть учасникiв: " + researchTeam.PersonList.Count() + "\n"
                    + "К-сть публiкацiй: " + researchTeam.PapersList.Count() + "\n\n";
            }
            return data;
        }

        public void SortByTeamNumber()
        {
            _researchTeamList.Sort();
        }

        public void SortByTopic()
        {
            _researchTeamList.Sort(new ResearchTeam());
        }

        public void SortByCountPapers()
        {
            _researchTeamList.Sort(new ResearchTeamComparer());
        }

        public int MinNumber
        {
            get
            {
                if (!_researchTeamList.Any()) return -1;
                else return _researchTeamList.Min(researchTeam => researchTeam.RegisterNumberTeam);
            }
        }

        public IEnumerable<ResearchTeam> ResearchTeamsGroup
        {
            get
            {
                return _researchTeamList.Where(researchTeam => researchTeam.DurationOfStudy.Equals(TimeFrame.TWO_YEARS));
            }
        }

        public List<ResearchTeam> NGroup(int value)
        {
            List<ResearchTeam> resteamList = new List<ResearchTeam>();

            var regnumberQuery = from resteam in _researchTeamList
                                 where resteam.PersonList.Count == value
                                 group resteam by resteam.RegisterNumberTeam;



            IEnumerable<ResearchTeam> resTeam = regnumberQuery.SelectMany(group => group);
            resteamList = resTeam.ToList();

            return resteamList;
        }
    }
}
