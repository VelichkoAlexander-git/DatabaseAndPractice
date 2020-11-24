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
        #region User
        [OperationContract]
        bool AddUser(string login, string password);

        [OperationContract]
        bool DeleteUser(int id);
        #endregion

        #region Subscriber
        [OperationContract]
        bool AddSubscriber(int UserId, string firstName, string middleName, string lastName, DateTime? dateOfBirth, byte[] photo, Sex sex, string mail);

        [OperationContract]
        bool DeleteSubscriber(int UserId, int id);

        [OperationContract]
        SubscriberDto GetSubscriber(int UserId, int id);
        #endregion

        #region GroupAddress
        [OperationContract]
        bool AddGroupAddress(int UserId, string name);

        [OperationContract]
        bool DeleteGroupAddress(int UserId, int id);

        [OperationContract]
        GroupAddressDto GetGroupAddress(int UserId, int id);
        #endregion

        #region Group
        [OperationContract]
        bool AddGroup(int UserId, string name);

        [OperationContract]
        bool DeleteGroup(int UserId, int id);

        [OperationContract]
        GroupDto GetGroup(int UserId, int id);
        #endregion

        #region GroupPhone
        [OperationContract]
        bool AddGroupPhone(int UserId, string name);

        [OperationContract]
        bool DeleteGroupPhone(int UserId, int id);

        [OperationContract]
        GroupPhoneDto GetGroupPhone(int UserId, int id);
        #endregion

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

        [DataMember]
        public int GroupPhoneId { get; protected set; }

        public static PhoneDto Get(Phone phone)
        {
            return new PhoneDto()
            {
                Id = phone.Id,
                Number = phone.Number,
                //GroupPhoneId = phone.GroupPhoneId
            };
        }
    }

    [DataContract]
    public class AddressDto
    {
        [DataMember]
        public int Id { get; protected set; }

        [DataMember]
        public int GroupAddressId { get; protected set; }

        [DataMember]
        public string Information { get; protected set; }


        public static AddressDto Get(Address address)
        {
            return new AddressDto()
            {
                Id = address.Id,
                Information = address.Information,
                //GroupAddressId = address.GroupAddressId
            };
        }
    }

    [DataContract]
    public class UserDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Login { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public IEnumerable<Subscriber> Subscriber { get; set; }

        [DataMember]
        public IEnumerable<GroupAddress> GroupAddress { get; set; }

        [DataMember]
        public IEnumerable<GroupPhone> GroupPhone { get; set; }

        [DataMember]
        public IEnumerable<Group> Group { get; set; }


        public static UserDto Get(User user)
        {
            return new UserDto()
            {
                Id = user.Id,
                Login = user.Login,
                Password = user.Password,
                Subscriber = (IEnumerable<Subscriber>)user.Subscribers.Select(a => SubscriberDto.Get(a)).ToList(),
                GroupAddress = (IEnumerable<GroupAddress>)user.GroupAddresses.Select(a => GroupAddressDto.Get(a)).ToList(),
                GroupPhone = (IEnumerable<GroupPhone>)user.GroupPhones.Select(a => GroupPhoneDto.Get(a)).ToList(),
                Group = (IEnumerable<Group>)user.Groups.Select(a => GroupDto.Get(a)).ToList()
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
        public byte[] Photo { get; protected set; }

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
                Photo = subscriber.Photo,
                Sex = subscriber.Sex,
                Mail = subscriber.Mail,
                Addresses = (IEnumerable<Address>)subscriber.Addresses.Select(a => AddressDto.Get(a)).ToList(),
                Groups = (IEnumerable<Group>)subscriber.Groups.Select(g => GroupDto.Get(g)).ToList(),
                Phones = (IEnumerable<Phone>)subscriber.Phones.Select(p => PhoneDto.Get(p)).ToList()
            };
        }
    }

    [DataContract]
    public class GroupAddressDto
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }


        public static GroupAddressDto Get(GroupAddress groupAddress)
        {
            return new GroupAddressDto()
            {
                Id = groupAddress.Id,
                Name = groupAddress.Name
            };
        }
    }

    [DataContract]
    public class GroupPhoneDto
    {
        [DataMember]
        public int Id { get; protected set; }

        [DataMember]
        public string Name { get; protected set; }

        public static GroupPhoneDto Get(GroupPhone roupPhone)
        {
            return new GroupPhoneDto()
            {
                Id = roupPhone.Id,
                Name = roupPhone.Name
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

}
