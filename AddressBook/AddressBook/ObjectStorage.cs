using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class SubscriberManagerData
    {
        public List<GroupAddress> GroupAddresses { get; set; }
        public List<GroupPhone> GroupPhones { get; set; }
        public List<Subscriber> Subscribers { get; set; }
        public List<Group> Groups { get; set; }
    }

    class ObjectStorage
    {
        #region Singleton
        private static readonly ObjectStorage instance = new ObjectStorage();

        public static ObjectStorage GetInstance()
        {
            return instance;
        }

        private ObjectStorage()
        {
            _groupAddresses = new ContainerGroupAddress();
            _groupPhones = new ContainerGroupPhone();
            _subscribers = new ContainerSubscriber();
            _groups = new ContainerGroup();

            _groupAddresses.Add(GroupAddress.Create("Домашний").Value);
            _groupAddresses.Add(GroupAddress.Create("Рабочий").Value);

            _groupPhones.Add(GroupPhone.Create("Домашний").Value);
            _groupPhones.Add(GroupPhone.Create("Рабочий").Value);
            _groupPhones.Add(GroupPhone.Create("Мобильный").Value);

            _groups.Add(Group.Create("Семья").Value);
            _groups.Add(Group.Create("Работа").Value);
            _groups.Add(Group.Create("Друзья").Value);
            _groups.Add(Group.Create("Общие").Value);

            _subscribers.Add(
                Subscriber.Create("Alexander", "Velichko", "Alexandrovich", group: _groups[3],
                    addresses: new ContainerAddress(new List<Address>() {Address.Create("Marks", _groupAddresses[0]).Value, Address.Create("Home", _groupAddresses[1]).Value })).Value);
        }

        #endregion

        private ContainerGroupAddress _groupAddresses { get; set; }
        private ContainerGroupPhone _groupPhones { get; set; }
        private ContainerSubscriber _subscribers { get; set; }
        private ContainerGroup _groups { get; set; }

        public void SetData(SubscriberManagerData data)
        {
            if (data != null)
            {
                _groupAddresses.SetList(data.GroupAddresses);
                _groupPhones.SetList(data.GroupPhones);
                _subscribers.SetList(data.Subscribers);
                _groups.SetList(data.Groups);
            }
        }

        public ContainerGroupAddress GetGroupAddress() => _groupAddresses;
        public ContainerGroupPhone GetGroupPhone() => _groupPhones;
        public ContainerSubscriber GetSubscriber() => _subscribers;
        public ContainerGroup GetGroup() => _groups;

    }
}
