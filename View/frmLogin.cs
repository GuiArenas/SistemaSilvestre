using System;
using System.Windows.Forms;
using SistemaSilvestre.Model;
using SistemaSilvestre.Controller;
using BCrypt.Net; 

namespace SistemaSilvestre.View
{
    public partial class frmLogin : Form
    {
        public bool Logado { get; private set; } = false;
        public string UsuarioLogado { get; private set; }

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string login = txtUsuario.Text.Trim();
            string senhaDigitada = txtSenha.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(senhaDigitada))
            {
                MessageBox.Show("Preencha usuário e senha.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            UsuarioDAO dao = new UsuarioDAO();
            Usuario usuarioEncontrado = dao.BuscarPorLogin(login);

            if (usuarioEncontrado != null)
            {
                bool senhaCorreta = false;

                try
                {
                    senhaCorreta = BCrypt.Net.BCrypt.Verify(senhaDigitada, usuarioEncontrado.Senha);
                }
                catch
                {
                    if (senhaDigitada == usuarioEncontrado.Senha) senhaCorreta = true;
                }

                if (senhaCorreta)
                {
                    Logado = true;
                    UsuarioLogado = usuarioEncontrado.Login;
                    this.Close(); 
                }
                else
                {
                    MessageBox.Show("Senha incorreta.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Usuário não encontrado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}