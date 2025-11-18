namespace SistemaSilvestre.View
{
    partial class frmCadastroManejoClinico
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPesoAferido = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpDataHoraManejo = new System.Windows.Forms.DateTimePicker();
            this.cmbFuncionario = new System.Windows.Forms.ComboBox();
            this.cmbAnimal = new System.Windows.Forms.ComboBox();
            this.txtDescricaoProcedimento = new System.Windows.Forms.TextBox();
            this.txtIdManejo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(169, 9);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(329, 37);
            this.label1.TabIndex = 11;
            this.label1.Text = "Cadastro de Funcionário";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtPesoAferido);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.dtpDataHoraManejo);
            this.groupBox1.Controls.Add(this.cmbFuncionario);
            this.groupBox1.Controls.Add(this.cmbAnimal);
            this.groupBox1.Controls.Add(this.txtDescricaoProcedimento);
            this.groupBox1.Controls.Add(this.txtIdManejo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(650, 262);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados do Manejo";
            // 
            // txtPesoAferido
            // 
            this.txtPesoAferido.Location = new System.Drawing.Point(448, 58);
            this.txtPesoAferido.Name = "txtPesoAferido";
            this.txtPesoAferido.Size = new System.Drawing.Size(138, 20);
            this.txtPesoAferido.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(472, 35);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Peso Aferido (kg):";
            // 
            // dtpDataHoraManejo
            // 
            this.dtpDataHoraManejo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataHoraManejo.Location = new System.Drawing.Point(164, 203);
            this.dtpDataHoraManejo.Name = "dtpDataHoraManejo";
            this.dtpDataHoraManejo.Size = new System.Drawing.Size(140, 20);
            this.dtpDataHoraManejo.TabIndex = 26;
            // 
            // cmbFuncionario
            // 
            this.cmbFuncionario.FormattingEnabled = true;
            this.cmbFuncionario.Location = new System.Drawing.Point(164, 143);
            this.cmbFuncionario.Name = "cmbFuncionario";
            this.cmbFuncionario.Size = new System.Drawing.Size(140, 21);
            this.cmbFuncionario.TabIndex = 25;
            // 
            // cmbAnimal
            // 
            this.cmbAnimal.FormattingEnabled = true;
            this.cmbAnimal.Location = new System.Drawing.Point(164, 82);
            this.cmbAnimal.Name = "cmbAnimal";
            this.cmbAnimal.Size = new System.Drawing.Size(140, 21);
            this.cmbAnimal.TabIndex = 24;
            // 
            // txtDescricaoProcedimento
            // 
            this.txtDescricaoProcedimento.Location = new System.Drawing.Point(409, 121);
            this.txtDescricaoProcedimento.Multiline = true;
            this.txtDescricaoProcedimento.Name = "txtDescricaoProcedimento";
            this.txtDescricaoProcedimento.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescricaoProcedimento.Size = new System.Drawing.Size(206, 93);
            this.txtDescricaoProcedimento.TabIndex = 22;
            // 
            // txtIdManejo
            // 
            this.txtIdManejo.Location = new System.Drawing.Point(164, 31);
            this.txtIdManejo.Name = "txtIdManejo";
            this.txtIdManejo.ReadOnly = true;
            this.txtIdManejo.Size = new System.Drawing.Size(140, 20);
            this.txtIdManejo.TabIndex = 20;
            this.txtIdManejo.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(445, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(141, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Descrição do Procedimento:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 209);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Data/Hora do Manejo:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Funcionário Responsável:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Animal:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "ID Manejo:";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(587, 353);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 28;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalvar.Location = new System.Drawing.Point(500, 353);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 27;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // frmCadastroManejoClinico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(674, 388);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmCadastroManejoClinico";
            this.Text = "frmCadastroManejoClinico";
            this.Load += new System.EventHandler(this.frmCadastroManejoClinico_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.ComboBox cmbFuncionario;
        private System.Windows.Forms.ComboBox cmbAnimal;
        private System.Windows.Forms.TextBox txtDescricaoProcedimento;
        private System.Windows.Forms.TextBox txtIdManejo;
        private System.Windows.Forms.DateTimePicker dtpDataHoraManejo;
        private System.Windows.Forms.TextBox txtPesoAferido;
        private System.Windows.Forms.Label label6;
    }
}