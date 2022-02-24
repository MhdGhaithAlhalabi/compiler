using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lexical
{
    public enum tokenTypes { keyword, identifier
        , number, op, symbol, error,datatype
        , Arithmetic_operators, Comparison_operators
        , Logical_operators, Assignment_operators
        , Conditional, Bitwise_operators, Special_in, modifier , stringg };
     class Token 
    {
        public tokenTypes type;
        public string value;
        public int line;

        public Token()
        {
            value = "";
            line = -1;
        }

        public Token(tokenTypes t, string v ,int l)
        {
            type = t;
            value = v;
            line = l;
        }

        public void print()
        {
            Console.WriteLine("Type: " + type + " , value: " + value + " , line: " + line);
        }
    }
}
