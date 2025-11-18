using System;
using System.Windows.Forms;
using SistemaSilvestre.Model; 
using SistemaSilvestre.Controller;

namespace SistemaSilvestre.View
{
    public partial class frmCadastroEspecie : Form
    {
        private EspecieController especieController;

        public Especie EspecieSelecionada { get; set; }

        public frmCadastroEspecie()
        {
            InitializeComponent();
            especieController = new EspecieController(); 
            LimparCampos(); 
        }

        public frmCadastroEspecie(Especie especieParaEditar) : this()
        {
            EspecieSelecionada = especieParaEditar;
            PreencherCampos(especieParaEditar);
            this.Text = "Sistema Silvestre - Edição de Espécie"; 
        }

        private void LimparCampos()
        {
            txtIdEspecie.Text = "0";
            txtNomePopular.Clear();
            txtNomeCientifico.Clear();
            txtDietaPadrao.Clear();
            txtObservacoes.Clear();
            txtNomePopular.Focus(); 
            EspecieSelecionada = null;
        }

        private void PreencherCampos(Especie especie)
        {
            if (especie != null)
            {
                txtIdEspecie.Text = especie.IdEspecie.ToString();
                txtNomePopular.Text = especie.NomePopular;
                txtNomeCientifico.Text = especie.NomeCientifico;
                txtDietaPadrao.Text = especie.DietaPadrao;
                txtObservacoes.Text = especie.Observacoes;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Especie especie = new Especie();

            if (EspecieSelecionada != null)
            {
                especie.IdEspecie = EspecieSelecionada.IdEspecie;
            }

            especie.NomePopular = txtNomePopular.Text;
            especie.NomeCientifico = txtNomeCientifico.Text;
            especie.DietaPadrao = txtDietaPadrao.Text;
            especie.Observacoes = txtObservacoes.Text;

            especieController.Salvar(especie);

            if (especie.IdEspecie == 0) 
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