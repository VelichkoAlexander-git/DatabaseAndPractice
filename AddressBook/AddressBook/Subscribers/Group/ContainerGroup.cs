using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class ContainerGroup : IEnumerable<Group>
    {
        private List<Group> _list;

        public ContainerGroup(List<Group> groupList)
        {
            _list = groupList;
        }

        public ContainerGroup() : this(new List<Group>())
        { }

        public Group this[int i]
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
        public ContainerGroup SetList(List<Group> list)
        {
            _list = list;

            return this;
        }

        public ContainerGroup Add(Group group)
        {

            if (!_list.Contains(group))
                if (!_list.Any(i => i.Name == group.Name))
                    _list.Add(group);

            return this;
        }

        public int Count() => _list.Count;

        public IEnumerator<Group> GetEnumerator()
        {
            return ((IEnumerable<Group>)_list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_list).GetEnumerator();
        }
    }
}
