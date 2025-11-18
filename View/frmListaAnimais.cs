using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaSilvestre.Model;
using SistemaSilvestre.Controller;

namespace SistemaSilvestre.View
{
    public partial class frmListaAnimais : Form
    {
        private AnimalController animalController;

        public frmListaAnimais()
        {
            InitializeComponent();
            animalController = new AnimalController();
        }

        private void frmListaAnimais_Load(object sender, EventArgs e)
        {
            CarregarGrid();
        }

        private void CarregarGrid()
        {
            try
            {
                List<Animal> animais = animalController.ConsultarTodos();

                dgvAnimais.DataSource = null;
                dgvAnimais.DataSource = animais;

                ConfigurarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar lista de animais: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigurarGrid()
        {
            if (dgvAnimais.Columns.Count > 0)
            {
                dgvAnimais.Columns["IdAnimal"].Visible = false;
                dgvAnimais.Columns["IdEspecie"].Visible = false;
                dgvAnimais.Columns["IdRecinto"].Visible = false;

                dgvAnimais.Columns["MotivoEntrada"].Visible = false;
                dgvAnimais.Columns["Origem"].Visible = false;
                dgvAnimais.Columns["Observacoes"].Visible = false;
                dgvAnimais.Columns["DataSaida"].Visible = false;

                dgvAnimais.Columns["NomeIdentificacao"].HeaderText = "Identificador"; 
                dgvAnimais.Columns["NomeEspecie"].HeaderText = "Espécie";
                dgvAnimais.Columns["CodigoRecinto"].HeaderText = "Recinto";
                dgvAnimais.Columns["StatusAnimal"].HeaderText = "Status"; 
                dgvAnimais.Columns["DataEntrada"].HeaderText = "Entrada";

                dgvAnimais.Columns["NomeIdentificacao"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; 
                dgvAnimais.Columns["NomeEspecie"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvAnimais.Columns["StatusAnimal"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells; 
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            frmCadastroAnimal telaCadastro = new frmCadastroAnimal();
            telaCadastro.ShowDialog();
            CarregarGrid();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvAnimais.SelectedRows.Count > 0)
            {
                Animal animalSelecionado = (Animal)dgvAnimais.SelectedRows[0].DataBoundItem;

                frmCadastroAnimal telaCadastro = new frmCadastroAnimal(animalSelecionado);
                telaCadastro.ShowDialog();
                CarregarGrid();
            }
            else
            {
                MessageBox.Show("Por favor, selecione um animal para editar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvAnimais.SelectedRows.Count > 0)
            {
                DialogResult resultado = MessageBox.Show("Tem certeza que deseja excluir este animal?",
                                                        "Confirmar Exclusão",
                                                        MessageBoxButtons.YesNo,
                                                        MessageBoxIcon.Warning);

                if (resultado == DialogResult.Yes)
                {
                    Animal animalSelecionado = (Animal)dgvAnimais.SelectedRows[0].DataBoundItem;
                    animalController.Excluir(animalSelecionado.IdAnimal);
                    CarregarGrid();
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione um animal para excluir.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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