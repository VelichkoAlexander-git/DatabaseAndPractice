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
            throw new NotImplementedException();
        }

        [WebInvoke(Method = "POST", UriTemplate = "User/{id}/Add")]
        public bool AddSubscriber(int UserId, string firstName, string middleName, string lastName, DateTime? dateOfBirth, Sex sex, string mail)
        {
            throw new NotImplementedException();
        }

        [WebInvoke(Method = "POST", UriTemplate = "User/{id}/Delete")]
        public bool DeleteSubscriber(int UserId, int id)
        {
            throw new NotImplementedException();
        }

        [WebInvoke(Method = "GET", UriTemplate = "User/{id}")]
        public SubscriberDto GetSubscriber(int UserId, int id)
        {
            throw new NotImplementedException();
        }
    }
}
