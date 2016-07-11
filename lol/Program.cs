using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task01;

namespace lol
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] b = { 1.2, 1.5, 0 };
            double[] g = { 1.2, 1.7,9};
            Polinome a = new Polinome(b);
            Polinome c = new Polinome(g);
            Polinome f = a * c;
            Console.WriteLine(f.ToString());
            Console.ReadKey();
        }
    }
}
