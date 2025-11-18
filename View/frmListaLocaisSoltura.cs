using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaSilvestre.Model;
using SistemaSilvestre.Controller;

namespace SistemaSilvestre.View
{
    public partial class frmListaLocaisSoltura : Form
    {
        private LocalSolturaController localSolturaController;

        public frmListaLocaisSoltura()
        {
            InitializeComponent();
            localSolturaController = new LocalSolturaController();
        }

        private void frmListaLocaisSoltura_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            try
            {
                List<LocalSoltura> locaisSoltura = localSolturaController.ConsultarTodos();

                dgvLocaisSoltura.DataSource = null;
                dgvLocaisSoltura.DataSource = locaisSoltura;

                ConfigurarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar lista de locais de soltura: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrid()
        {
            if (dgvLocaisSoltura.Columns.Count > 0)
            {
                dgvLocaisSoltura.Columns["IdLocalSoltura"].Visible = false;

                dgvLocaisSoltura.Columns["NomeLocal"].HeaderText = "Nome do Local";
                dgvLocaisSoltura.Columns["Bioma"].HeaderText = "Bioma";
                dgvLocaisSoltura.Columns["CoordenadasGPS"].HeaderText = "Coordenadas";
                dgvLocaisSoltura.Columns["ResponsavelContato"].HeaderText = "Contato";

                dgvLocaisSoltura.Columns["NomeLocal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvLocaisSoltura.Columns["Bioma"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCadastroLocalSoltura telaCadastro = new frmCadastroLocalSoltura();
            telaCadastro.ShowDialog();
            CarregarGrid();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvLocaisSoltura.SelectedRows.Count > 0)
            {
                LocalSoltura localSelecionado = (LocalSoltura)dgvLocaisSoltura.SelectedRows[0].DataBoundItem;

                frmCadastroLocalSoltura telaCadastro = new frmCadastroLocalSoltura(localSelecionado);
                telaCadastro.ShowDialog();
                CarregarGrid();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um local para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvLocaisSoltura.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja excluir este local de soltura?",
                                                        "Confirmar Exclusão",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    LocalSoltura localSelecionado = (LocalSoltura)dgvLocaisSoltura.SelectedRows[0].DataBoundItem;
                    localSolturaController.Excluir(localSelecionado.IdLocalSoltura);
                    CarregarGrid();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um local para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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