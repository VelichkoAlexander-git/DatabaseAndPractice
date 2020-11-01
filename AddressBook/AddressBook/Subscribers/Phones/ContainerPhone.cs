using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class ContainerPhone : IEnumerable<Phone>
    {
        private List<Phone> _list;

        public ContainerPhone(List<Phone> phonesList)
        {
            _list = phonesList;
        }

        public ContainerPhone() : this(new List<Phone>())
        { }

        public Phone this[int i]
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

        public ContainerPhone Add(Phone phone)
        {

            if (!_list.Contains(phone))
                if (!_list.Any(i => i.Number == phone.Number))
                    _list.Add(phone);

            return this;
        }

        public ContainerPhone SetList(List<Phone> list)
        {
            _list = list;

            return this;
        }

        public IEnumerator<Phone> GetEnumerator()
        {
            return ((IEnumerable<Phone>)_list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_list).GetEnumerator();
        }
    }
}
