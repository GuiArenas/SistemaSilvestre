using System;
using System.Windows.Forms;
using SistemaSilvestre.Model;
using SistemaSilvestre.Controller;

namespace SistemaSilvestre.View
{
    public partial class frmCadastroLocalSoltura : Form
    {
        private LocalSolturaController localSolturaController;
        public LocalSoltura LocalSolturaSelecionado { get; set; }

        public frmCadastroLocalSoltura()
        {
            InitializeComponent();
            localSolturaController = new LocalSolturaController();
            LimparCampos();
        }

        public frmCadastroLocalSoltura(LocalSoltura localParaEditar) : this()
        {
            LocalSolturaSelecionado = localParaEditar;
            PreencherCampos(localParaEditar);
            this.Text = "Sistema Silvestre - Edição de Local de Soltura";
        }

        private void LimparCampos()
        {
            txtIdLocalSoltura.Text = "0";
            txtNomeLocal.Clear();
            txtBioma.Clear();
            txtCoordenadasGPS.Clear();
            txtResponsavelContato.Clear();
            txtNomeLocal.Focus();
            LocalSolturaSelecionado = null;
        }

        private void PreencherCampos(LocalSoltura localSoltura)
        {
            if (localSoltura != null)
            {
                txtIdLocalSoltura.Text = localSoltura.IdLocalSoltura.ToString();
                txtNomeLocal.Text = localSoltura.NomeLocal;
                txtBioma.Text = localSoltura.Bioma;
                txtCoordenadasGPS.Text = localSoltura.CoordenadasGPS;
                txtResponsavelContato.Text = localSoltura.ResponsavelContato;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            LocalSoltura localSoltura = new LocalSoltura();

            if (LocalSolturaSelecionado != null)
            {
                localSoltura.IdLocalSoltura = LocalSolturaSelecionado.IdLocalSoltura;
            }

            localSoltura.NomeLocal = txtNomeLocal.Text;
            localSoltura.Bioma = txtBioma.Text;
            localSoltura.CoordenadasGPS = txtCoordenadasGPS.Text;
            localSoltura.ResponsavelContato = txtResponsavelContato.Text;

            localSolturaController.Salvar(localSoltura);

            if (localSoltura.IdLocalSoltura == 0)
            {
                LimparCampos();
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}