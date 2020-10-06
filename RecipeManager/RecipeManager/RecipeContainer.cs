using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeManager
{
    public class RecipeContainer
    {
        public event EventHandler Changed;

        private List<Recipe> _list;

        public RecipeContainer(List<Recipe> RecipeList)
        {
            _list = RecipeList;
        }

        public RecipeContainer() : this(new List<Recipe>())
        {
        }

        public Recipe this[int i]
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

        public RecipeContainer Add(Recipe recipe)
        {
            _list.Add(recipe);

            if (Changed != null) Changed(this, new EventArgs());

            return this;
        }

        public RecipeContainer Remove(Recipe recipe)
        {
            _list.Remove(recipe);

            if (Changed != null) Changed(this, new EventArgs());

            return this;
        }
        public RecipeContainer Remove(int Index)
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
