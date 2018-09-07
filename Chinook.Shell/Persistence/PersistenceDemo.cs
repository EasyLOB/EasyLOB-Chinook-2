using System;

namespace Chinook.Shell
{
    partial class Program
    {
        private static void PersistenceDemo()
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Persistence Demo\n");
                Console.WriteLine("<0> RETURN");
                Console.WriteLine("<1> Chinook Demo");
                Console.WriteLine("<2> Chinook Album Demo");
                Console.WriteLine("<3> Chinook CRUD Demo");
                Console.WriteLine("<4> Chinook LINQ Demo");
                Console.WriteLine("<5> Chinook LINQ Join Demo, does not work with MongoDB,RavenDB and Redis, because there are no server-side Joins");
                Console.WriteLine("<6> Chinook LINQ Selector Demo");
                Console.WriteLine("<7> Chinook GetById() Demo");
                Console.WriteLine("<8> Chinook Transaction Commit Demo (*)");
                Console.WriteLine("<9> Chinook Transaction Rollback Demo (*)");
                Console.WriteLine("<A> Chinook LINQ Entity Framework Demo");
                Console.WriteLine("<B> Chinook LINQ Entity Framework UnitOfWork Demo");
                Console.WriteLine("<C> Chinook LINQ NHibernate Demo");
                Console.WriteLine("<D> Chinook LINQ NHibernate Framework UnitOfWork Demo");
                Console.WriteLine("\n(*) NoSQL Databases MongoDb, RavenDB and Redis DO NOT SUPPORT TRANSACTION");
                Console.Write("\nChoose an option... ");

                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();

                switch (key.KeyChar) // <ENTER> = '\r'
                {
                    case ('0'):
                        exit = true;
                        break;

                    case ('1'):
                        PersistenceChinookDemo();
                        break;

                    case ('2'):
                        PersistenceChinookAlbumDemo();
                        break;

                    case ('3'):
                        PersistenceChinookCRUDDemo();
                        break;

                    case ('4'):
                        PersistenceChinookLINQDemo();
                        break;

                    case ('5'):
                        PersistenceChinookLINQJoinDemo();
                        break;

                    case ('6'):
                        PersistenceChinookLINQSelectorDemo();
                        break;

                    case ('7'):
                        PersistenceChinookGetByIdDemo();
                        break;

                    case ('8'):
                        PersistenceChinookTransactionDemo();
                        break;

                    case ('9'):
                        PersistenceChinookTransactionDemo(false);
                        break;

                    case ('A'):
                        PersistenceChinookLINQEntityFrameworkDemo();
                        break;

                    case ('B'):
                        PersistenceChinookLINQEntityFrameworkUnitOfWorkDemo();
                        break;

                    case ('C'):
                        PersistenceChinookLINQNHibernateDemo();
                        break;

                    case ('D'):
                        PersistenceChinookLINQNHibernateUnitOfWorkDemo();
                        break;
                }

                if (!exit)
                {
                    Console.Write("\nPress <KEY> to continue... ");
                    Console.ReadKey();
                }
            }
        }
    }
}