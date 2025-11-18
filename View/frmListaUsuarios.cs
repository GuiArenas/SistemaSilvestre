using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaSilvestre.Model;
using SistemaSilvestre.Controller;

namespace SistemaSilvestre.View
{
    public partial class frmListaUsuarios : Form
    {
        private UsuarioController usuarioController;

        public frmListaUsuarios()
        {
            InitializeComponent();
            usuarioController = new UsuarioController();
        }

        private void frmListaUsuarios_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            try
            {
                List<Usuario> usuarios = usuarioController.ConsultarTodos();

                dgvUsuarios.DataSource = null;
                dgvUsuarios.DataSource = usuarios;

                ConfigurarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar lista de usuários: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrid()
        {
            if (dgvUsuarios.Columns.Count > 0)
            {
                dgvUsuarios.Columns["IdUsuario"].Visible = false;
                dgvUsuarios.Columns["Senha"].Visible = false;
                dgvUsuarios.Columns["IdFuncionario"].Visible = false;

                dgvUsuarios.Columns["Login"].HeaderText = "Login"; 
                dgvUsuarios.Columns["NivelAcesso"].HeaderText = "Nível de Acesso";

                dgvUsuarios.Columns["Login"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; 
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCadastroUsuario telaCadastro = new frmCadastroUsuario();
            telaCadastro.ShowDialog();
            CarregarGrid();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                Usuario usuarioSelecionado = (Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem;

                frmCadastroUsuario telaCadastro = new frmCadastroUsuario(usuarioSelecionado);
                telaCadastro.ShowDialog();
                CarregarGrid();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um usuário para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja excluir este usuário?",
                                                        "Confirmar Exclusão",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    Usuario usuarioSelecionado = (Usuario)dgvUsuarios.SelectedRows[0].DataBoundItem;
                    usuarioController.Excluir(usuarioSelecionado.IdUsuario);
                    CarregarGrid();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um usuário para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}