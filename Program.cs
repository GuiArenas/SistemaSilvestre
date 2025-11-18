using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SistemaSilvestre.View;

namespace SistemaSilvestre
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            frmLogin login = new frmLogin();
            login.ShowDialog(); 

            if (login.Logado)
            {
                Application.Run(new frmMenuPrincipal());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
