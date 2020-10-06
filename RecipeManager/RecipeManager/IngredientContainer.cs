using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace RecipeManager
{
    [Serializable]
    [XmlRoot(ElementName = "Ingredients")]
    public class IngredientContainer
    {
        [XmlArrayItem("ListOfIngredient")]
        private List<Ingredient> _list;

        public event EventHandler Changed;

        public IngredientContainer(List<Ingredient> IngredientList)
        {
            _list = IngredientList;
        }

        public IngredientContainer() : this (new List<Ingredient>())
        { 
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

        public IngredientContainer Add(Ingredient ingredient)
        {
            _list.Add(ingredient);

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
    }
}
