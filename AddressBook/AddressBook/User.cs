using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class User
    {
        #region User
        private static string _login;
        private static string _password;
        protected User(string login, string password)
        {
            _login = login;
            _password = password;

            SubscriberInternal = new List<Subscriber>();
            GroupPhoneInternal = new List<GroupPhone>();
            GroupAddressInternal = new List<GroupAddress>();
            GroupInternal = new List<Group>();
        }
        public static Result<User> Register(string login, string password)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(login)) { errors.Add("Логин не может быть пустым"); }
            if (string.IsNullOrEmpty(password)) { errors.Add("Пароль не может быть пустым"); }

            if (errors.Any())
            {
                return Result<User>.Fail(errors);
            }
            return Result<User>.Success(new User(login, password));
        }
        #endregion

        #region Subscriber
        protected List<Subscriber> SubscriberInternal { get; set; }
        public IEnumerable<Subscriber> Subscriber => SubscriberInternal;
        public void AddSubscriber(Subscriber subscriber)
        {

            if (!SubscriberInternal.Contains(subscriber))
                if (!SubscriberInternal.Any(i => i.Name == subscriber.Name))
                    SubscriberInternal.Add(subscriber);
        }
        public void RemoveSubscriberAt(int index)
        {
            SubscriberInternal.RemoveAt(index);
        }
        public void RemoveSubscriber(Subscriber subscriber)
        {
            SubscriberInternal.Remove(subscriber);
        }
        #endregion

        #region GroupAddress
        protected List<GroupAddress> GroupAddressInternal { get; set; }
        public IEnumerable<GroupAddress> GroupAddress => GroupAddressInternal;
        public void AddGroupAddress(GroupAddress groupAddress)
        {
            if (!GroupAddressInternal.Contains(groupAddress))
                if (!GroupAddressInternal.Any(i => i.Name == groupAddress.Name))
                    GroupAddressInternal.Add(groupAddress);
        }
        public void RemoveGroupAddressAt(int index)
        {
            GroupAddressInternal.RemoveAt(index);
        }
        public void RemoveGroupAddress(GroupAddress groupAddress)
        {
            GroupAddressInternal.Remove(groupAddress);
        }
        #endregion

        #region GroupPhone
        protected List<GroupPhone> GroupPhoneInternal { get; set; }
        public IEnumerable<GroupPhone> GroupPhone => GroupPhoneInternal;
        public void AddGroupPhone(GroupPhone groupPhone)
        {
            if (!GroupPhoneInternal.Contains(groupPhone))
                if (!GroupPhoneInternal.Any(i => i.Name == groupPhone.Name))
                    GroupPhoneInternal.Add(groupPhone);
        }
        public void RemoveGroupPhoneAt(int index)
        {
            GroupPhoneInternal.RemoveAt(index);
        }
        public void RemoveGroupPhone(GroupPhone groupPhone)
        {
            GroupPhoneInternal.Remove(groupPhone);
        }
        #endregion

        #region Group
        protected List<Group> GroupInternal { get; set; }
        public IEnumerable<Group> Group => GroupInternal;
        public void AddGroup(Group group)
        {

            if (!GroupInternal.Contains(group))
                if (!GroupInternal.Any(i => i.Name == group.Name))
                    GroupInternal.Add(group);

        }
        public void RemoveGroupAt(int index)
        {
            GroupInternal.RemoveAt(index);
        }
        public void RemoveGroup(Group group)
        {
            GroupInternal.Remove(group);
        }
        #endregion
    }
}
