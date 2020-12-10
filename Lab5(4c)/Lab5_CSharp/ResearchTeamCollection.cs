using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_CSharp
{
    class ResearchTeamCollection
    {
        private List<ResearchTeam> _researchTeamList = new List<ResearchTeam>();

        public ResearchTeam this[int index] { get => _researchTeamList[index]; set => _researchTeamList[index] = value; }
        public string CollectionName { get; set; }

        public delegate void TeamListHandler(object source, TeamListHandlerEventArgs args);
        public event TeamListHandler ResearchTeamAdded;
        public event TeamListHandler ResearchTeamInserted;

        public void InsertAt(int j, ResearchTeam researchTeam)
        {
            ResearchTeam rt = _researchTeamList.ElementAtOrDefault(j);

            if((object)rt == null)
            {
                _researchTeamList.Add(researchTeam);
                ResearchTeamAdded(this, new TeamListHandlerEventArgs(this.CollectionName, "Element Added", _researchTeamList.Count - 1));
            } 
            else {
                _researchTeamList.Insert(j, researchTeam);
                ResearchTeamInserted(this, new TeamListHandlerEventArgs(this.CollectionName, "Element Inserted", j));
            }
        }

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
                    researchTeam.AddMembers(person);
                }
                _researchTeamList.Add(researchTeam);
                ResearchTeamAdded(this, new TeamListHandlerEventArgs(this.CollectionName, "Element Added", _researchTeamList.Count - 1));
            }
        }

        public void AddResearchTeams(params ResearchTeam[] researchTeams)
        {
            foreach (ResearchTeam team in researchTeams)
            {
                try
                {
                    _researchTeamList.Add(team);
                    ResearchTeamAdded(this, new TeamListHandlerEventArgs(this.CollectionName, "Element Added", _researchTeamList.Count - 1));
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Error!");
                }

            }
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
                data += researchTeam.ToShortString()
                    + "К-сть учасникiв: " + researchTeam.ResearchTeamPersonList.Count() + "\n"
                    + "К-сть публiкацiй: " + researchTeam.ResearchTeamPaperList.Count() + "\n\n";
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
                else return _researchTeamList.Min(researchTeam => researchTeam.ReseachTeamNumber);
            }
        }

        public IEnumerable<ResearchTeam> ResearchTeamsGroup
        {
            get
            {
                return _researchTeamList.Where(researchTeam => researchTeam.ResearchTeamTimeframe.Equals(TimeFrame.TWO_YEARS));
            }
        }

        public List<ResearchTeam> NGroup(int value)
        {
            List<ResearchTeam> resteamList = new List<ResearchTeam>();

            var regnumberQuery = from resteam in _researchTeamList
                                 where resteam.ResearchTeamPersonList.Count == value
                                 group resteam by resteam.ReseachTeamNumber;



            IEnumerable<ResearchTeam> resTeam = regnumberQuery.SelectMany(group => group);
            resteamList = resTeam.ToList();

            return resteamList;
        }
    }
}
