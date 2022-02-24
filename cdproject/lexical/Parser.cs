using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lexical
{
    class Parser
    {
        int TokenIndex;
        int scope;
        Lexical lex;
        SymbolTable ST;
        public Parser(string input)
        {
            scope = 0;
            ST = new SymbolTable();
            lex = new Lexical(input);
            TokenIndex = 0;
            
            bool res = MainProgram();
            if (res)
            {
                Console.WriteLine("True");
            }
            else
            {
                Console.WriteLine("False");
            }
           ST.printTable();
        }

        public bool MainProgram()
        {
            if (lex.tokenList[TokenIndex].value == "void")
            {
                TokenIndex++;
                if (lex.tokenList[TokenIndex].value == "main")
                {
                    TokenIndex++;
                    if (lex.tokenList[TokenIndex].value == "(")
                    {
                        TokenIndex++;
                        if (lex.tokenList[TokenIndex].value == ")")
                        {
                            TokenIndex++;
                            if (lex.tokenList[TokenIndex].value == "{")
                            {
                                scope++;
                                TokenIndex++;
                                if (Attribute_())
                                {
                                    if (lex.tokenList[TokenIndex].value == "}")
                                    {
                                        scope--;
                                        return true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error in line ( " + lex.tokenList[TokenIndex].line + " ): I expected to find } but I found " + lex.tokenList[TokenIndex].value);
                                    }

                                }
                            }
                            else
                            {

                                TokenIndex++;
                                Console.WriteLine("Error in line ( " + lex.tokenList[TokenIndex].line
                                    + " ): I expected to find 'identifier' but I found Attribute ");
                            }


                        }
                        else
                        {

                            Console.WriteLine("Error in line ( " + lex.tokenList[TokenIndex].line
                                + " ): I expected to find ')' but I found  {");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Error in line ( " + lex.tokenList[TokenIndex].line
                            + " ): I expected to find '(' but I found  " + lex.tokenList[TokenIndex].value);
                    }
                }

                else
                {
                    Console.WriteLine("Error in line ( " + lex.tokenList[TokenIndex].line
                        + " ): I expected to find 'main' but I found " + lex.tokenList[TokenIndex].value);
                }
            }
            else
            {
                Console.WriteLine("Error in line ( " + lex.tokenList[TokenIndex].line
                    + " ): I expected to find 'modifier' but I found " + lex.tokenList[TokenIndex].value);
            }

                return false;
        }
        public bool classs()
        {
            if (lex.tokenList[TokenIndex].type == tokenTypes.modifier)
            {
                TokenIndex++;
                if (lex.tokenList[TokenIndex].value == "class")
                {
                    TokenIndex++;
                    if (lex.tokenList[TokenIndex].type == tokenTypes.identifier)
                    {
                        TokenIndex++;
                        if (lex.tokenList[TokenIndex].value == "{")
                        {
                            scope++;
                            TokenIndex++;
                            if (Attribute_())
                            {
                                if (lex.tokenList[TokenIndex].value == "}")
                                {
                                    scope--;
                                    return true;
                                }
                                else
                                {
                                    Console.WriteLine("Error in line ( " + lex.tokenList[TokenIndex].line + " ): I expected to find } but I found " + lex.tokenList[TokenIndex].value);
                                }

                            }
                        }
                        else
                        {

                            TokenIndex++;
                            Console.WriteLine("Error in line ( " + lex.tokenList[TokenIndex].line
                                + " ): I expected to find 'identifier' but I found Attribute ");
                        }


                    }
                    else
                    {

                        Console.WriteLine("Error in line ( " + lex.tokenList[TokenIndex].line
                            + " ): I expected to find 'identifier' but I found  {");
                    }

                }
                else
                {
                    Console.WriteLine("Error in line ( " + lex.tokenList[TokenIndex].line
                        + " ): I expected to find 'class' but I found  identifier");
                }
            }
            else
            {
                Console.WriteLine("Error in line ( " + lex.tokenList[TokenIndex].line
                    + " ): I expected to find 'modifier' but I found " + lex.tokenList[TokenIndex].value);
            }
            return false;
        }

        public bool Attribute_()
        {

             if (Parameter()) 
            {
                if (lex.tokenList[TokenIndex].value != "}")
                {
                    if (Attribute_())
                    {
                        return true;
                    }
                }
               else { return true; }
            }


            return false;
        }
      

        public bool Statement()
        {
            if (Stmt())
            {
                if (lex.tokenList[TokenIndex].value != "}")
                {
                    if (Statement())
                    {
                        return true;
                    }
                }
                else { return true; }
            }

            return false;
             
        }

       public bool Stmt()
        {
            if (InputStmt())
            {
                return true;
            }
            else if (OutputStmt())
            {
                return true;
            }
            else if (Declare())
            {
                return true;
            }
            else if (whileloop())
            {
                return true;
            }
            else if (forloop())
            {
                return true;
            }
          
           


            return false;
        }


        public bool InputStmt()
        {
            if (lex.tokenList[TokenIndex].value == "cin")
            {
                TokenIndex++;
                if (lex.tokenList[TokenIndex].value == ">>")
                {
                        TokenIndex++;
                        if (ReadVar())
                        {

                            if (lex.tokenList[TokenIndex].value == ";")
                            {
                                TokenIndex++;
                                return true;
                            }
                        }
                    
                }
                else
                {
                    Console.WriteLine("Error in line ( " + lex.tokenList[TokenIndex].line
                        + " ): I expected to find '>>' but No found ");
                }
            }
            return false;
        }

        public bool OutputStmt()
        {
            if (lex.tokenList[TokenIndex].value == "cout")
            {
                TokenIndex++;
                if (lex.tokenList[TokenIndex].value == "<<")
                {
                    TokenIndex++;
                    if (OutVar())
                    {

                        if (lex.tokenList[TokenIndex].value == ";")
                        {
                            TokenIndex++;
                            return true;
                        }
                    }

                }
                else
                {
                    Console.WriteLine("Error in line ( " + lex.tokenList[TokenIndex].line
                        + " ): I expected to find '<<' but No found ");
                }
            }
            return false;
        }
        public bool forloop()
        {
            if (lex.tokenList[TokenIndex].value == "for")
            {
                TokenIndex++;
                if (lex.tokenList[TokenIndex].value == "(")
                {
                    TokenIndex++;
                    if (Declare())
                    {
                        if (lex.tokenList[TokenIndex].value == ";")
                        {
                            TokenIndex++;
                            if (Compare())
                            {
                                if (lex.tokenList[TokenIndex].value == ";")
                                {
                                    TokenIndex++;
                                    if (Assing(""))
                                    {
                                        if (lex.tokenList[TokenIndex].value == ")")
                                        {
                                            TokenIndex++;
                                            if (lex.tokenList[TokenIndex].value == "{")
                                            {
                                                scope++;
                                                TokenIndex++;
                                                if (Stmt())
                                                {
                                                    if (lex.tokenList[TokenIndex].value == "}")
                                                    {
                                                        scope++;
                                                        TokenIndex++;
                                                        return true;
                                                    }
                                                }

                                            }
                                            else
                                            {
                                                Console.WriteLine("Error in line ( " + lex.tokenList[TokenIndex].line
                                                    + " ): I expected to find '{' but No found ");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error in line ( " + lex.tokenList[TokenIndex].line
                                                + " ): I expected to find ')' but No found ");
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Error in line ( " + lex.tokenList[TokenIndex].line
                                        + " ): I expected to find ';' but No found ");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error in line ( " + lex.tokenList[TokenIndex].line
                                + " ): I expected to find ';' but No found ");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Error in line ( " + lex.tokenList[TokenIndex].line
                        + " ): I expected to find '(' but No found ");
                }
            }
            return false;

        }
        public bool whileloop()
        {
            if (lex.tokenList[TokenIndex].value == "while")
            {
                TokenIndex++;
                if (lex.tokenList[TokenIndex].value == "(")
                {
                    TokenIndex++;
                    if (Compare())
                    {
                        if (lex.tokenList[TokenIndex].value == ")")
                        {
                            TokenIndex++;
                            if (lex.tokenList[TokenIndex].value == "{")
                            {
                                scope++;
                                TokenIndex++;
                                if (Statement())
                                {
                                    if (lex.tokenList[TokenIndex].value == "}")
                                    {
                                        scope--;
                                        TokenIndex++;
                                        return true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Error in line ( " + lex.tokenList[TokenIndex].line
                                            + " ): I expected to find '}' but No found ");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("Error in line ( " + lex.tokenList[TokenIndex].line
                                    + " ): I expected to find '{' but No found ");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Error in line ( " + lex.tokenList[TokenIndex].line
                                + " ): I expected to find ')' but No found ");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Error in line ( " + lex.tokenList[TokenIndex].line
                        + " ): I expected to find '(' but No found ");
                }

            }
            return false;
        }
       

       


        public bool Compare()
        {
            if (lex.tokenList[TokenIndex].value == "true" ||lex.tokenList[TokenIndex].value == "false")
            {
                TokenIndex++;
                return true;
            }
            else if(Id_num()){
                if (lex.tokenList[TokenIndex].type == tokenTypes.Comparison_operators)
                {
                    TokenIndex++;
                    if (Id_num())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool Id_num()
        {
            if(lex.tokenList[TokenIndex].type==tokenTypes.number || lex.tokenList[TokenIndex].type==tokenTypes.identifier)
            {
                TokenIndex++;
                return true;
            }
            return false;
        }

        public bool ReadVar()
        {
            if (lex.tokenList[TokenIndex].type == tokenTypes.identifier)
            {
                bool f = ST.searchName(lex.tokenList[TokenIndex].value);
                if (f == false)
                {
                    Console.WriteLine("Error in line ( " + lex.tokenList[TokenIndex].line + " ): I found undeclared variable, with the name of " + lex.tokenList[TokenIndex].value);
                    TokenIndex++;
                    // return false;
                }

                TokenIndex++;

                    if (lex.tokenList[TokenIndex].value == ">>")
                    {
                        TokenIndex++;
                        if (ReadVar())
                        {
                            return true;
                        }
                    }                  
                
                else
                {
                    return true;
                }
            }
            return false;
        }
        public bool OutVar()
        {
            if (lex.tokenList[TokenIndex].type == tokenTypes.identifier)
            {
                bool f = ST.searchName(lex.tokenList[TokenIndex].value);
                if (f == false)
                {
                    Console.WriteLine("Error in line ( " + lex.tokenList[TokenIndex].line + " ): I found undeclared variable, with the name of " + lex.tokenList[TokenIndex].value);
                    TokenIndex++;
                    // return false;
                }

                TokenIndex++;

                if (lex.tokenList[TokenIndex].value == "<<")
                {
                    TokenIndex++;
                    if (OutVar())
                    {
                        return true;
                    }
                }

                else
                {
                    return true;
                }
            }
            return false;
        }


        public bool Parameter()
        {
            if (Declare())
            {
                return true;
            }
           
            return false;
        }

        public bool Declare()
        {
            if (lex.tokenList[TokenIndex].value == ")")
            {
                return true;
            }
            string tmpType = DataType();

            if (tmpType!="")
            {
                string varName = Vars(tmpType);
                if (varName!="")
                {
                    return true;
                }
            }
           
            return false;
        }

        public string DataType()
        {
            if (lex.tokenList[TokenIndex].type == tokenTypes.datatype)
            {
                string tmp = lex.tokenList[TokenIndex].value;
                TokenIndex++;
                return tmp;
            }
            return "";
        }
        public string Vars(string type)
        {
            string varName = Var(type); 
            if (varName!="")
            {
                if (lex.tokenList[TokenIndex].value == ";")
                {
                    Symbol s = new Symbol(varName, type, scope);
                    ST.addSymbol(s);
                    if((lex.tokenList.Count-1)==TokenIndex){
                        Console.WriteLine("Error in line ( " + lex.tokenList[TokenIndex].line + " ): I expected to find } but I found " + lex.tokenList[TokenIndex].value);
                           return varName;
                    }
                    else
                    {
                        TokenIndex++;
                        return varName;
                    }
                }

                else
                {
                    if (lex.tokenList[TokenIndex].value == ",")
                    {
                        TokenIndex++;
                        varName = Var(type); 
                        if (varName != "")
                        {
                            TokenIndex++;
                            return varName;
                        }
                    }
                }

            }
            return "";
        }
        public string Var(string type)
        {

            if (lex.tokenList[TokenIndex].type == tokenTypes.identifier)
            {
                bool f = ST.searchName(lex.tokenList[TokenIndex].value);
                if (f == true)
                {
                    //scope
                    //("لقيتو");
                    TokenIndex++;
                    return "";
                }

                string var_ = lex.tokenList[TokenIndex].value;
                TokenIndex++;

                if (lex.tokenList[TokenIndex].value == "=")
                {
                    TokenIndex++;
                    if (Valuee(type))
                    {
                       // TokenIndex++;
                        return var_;
                    }
                }
                else {
                    return var_;
                }

            }
           
            return "";
        }

        public bool Assing(string type)
        {
            if (Arithmetic())
            {
                if (Assing(type))
                {
                    return true;
                }
            }
            else if (Valuee(type))
            {
                if (Assing(type))
                {
                    return true;
                }
            }
            else
            {
                if (Valuee(type))
                {
                    return true;
                }
            }

            return true;
        }
        public bool Arithmetic()
        {
            if (lex.tokenList[TokenIndex].type == tokenTypes.Arithmetic_operators)
            {
                TokenIndex++;
                return true;
            }
            return false;
        }
       
        public bool Valuee(string type)
        {
            if (lex.tokenList[TokenIndex].type == tokenTypes.identifier)
            {
                bool f = ST.searchName(lex.tokenList[TokenIndex].value);
                if (f == false)
                {
                    Console.WriteLine("Error in line ( " + lex.tokenList[TokenIndex].line + " ): I found undeclared variable, with the name of " + lex.tokenList[TokenIndex].value);
                    TokenIndex++;
                   
                }
                TokenIndex++;
            }

            if (lex.tokenList[TokenIndex].type == tokenTypes.number)
            {
                TokenIndex++;
                if (lex.Comparison(type, lex.kk.datatype))
                {
                    return true;
                }
                else
                {
                   Console.WriteLine("Error in line ( " + lex.tokenList[TokenIndex].line
                   + " ): I expected to find not number but No found ");
                    return false;
                }

            }
            return false;
        }

        public bool Exp()
        {
            if (lex.tokenList[TokenIndex].type == tokenTypes.number )
            {
                TokenIndex++;
                if (lex.tokenList[TokenIndex].value == ",")
                {
                    TokenIndex++;
                    if (Exp())
                    {
                        TokenIndex++;
                        return true;
                    }

                }
                else {
                    return true;
                }

            }
            return false;
        }

    }
}
