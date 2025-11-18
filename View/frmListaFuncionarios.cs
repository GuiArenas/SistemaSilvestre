using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaSilvestre.Model;
using SistemaSilvestre.Controller;

namespace SistemaSilvestre.View
{
    public partial class frmListaFuncionarios : Form
    {
        private FuncionarioController funcionarioController;

        public frmListaFuncionarios()
        {
            InitializeComponent();
            funcionarioController = new FuncionarioController();
        }

        private void frmListaFuncionarios_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            try
            {
                List<Funcionario> funcionarios = funcionarioController.ConsultarTodos();

                dgvFuncionarios.DataSource = null;
                dgvFuncionarios.DataSource = funcionarios;

                ConfigurarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar lista de funcionários: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrid()
        {
            if (dgvFuncionarios.Columns.Count > 0)
            {
                dgvFuncionarios.Columns["IdFuncionario"].Visible = false;

                dgvFuncionarios.Columns["NomeCompleto"].HeaderText = "Nome";
                dgvFuncionarios.Columns["Cargo"].HeaderText = "Cargo";
                dgvFuncionarios.Columns["Telefone"].HeaderText = "Telefone";
                dgvFuncionarios.Columns["CRMV_CRBio"].HeaderText = "CRMV/CRBio";

                dgvFuncionarios.Columns["NomeCompleto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvFuncionarios.Columns["Cargo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCadastroFuncionario telaCadastro = new frmCadastroFuncionario();
            telaCadastro.ShowDialog();
            CarregarGrid();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvFuncionarios.SelectedRows.Count > 0)
            {
                Funcionario funcionarioSelecionado = (Funcionario)dgvFuncionarios.SelectedRows[0].DataBoundItem;

                frmCadastroFuncionario telaCadastro = new frmCadastroFuncionario(funcionarioSelecionado);
                telaCadastro.ShowDialog();
                CarregarGrid();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um funcionário para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvFuncionarios.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja excluir este funcionário?",
                                                        "Confirmar Exclusão",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    Funcionario funcionarioSelecionado = (Funcionario)dgvFuncionarios.SelectedRows[0].DataBoundItem;
                    funcionarioController.Excluir(funcionarioSelecionado.IdFuncionario);
                    CarregarGrid();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um funcionário para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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