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
        public ContainerPhone Phones { get; set; }
        public ContainerAddress Addresses { get; set; }
        public Group Group { get; set; }
        public string Gender { get; set; }
        public DateTime DateBirth { get; set; }
        public Bitmap Photo { get; set; }
        public MailAddress Mail { get; set; }

        protected Subscriber(string name, string surname, string patronymic,
                             ContainerPhone phones, ContainerAddress addresses, Group group,
                             string gender, DateTime dateBirth, Bitmap photo, MailAddress mail)
        {
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            Phones = phones;
            Addresses = addresses;
            Group = group;
            Gender = gender;
            DateBirth = dateBirth;
            Photo = photo;
            Mail = mail;
        }

        protected Subscriber()
        { }

        public static Result<Subscriber> Create(string name, string surname = "", string patronymic = "",
                             ContainerPhone phones = null, ContainerAddress addresses = null, Group group = null,
                             string gender = "", DateTime dateBirth = new DateTime(), Bitmap photo = null, MailAddress mail = null)
        {
            if (phones == null) phones = new ContainerPhone();
            if (addresses == null) addresses = new ContainerAddress();

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
            sb.AppendLine($"{Group}");
            sb.AppendLine($"Gender : {Gender}");
            sb.AppendLine($"DateBirth : {DateBirth}");
            sb.Append($"Mail : {Mail}");

            return sb.ToString();
        }
    }
}
