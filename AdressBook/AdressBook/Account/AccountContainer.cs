using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdressBook
{
    class AccountContainer : IAccount
    {
        private Dictionary<string, string> _list;

        public AccountContainer(Dictionary<string, string> AccountList)
        {
            _list = AccountList;
        }

        public AccountContainer()
            : this(new Dictionary<string, string>())
        {
        }

        public void Register(string userName, string password)
        {
            if (!_list.ContainsKey(userName))
            {
                _list.Add(userName, password);

                MessageBox.Show("Account created successfully");
            }
            else
            {
                MessageBox.Show("This login is already taken");
            }
        }

        public bool Login(string userName, string password)
        {
            var thisUser = _list.FirstOrDefault(t => t.Key == userName);
            bool flag = thisUser.Value == password ? true : false;
            if (flag)
            {
                MainForm objmainForm = new MainForm();            
                objmainForm.Show();
            }
            else
            {
                MessageBox.Show("Check your username and password");
            }
            return flag;
        }
    }
}
