using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaSilvestre.Model;
using SistemaSilvestre.Controller;

namespace SistemaSilvestre.View
{
    public partial class frmListaManejosClinicos : Form
    {
        private ManejoClinicoController manejoController;

        public frmListaManejosClinicos()
        {
            InitializeComponent();
            manejoController = new ManejoClinicoController();
        }

        private void frmListaManejosClinicos_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            try
            {
                List<ManejoClinico> manejos = manejoController.ConsultarTodos();
                dgvManejos.DataSource = null;
                dgvManejos.DataSource = manejos;
                ConfigurarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar lista de manejos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrid()
        {
            if (dgvManejos.Columns.Count > 0)
            {
                dgvManejos.Columns["IdManejo"].Visible = false;
                dgvManejos.Columns["IdAnimal"].Visible = false;
                dgvManejos.Columns["IdFuncionario"].Visible = false;

                dgvManejos.Columns["DescricaoProcedimento"].Visible = false;

                dgvManejos.Columns["DataHoraManejo"].HeaderText = "Data/Hora";
                dgvManejos.Columns["PesoAferido"].HeaderText = "Peso (kg)";
                dgvManejos.Columns["NomeIdentificacaoAnimal"].HeaderText = "Animal";
                dgvManejos.Columns["NomeFuncionario"].HeaderText = "Responsável";

                dgvManejos.Columns["DataHoraManejo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvManejos.Columns["PesoAferido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvManejos.Columns["NomeIdentificacaoAnimal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvManejos.Columns["NomeFuncionario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCadastroManejoClinico telaCadastro = new frmCadastroManejoClinico();
            telaCadastro.ShowDialog();
            CarregarGrid();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvManejos.SelectedRows.Count > 0)
            {
                ManejoClinico manejoSelecionado = (ManejoClinico)dgvManejos.SelectedRows[0].DataBoundItem;
                frmCadastroManejoClinico telaCadastro = new frmCadastroManejoClinico(manejoSelecionado);
                telaCadastro.ShowDialog();
                CarregarGrid();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um manejo para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvManejos.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja excluir este registro de manejo?",
                                                        "Confirmar Exclusão",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    ManejoClinico manejoSelecionado = (ManejoClinico)dgvManejos.SelectedRows[0].DataBoundItem;
                    manejoController.Excluir(manejoSelecionado.IdManejo);
                    CarregarGrid();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um manejo para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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