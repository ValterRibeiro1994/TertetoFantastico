namespace Proj_Escola_BD
{
    partial class listagem
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
            this.btnAlunos = new System.Windows.Forms.Button();
            this.btnAniver = new System.Windows.Forms.Button();
            this.btnPagamentos = new System.Windows.Forms.Button();
            this.btnDesconto = new System.Windows.Forms.Button();
            this.gridLista = new System.Windows.Forms.DataGridView();
            this.dtpInput = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.gridLista)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAlunos
            // 
            this.btnAlunos.Location = new System.Drawing.Point(642, 59);
            this.btnAlunos.Name = "btnAlunos";
            this.btnAlunos.Size = new System.Drawing.Size(87, 23);
            this.btnAlunos.TabIndex = 0;
            this.btnAlunos.Text = "Alunos";
            this.btnAlunos.UseVisualStyleBackColor = true;
            this.btnAlunos.Click += new System.EventHandler(this.btnAlunos_Click);
            // 
            // btnAniver
            // 
            this.btnAniver.Location = new System.Drawing.Point(642, 198);
            this.btnAniver.Name = "btnAniver";
            this.btnAniver.Size = new System.Drawing.Size(87, 23);
            this.btnAniver.TabIndex = 1;
            this.btnAniver.Text = "Aniversariantes";
            this.btnAniver.UseVisualStyleBackColor = true;
            this.btnAniver.Click += new System.EventHandler(this.btnAniver_Click);
            // 
            // btnPagamentos
            // 
            this.btnPagamentos.Location = new System.Drawing.Point(642, 152);
            this.btnPagamentos.Name = "btnPagamentos";
            this.btnPagamentos.Size = new System.Drawing.Size(87, 23);
            this.btnPagamentos.TabIndex = 2;
            this.btnPagamentos.Text = "Pagamentos";
            this.btnPagamentos.UseVisualStyleBackColor = true;
            this.btnPagamentos.Click += new System.EventHandler(this.btnPagamentos_Click);
            // 
            // btnDesconto
            // 
            this.btnDesconto.Location = new System.Drawing.Point(642, 239);
            this.btnDesconto.Name = "btnDesconto";
            this.btnDesconto.Size = new System.Drawing.Size(87, 23);
            this.btnDesconto.TabIndex = 3;
            this.btnDesconto.Text = "Descontos";
            this.btnDesconto.UseVisualStyleBackColor = true;
            this.btnDesconto.Click += new System.EventHandler(this.btnDesconto_Click);
            // 
            // gridLista
            // 
            this.gridLista.BackgroundColor = System.Drawing.Color.CadetBlue;
            this.gridLista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridLista.Location = new System.Drawing.Point(56, 59);
            this.gridLista.Name = "gridLista";
            this.gridLista.Size = new System.Drawing.Size(529, 379);
            this.gridLista.TabIndex = 4;
            // 
            // dtpInput
            // 
            this.dtpInput.CustomFormat = "";
            this.dtpInput.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpInput.Location = new System.Drawing.Point(642, 106);
            this.dtpInput.Name = "dtpInput";
            this.dtpInput.Size = new System.Drawing.Size(87, 20);
            this.dtpInput.TabIndex = 5;
            this.dtpInput.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // listagem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(855, 450);
            this.Controls.Add(this.dtpInput);
            this.Controls.Add(this.gridLista);
            this.Controls.Add(this.btnDesconto);
            this.Controls.Add(this.btnPagamentos);
            this.Controls.Add(this.btnAniver);
            this.Controls.Add(this.btnAlunos);
            this.Name = "listagem";
            this.Text = "listagem";
            ((System.ComponentModel.ISupportInitialize)(this.gridLista)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAlunos;
        private System.Windows.Forms.Button btnAniver;
        private System.Windows.Forms.Button btnPagamentos;
        private System.Windows.Forms.Button btnDesconto;
        private System.Windows.Forms.DataGridView gridLista;
        private System.Windows.Forms.DateTimePicker dtpInput;
    }
}