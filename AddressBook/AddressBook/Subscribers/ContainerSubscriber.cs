using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class ContainerSubscriber : IEnumerable<Subscriber>
    {
        private List<Subscriber> _list;

        public ContainerSubscriber(List<Subscriber> subscriberList)
        {
            _list = subscriberList;
        }

        public ContainerSubscriber() : this(new List<Subscriber>())
        { }

        public Subscriber this[int i]
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
        public ContainerSubscriber SetList(List<Subscriber> list)
        {
            _list = list;

            return this;
        }

        public ContainerSubscriber Add(Subscriber subscriber)
        {

            if (!_list.Contains(subscriber))
                if (!_list.Any(i => i.Name == subscriber.Name))
                    _list.Add(subscriber);

            return this;
        }

        public int Count() => _list.Count;

        public IEnumerator<Subscriber> GetEnumerator()
        {
            return ((IEnumerable<Subscriber>)_list).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_list).GetEnumerator();
        }
    }
}
