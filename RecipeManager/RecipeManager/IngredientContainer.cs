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
    [XmlRoot(ElementName = "Ingredients")]
    public class IngredientContainer : IEnumerable<Ingredient>
    {
        [XmlArrayItem("ListOfIngredient")]
        private List<Ingredient> _list;

        public event EventHandler Changed;

        public IngredientContainer(List<Ingredient> IngredientList)
        {
            _list = IngredientList;
        }

        public IngredientContainer() : this(new List<Ingredient>())
        {
        }

        public IngredientContainer SetList(List<Ingredient> list)
        {
            _list = list;

            if (Changed != null) Changed(this, new EventArgs());

            return this;
        }

        public Ingredient this[int i]
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
        public int this[Ingredient i]
        {
            get
            {
                return _list.IndexOf(i);
            }
        }

        public IngredientContainer Add(Ingredient ingredient)
        {
            if (!_list.Contains(ingredient))
                if (!_list.Any(i => i.Name.Equals(ingredient.Name, StringComparison.CurrentCultureIgnoreCase)))
                {
                    _list.Add(ingredient);
                    if (Changed != null) Changed(this, new EventArgs());
                }



            return this;
        }

        public IngredientContainer Edit(int index, string name)
        {
            if (!_list.Any(t => t.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase)))
                _list[index].Name = name;

            if (Changed != null) Changed(this, new EventArgs());

            return this;
        }

        public IngredientContainer Remove(Ingredient ingredient)
        {
            _list.Remove(ingredient);

            if (Changed != null) Changed(this, new EventArgs());

            return this;
        }

        public IngredientContainer Remove(int Index)
        {
            _list.RemoveAt(Index);

            if (Changed != null) Changed(this, new EventArgs());

            return this;
        }

        public int Count()
        {
            return _list.Count;
        }

        public IEnumerator<Ingredient> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _list.GetEnumerator();
        }
    }
}
