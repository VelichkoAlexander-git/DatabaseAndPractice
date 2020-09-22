using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdressBook
{
    public partial class formLogin : Form
    {
        IAccount account;
        public formLogin()
        {
            InitializeComponent();
            account = new AccountContainer();
            this.FormClosed += FormLogin_FormClosed1;
            
        }

        private void FormLogin_FormClosed1(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text;
            string password = txtPassword.Text;
            bool flag = account.Login(userName, password);
            if (flag)
            base.Dispose();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string userName = txtUsername.Text;
            string password = txtPassword.Text;
            account.Register(userName, password);
        }
    }
}
