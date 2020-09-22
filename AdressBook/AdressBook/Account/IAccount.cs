using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdressBook
{
    public interface IAccount
    {
        void Register(string userName, string password);
        bool Login(string userName, string password);
    }
}
