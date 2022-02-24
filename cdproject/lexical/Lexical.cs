using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lexical
{
    class Lexical
    {
        public List<Token> tokenList;
        public String code;
        public int lineNum;
        public data_type kk = new data_type();

        public Lexical(string code)
        {
            lineNum = 1;
            this.code = code;
            tokenList = new List<Token>();
            generateTokens();
            for(int i=0;i<tokenList.Count;i++)
            {
                tokenList[i].print();
            }
        }
       public Lexical() { }

        public void generateTokens()
        {
            for(int i=0;i<code.Length;i++)
            {

                int index = i;
                char ch = code[index];


                // reading a io z and A to Z with error identifier
                if (ch >= 'a' && ch <= 'z' || (ch >= 'A' && ch <= 'Z'))
                {
                    string tmp = "";
                    while ((ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z') || (ch >= '0' && ch <= '9'))
                    {
                        tmp += ch;
                        index++;
                        if(index>=code.Length)
                        {
                            break;
                        }
                        ch = code[index];
                    }
  
                    if (Comparison(tmp,kk.datatype) == true)
                    {
                        Token t = new Token(tokenTypes.datatype, tmp, lineNum);
                        tokenList.Add(t);
                        i = index - 1;
                    }
                    else if (Comparison(tmp, kk.modifier) == true)
                    {
                        Token t = new Token(tokenTypes.modifier, tmp, lineNum);
                        tokenList.Add(t);
                        i = index - 1;
                    }
                    else if (Comparison(tmp,kk.keyword)==true){
                        Token t = new Token(tokenTypes.keyword, tmp, lineNum);
                        tokenList.Add(t);
                        i = index - 1;
                    
                    }
                     else
                    {
                        Token t = new Token(tokenTypes.identifier, tmp, lineNum);
                        tokenList.Add(t);
                        i = index - 1;
                     
                    }      
                }

                
                 if(ch>='0' && ch<='9')
                {

                    int coun = 0;
                    string tmp = "";
                    while ((ch >= '0' && ch <= '9') || (ch == '.') || (ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z'))
                    {
                        tmp += ch;
                        index++;
                        if (index >= code.Length)
                        {
                            break;
                        }
                        ch = code[index];
                        if (ch == '.')
                        {
                            coun += 1;
                        }
                    }
                    // check if tmp exist in keyword list
                    if (coun > 1 || Comparison_eror_number(tmp)==tokenTypes.error)
                    {
                        Token t = new Token(tokenTypes.error, tmp, lineNum);
                        tokenList.Add(t);
                        i = index - 1;
                    }
                    else
                    {
                        Token t = new Token(tokenTypes.number, tmp, lineNum);
                        tokenList.Add(t);
                        i = index - 1;

                    }

                  //
                }


                //reading logical Operators
                 if (char_comparison(ch, kk.logicalOperators))
                {
                    string tmp = "";
                    while (char_comparison(ch, kk.logicalOperators) == true)
                    {
                        tmp += ch;
                        index++;
                        if (index >= code.Length)
                        {
                            break;
                        }
                        ch = code[index];
                    }
                    if (Comparison(tmp, kk.logicalOperators))
                    {
                        Token t = new Token(tokenTypes.Logical_operators, tmp, lineNum);
                        tokenList.Add(t);
                        i = index - 1;
                    }
                    else
                    {
                        i = index - 1;
                        ch = code[i];
                        index = i;
                    }
                }

                //reading bitwise Operators
                  if (char_comparison(ch, kk.bitwiseOperators))
                    {
                        string tmp = "";
                        while (char_comparison(ch, kk.bitwiseOperators) == true)
                        {
                            tmp += ch;
                            index++;
                            if (index >= code.Length)
                            {
                                break;
                            }
                            ch = code[index];
                        }
                        if (Comparison(tmp, kk.bitwiseOperators))
                        {
                            Token t = new Token(tokenTypes.Bitwise_operators, tmp, lineNum);
                            tokenList.Add(t);
                            i = index - 1;
                        }
                        else
                        {
                            i = index - 1;
                            ch = code[i];
                            index = i;
                        }
                    }

                    //reading comparison Operators
                 if (char_comparison(ch, kk.comparisonOperators))
                 {
                     string tmp = "";
                     while (ch !=' ')
                     {
                         tmp += ch;
                         index++;
                         if (index >= code.Length)
                         {
                             break;
                         }
                         ch = code[index];
                     }

                     if (Comparison(tmp, kk.comparisonOperators))
                     {
                         Token t = new Token(tokenTypes.Comparison_operators, tmp, lineNum);
                         tokenList.Add(t);
                         i = index - 1;
                     }
                     else
                     {
                         i = index - 1;
                         ch = code[i];
                         index = i;
                     }

                 }

                //reading arithmetic operators
                 if (char_comparison(ch,kk.arithmeticOperators))
                    {
                        string tmp = "";
                        while (char_comparison(ch, kk.arithmeticOperators)==true)
                        {
                            tmp += ch;
                            index++;
                            if (index >= code.Length)
                            {
                                break;
                            }
                            ch = code[index];
                        }
                        if (Comparison(tmp, kk.arithmeticOperators))
                        {
                            Token t = new Token(tokenTypes.Arithmetic_operators, tmp, lineNum);
                            tokenList.Add(t);
                            i = index - 1;
                        }
                        else
                        {
                            i = index - 1;
                            ch = code[i];
                            index = i;
                        }
                    }

                //reading special
                     if (char_comparison(ch, kk.special))
                     {
                         string tmp = "";
                         while (char_comparison(ch, kk.special) == true)
                         {
                             tmp += ch;
                             index++;
                             if (index >= code.Length)
                             {
                                 break;
                             }
                             ch = code[index];
                         }
                         if (Comparison(tmp, kk.special))
                         {
                             Token t = new Token(tokenTypes.Special_in, tmp, lineNum);
                             tokenList.Add(t);
                             i = index - 1;
                         }
                         else
                         {
                             i = index - 1;
                             ch = code[i];
                             index = i;
                         }
                     }


                     if (char_comparison(ch, kk.symbol))
                     {
                         string tmp = "";
                         while (char_comparison(ch, kk.symbol) == true)
                         {
                             tmp += ch;
                             index++;
                             if (index >= code.Length)
                             {
                                 break;
                             }
                             ch = code[index];
                         }
                         if (Comparison(tmp, kk.symbol))
                         {
                             Token t = new Token(tokenTypes.symbol, tmp, lineNum);
                             tokenList.Add(t);
                             i = index - 1;

                         }
                         else
                         {
                             i = index - 1;
                             ch = code[i];
                             index = i;
                         }
                     }

                     if (ch == '"')
                     {
                         ch = code[index++];
                         string tmp = "";
                         while (ch != '"')
                         {
                             tmp += ch;
                             index++;
                             if (index >= code.Length)
                             {
                                 break;
                             }
                             ch = code[index];
                         }
                         // check if tmp exist in keyword list
                         Token t = new Token(tokenTypes.stringg, tmp, lineNum);
                         tokenList.Add(t);
                        i = index ;
                     }         
                     if (ch == '\n')
                     {
                         lineNum++;
                     }
                  }

            }
        //function Comparison tmp with arry
        public bool Comparison(string da , List<string> arry)
        {
            for (int i = 0; i < arry.Count; i++)
            {
                if (arry[i] == da)
                {
                    return true;
                }
            }
            return false;
        }
        //function check from number if wiht Characters
        public tokenTypes Comparison_eror_number(string da)
        {
            for (int i = 0; i < da.Length; i++)
            {
                char c = da[i];
                if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
                {
                    return tokenTypes.error;
                    break;
                }
            }
            return tokenTypes.number;
        }
        //function 
        public bool char_comparison(char c , List<string> jj)
        {
            for (int i = 0; i < jj.Count; i++)
            {
                if (jj[i][0] == c)
                {
                    return true;
                }
            }
            return false;
        }

        }
}


