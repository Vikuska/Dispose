using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace sql
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 1000; i++)
            {
                using (var state = new DatabaseState())
                //var state = new DatabaseState();
                {
                    Console.WriteLine(state.GetDate().ToString());
                }
            }
            Console.ReadLine();
        }
    }
}
