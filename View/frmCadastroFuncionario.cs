using System;
using System.Windows.Forms;
using SistemaSilvestre.Model;
using SistemaSilvestre.Controller;

namespace SistemaSilvestre.View
{
    public partial class frmCadastroFuncionario : Form
    {
        private FuncionarioController funcionarioController;
        public Funcionario FuncionarioSelecionado { get; set; }

        public frmCadastroFuncionario()
        {
            InitializeComponent();
            funcionarioController = new FuncionarioController();
            LimparCampos();
        }

        public frmCadastroFuncionario(Funcionario funcionarioParaEditar) : this()
        {
            FuncionarioSelecionado = funcionarioParaEditar;
            PreencherCampos(funcionarioParaEditar);
            this.Text = "Sistema Silvestre - Edição de Funcionário";
        }

        private void LimparCampos()
        {
            txtIdFuncionario.Text = "0";
            txtNomeCompleto.Clear(); 
            txtCargo.Clear();
            txtTelefone.Clear();
            txtCRMV_CRBio.Clear();
            txtNomeCompleto.Focus(); 
            FuncionarioSelecionado = null;
        }

        private void PreencherCampos(Funcionario funcionario)
        {
            if (funcionario != null)
            {
                txtIdFuncionario.Text = funcionario.IdFuncionario.ToString();
                txtNomeCompleto.Text = funcionario.NomeCompleto; 
                txtCargo.Text = funcionario.Cargo;
                txtTelefone.Text = funcionario.Telefone;
                txtCRMV_CRBio.Text = funcionario.CRMV_CRBio;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Funcionario funcionario = new Funcionario();

            if (FuncionarioSelecionado != null)
            {
                funcionario.IdFuncionario = FuncionarioSelecionado.IdFuncionario;
            }

            funcionario.NomeCompleto = txtNomeCompleto.Text; 
            funcionario.Cargo = txtCargo.Text;
            funcionario.Telefone = txtTelefone.Text;
            funcionario.CRMV_CRBio = txtCRMV_CRBio.Text;

            funcionarioController.Salvar(funcionario);

            if (funcionario.IdFuncionario == 0)
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