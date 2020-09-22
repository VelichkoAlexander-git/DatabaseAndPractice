using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RecipeManager
{
    public partial class AddIngredientForm : Form
    {
        public AddIngredientForm()
        {
            InitializeComponent();
            listView1.Items.Add("234");
            listView1.Items.Add("24");
            listView1.Items.Add("4");
            listView1.Items.Add("222");
        }

        public Ingredient Ingredient
        {
            get
            {
                if (listView1.SelectedItems.Count == 0)
                {
                    return null;
                }
                else
                {
                    int index = listView1.SelectedIndices[0];
                    //telForm telForm = new telForm(_telephoneContainer[index]);
                    return new Ingredient(listView1.SelectedItems[0].Text);
                }
            }
        }
    }
}
