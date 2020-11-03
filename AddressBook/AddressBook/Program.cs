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
            User storage = User.Register("123", "123").Value;

            storage.AddGroupPhone(GroupPhone.Create("Домашний").Value);
            storage.AddGroupPhone(GroupPhone.Create("Рабочий").Value);
            storage.AddGroupPhone(GroupPhone.Create("Мобильный").Value);

            storage.AddGroupAddress(GroupAddress.Create("Дом").Value);
            storage.AddGroupAddress(GroupAddress.Create("Работа").Value);

            storage.AddGroup(Group.Create("Семья").Value);
            storage.AddGroup(Group.Create("Работа").Value);
            storage.AddGroup(Group.Create("Друзья").Value);
            storage.AddGroup(Group.Create("Общие").Value);

            storage.AddSubscriber(Subscriber.Create("Alexander").Value);
            storage.Subscriber.ElementAtOrDefault(0).AddAddress(Address.Create("tky", GroupAddress.Create("dd").Value).Value);
            storage.Subscriber.ElementAtOrDefault(0).AddGroup(storage.Group.ElementAtOrDefault(3));
            storage.Subscriber.ElementAtOrDefault(0).AddGroup(storage.Group.ElementAtOrDefault(2));

            var tmp = Phone.Create("2222222", storage.GroupPhone.ElementAtOrDefault(0)).Value;
            storage.Subscriber.ElementAtOrDefault(0).AddPhone(tmp);

            Console.WriteLine("||GroupAddress||");
            foreach (var item in storage.GroupAddress)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n");

            Console.WriteLine("||GroupPhone||");
            foreach (var item in storage.GroupPhone)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n");

            Console.WriteLine("||Group||");
            foreach (var item in storage.Group)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("\n");

            Console.WriteLine("||Subscriber||");
            foreach (var item in storage.Subscriber)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
