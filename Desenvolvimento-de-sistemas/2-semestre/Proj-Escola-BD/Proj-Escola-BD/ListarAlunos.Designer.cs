namespace Proj_Escola_BD
{
    partial class ListarAlunos
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
            this.gridAlunos = new System.Windows.Forms.DataGridView();
            this.outputFoto = new System.Windows.Forms.PictureBox();
            this.btnListarAlunos = new System.Windows.Forms.Button();
            this.btnAniversariantes = new System.Windows.Forms.Button();
            this.dataAtual = new System.Windows.Forms.DateTimePicker();
            this.btnDesconto = new System.Windows.Forms.Button();
            this.btnPagamentos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.inputDataDe = new System.Windows.Forms.DateTimePicker();
            this.inputDataAte = new System.Windows.Forms.DateTimePicker();
            this.lblDataDe = new System.Windows.Forms.Label();
            this.lblDataAte = new System.Windows.Forms.Label();
            this.checkFiltro = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.gridAlunos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // gridAlunos
            // 
            this.gridAlunos.BackgroundColor = System.Drawing.SystemColors.WindowText;
            this.gridAlunos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAlunos.Location = new System.Drawing.Point(12, 33);
            this.gridAlunos.Name = "gridAlunos";
            this.gridAlunos.Size = new System.Drawing.Size(765, 470);
            this.gridAlunos.TabIndex = 0;
            this.gridAlunos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridAlunos_MouseClick);
            // 
            // outputFoto
            // 
            this.outputFoto.Location = new System.Drawing.Point(799, 33);
            this.outputFoto.Name = "outputFoto";
            this.outputFoto.Size = new System.Drawing.Size(195, 176);
            this.outputFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.outputFoto.TabIndex = 1;
            this.outputFoto.TabStop = false;
            // 
            // btnListarAlunos
            // 
            this.btnListarAlunos.Location = new System.Drawing.Point(799, 225);
            this.btnListarAlunos.Name = "btnListarAlunos";
            this.btnListarAlunos.Size = new System.Drawing.Size(195, 23);
            this.btnListarAlunos.TabIndex = 2;
            this.btnListarAlunos.Text = "Listar Alunos";
            this.btnListarAlunos.UseVisualStyleBackColor = true;
            this.btnListarAlunos.Click += new System.EventHandler(this.btnListarAlunos_Click);
            // 
            // btnAniversariantes
            // 
            this.btnAniversariantes.Location = new System.Drawing.Point(799, 254);
            this.btnAniversariantes.Name = "btnAniversariantes";
            this.btnAniversariantes.Size = new System.Drawing.Size(195, 23);
            this.btnAniversariantes.TabIndex = 3;
            this.btnAniversariantes.Text = "Aniversariantes do Mês";
            this.btnAniversariantes.UseVisualStyleBackColor = true;
            this.btnAniversariantes.Click += new System.EventHandler(this.btnAniversariantes_Click);
            // 
            // dataAtual
            // 
            this.dataAtual.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dataAtual.Location = new System.Drawing.Point(82, 7);
            this.dataAtual.Name = "dataAtual";
            this.dataAtual.Size = new System.Drawing.Size(195, 20);
            this.dataAtual.TabIndex = 4;
            // 
            // btnDesconto
            // 
            this.btnDesconto.Location = new System.Drawing.Point(799, 397);
            this.btnDesconto.Name = "btnDesconto";
            this.btnDesconto.Size = new System.Drawing.Size(195, 23);
            this.btnDesconto.TabIndex = 6;
            this.btnDesconto.Text = "Descontos do Mês";
            this.btnDesconto.UseVisualStyleBackColor = true;
            this.btnDesconto.Click += new System.EventHandler(this.btnDesconto_Click);
            // 
            // btnPagamentos
            // 
            this.btnPagamentos.Location = new System.Drawing.Point(799, 368);
            this.btnPagamentos.Name = "btnPagamentos";
            this.btnPagamentos.Size = new System.Drawing.Size(195, 23);
            this.btnPagamentos.TabIndex = 7;
            this.btnPagamentos.Text = "Pagamentos do Mês";
            this.btnPagamentos.UseVisualStyleBackColor = true;
            this.btnPagamentos.Click += new System.EventHandler(this.btnPagamentos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Data Atual: ";
            // 
            // inputDataDe
            // 
            this.inputDataDe.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.inputDataDe.Location = new System.Drawing.Point(838, 306);
            this.inputDataDe.Name = "inputDataDe";
            this.inputDataDe.Size = new System.Drawing.Size(156, 20);
            this.inputDataDe.TabIndex = 9;
            this.inputDataDe.Visible = false;
            // 
            // inputDataAte
            // 
            this.inputDataAte.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.inputDataAte.Location = new System.Drawing.Point(839, 332);
            this.inputDataAte.Name = "inputDataAte";
            this.inputDataAte.Size = new System.Drawing.Size(155, 20);
            this.inputDataAte.TabIndex = 10;
            this.inputDataAte.Visible = false;
            // 
            // lblDataDe
            // 
            this.lblDataDe.AutoSize = true;
            this.lblDataDe.Location = new System.Drawing.Point(796, 312);
            this.lblDataDe.Name = "lblDataDe";
            this.lblDataDe.Size = new System.Drawing.Size(27, 13);
            this.lblDataDe.TabIndex = 11;
            this.lblDataDe.Text = "De: ";
            this.lblDataDe.Visible = false;
            // 
            // lblDataAte
            // 
            this.lblDataAte.AutoSize = true;
            this.lblDataAte.Location = new System.Drawing.Point(795, 338);
            this.lblDataAte.Name = "lblDataAte";
            this.lblDataAte.Size = new System.Drawing.Size(28, 13);
            this.lblDataAte.TabIndex = 12;
            this.lblDataAte.Text = "até: ";
            this.lblDataAte.Visible = false;
            // 
            // checkFiltro
            // 
            this.checkFiltro.AutoSize = true;
            this.checkFiltro.Location = new System.Drawing.Point(799, 283);
            this.checkFiltro.Name = "checkFiltro";
            this.checkFiltro.Size = new System.Drawing.Size(95, 17);
            this.checkFiltro.TabIndex = 13;
            this.checkFiltro.Text = "Filtrar por Data";
            this.checkFiltro.UseVisualStyleBackColor = true;
            this.checkFiltro.CheckedChanged += new System.EventHandler(this.checkFiltro_CheckedChanged);
            // 
            // ListarAlunos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.ClientSize = new System.Drawing.Size(1018, 515);
            this.Controls.Add(this.checkFiltro);
            this.Controls.Add(this.lblDataAte);
            this.Controls.Add(this.lblDataDe);
            this.Controls.Add(this.inputDataAte);
            this.Controls.Add(this.inputDataDe);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPagamentos);
            this.Controls.Add(this.btnDesconto);
            this.Controls.Add(this.dataAtual);
            this.Controls.Add(this.btnAniversariantes);
            this.Controls.Add(this.btnListarAlunos);
            this.Controls.Add(this.outputFoto);
            this.Controls.Add(this.gridAlunos);
            this.Name = "ListarAlunos";
            this.Text = "listarAlunos";
            ((System.ComponentModel.ISupportInitialize)(this.gridAlunos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputFoto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridAlunos;
        private System.Windows.Forms.PictureBox outputFoto;
        private System.Windows.Forms.Button btnListarAlunos;
        private System.Windows.Forms.Button btnAniversariantes;
        private System.Windows.Forms.DateTimePicker dataAtual;
        private System.Windows.Forms.Button btnDesconto;
        private System.Windows.Forms.Button btnPagamentos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker inputDataDe;
        private System.Windows.Forms.DateTimePicker inputDataAte;
        private System.Windows.Forms.Label lblDataDe;
        private System.Windows.Forms.Label lblDataAte;
        private System.Windows.Forms.CheckBox checkFiltro;
    }
}