using AddressBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace AddressBookService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IService1" в коде и файле конфигурации.
    [ServiceContract]
    public interface IAddressBookServiceContract
    {
        [OperationContract]
        bool AddCustomer(string firstName, string middleName, string lastName, DateTime? dateOfBirth, Sex sex, string mail);

        [OperationContract]
        SubscriberDto GetSubscriber(int id);

        [OperationContract]
        bool DeleteCustomer(int id);




        // TODO: Добавьте здесь операции служб
    }

    // Используйте контракт данных, как показано на следующем примере, чтобы добавить сложные типы к сервисным операциям.
    // В проект можно добавлять XSD-файлы. После построения проекта вы можете напрямую использовать в нем определенные типы данных с пространством имен "AddressBookService.ContractType".

    [DataContract]
    public class PhoneDto
    {
        [DataMember]
        public int Id { get; protected set; }

        [DataMember]
        public string Number { get; protected set; }

        public static PhoneDto Get(Phone phone)
        {
            return new PhoneDto()
            {
                Id = phone.Id,
                Number = phone.Number
            };
        }
    }

    [DataContract]
    public class GroupDto
    {
        [DataMember]
        public int Id { get; protected set; }

        [DataMember]
        public string Name { get; protected set; }

        public static GroupDto Get(Group group)
        {
            return new GroupDto()
            {
                Id = group.Id,
                Name = group.Name
            };
        }
    }

    [DataContract]
    public class AddressDto
    {
        [DataMember]
        public int Id { get; protected set; }

        [DataMember]
        public string Information { get; protected set; }

        public static AddressDto Get(Address address)
        {
            return new AddressDto()
            {
                Id = address.Id,
                Information = address.Information
            };
        }
    }

    [DataContract]
    public class SubscriberDto
    {
        [DataMember]
        public int Id { get; protected set; }

        [DataMember]
        public string FirstName { get; protected set; }

        [DataMember]
        public string MiddleName { get; protected set; }

        [DataMember]
        public string LastName { get; protected set; }

        [DataMember]
        public Sex Sex { get; protected set; }

        [DataMember]
        public DateTime? DateOfBirth { get; protected set; }

        [DataMember]
        public string Mail { get; protected set; }

        [DataMember]
        public IEnumerable<Phone> Phones { get; set; }

        [DataMember]
        public IEnumerable<Address> Addresses { get; set; }

        [DataMember]
        public IEnumerable<Group> Groups { get; set; }

        public static SubscriberDto Get(Subscriber subscriber)
        {
            return new SubscriberDto()
            {
                Id = subscriber.Id,
                FirstName = subscriber.FirstName,
                MiddleName = subscriber.MiddleName,
                LastName = subscriber.LastName,
                DateOfBirth = subscriber.DateOfBirth,
                Sex = subscriber.Sex,
                Mail = subscriber.Mail,
                Addresses = (IEnumerable<Address>)subscriber.Addresses.Select(a => AddressDto.Get(a)).ToList(),
                Groups = (IEnumerable<Group>)subscriber.Groups.Select(g => GroupDto.Get(g)).ToList(),
                Phones = (IEnumerable<Phone>)subscriber.Phones.Select(g => PhoneDto.Get(g)).ToList()
            };
        }
    }
}
