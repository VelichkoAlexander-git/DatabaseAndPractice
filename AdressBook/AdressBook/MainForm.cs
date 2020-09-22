using System.Windows.Forms;
using System;

namespace AdressBook
{
	public partial class MainForm : Form
	{
		private PersonContainer personContainer = new PersonContainer();

		public MainForm()
		{
			InitializeComponent();
			personContainer.Changed += personContainer_Changed;
			
		}

		private void personContainer_Changed( object sender, System.EventArgs e )
		{
			mainListView.Items.Clear();

			for ( int i = 0; i < personContainer.Count(); i++ )
			{
                for (int j = 0; j < personContainer[i].PhoneNumber.Count(); j++)
                {
					mainListView.Items.Add(new ListViewItem(new string[] { personContainer[i].FIO,
					personContainer[i].DateOfBirthDay.ToString("dd.MM.yyyy"), personContainer[i].Adress,
					personContainer[i].PhoneNumber[j].Number, personContainer[i].PhoneNumber[j].Group}));
				}
			}

			countElem.Text = personContainer.Count().ToString();
		}

		private void addButton_Click( object sender, System.EventArgs e )
		{
			addForm addForm = new addForm();
			addForm.ShowDialog();

			if ( addForm.DialogResult == System.Windows.Forms.DialogResult.OK )
				personContainer.Add( addForm.Person );
		}

		private void removeButton_Click( object sender, EventArgs e )
		{
			if ( mainListView.SelectedItems.Count == 0 )
			{
				MessageBox.Show( "Выберите хотя бы один эллемент из списка", "Ошибка удаления",
					MessageBoxButtons.OK, MessageBoxIcon.Error );
				return;
			}
			else
			{
					personContainer.Remove( mainListView.SelectedIndices[0]);
			}
		}

		private void sortButton_Click( object sender, EventArgs e )
		{
			personContainer.SortOnFIO();
		}

		private void findButton_Click( object sender, EventArgs e )
		{
			if ( findTextBox.Text == "" )
			{
				MessageBox.Show( "Введите фамилию для поиска", "Ошибка поиска",
					MessageBoxButtons.OK, MessageBoxIcon.Error );
				return;
			}
			else
			{
				ListViewItem temp = mainListView.FindItemWithText( findTextBox.Text );

				if ( temp != null )
				{
					temp.Focused = true;
					temp.EnsureVisible();
				}
			}

		}

		private void openButton_Click( object sender, EventArgs e )
		{
			openFileDialog.ShowDialog();
		}

		private void saveButton_Click( object sender, EventArgs e )
		{
			saveFileDialog.ShowDialog();
		}

		private void openFileDialog_FileOk( object sender, System.ComponentModel.CancelEventArgs e )
		{
			string error = string.Empty;
			personContainer.LoadFromFile( ((OpenFileDialog)sender).FileName, out error );

			if ( error != "None" )
				MessageBox.Show( error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error );
		}

		private void saveFileDialog_FileOk( object sender, System.ComponentModel.CancelEventArgs e )
		{
			string error = string.Empty;
			personContainer.SaveInFile( ((SaveFileDialog)sender).FileName, out error );

			if ( error != "None" )
				MessageBox.Show( error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error );
		}

		private void findTextBox_KeyUp( object sender, KeyEventArgs e )
		{
			if ( e.KeyCode == Keys.Enter )
				findButton_Click( sender, e );
		}
	}
}
