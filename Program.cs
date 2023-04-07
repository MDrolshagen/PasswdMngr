using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace PasswdMngr // Note: RunController hinzufügen, Run Methode auslagern
{
    internal class Program
    {
        public static string? profile;
        public static string? platf;

        public static ConsoleKeyInfo esc;
        static void Main(string[] args)
        {
            Start();
        }


       public static void Start() //Überschrift und Pofileingabe
        {
            do
            {
                
            Console.WriteLine("PaswdM");
            Console.WriteLine("==========================");
            Console.Write(">> Profile: ");
            if(esc.Key == ConsoleKey.Escape){return;};
            profile = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Selected Profile: [" + profile + "]");
            profile = profile + "#";
            Run();

            } while (true);
        }

        static void Run()
        {
            do
            {
                
            Console.Write("Plattform: ");
            esc = Console.ReadKey();
            if(esc.Key == ConsoleKey.Escape){break;};
            platf = Console.ReadLine().ToString();
            string toHash = platf + profile;
            Console.WriteLine(sha256(toHash));

            } while (true);

            Console.Clear();
        }

        static string sha256(string hashString)
        {
            var crypt = new SHA256Managed();
            var hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(hashString));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }


    }
}