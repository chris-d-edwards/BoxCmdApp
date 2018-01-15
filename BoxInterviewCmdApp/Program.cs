using System;
using System.Dynamic;
using Newtonsoft.Json;
using RestSharp;


namespace BoxInterviewCmdApp
{

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello Box!");
            Console.WriteLine("This is the code submission for the interview test!");

            BoxAppLibrary boxLib = new BoxAppLibrary();

            if (args.Length == 0)
            {
                Console.WriteLine("Please provide the Authentication Key:");
                string key = Console.ReadLine();
                boxLib.AuthKey = string.Format("Bearer {0}", key) ;
                //return;
            }
            if (args.Length > 1)
            {
                Console.WriteLine("Please only provide the Authentication Key as a startup argument.");
                return;
            }

            if (args.Length == 1)
            {
                Console.WriteLine("Please only provide the Authentication Key as a startup argument.");
                boxLib.AuthKey = string.Format("Bearer {0}", args[0]);
            }

            bool run = true;
            while (run)
            {
                try
                {

                    boxLib.getStreamNextPosition();
                    boxLib.getStreamEventURL();

                    while (boxLib.getLongPoll())
                    {
                        boxLib.getEventEntry();
                    }

                }
                catch(Exception e)
                {
                    Console.WriteLine("There was an Error, exiting out");
                    break;
                }


            }



        }




    }


}
