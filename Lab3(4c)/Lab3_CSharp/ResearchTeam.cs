using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_CSharp
{
    class ResearchTeam : Team, INameAndCopy, IComparer<ResearchTeam>
    {
        private string _name;
        private TimeFrame _durationOfStudy;
        List<Paper> _papersList = new List<Paper>();
        List<Person> _personList = new List<Person>();

        public string Name { get => _name; set => _name = value; }
        public TimeFrame DurationOfStudy { get => _durationOfStudy; set => _durationOfStudy = value; }
        public List<Paper> PapersList { get => _papersList; set => _papersList = value; }
        public List<Person> PersonList { get => _personList; set => _personList = value; }
        public Paper LastPaper { get => PapersList.Where(p1 => p1.Date.Equals(PapersList.Max(p2 => p2.Date))).FirstOrDefault(); }
        public bool this[TimeFrame index] { get => DurationOfStudy.Equals(index); }
        public Team Team
        {
            get => new Team(OrganizationNameTeam, RegisterNumberTeam);
            set
            {
                _organizationNameTeam = value.OrganizationNameTeam;
                _registerNumberTeam = value.RegisterNumberTeam;
            }
        }
        public ResearchTeam() : base()
        {
            Name = "ResearchTopicName";
            DurationOfStudy = TimeFrame.TWO_YEARS;
        }

        public ResearchTeam(string researchTopicName, string organizationName, int registerNumber, TimeFrame durationOfStudy) : base(organizationName, registerNumber)
        {
            Name = researchTopicName;
            DurationOfStudy = durationOfStudy;
        }

        public void AddPapers(params Paper[] papers)
        {
            PapersList.AddRange(papers);
        }

        public void AddPersons(params Person[] persons)
        {
            PersonList.AddRange(persons);
        }

        public string GetPapers()
        {
            string str = "";
            int i = 1;
            foreach (Paper paper in PapersList)
            {
                str = str + "\t" + i++ + ") " + paper.ToString() + "\n";
            }
            return str;
        }

        public string GetPersons()
        {
            string str = "";
            int i = 1;
            foreach (Person person in PersonList)
            {
                str = str + "\t" + i++ + ") " + person.ToString() + "\n";
            }
            return str;
        }

        public override string ToString()
        {
            return "Назва теми дослiдження: " + Name + "\n" + base.ToString() +
                   "Тривалiсть дослiдження: " + DurationOfStudy + "\n" + "Список публiкацiй: \n" + GetPapers() + "Список людей: \n" + GetPersons();
        }

        public virtual string ToShorString()
        {
            return "Назва теми дослiдження: " + Name + "\n" + base.ToString() + "Тривалiсть дослiдження: " + DurationOfStudy + "\n";
        }

        public new object DeepCopy()
        {
            ResearchTeam researchTeamCopy = new ResearchTeam(this.Name, this.OrganizationNameTeam, this.RegisterNumberTeam, this.DurationOfStudy);
            researchTeamCopy.PapersList = this.PapersList;
            researchTeamCopy.PersonList = this.PersonList;

            return researchTeamCopy as object;
        }


        public IEnumerable<Person> GetPersonEnumerator()
        {
            bool FoundMatch;

            for (int WorkerIndex = 0; WorkerIndex < PersonList.Count; WorkerIndex++)
            {
                FoundMatch = false;

                for (int PaperIndex = 0; PaperIndex < PapersList.Count; PaperIndex++)
                {

                    if (PapersList.ElementAt(PaperIndex).Author == PersonList.ElementAt(WorkerIndex))
                    {
                        FoundMatch = true;
                        break;
                    }

                }
                if (!FoundMatch)
                {
                    yield return PersonList.ElementAt(WorkerIndex);
                }

            }
        }

        public IEnumerable<Paper> GetPublicationsEnumerator(int inputTimeRange)
        {
            DateTime inputTimeFrame = new DateTime(((int)DateTime.Now.Year - inputTimeRange), 1, 1, 1, 1, 1);
            for (int index = 0; index < PapersList.Count; index++)
            {
                if (PapersList[index].Date.Ticks > inputTimeFrame.Ticks)
                    yield return PapersList[index]; // Yield each paper of the team.
            }
        }

        public IEnumerable<Person> GetWorkersEnumerator()
        {
            bool FoundMatch;

            for (int WorkerIndex = 0; WorkerIndex < PersonList.Count; WorkerIndex++)
            {
                FoundMatch = false;

                for (int PaperIndex = 0; PaperIndex < PapersList.Count; PaperIndex++)
                {

                    if (PapersList.ElementAt(PaperIndex).Author == PersonList.ElementAt(WorkerIndex))
                    {
                        FoundMatch = true;
                        break;
                    }

                }
                if (FoundMatch)
                    yield return PersonList.ElementAt(WorkerIndex);
            }
        }

        public IEnumerable<Person> GetGoodWorkersEnumerator()
        {
            bool FoundMatch;
            int hasWorks = 0;

            for (int WorkerIndex = 0; WorkerIndex < PersonList.Count; WorkerIndex++)
            {
                hasWorks = 0;
                FoundMatch = false;

                for (int PaperIndex = 0; PaperIndex < PapersList.Count; PaperIndex++)
                {

                    if (PapersList.ElementAt(PaperIndex).Author == PersonList.ElementAt(WorkerIndex))
                    {
                        FoundMatch = true;
                        hasWorks++;
                        break;
                    }

                }
                if (FoundMatch && hasWorks > 1)
                    yield return PersonList.ElementAt(WorkerIndex);
            }
        }

        public IEnumerable<Paper> GetYearPublicationsEnumerator()
        {
            DateTime inputTimeFrame = new DateTime(((int)DateTime.Now.Year - 1), 1, 1, 1, 1, 1);
            for (int index = 0; index < PapersList.Count; index++)
                if (PapersList[index].Date.Ticks > inputTimeFrame.Ticks)
                    yield return PapersList[index];
        }

        public int Compare(ResearchTeam x, ResearchTeam y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}
