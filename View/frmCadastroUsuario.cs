using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaSilvestre.Model;
using SistemaSilvestre.Controller;

namespace SistemaSilvestre.View
{
    public partial class frmCadastroUsuario : Form
    {
        private UsuarioController usuarioController;
        private FuncionarioController funcionarioController;
        public Usuario UsuarioSelecionado { get; set; }

        public frmCadastroUsuario()
        {
            InitializeComponent();
            usuarioController = new UsuarioController();
            funcionarioController = new FuncionarioController();
            LimparCampos();
        }

        public frmCadastroUsuario(Usuario usuarioParaEditar) : this()
        {
            UsuarioSelecionado = usuarioParaEditar;
            PreencherCampos(usuarioParaEditar);
            this.Text = "Sistema Silvestre - Edição de Usuário";
        }

        private void frmCadastroUsuario_Load(object sender, EventArgs e)
        {
            CarregarComboBoxFuncionario();

            if (UsuarioSelecionado == null)
            {
                cmbNivelAcesso.SelectedIndex = 1;
            }
        }

        private void CarregarComboBoxFuncionario()
        {
            try
            {
                List<Funcionario> funcionarios = funcionarioController.ConsultarTodos();

                cmbFuncionario.DataSource = funcionarios;
                cmbFuncionario.DisplayMember = "NomeCompleto";
                cmbFuncionario.ValueMember = "IdFuncionario";

                cmbFuncionario.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar funcionários: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            txtIdUsuario.Text = "0";
            txtLogin.Clear(); 
            txtSenha.Clear();
            cmbNivelAcesso.SelectedIndex = -1;
            cmbFuncionario.SelectedIndex = -1;
            txtLogin.Focus(); 
            UsuarioSelecionado = null;
        }

        private void PreencherCampos(Usuario usuario)
        {
            if (usuario != null)
            {
                txtIdUsuario.Text = usuario.IdUsuario.ToString();
                txtLogin.Text = usuario.Login;
                txtSenha.Text = usuario.Senha;
                cmbNivelAcesso.SelectedItem = usuario.NivelAcesso;
                cmbFuncionario.SelectedValue = usuario.IdFuncionario;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();

            if (UsuarioSelecionado != null)
            {
                usuario.IdUsuario = UsuarioSelecionado.IdUsuario;
            }

            usuario.Login = txtLogin.Text; 
            usuario.Senha = txtSenha.Text;
            usuario.NivelAcesso = cmbNivelAcesso.SelectedItem?.ToString();

            if (cmbFuncionario.SelectedValue != null)
            {
                usuario.IdFuncionario = (int)cmbFuncionario.SelectedValue;
            }
            else
            {
                usuario.IdFuncionario = 0;
            }

            usuarioController.Salvar(usuario);

            if (usuario.IdUsuario == 0)
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