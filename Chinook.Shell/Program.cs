using EasyLOB;
using Hangfire;
using System;
using Unity;

namespace Chinook.Shell
{
    partial class Program
    {
        private static void Main(string[] args)
        {
            bool exit = false;

            // Unity

            AppDIUnityHelper.Setup(new UnityContainer());

            // Hangfire

            //GlobalConfiguration.Configuration.UseSqlServerStorage("hangfire");

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Chinook Shell\n");
                Console.WriteLine("<0> EXIT");
                Console.WriteLine("<1> Chinook Application Demo");
                Console.WriteLine("<2> Chinook Persistence Demo");
                Console.WriteLine("<3> Chinook RESET");
                //Console.WriteLine("<4> Hangfire");
                Console.Write("\nChoose an option... ");

                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                switch (key.KeyChar) // <ENTER> = '\r'
                {
                    case ('0'):
                        exit = true;
                        break;

                    case ('1'):
                        ApplicationDemo();
                        break;

                    case ('2'):
                        PersistenceDemo();
                        break;

                    case ('3'):
                        ApplicationChinookReset();
                        break;

                    //case ('4'):
                    //    HangfireDemo();
                    //    break;
                }

                if (!exit && "345".IndexOf(key.KeyChar) >= 0)
                {
                    Console.Write("\nPress <KEY> to continue... ");
                    Console.ReadKey();
                }
            }
        }
    }
}