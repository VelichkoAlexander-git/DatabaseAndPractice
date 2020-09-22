using System.Windows.Forms;
using System;
using System.Collections.Generic;

namespace AdressBook
{
    public partial class addForm : Form
    {
        private TelephoneContainer _telephoneContainer;
        public Person Person
        {
            get
            {
                return new Person(fioTextBox.Text, dateBox.Value.Date, adressTextBox.Text, _telephoneContainer);
            }
        }

        public addForm()
        {
            InitializeComponent();
            _telephoneContainer = new TelephoneContainer();
            _telephoneContainer.Changed += _telephoneContainer_Changed;
        }

        public addForm(Person person)
        {
            InitializeComponent();

            fioTextBox.Text = person.FIO;
            dateBox.Value = person.DateOfBirthDay;
            adressTextBox.Text = person.Adress;
            _telephoneContainer = person.PhoneNumber;
            _telephoneContainer.Changed += _telephoneContainer_Changed;
        }

        private void _telephoneContainer_Changed(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            for (int i = 0; i < _telephoneContainer.Count(); i++)
            {
                listView1.Items.Add(new ListViewItem(new string[] { _telephoneContainer[i].Number, _telephoneContainer[i].Group }));
            }
        }

        private void addButton_Click(object sender, System.EventArgs e)
        {
            telForm telForm = new telForm();
            telForm.ShowDialog();

            if (telForm.DialogResult == System.Windows.Forms.DialogResult.OK)
                _telephoneContainer.Add(telForm.Telephone);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы один эллемент из списка", "Ошибка удаления",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                _telephoneContainer.Remove(listView1.SelectedIndices[0]);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Выберите хотя бы один эллемент из списка", "Ошибка удаления",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                int index = listView1.SelectedIndices[0];
                telForm telForm = new telForm(_telephoneContainer[index]);
                telForm.ShowDialog();

                if (telForm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    _telephoneContainer.Remove(listView1.SelectedIndices[0]);
                    _telephoneContainer.Add(telForm.Telephone);
                }
            }
        }
    }
}
