using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_CSharp
{
    class ResearchTeamComparer : IComparer<ResearchTeam>
    {
        public int Compare(ResearchTeam x, ResearchTeam y)
        {
            if (x.ResearchTeamPaperList.Count > y.ResearchTeamPaperList.Count) return 1;
            else if (x.ResearchTeamPaperList.Count < y.ResearchTeamPaperList.Count) return -1;
            else return 0;
        }
    }
}
