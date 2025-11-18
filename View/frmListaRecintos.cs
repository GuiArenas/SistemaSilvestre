using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaSilvestre.Model;
using SistemaSilvestre.Controller;

namespace SistemaSilvestre.View
{
    public partial class frmListaRecintos : Form
    {
        private RecintoController recintoController;

        public frmListaRecintos()
        {
            InitializeComponent();
            recintoController = new RecintoController();
        }

        private void frmListaRecintos_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            try
            {
                List<Recinto> recintos = recintoController.ConsultarTodos();

                dgvRecintos.DataSource = null;
                dgvRecintos.DataSource = recintos;

                ConfigurarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar lista de recintos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrid()
        {
            if (dgvRecintos.Columns.Count > 0)
            {
                dgvRecintos.Columns["IdRecinto"].Visible = false;

                dgvRecintos.Columns["CodigoRecinto"].HeaderText = "Código";
                dgvRecintos.Columns["TipoRecinto"].HeaderText = "Tipo";
                dgvRecintos.Columns["TamanhoM2"].HeaderText = "Tamanho (m²)";
                dgvRecintos.Columns["CapacidadeMaxima"].HeaderText = "Capacidade Máx.";

                dgvRecintos.Columns["CodigoRecinto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvRecintos.Columns["TipoRecinto"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCadastroRecinto telaCadastro = new frmCadastroRecinto();
            telaCadastro.ShowDialog();
            CarregarGrid();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvRecintos.SelectedRows.Count > 0)
            {
                Recinto recintoSelecionado = (Recinto)dgvRecintos.SelectedRows[0].DataBoundItem;

                frmCadastroRecinto telaCadastro = new frmCadastroRecinto(recintoSelecionado);
                telaCadastro.ShowDialog();
                CarregarGrid();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um recinto para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvRecintos.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja excluir este recinto?",
                                                        "Confirmar Exclusão",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    Recinto recintoSelecionado = (Recinto)dgvRecintos.SelectedRows[0].DataBoundItem;
                    recintoController.Excluir(recintoSelecionado.IdRecinto);
                    CarregarGrid();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um recinto para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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