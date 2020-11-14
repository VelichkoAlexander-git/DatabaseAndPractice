using AddressBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AddressBookService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "Service1" в коде и файле конфигурации.
    public class AddressBookServiceContract : IAddressBookServiceContract
    {
        public bool AddCustomer(string firstName, string middleName, string lastName, DateTime? dateOfBirth, Sex sex, string mail)
        {
            throw new NotImplementedException();
        }

        public bool DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public SubscriberDto GetSubscriber(int id)
        {
            throw new NotImplementedException();
        }
    }
}
