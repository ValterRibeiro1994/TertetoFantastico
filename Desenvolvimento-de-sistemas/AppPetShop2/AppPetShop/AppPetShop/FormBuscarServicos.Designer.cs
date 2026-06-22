namespace AppPetShop
{
    partial class FormBuscarServicos
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
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.gridServico = new System.Windows.Forms.DataGridView();
            this.btnPesquisarTodos = new System.Windows.Forms.Button();
            this.btnFitrarCod = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.campoCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.campoValor = new System.Windows.Forms.TextBox();
            this.campoData = new System.Windows.Forms.DateTimePicker();
            this.campoTipo = new System.Windows.Forms.ComboBox();
            this.campoId = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridServico)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRemover
            // 
            this.btnRemover.BackColor = System.Drawing.Color.Gold;
            this.btnRemover.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemover.Location = new System.Drawing.Point(355, 210);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(128, 23);
            this.btnRemover.TabIndex = 29;
            this.btnRemover.Text = "Remover serviço";
            this.btnRemover.UseVisualStyleBackColor = false;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.Color.Gold;
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Location = new System.Drawing.Point(355, 254);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(128, 23);
            this.btnLimpar.TabIndex = 28;
            this.btnLimpar.Text = "Limpar Campos";
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.BackColor = System.Drawing.Color.Gold;
            this.btnAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Location = new System.Drawing.Point(355, 167);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(128, 23);
            this.btnAlterar.TabIndex = 27;
            this.btnAlterar.Text = "Alterar Serviço";
            this.btnAlterar.UseVisualStyleBackColor = false;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // gridServico
            // 
            this.gridServico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridServico.BackgroundColor = System.Drawing.SystemColors.Info;
            this.gridServico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridServico.Location = new System.Drawing.Point(527, 71);
            this.gridServico.Name = "gridServico";
            this.gridServico.RowHeadersWidth = 51;
            this.gridServico.Size = new System.Drawing.Size(365, 276);
            this.gridServico.TabIndex = 26;
            this.gridServico.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clicarCelula);
            // 
            // btnPesquisarTodos
            // 
            this.btnPesquisarTodos.BackColor = System.Drawing.Color.Gold;
            this.btnPesquisarTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisarTodos.Location = new System.Drawing.Point(355, 71);
            this.btnPesquisarTodos.Name = "btnPesquisarTodos";
            this.btnPesquisarTodos.Size = new System.Drawing.Size(128, 23);
            this.btnPesquisarTodos.TabIndex = 25;
            this.btnPesquisarTodos.Text = "Buscar Todos";
            this.btnPesquisarTodos.UseVisualStyleBackColor = false;
            this.btnPesquisarTodos.Click += new System.EventHandler(this.btnPesquisarTodos_Click);
            // 
            // btnFitrarCod
            // 
            this.btnFitrarCod.BackColor = System.Drawing.Color.Gold;
            this.btnFitrarCod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFitrarCod.Location = new System.Drawing.Point(355, 117);
            this.btnFitrarCod.Name = "btnFitrarCod";
            this.btnFitrarCod.Size = new System.Drawing.Size(128, 23);
            this.btnFitrarCod.TabIndex = 24;
            this.btnFitrarCod.Text = "Buscar Codigo";
            this.btnFitrarCod.UseVisualStyleBackColor = false;
            this.btnFitrarCod.Click += new System.EventHandler(this.btnFitrarCod_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gold;
            this.label1.Location = new System.Drawing.Point(240, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(276, 36);
            this.label1.TabIndex = 15;
            this.label1.Text = "Localizar Serviços";
            // 
            // campoCodigo
            // 
            this.campoCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campoCodigo.Location = new System.Drawing.Point(159, 118);
            this.campoCodigo.Name = "campoCodigo";
            this.campoCodigo.Size = new System.Drawing.Size(179, 26);
            this.campoCodigo.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(50, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 18);
            this.label2.TabIndex = 17;
            this.label2.Text = "Codigo Pet";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(19, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 18);
            this.label3.TabIndex = 18;
            this.label3.Text = "Tipo de Serviço";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(17, 215);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 18);
            this.label4.TabIndex = 19;
            this.label4.Text = "Data do Serviço";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(14, 259);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 18);
            this.label5.TabIndex = 20;
            this.label5.Text = "Valor do Serviço";
            // 
            // campoValor
            // 
            this.campoValor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campoValor.Location = new System.Drawing.Point(159, 255);
            this.campoValor.Name = "campoValor";
            this.campoValor.Size = new System.Drawing.Size(179, 26);
            this.campoValor.TabIndex = 23;
            // 
            // campoData
            // 
            this.campoData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campoData.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.campoData.Location = new System.Drawing.Point(159, 211);
            this.campoData.Name = "campoData";
            this.campoData.Size = new System.Drawing.Size(179, 24);
            this.campoData.TabIndex = 30;
            // 
            // campoTipo
            // 
            this.campoTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campoTipo.FormattingEnabled = true;
            this.campoTipo.Items.AddRange(new object[] {
            "banho",
            "tosa"});
            this.campoTipo.Location = new System.Drawing.Point(159, 165);
            this.campoTipo.Name = "campoTipo";
            this.campoTipo.Size = new System.Drawing.Size(179, 25);
            this.campoTipo.TabIndex = 31;
            // 
            // campoId
            // 
            this.campoId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campoId.Location = new System.Drawing.Point(159, 71);
            this.campoId.Name = "campoId";
            this.campoId.Size = new System.Drawing.Size(179, 24);
            this.campoId.TabIndex = 32;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(64, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 13);
            this.label6.TabIndex = 33;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.Window;
            this.label7.Location = new System.Drawing.Point(56, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 18);
            this.label7.TabIndex = 34;
            this.label7.Text = "ID serviço";
            // 
            // FormBuscarServicos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1062, 379);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.campoId);
            this.Controls.Add(this.campoTipo);
            this.Controls.Add(this.campoData);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.gridServico);
            this.Controls.Add(this.btnPesquisarTodos);
            this.Controls.Add(this.btnFitrarCod);
            this.Controls.Add(this.campoValor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.campoCodigo);
            this.Controls.Add(this.label1);
            this.Name = "FormBuscarServicos";
            this.Text = "FormBuscarServicos";
            ((System.ComponentModel.ISupportInitialize)(this.gridServico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.DataGridView gridServico;
        private System.Windows.Forms.Button btnPesquisarTodos;
        private System.Windows.Forms.Button btnFitrarCod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox campoCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox campoValor;
        private System.Windows.Forms.DateTimePicker campoData;
        private System.Windows.Forms.ComboBox campoTipo;
        private System.Windows.Forms.TextBox campoId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}