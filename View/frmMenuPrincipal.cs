using System;
using System.Windows.Forms;
using SistemaSilvestre.View; 

namespace SistemaSilvestre.View 
{
    public partial class frmMenuPrincipal : Form
    {
        public frmMenuPrincipal()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnAnimais_Click(object sender, EventArgs e)
        {
            frmListaAnimais telaListaAnimais = new frmListaAnimais();
            telaListaAnimais.ShowDialog();
        }

        private void btnEspecies_Click(object sender, EventArgs e)
        {
            frmListaEspecies telaListaEspecies = new frmListaEspecies();
            telaListaEspecies.ShowDialog(); 
        }

        private void btnFuncionario_Click(object sender, EventArgs e)
        {
            frmListaFuncionarios telaListaFuncionarios = new frmListaFuncionarios();
            telaListaFuncionarios.ShowDialog(); 
        }

        private void btnLocalSoltura_Click(object sender, EventArgs e) 
        {
            frmListaLocaisSoltura telaListaLocaisSoltura = new frmListaLocaisSoltura();
            telaListaLocaisSoltura.ShowDialog(); 
        }

        private void btnManejoClinico_Click(object sender, EventArgs e) 
        {
            frmListaManejosClinicos telaListaManejosClinicos = new frmListaManejosClinicos();
            telaListaManejosClinicos.ShowDialog(); 
        }

        private void btnRecinto_Click(object sender, EventArgs e) 
        {
            frmListaRecintos telaListaRecintos = new frmListaRecintos();
            telaListaRecintos.ShowDialog(); 
        }

        private void btnUsuario_Click(object sender, EventArgs e) 
        {
            frmListaUsuarios telaListaUsuarios = new frmListaUsuarios();
            telaListaUsuarios.ShowDialog(); 
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void frmMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void frmMenuPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}