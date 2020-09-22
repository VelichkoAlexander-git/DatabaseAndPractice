using System;
using System.Windows.Forms;

namespace AdressBook
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new formLogin());            
            Application.Run(new MainForm());
            //Application.Run(new addForm());
        }
    }
}
