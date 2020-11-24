using AddressBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AddressBookService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class AddressBookServiceContract : IAddressBookServiceContract
    {

        #region User
        //[WebInvoke(Method = "POST", UriTemplate = "User/Add/{id}")]
        public bool AddUser(string login, string password)
        {
            var newUser = User.Register(login, password);
            if (newUser != null)
            {
                var context = new AddressBookContext();
                context.Users.Add(newUser.Value);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        [WebInvoke(Method = "POST", UriTemplate = "User/Delete/{id}")]
        public bool DeleteUser(int id)
        {
            var context = new AddressBookContext();
            var user = context.GetUser(id);
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
                return true;
            }

            return false;
        }
        #endregion

        #region Subscriber
        [WebInvoke(Method = "POST", UriTemplate = "User/{id}/AddSubscriber")]
        public bool AddSubscriber(int UserId, string firstName, string middleName, string lastName, DateTime? dateOfBirth, byte[] photo, Sex sex, string mail)
        {
            var context = new AddressBookContext();
            var user = context.GetUser(UserId);
            if (user != null)
            {               
                user.AddSubscriber(firstName, middleName, lastName, dateOfBirth, photo, sex, mail);
                context.SaveChanges();
                return true;
            }

            return false;
        }

        [WebInvoke(Method = "POST", UriTemplate = "User/{UserId}/DeleteSubscriber/{id}")]
        public bool DeleteSubscriber(int UserId, int id)
        {
            var context = new AddressBookContext();
            var user = context.GetUser(UserId);
            if (user != null)
            {
                var subscriber = user.Subscribers.ToList().Find(s => s.Id == id);
                if (subscriber != null)
                user.RemoveSubscriber(subscriber);
                context.SaveChanges();
                return true;
            }

            return false;
        }

        [WebInvoke(Method = "GET", UriTemplate = "User/{UserId}/Subscriber/{id}")]
        public SubscriberDto GetSubscriber(int UserId, int id)
        {
            var context = new AddressBookContext();
            var user = context.GetUser(UserId);
            if (user != null)
            {
                var subscriber = user.Subscribers.ToList().Find(s => s.Id == id);
                if (subscriber != null)
                {
                    return SubscriberDto.Get(subscriber);
                }
            }
            return null;
        }
        #endregion

        #region GroupAddress
        [WebInvoke(Method = "POST", UriTemplate = "User/{Userid}/AddGroupAddress")]
        public bool AddGroupAddress(int UserId, string name)
        {
            var context = new AddressBookContext();
            var user = context.GetUser(UserId);
            if (user != null)
            {
                user.AddGroupAddress(name);
                context.SaveChanges();
                return true;
            }

            return false;
        }

        [WebInvoke(Method = "POST", UriTemplate = "User/{UserId}/DeleteGroupAddress/{id}")]
        public bool DeleteGroupAddress(int UserId, int id)
        {
            var context = new AddressBookContext();
            var user = context.GetUser(UserId);
            if (user != null)
            {
                var groupAddress = user.GroupAddresses.ToList().Find(s => s.Id == id);
                if (groupAddress != null)
                   user.RemoveGroupAddress(groupAddress);
                context.SaveChanges();
                return true;
            }

            return false;
        }

        [WebInvoke(Method = "GET", UriTemplate = "User/{UserId}/GroupAddress/{id}")]
        public GroupAddressDto GetGroupAddress(int UserId, int id)
        {
            var context = new AddressBookContext();
            var user = context.GetUser(UserId);
            if (user != null)
            {
                var groupAddress = user.GroupAddresses.ToList().Find(s => s.Id == id);
                if (groupAddress != null)
                {
                    return GroupAddressDto.Get(groupAddress);
                }
            }
            return null;
        }
        #endregion

        #region Group
        [WebInvoke(Method = "POST", UriTemplate = "User/{Userid}/AddGroup")]
        public bool AddGroup(int UserId, string name)
        {
            var context = new AddressBookContext();
            var user = context.GetUser(UserId);
            if (user != null)
            {
                user.AddGroup(name);
                context.SaveChanges();
                return true;
            }

            return false;
        }

        [WebInvoke(Method = "POST", UriTemplate = "User/{UserId}/DeleteGroup/{id}")]
        public bool DeleteGroup(int UserId, int id)
        {
            var context = new AddressBookContext();
            var user = context.GetUser(UserId);
            if (user != null)
            {
                var group = user.Groups.ToList().Find(s => s.Id == id);
                if (group != null)
                    user.RemoveGroup(group);
                context.SaveChanges();
                return true;
            }

            return false;
        }

        [WebInvoke(Method = "GET", UriTemplate = "User/{UserId}/Group/{id}")]
        public GroupDto GetGroup(int UserId, int id)
        {
            var context = new AddressBookContext();
            var user = context.GetUser(UserId);
            if (user != null)
            {
                var group = user.Groups.ToList().Find(s => s.Id == id);
                if (group != null)
                {
                    return GroupDto.Get(group);
                }
            }
            return null;
        }
        #endregion

        #region GroupPhone
        [WebInvoke(Method = "POST", UriTemplate = "User/{Userid}/AddGroupPhone")]
        public bool AddGroupPhone(int UserId, string name)
        {
            var context = new AddressBookContext();
            var user = context.GetUser(UserId);
            if (user != null)
            {
                user.AddGroupPhone(name);
                context.SaveChanges();
                return true;
            }

            return false;
        }

        [WebInvoke(Method = "POST", UriTemplate = "User/{UserId}/DeleteGroupPhone/{id}")]
        public bool DeleteGroupPhone(int UserId, int id)
        {
            var context = new AddressBookContext();
            var user = context.GetUser(UserId);
            if (user != null)
            {
                var groupPhone = user.GroupPhones.ToList().Find(s => s.Id == id);
                if (groupPhone != null)
                {
                    user.RemoveGroupPhone(groupPhone);
                    context.SaveChanges();
                    return true;
                }

            }

            return false;
        }

        [WebInvoke(Method = "GET", UriTemplate = "User/{UserId}/GroupPhone/{id}")]
        public GroupPhoneDto GetGroupPhone(int UserId, int id)
        {
            var context = new AddressBookContext();
            var user = context.GetUser(UserId);
            if (user != null)
            {
                var groupPhone = user.GroupPhones.ToList().Find(s => s.Id == id);
                if (groupPhone != null)
                {
                    return GroupPhoneDto.Get(groupPhone);
                }
            }
            return null;
        }
        #endregion
    }
}
