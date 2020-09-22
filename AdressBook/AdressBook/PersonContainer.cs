using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace AdressBook
{
	class PersonContainer
	{
		public event EventHandler Changed;

		private List<Person> _list;

		public PersonContainer( List<Person> PersonList )
		{
			_list = PersonList;
		}

		public PersonContainer()
			: this( new List<Person>() )
		{
		}

		public Person this[int i]
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

		public PersonContainer Add( Person Person )
		{
			_list.Add( Person );

			if ( Changed != null ) Changed( this, new EventArgs() );

			return this;
		}

		public PersonContainer Remove( Person Person )
		{
			_list.Remove( Person );

			if ( Changed != null ) Changed( this, new EventArgs() );

			return this;
		}

		public PersonContainer Remove( int Index )
		{
			_list.RemoveAt( Index );

			if ( Changed != null ) Changed( this, new EventArgs() );

			return this;
		}

		public PersonContainer RemoveAll()
		{
			_list.RemoveAll( null );

			if ( Changed != null ) Changed( this, new EventArgs() );

			return this;
		}

		public PersonContainer SortOnFIO()
		{
			_list.Sort( (x, y) => x.FIO.CompareTo( y.FIO ) );

			if ( Changed != null ) Changed( this, new EventArgs() );

			return this;
		}

		public int Count()
		{
			return _list.Count;
		}

		public PersonContainer LoadFromFile( string Path, out string Error )
		{
			try
			{
				using ( FileStream fs = new FileStream( Path, FileMode.Open ) )
				{
					XmlSerializer xs = new XmlSerializer( typeof( List<Person> ) );
					_list = xs.Deserialize( fs ) as List<Person>;
				}

				if ( Changed != null ) Changed( this, new EventArgs() );

				Error = "None";
				return this;
			}
			catch ( Exception e )
			{
				Error = e.Message;
				return null;
			}
		}

		public bool SaveInFile( string Path, out string Error )
		{
			try
			{
				using ( FileStream fs = new FileStream( Path, FileMode.Create ) )
				{
					XmlSerializer xs = new XmlSerializer( typeof( List<Person> ) );
					xs.Serialize( fs, _list );
				}

				Error = "None";
				return true;
			}
			catch ( Exception e )
			{
				Error = e.Message;
				return false;
			}
		}
	}
}