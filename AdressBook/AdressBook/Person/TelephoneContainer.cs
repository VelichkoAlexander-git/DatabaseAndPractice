using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressBook
{
    public class TelephoneContainer
    {
		public event EventHandler Changed;

		private List<Telephone> _list;

		public TelephoneContainer(List<Telephone> PersonList)
		{
			_list = PersonList;
		}

		public TelephoneContainer()
			: this(new List<Telephone>())
		{
		}

		public Telephone this[int i]
		{
			get
			{
				return _list[i];
			}

			set
			{
				_list[i] = value;
			}
		}

		public TelephoneContainer Add(Telephone Person)
		{
			_list.Add(Person);

			if (Changed != null) Changed(this, new EventArgs());

			return this;
		}

		public TelephoneContainer Remove(Telephone telephone)
		{
			_list.Remove(telephone);

			if (Changed != null) Changed(this, new EventArgs());

			return this;
		}

		public TelephoneContainer Remove(int Index)
		{
			_list.RemoveAt(Index);

			if (Changed != null) Changed(this, new EventArgs());

			return this;
		}
		public int Count()
		{
			return _list.Count;
		}

		public List<Telephone> GetList()
		{
			return _list;
		}
	}
}
