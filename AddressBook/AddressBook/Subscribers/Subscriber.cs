using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class Subscriber
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        protected List<Phone> PhoneInternal { get; set; }
        public IEnumerable<Phone> Phones => PhoneInternal;
        protected List<Address> AddressInternal { get; set; }
        public IEnumerable<Address> Addresses => AddressInternal;
        protected List<Group> GroupInternal { get; set; }
        public IEnumerable<Group> Groups => GroupInternal;
        public string Gender { get; set; }
        public DateTime DateBirth { get; set; }
        public Bitmap Photo { get; set; }
        public MailAddress Mail { get; set; }

        protected Subscriber(string name, string surname, string patronymic,
                             List<Phone> phones, List<Address> addresses, List<Group> group,
                             string gender, DateTime dateBirth, Bitmap photo, MailAddress mail)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            PhoneInternal = phones;
            AddressInternal = addresses;
            GroupInternal = group;
            Gender = gender;
            DateBirth = dateBirth;
            Photo = photo;
            Mail = mail;
        }

        protected Subscriber()
        { }

        public static Result<Subscriber> Create(string name, string surname = "", string patronymic = "",
                             List<Phone> phones = null, List<Address> addresses = null, List<Group> group = null,
                             string gender = "", DateTime dateBirth = new DateTime(), Bitmap photo = null, MailAddress mail = null)
        {
            if (phones == null) phones = new List<Phone>();
            if (addresses == null) addresses = new List<Address>();
            if (group == null) group = new List<Group>();

            var errors = new List<string>();

            if (errors.Any())
            {
                return Result<Subscriber>.Fail(errors);
            }
            return Result<Subscriber>.Success(new Subscriber(
                name, surname, patronymic,
                phones, addresses, group,
                gender, dateBirth, photo, mail));
        }

        public void AddPhone(Phone phone)
        {
            PhoneInternal.Add(phone);
        }
        public void RemovePhone(Phone phone)
        {
            PhoneInternal.Remove(phone);
        }
        public void RemovePhoneAt(int index)
        {
            PhoneInternal.RemoveAt(index);
        }

        public void AddAddress(Address address)
        {
            AddressInternal.Add(address);
        }
        public void RemoveAddress(Address address)
        {
            AddressInternal.Remove(address);
        }
        public void RemoveAddressAt(int index)
        {
            AddressInternal.RemoveAt(index);
        }

        public void AddGroup(Group group)
        {
            GroupInternal.Add(group);
        }
        public void RemoveGroup(Group group)
        {
            GroupInternal.Remove(group);
        }
        public void RemoveGroupAt(int index)
        {
            GroupInternal.RemoveAt(index);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name : {Name}");
            sb.AppendLine($"Surname : {Surname}");
            sb.AppendLine($"Patronymic : {Patronymic}");
            sb.AppendLine($"Phones : ");
            foreach (var phone in Phones)
            {
                sb.AppendLine($"{"",5}{phone.ToString()}");
            }
            sb.AppendLine($"Addresses : ");
            foreach (var address in Addresses)
            {
                sb.AppendLine($"{"",5}{address.ToString()}");
            }
            sb.AppendLine($"Group : ");
            foreach (var group in Groups)
            {
                sb.AppendLine($"{"",5}{group.ToString()}");
            }
            sb.AppendLine($"Gender : {Gender}");
            sb.AppendLine($"DateBirth : {DateBirth}");
            sb.Append($"Mail : {Mail}");

            return sb.ToString();
        }
    }
}
