using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaSilvestre.Model;      
using SistemaSilvestre.Controller; 

namespace SistemaSilvestre.View
{
    public partial class frmListaEspecies : Form
    {
        private EspecieController especieController;

        public frmListaEspecies()
        {
            InitializeComponent();
            especieController = new EspecieController(); 
        }

        private void frmListaEspecies_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            try
            {
                List<Especie> especies = especieController.ConsultarTodos();

                dgvEspecies.DataSource = null; 
                dgvEspecies.DataSource = especies;

                ConfigurarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar lista de espécies: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrid()
        {
            if (dgvEspecies.Columns.Count > 0)
            {
                dgvEspecies.Columns["IdEspecie"].Visible = false;

                dgvEspecies.Columns["NomePopular"].HeaderText = "Nome Popular";
                dgvEspecies.Columns["NomeCientifico"].HeaderText = "Nome Científico";
                dgvEspecies.Columns["DietaPadrao"].HeaderText = "Dieta";
                dgvEspecies.Columns["Observacoes"].HeaderText = "Observações";

                dgvEspecies.Columns["NomePopular"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvEspecies.Columns["NomeCientifico"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }
        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCadastroEspecie telaCadastro = new frmCadastroEspecie();
            telaCadastro.ShowDialog(); 

            CarregarGrid();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvEspecies.SelectedRows.Count > 0)
            {
                Especie especieSelecionada = (Especie)dgvEspecies.SelectedRows[0].DataBoundItem;

                frmCadastroEspecie telaCadastro = new frmCadastroEspecie(especieSelecionada);
                telaCadastro.ShowDialog();

                CarregarGrid();
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma espécie para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvEspecies.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja excluir esta espécie? (Esta ação não pode ser desfeita)",
                                                        "Confirmar Exclusão",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    Especie especieSelecionada = (Especie)dgvEspecies.SelectedRows[0].DataBoundItem;

                    especieController.Excluir(especieSelecionada.IdEspecie);

                    CarregarGrid();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma espécie para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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