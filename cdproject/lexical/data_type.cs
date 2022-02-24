using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lexical
{
   public class data_type
   {    
        public List<string> symbol;
        public List<string> keyword;
        public List<string> datatype;
        public List<string> comparisonOperators;
        public List<string> special;
        public List<string> arithmeticOperators;
        public List<string> logicalOperators;
        public List<string> bitwiseOperators;
        public List<string> modifier;
        public string conditionalOp;

       public data_type()
        {   // Industrialization list string
           conditionalOp = "?:";
           bitwiseOperators = new List<string>();
           logicalOperators=new List<string>();
           arithmeticOperators=new List<string>();
           special = new List<string>();
           comparisonOperators = new List<string>();
           datatype=new List<string>();
           keyword=new List<String>();
           symbol=new List<string>();
           modifier = new List<string>();

            add_datatype();
            add_comparisonOperators();
            add_bitwiseOperators();
            add_logicalOperators();
            add_arithmeticOperators();
            add_special();
            add_keyword();
            add_symbol();
            add_modifier();
        }


       public void add_modifier()
       {
           modifier.Add("public");
            modifier.Add("void");
            modifier.Add("static");
           modifier.Add("private");
       }
       public void add_symbol(){
           symbol.Add("{");
           symbol.Add("}");
           symbol.Add("[");
           symbol.Add("]");
           symbol.Add(";");
           symbol.Add(":");
           symbol.Add("<");
           symbol.Add(">");
           symbol.Add("(");
           symbol.Add(")");
           symbol.Add(",");
       }

       public void add_keyword()
       {
           keyword.Add("finally");
           keyword.Add("super");
           keyword.Add("while");
           keyword.Add("const");
           keyword.Add("class");
           keyword.Add("final");
           keyword.Add("interface");
           keyword.Add("strictfp");
           keyword.Add("volatile");
           keyword.Add("extends");
           keyword.Add("catch");
           keyword.Add("case");
           keyword.Add("enum");
           keyword.Add("instanceof");
           keyword.Add("try");
           keyword.Add("else");
           keyword.Add("assert");
           keyword.Add("import");
           keyword.Add("return");
           keyword.Add("transient");
           keyword.Add("implements");
           keyword.Add("throws");
           keyword.Add("break");
           keyword.Add("do");
           keyword.Add("if");
           keyword.Add("protected");
           keyword.Add("throw");
           keyword.Add("boolean");
           keyword.Add("default");
           keyword.Add("goto");
           keyword.Add("this");
           keyword.Add("abstract");
           keyword.Add("continue");
           keyword.Add("for");
           keyword.Add("new");
           keyword.Add("synchronized");
       }
       
       //add in list data type
        public void add_datatype()
        {
            datatype.Add("int");
            datatype.Add("float");
            datatype.Add("double");
            datatype.Add("char");
            datatype.Add("boolean");
            datatype.Add("short");
            datatype.Add("long");
            datatype.Add("byte");
        }
        //add in list comparison operators
        public void add_comparisonOperators()
        {
            comparisonOperators.Add("=>");
            comparisonOperators.Add("=<");
            comparisonOperators.Add(">");
            comparisonOperators.Add("<");
            comparisonOperators.Add("=!");
            comparisonOperators.Add("==");
        }
        //add in list arithmetic operators
        public void add_arithmeticOperators()
        {
            arithmeticOperators.Add("=");
            arithmeticOperators.Add("++");
            arithmeticOperators.Add("--");
            arithmeticOperators.Add("*");
            arithmeticOperators.Add("-");
            arithmeticOperators.Add("+");
            arithmeticOperators.Add("/");
            arithmeticOperators.Add("%");
        }
        //add in list bitwise operators
        public void add_bitwiseOperators()
        {
            bitwiseOperators.Add(">>>");
            bitwiseOperators.Add("<<<");
            bitwiseOperators.Add("<<");
            bitwiseOperators.Add(">>");
            bitwiseOperators.Add("~");
            bitwiseOperators.Add("^");
            bitwiseOperators.Add("|");
            bitwiseOperators.Add("&");
        }
        //add in list logical operators
        public void add_logicalOperators()
        {
            logicalOperators.Add("!");
            logicalOperators.Add("||");
            logicalOperators.Add("&&");
        }
      
        public void add_special()
        {
            special.Add("\\");
            special.Add("\\\\");
            special.Add("\\n");
            special.Add("\\t");
            special.Add("\\t\\");
        }

        public void print_data()
        {
            for (int i = 0; i < special.Count; i++)
            {
                Console.WriteLine(special[i]);
            }
        }
    }
}
