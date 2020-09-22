using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdressBook
{
    public partial class telForm : Form
    {
        public telForm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }
        public telForm(Telephone telephone)
        {
            InitializeComponent();

            telephoneTextBox.Text = telephone.Number;
            comboBox1.SelectedItem = telephone.Group;
        }

        public Telephone Telephone
        {
            get
            {
                return new Telephone(telephoneTextBox.Text, comboBox1.SelectedItem.ToString());
            }
        }


    }
}
