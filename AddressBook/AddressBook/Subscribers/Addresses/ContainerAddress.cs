using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class ContainerAddress : IEnumerable<Address>
    {
        private List<Address> _list;

        public ContainerAddress(List<Address> addressList)
        {
            _list = addressList;
        }

        public ContainerAddress() : this(new List<Address>())
        { }

        public Address this[int i]
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

        public ContainerAddress SetList(List<Address> list)
        {
            _list = list;

            return this;
        }

        public ContainerAddress Add(Address address)
        {

            if (!_list.Contains(address))
                if (!_list.Any(i => i.Information == address.Information))
                    _list.Add(address);

            return this;
        }

        public int Count() => _list.Count;

        public IEnumerator<Address> GetEnumerator()
        {
            return ((IEnumerable<Address>)_list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_list).GetEnumerator();
        }
    }
}
