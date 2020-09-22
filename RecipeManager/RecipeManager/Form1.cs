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
    public partial class Form1 : Form
    {
        private RecipeContainer recipeContainer = new RecipeContainer();
        public Form1()
        {
            InitializeComponent();
            recipeContainer.Changed += RecipeContainer_Changed;
            mainListView.ItemSelectionChanged += mainListView_ItemSelectionChanged;
        }

        private void mainListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (mainListView.SelectedItems.Count == 0)
            {
                listView1.Items.Clear();
                listView2.Items.Clear();
                return;
            }

            int index = mainListView.SelectedIndices[0];

            listView1.Items.Clear();
            for (int i = 0; i < recipeContainer[index].Ingredients.Count(); i++)
            {
                listView1.Items.Add(new ListViewItem(new string[] {
                    recipeContainer[index].Ingredients[i].Name}));
            }

            listView2.Items.Clear();
            listView2.Items.Add(new ListViewItem(new string[] {
                    recipeContainer[index].RecipeSteps}));
        }

        private void RecipeContainer_Changed(object sender, EventArgs e)
        {
            mainListView.Items.Clear();

            for (int i = 0; i < recipeContainer.Count(); i++)
            {
                mainListView.Items.Add(new ListViewItem(new string[] { 
                    recipeContainer[i].Description,
                    recipeContainer[i].Group.Name}));
            }
        }
        private void addButton_Click(object sender, System.EventArgs e)
        {
            IngredientForm addForm = new IngredientForm();
            addForm.ShowDialog();

            if (addForm.DialogResult == System.Windows.Forms.DialogResult.OK)
                recipeContainer.Add(addForm.Recipe);
        }


        private void removeButton_Click(object sender, EventArgs e)
        {
            if (mainListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы один эллемент из списка", "Ошибка удаления",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                recipeContainer.Remove(mainListView.SelectedIndices[0]);
            }
        }
    }


    public class Group
    {
        public Group(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }



}
