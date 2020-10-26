using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RecipeManager
{
    [Serializable]
    [XmlRoot(ElementName = "Groups")]
    public class GroupContainer : IEnumerable<Group>
    {
        [XmlArrayItem("ListOfGroup")]
        private List<Group> _list;

        public event EventHandler Changed;

        public GroupContainer(List<Group> Group)
        {
            _list = Group;
        }

        public GroupContainer() : this(new List<Group>())
        {
        }

        public GroupContainer SetList(List<Group> list)
        {
            _list = list;

            if (Changed != null) Changed(this, new EventArgs());

            return this;
        }

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

        public int this[Group i]
        {
            get
            {
                return _list.IndexOf(i);
            }
        }
        public GroupContainer Add(Group group)
        {

            if (!_list.Contains(group))
                if (!_list.Any(i => i.Name.Equals(group.Name, StringComparison.CurrentCultureIgnoreCase)))
                    _list.Add(group);

            if (Changed != null) Changed(this, new EventArgs());

            return this;
        }

        public GroupContainer Edit(int index, string name)
        {
            if (!_list.Any(t => t.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)))
                _list[index].Name = name;

            if (Changed != null) Changed(this, new EventArgs());

            return this;
        }

        public GroupContainer Remove(Group group)
        {
            _list.Remove(group);

            if (Changed != null) Changed(this, new EventArgs());

            return this;
        }

        public GroupContainer Remove(int Index)
        {
            _list.RemoveAt(Index);

            if (Changed != null) Changed(this, new EventArgs());

            return this;
        }

        public int Count()
        {
            return _list.Count;
        }

        public IEnumerator<Group> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_list).GetEnumerator();
        }
    }
}
