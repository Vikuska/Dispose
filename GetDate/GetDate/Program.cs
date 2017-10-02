using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDate
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("'g' to Get Date; 'gc' to Garbage Collect; 'x' to Exit");
            var command = "";
            while (command != "x")
            {
                command = Console.ReadLine();
                switch (command)
                {
                    case "g":
                        GetDate();
                        break;

                    case "gc":
                        GC.Collect();
                        break;
                }
            }
        }

        private static void GetDate()
        {
            //using (var databaseState = new DatabaseState())
            //{
            //    Console.WriteLine(databaseState.GetDate());
            //}

            //var databaseState = new DatabaseState();
            //Console.WriteLine(databaseState.GetDate());


            using (var databaseState = new UnmanagedDatabaseState())
            {
                Console.WriteLine(databaseState.GetDate());
            }

            //var databaseState = new UnmanagedDatabaseState();
            //Console.WriteLine(databaseState.GetDate());
        }
    }
}
