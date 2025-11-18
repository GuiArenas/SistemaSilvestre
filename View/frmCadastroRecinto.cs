using System;
using System.Windows.Forms;
using SistemaSilvestre.Model;
using SistemaSilvestre.Controller;

namespace SistemaSilvestre.View
{
    public partial class frmCadastroRecinto : Form
    {
        private RecintoController recintoController;
        public Recinto RecintoSelecionado { get; set; }

        public frmCadastroRecinto()
        {
            InitializeComponent();
            recintoController = new RecintoController();
            LimparCampos();
        }

        public frmCadastroRecinto(Recinto recintoParaEditar) : this()
        {
            RecintoSelecionado = recintoParaEditar;
            PreencherCampos(recintoParaEditar);
            this.Text = "Sistema Silvestre - Edição de Recinto";
        }

        private void LimparCampos()
        {
            txtIdRecinto.Text = "0";
            txtCodigoRecinto.Clear();
            txtTipoRecinto.Clear();
            txtTamanhoM2.Clear();
            txtCapacidadeMaxima.Clear();
            txtCodigoRecinto.Focus();
            RecintoSelecionado = null;
        }

        private void PreencherCampos(Recinto recinto)
        {
            if (recinto != null)
            {
                txtIdRecinto.Text = recinto.IdRecinto.ToString();
                txtCodigoRecinto.Text = recinto.CodigoRecinto;
                txtTipoRecinto.Text = recinto.TipoRecinto;
                txtTamanhoM2.Text = recinto.TamanhoM2?.ToString();
                txtCapacidadeMaxima.Text = recinto.CapacidadeMaxima?.ToString();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Recinto recinto = new Recinto();

            if (RecintoSelecionado != null)
            {
                recinto.IdRecinto = RecintoSelecionado.IdRecinto;
            }

            recinto.CodigoRecinto = txtCodigoRecinto.Text;
            recinto.TipoRecinto = txtTipoRecinto.Text;

            decimal tamanho;
            if (string.IsNullOrWhiteSpace(txtTamanhoM2.Text))
            {
                recinto.TamanhoM2 = null;
            }
            else if (Decimal.TryParse(txtTamanhoM2.Text, out tamanho))
            {
                recinto.TamanhoM2 = tamanho;
            }
            else
            {
                MessageBox.Show("Valor inválido para Tamanho (m²). Use apenas números.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int capacidade;
            if (string.IsNullOrWhiteSpace(txtCapacidadeMaxima.Text))
            {
                recinto.CapacidadeMaxima = null;
            }
            else if (Int32.TryParse(txtCapacidadeMaxima.Text, out capacidade))
            {
                recinto.CapacidadeMaxima = capacidade;
            }
            else
            {
                MessageBox.Show("Valor inválido para Capacidade Máxima. Use apenas números inteiros.", "Erro de Validação", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            recintoController.Salvar(recinto);

            if (recinto.IdRecinto == 0)
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