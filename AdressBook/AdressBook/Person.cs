using System;
using System.Collections.Generic;

namespace AdressBook
{
	public class Person
	{
		public string FIO { get; set; }
		public DateTime DateOfBirthDay { get; set; }
		public string Adress { get; set; }
		public TelephoneContainer PhoneNumber { get; set; }

		public Person( string FIO, DateTime DateOfBirthayDay, string Adress, TelephoneContainer PhoneNumber)
		{
			this.FIO = FIO;
			this.DateOfBirthDay = DateOfBirthayDay;
			this.Adress = Adress;
			this.PhoneNumber = PhoneNumber;
		}

		public Person()
			: this( "Empty", DateTime.MinValue, "Empty", new TelephoneContainer())
		{
		}

		public override string ToString()
		{
			return string.Format( "ФИО: {0}\nДата рождения: {1}\nАдресс: {2}\nТелефонный номер: {3}",
				this.FIO, this.DateOfBirthDay, this.Adress, this.PhoneNumber );
		}
	}
}