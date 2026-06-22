namespace AppPetShop
{
    partial class FormBuscarConsultas
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
            this.campoId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.campoDesc = new System.Windows.Forms.TextBox();
            this.dtpDataConsulta = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.campoCodPet = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gridConsulta = new System.Windows.Forms.DataGridView();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnPesquisarTodos = new System.Windows.Forms.Button();
            this.btnFitrarCod = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridConsulta)).BeginInit();
            this.SuspendLayout();
            // 
            // campoId
            // 
            this.campoId.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campoId.Location = new System.Drawing.Point(171, 84);
            this.campoId.Name = "campoId";
            this.campoId.Size = new System.Drawing.Size(228, 26);
            this.campoId.TabIndex = 43;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(51, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 18);
            this.label2.TabIndex = 42;
            this.label2.Text = "ID Consulta";
            // 
            // campoDesc
            // 
            this.campoDesc.Location = new System.Drawing.Point(171, 226);
            this.campoDesc.Multiline = true;
            this.campoDesc.Name = "campoDesc";
            this.campoDesc.Size = new System.Drawing.Size(228, 199);
            this.campoDesc.TabIndex = 41;
            // 
            // dtpDataConsulta
            // 
            this.dtpDataConsulta.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDataConsulta.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDataConsulta.Location = new System.Drawing.Point(171, 182);
            this.dtpDataConsulta.Name = "dtpDataConsulta";
            this.dtpDataConsulta.Size = new System.Drawing.Size(228, 20);
            this.dtpDataConsulta.TabIndex = 40;
            this.dtpDataConsulta.Value = new System.DateTime(2026, 6, 21, 0, 0, 0, 0);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Gold;
            this.label5.Location = new System.Drawing.Point(298, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(202, 29);
            this.label5.TabIndex = 39;
            this.label5.Text = "Buscar Consulta";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(62, 226);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 18);
            this.label4.TabIndex = 38;
            this.label4.Text = "Descrição";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(12, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 18);
            this.label3.TabIndex = 37;
            this.label3.Text = "Data da consulta";
            // 
            // campoCodPet
            // 
            this.campoCodPet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campoCodPet.Location = new System.Drawing.Point(171, 131);
            this.campoCodPet.Name = "campoCodPet";
            this.campoCodPet.Size = new System.Drawing.Size(228, 26);
            this.campoCodPet.TabIndex = 36;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(55, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 18);
            this.label1.TabIndex = 35;
            this.label1.Text = "Codigo Pet";
            // 
            // gridConsulta
            // 
            this.gridConsulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridConsulta.BackgroundColor = System.Drawing.SystemColors.Info;
            this.gridConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridConsulta.Location = new System.Drawing.Point(460, 84);
            this.gridConsulta.Name = "gridConsulta";
            this.gridConsulta.RowHeadersWidth = 51;
            this.gridConsulta.Size = new System.Drawing.Size(424, 335);
            this.gridConsulta.TabIndex = 44;
            this.gridConsulta.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clicarCelula);
            // 
            // btnRemover
            // 
            this.btnRemover.BackColor = System.Drawing.Color.Gold;
            this.btnRemover.FlatAppearance.BorderSize = 2;
            this.btnRemover.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemover.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemover.Location = new System.Drawing.Point(40, 389);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(110, 30);
            this.btnRemover.TabIndex = 49;
            this.btnRemover.Text = "Remover serviço";
            this.btnRemover.UseVisualStyleBackColor = false;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.BackColor = System.Drawing.Color.Gold;
            this.btnLimpar.FlatAppearance.BorderSize = 2;
            this.btnLimpar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Location = new System.Drawing.Point(40, 355);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(110, 28);
            this.btnLimpar.TabIndex = 48;
            this.btnLimpar.Text = "Limpar Campos";
            this.btnLimpar.UseVisualStyleBackColor = false;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.BackColor = System.Drawing.Color.Gold;
            this.btnAlterar.FlatAppearance.BorderSize = 2;
            this.btnAlterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlterar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterar.Location = new System.Drawing.Point(40, 322);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(110, 27);
            this.btnAlterar.TabIndex = 47;
            this.btnAlterar.Text = "Alterar Consulta";
            this.btnAlterar.UseVisualStyleBackColor = false;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnPesquisarTodos
            // 
            this.btnPesquisarTodos.BackColor = System.Drawing.Color.Gold;
            this.btnPesquisarTodos.FlatAppearance.BorderSize = 2;
            this.btnPesquisarTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPesquisarTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisarTodos.Location = new System.Drawing.Point(40, 257);
            this.btnPesquisarTodos.Name = "btnPesquisarTodos";
            this.btnPesquisarTodos.Size = new System.Drawing.Size(110, 26);
            this.btnPesquisarTodos.TabIndex = 46;
            this.btnPesquisarTodos.Text = "Buscar Todos";
            this.btnPesquisarTodos.UseVisualStyleBackColor = false;
            this.btnPesquisarTodos.Click += new System.EventHandler(this.btnPesquisarTodos_Click);
            // 
            // btnFitrarCod
            // 
            this.btnFitrarCod.BackColor = System.Drawing.Color.Gold;
            this.btnFitrarCod.FlatAppearance.BorderSize = 2;
            this.btnFitrarCod.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFitrarCod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFitrarCod.Location = new System.Drawing.Point(40, 289);
            this.btnFitrarCod.Name = "btnFitrarCod";
            this.btnFitrarCod.Size = new System.Drawing.Size(110, 27);
            this.btnFitrarCod.TabIndex = 45;
            this.btnFitrarCod.Text = "Buscar Codigo";
            this.btnFitrarCod.UseVisualStyleBackColor = false;
            this.btnFitrarCod.Click += new System.EventHandler(this.btnFitrarCod_Click);
            // 
            // FormBuscarConsultas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(908, 448);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.btnPesquisarTodos);
            this.Controls.Add(this.btnFitrarCod);
            this.Controls.Add(this.gridConsulta);
            this.Controls.Add(this.campoId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.campoDesc);
            this.Controls.Add(this.dtpDataConsulta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.campoCodPet);
            this.Controls.Add(this.label1);
            this.Name = "FormBuscarConsultas";
            this.Text = "FormBuscarConsultas";
            ((System.ComponentModel.ISupportInitialize)(this.gridConsulta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox campoId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox campoDesc;
        private System.Windows.Forms.DateTimePicker dtpDataConsulta;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox campoCodPet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gridConsulta;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnPesquisarTodos;
        private System.Windows.Forms.Button btnFitrarCod;
    }
}