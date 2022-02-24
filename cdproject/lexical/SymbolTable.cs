using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lexical
{
    class SymbolTable
    {
        private List<Symbol> symbolList;

        public SymbolTable()
        {
            symbolList = new List<Symbol>();
        }

        public void addSymbol(Symbol s)
        {
            symbolList.Add(s);
        }

        public void printTable()
        {
            for (int i = 0; i < symbolList.Count; i++)
            {
                symbolList[i].print();
            }
        }

        public bool searchName(string str)
        {
            for (int i = symbolList.Count - 1; i >= 0; i--)
            {
                if (symbolList[i].name == str)
                {
                    return true;
                }
            }
            return false;
        }

        public Symbol getSybmolebyName(string str)
        {
            for (int i = symbolList.Count - 1; i >= 0; i--)
            {
                if (symbolList[i].name == str)
                {
                    return symbolList[i];
                }
            }
            return null;
        }
        public void deleteSymbolbyScope(int scope)
        {
            for (int i = symbolList.Count - 1; i >= 0; i--)
            {
                if (symbolList[i].scope == scope)
                {
                    symbolList.RemoveAt(i);
                }
            }
        }
    }
}
