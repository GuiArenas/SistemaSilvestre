using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SistemaSilvestre.Model;
using SistemaSilvestre.Controller;

namespace SistemaSilvestre.View
{
    public partial class frmCadastroAnimal : Form
    {
        private AnimalController animalController;
        private EspecieController especieController;
        private RecintoController recintoController;

        public Animal AnimalSelecionado { get; set; }

        public frmCadastroAnimal()
        {
            InitializeComponent();
            animalController = new AnimalController();
            especieController = new EspecieController();
            recintoController = new RecintoController();
            LimparCampos();
        }

        public frmCadastroAnimal(Animal animalParaEditar) : this()
        {
            AnimalSelecionado = animalParaEditar;
            PreencherCampos(animalParaEditar);
            this.Text = "Sistema Silvestre - Edição de Animal";
        }

        private void frmCadastroAnimal_Load(object sender, EventArgs e)
        {
            CarregarComboBoxEspecie();
            CarregarComboBoxRecinto();

            if (AnimalSelecionado == null)
            {
                cmbStatusSaude.SelectedIndex = 0; 
            }
        }

        private void CarregarComboBoxEspecie()
        {
            try
            {
                List<Especie> especies = especieController.ConsultarTodos();
                cmbEspecie.DataSource = especies;
                cmbEspecie.DisplayMember = "NomePopular";
                cmbEspecie.ValueMember = "IdEspecie";
                cmbEspecie.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar espécies: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CarregarComboBoxRecinto()
        {
            try
            {
                List<Recinto> recintos = recintoController.ConsultarTodos();
                cmbRecinto.DataSource = recintos;
                cmbRecinto.DisplayMember = "CodigoRecinto";
                cmbRecinto.ValueMember = "IdRecinto";
                cmbRecinto.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar recintos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparCampos()
        {
            txtIdAnimal.Text = "0";
            txtNomeIdentificacao.Clear(); 
            cmbEspecie.SelectedIndex = -1;
            cmbRecinto.SelectedIndex = -1;
            cmbStatusSaude.SelectedIndex = -1;
            dtpDataEntrada.Value = DateTime.Now;

            dtpDataSaida.Checked = false;

            txtMotivoEntrada.Clear();
            txtOrigem.Clear();
            txtObservacoes.Clear();
            txtNomeIdentificacao.Focus(); 
            AnimalSelecionado = null;
        }

        private void PreencherCampos(Animal animal)
        {
            if (animal != null)
            {
                txtIdAnimal.Text = animal.IdAnimal.ToString();
                txtNomeIdentificacao.Text = animal.NomeIdentificacao; 
                cmbEspecie.SelectedValue = animal.IdEspecie;
                cmbRecinto.SelectedValue = animal.IdRecinto;
                cmbStatusSaude.SelectedItem = animal.StatusAnimal;
                dtpDataEntrada.Value = animal.DataEntrada;

                if (animal.DataSaida.HasValue)
                {
                    dtpDataSaida.Checked = true;
                    dtpDataSaida.Value = animal.DataSaida.Value;
                }
                else
                {
                    dtpDataSaida.Checked = false;
                }

                txtMotivoEntrada.Text = animal.MotivoEntrada;
                txtOrigem.Text = animal.Origem;
                txtObservacoes.Text = animal.Observacoes;
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Animal animal = new Animal();

            if (AnimalSelecionado != null)
            {
                animal.IdAnimal = AnimalSelecionado.IdAnimal;
            }

            animal.NomeIdentificacao = txtNomeIdentificacao.Text; 
            animal.StatusAnimal = cmbStatusSaude.SelectedItem?.ToString();
            animal.DataEntrada = dtpDataEntrada.Value;

            if (dtpDataSaida.Checked)
            {
                animal.DataSaida = dtpDataSaida.Value;
            }
            else
            {
                animal.DataSaida = null;
            }

            animal.MotivoEntrada = txtMotivoEntrada.Text;
            animal.Origem = txtOrigem.Text;
            animal.Observacoes = txtObservacoes.Text;

            if (cmbEspecie.SelectedValue != null)
            {
                animal.IdEspecie = (int)cmbEspecie.SelectedValue;
            }
            else
            {
                animal.IdEspecie = 0;
            }

            if (cmbRecinto.SelectedValue != null)
            {
                animal.IdRecinto = (int)cmbRecinto.SelectedValue;
            }
            else
            {
                animal.IdRecinto = 0;
            }

            animalController.Salvar(animal);

            if (animal.IdAnimal == 0)
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