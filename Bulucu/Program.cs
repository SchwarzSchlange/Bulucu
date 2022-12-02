using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulucu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Initilaze();

            Console.WriteLine("Loading data...");
            bEngine.LoadData("data_tr.txt");
            Console.WriteLine("Data succesfully loaded...");

            while(true)
            { 
                Console.Write("[Text 1] >>> ");
                string firstText = Console.ReadLine();
            
                bText ft = new bText(firstText);

                var Response = bEngine.FindData(ft);
                if (Response == null) { continue; }
                Console.WriteLine($"[Total '{Response.Count}' variant found.]");

                Console.WriteLine(new String('=', 40));
                foreach(var resp in Response.Skip(Math.Max(0, Response.Count() - 10)))
                {
                    Console.WriteLine($"Yoksa '{resp.Compered.Value}' demek mi istedin?");
                }
                Console.WriteLine(new String('=', 40));

                Console.ReadKey();
                Console.Clear();
            }

        }

        private static void Initilaze()
        {
            Console.Title = "Bulucu";
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetWindowSize(80, 15);
        }
    }
}
