using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace lexical
{
    class Program
    {
        static void Main(string[] args)
        {

            String text = File.ReadAllText("C:\\Users\\lenovo\\Desktop\\cdproject\\cdproject\\text.txt");
            Parser parser = new Parser(text);


        }
    }
}


















//  List<string> symbo=new List<string>();
//symbo.
//Parser parser = new Parser("public class mazen { public int mazen (int x ; ) { cout << x << y; cout << p << n; } } ");
//Parser parser = new Parser("public class mazen { public int mazen (int x ; ) { cin >> x >> y; cin >> p >> n; } } ");
//Lexical lex = new Lexical("(int x; )");
//data_type kk = new data_type();
//kk.print_data();
//data_type ltt = new data_type();
//tt.print_data();
//Lexical ll = new Lexical();
// Console.WriteLine(lex.tokenList.Count);