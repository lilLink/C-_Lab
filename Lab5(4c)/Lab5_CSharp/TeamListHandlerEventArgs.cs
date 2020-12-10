using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5_CSharp
{
    class TeamListHandlerEventArgs : EventArgs
    {
        public string CollectionName { get; set; }
        public string TypesOfChange { get; set; }
        public int ElementNumber { get; set; }

        public TeamListHandlerEventArgs(string name, string type, int num)
        {
            CollectionName = name;
            TypesOfChange = type;
            ElementNumber = num;
        }

        public override string ToString()
        {
            return "Collection Name : " + CollectionName + "; TypesOfChange : " + TypesOfChange + "; Element Number : " + ElementNumber + ";\n";
        }
    }
}
