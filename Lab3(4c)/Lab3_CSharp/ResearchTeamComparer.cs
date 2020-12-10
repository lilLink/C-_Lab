using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3_CSharp
{
    class ResearchTeamComparer : IComparer<ResearchTeam>
    {
        public int Compare(ResearchTeam x, ResearchTeam y)
        {
            if (x.PapersList.Count > y.PapersList.Count) return 1;
            else if (x.PapersList.Count < y.PapersList.Count) return -1;
            else return 0;
        }
    }
}
