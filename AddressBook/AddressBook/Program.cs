using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectStorage storage = ObjectStorage.GetInstance();

            Console.WriteLine("||GroupAddress||");
            foreach (var item in storage.GetGroupAddress())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n");

            Console.WriteLine("||GroupPhone||");
            foreach (var item in storage.GetGroupPhone())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n");

            Console.WriteLine("||Group||");
            foreach (var item in storage.GetGroup())
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n");

            Console.WriteLine("||Subscriber||");
            foreach (var item in storage.GetSubscriber())
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
