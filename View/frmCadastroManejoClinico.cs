using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;
using SistemaSilvestre.Model;
using SistemaSilvestre.Controller;

namespace SistemaSilvestre.View
{
    public partial class frmCadastroManejoClinico : Form
    {
        private ManejoClinicoController manejoController;
        private AnimalController animalController;
        private FuncionarioController funcionarioController;

        public ManejoClinico ManejoSelecionado { get; set; }

        public frmCadastroManejoClinico()
        {
            InitializeComponent();
            manejoController = new ManejoClinicoController();
            animalController = new AnimalController();
            funcionarioController = new FuncionarioController();
            LimparCampos();
        }

        public frmCadastroManejoClinico(ManejoClinico manejoParaEditar) : this()
        {
            ManejoSelecionado = manejoParaEditar;
            PreencherCampos(manejoParaEditar);
            this.Text = "Sistema Silvestre - Edição de Manejo";
        }

        private void frmCadastroManejoClinico_Load(object sender, EventArgs e)
        {
            dtpDataHoraManejo.Format = DateTimePickerFormat.Custom;
            dtpDataHoraManejo.CustomFormat = "dd/MM/yyyy HH:mm";

            CarregarComboBoxAnimal();
            CarregarComboBoxFuncionario();

            if (ManejoSelecionado != null)
            {
                cmbAnimal.SelectedValue = ManejoSelecionado.IdAnimal;
                cmbFuncionario.SelectedValue = ManejoSelecionado.IdFuncionario;
            }
        }

        private void CarregarComboBoxAnimal()
        {
            try
            {
                List<Animal> animais = animalController.ConsultarTodos();
                cmbAnimal.DataSource = animais;
                cmbAnimal.DisplayMember = "NomeIdentificacao";
                cmbAnimal.ValueMember = "IdAnimal";
                cmbAnimal.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar animais: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtIdManejo.Text = "0";
            cmbAnimal.SelectedIndex = -1;
            cmbFuncionario.SelectedIndex = -1;
            dtpDataHoraManejo.Value = DateTime.Now;
            txtPesoAferido.Clear();
            txtDescricaoProcedimento.Clear();
            cmbAnimal.Focus();
            ManejoSelecionado = null;
        }

        private void PreencherCampos(ManejoClinico manejo)
        {
            if (manejo != null)
            {
                txtIdManejo.Text = manejo.IdManejo.ToString();
                dtpDataHoraManejo.Value = manejo.DataHoraManejo;
                txtDescricaoProcedimento.Text = manejo.DescricaoProcedimento;
                txtPesoAferido.Text = manejo.PesoAferido?.ToString(CultureInfo.InvariantCulture); // Converte decimal para string
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ManejoClinico manejo = new ManejoClinico();

            if (ManejoSelecionado != null)
            {
                manejo.IdManejo = ManejoSelecionado.IdManejo;
            }

            manejo.DataHoraManejo = dtpDataHoraManejo.Value;
            manejo.DescricaoProcedimento = txtDescricaoProcedimento.Text;

            decimal pesoValue;
            if (string.IsNullOrWhiteSpace(txtPesoAferido.Text))
            {
                manejo.PesoAferido = null;
            }
            else if (decimal.TryParse(txtPesoAferido.Text, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out pesoValue))
            {
                manejo.PesoAferido = pesoValue;
            }
            else
            {
                MessageBox.Show("Peso inválido. Use ponto (.) como separador decimal (ex: 10.5).", "Erro de Formato", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbAnimal.SelectedValue != null)
            {
                manejo.IdAnimal = (int)cmbAnimal.SelectedValue;
            }
            else
            {
                manejo.IdAnimal = 0;
            }

            if (cmbFuncionario.SelectedValue != null)
            {
                manejo.IdFuncionario = (int)cmbFuncionario.SelectedValue;
            }
            else
            {
                manejo.IdFuncionario = 0;
            }

            manejoController.Salvar(manejo);

            if (manejo.IdManejo == 0)
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