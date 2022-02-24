using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lexical
{
    class Symbol
    {
        public string name;
        public string type;
        public int scope;
        //public string value;
        //public string address;
        //public string staticV;

        public Symbol()
        {
            name = "";
            type = "";
            scope = -1;
        
        }

        public Symbol(string n, string t, int s)
        {
            name = n;
            type = t;
            scope = s;
        }

        public void print()
        {
            Console.WriteLine("Name: " + name + " , type: " + type + " , scope: " + scope);
        }
    }
}
