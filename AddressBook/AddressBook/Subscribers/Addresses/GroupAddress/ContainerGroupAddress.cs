using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class ContainerGroupAddress : IEnumerable<GroupAddress>
    {
        private List<GroupAddress> _list;

        public ContainerGroupAddress(List<GroupAddress> groupList)
        {
            _list = groupList;
        }

        public ContainerGroupAddress() : this(new List<GroupAddress>())
        { }

        public GroupAddress this[int i]
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
        public ContainerGroupAddress SetList(List<GroupAddress> list)
        {
            _list = list;

            return this;
        }

        public ContainerGroupAddress Add(GroupAddress groupAddress)
        {

            if (!_list.Contains(groupAddress))
                if (!_list.Any(i => i.Name == groupAddress.Name))
                    _list.Add(groupAddress);

            return this;
        }

        public int Count() => _list.Count;

        public IEnumerator<GroupAddress> GetEnumerator()
        {
            return ((IEnumerable<GroupAddress>)_list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_list).GetEnumerator();
        }
    }
}
