using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    class ContainerGroupPhone : IEnumerable<GroupPhone>
    {
        private List<GroupPhone> _list;

        public ContainerGroupPhone(List<GroupPhone> groupList)
        {
            _list = groupList;
        }

        public ContainerGroupPhone() : this(new List<GroupPhone>())
        { }

        public GroupPhone this[int i]
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
        public ContainerGroupPhone SetList(List<GroupPhone> list)
        {
            _list = list;

            return this;
        }

        public ContainerGroupPhone Add(GroupPhone groupPhone)
        {

            if (!_list.Contains(groupPhone))
                if (!_list.Any(i => i.Name == groupPhone.Name))
                    _list.Add(groupPhone);

            return this;
        }

        public int Count() => _list.Count;

        public IEnumerator<GroupPhone> GetEnumerator()
        {
            return ((IEnumerable<GroupPhone>)_list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_list).GetEnumerator();
        }
    }
}
