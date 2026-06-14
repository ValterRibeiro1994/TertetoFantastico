namespace AppPetShop
{
    partial class FormPesquisarConsulta
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
            this.pesquisarTutor = new System.Windows.Forms.CheckBox();
            this.pesquisarPet = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rotuloIndentificador = new System.Windows.Forms.Label();
            this.inputId = new System.Windows.Forms.TextBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.pesquisarData = new System.Windows.Forms.CheckBox();
            this.inputDataDe = new System.Windows.Forms.DateTimePicker();
            this.inputDataAte = new System.Windows.Forms.DateTimePicker();
            this.rotuloDataDe = new System.Windows.Forms.Label();
            this.rotuloDataAte = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // pesquisarTutor
            // 
            this.pesquisarTutor.AutoSize = true;
            this.pesquisarTutor.Location = new System.Drawing.Point(31, 55);
            this.pesquisarTutor.Name = "pesquisarTutor";
            this.pesquisarTutor.Size = new System.Drawing.Size(119, 17);
            this.pesquisarTutor.TabIndex = 0;
            this.pesquisarTutor.Text = "Pesquisar Por Tutor";
            this.pesquisarTutor.UseVisualStyleBackColor = true;
            this.pesquisarTutor.CheckedChanged += new System.EventHandler(this.pesquisarTutor_CheckedChanged);
            // 
            // pesquisarPet
            // 
            this.pesquisarPet.AutoSize = true;
            this.pesquisarPet.Location = new System.Drawing.Point(169, 55);
            this.pesquisarPet.Name = "pesquisarPet";
            this.pesquisarPet.Size = new System.Drawing.Size(110, 17);
            this.pesquisarPet.TabIndex = 1;
            this.pesquisarPet.Text = "Pesquisar Por Pet";
            this.pesquisarPet.UseVisualStyleBackColor = true;
            this.pesquisarPet.CheckedChanged += new System.EventHandler(this.pesquisarPet_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 31);
            this.label1.TabIndex = 2;
            this.label1.Text = "Escolha a opção de busca";
            // 
            // rotuloIndentificador
            // 
            this.rotuloIndentificador.AutoSize = true;
            this.rotuloIndentificador.Location = new System.Drawing.Point(28, 100);
            this.rotuloIndentificador.Name = "rotuloIndentificador";
            this.rotuloIndentificador.Size = new System.Drawing.Size(66, 13);
            this.rotuloIndentificador.TabIndex = 3;
            this.rotuloIndentificador.Text = "Cpf do Tutor";
            this.rotuloIndentificador.Visible = false;
            // 
            // inputId
            // 
            this.inputId.Location = new System.Drawing.Point(109, 97);
            this.inputId.Name = "inputId";
            this.inputId.Size = new System.Drawing.Size(127, 20);
            this.inputId.TabIndex = 4;
            this.inputId.Visible = false;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Location = new System.Drawing.Point(31, 141);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(383, 28);
            this.btnPesquisar.TabIndex = 5;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Visible = false;
            // 
            // pesquisarData
            // 
            this.pesquisarData.AutoSize = true;
            this.pesquisarData.Location = new System.Drawing.Point(297, 55);
            this.pesquisarData.Name = "pesquisarData";
            this.pesquisarData.Size = new System.Drawing.Size(117, 17);
            this.pesquisarData.TabIndex = 6;
            this.pesquisarData.Text = "Pesquisar Por Data";
            this.pesquisarData.UseVisualStyleBackColor = true;
            this.pesquisarData.CheckedChanged += new System.EventHandler(this.pesquisarData_CheckedChanged);
            // 
            // inputDataDe
            // 
            this.inputDataDe.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.inputDataDe.Location = new System.Drawing.Point(272, 83);
            this.inputDataDe.Name = "inputDataDe";
            this.inputDataDe.Size = new System.Drawing.Size(142, 20);
            this.inputDataDe.TabIndex = 7;
            this.inputDataDe.Visible = false;
            // 
            // inputDataAte
            // 
            this.inputDataAte.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.inputDataAte.Location = new System.Drawing.Point(272, 108);
            this.inputDataAte.Name = "inputDataAte";
            this.inputDataAte.Size = new System.Drawing.Size(142, 20);
            this.inputDataAte.TabIndex = 8;
            this.inputDataAte.Visible = false;
            // 
            // rotuloDataDe
            // 
            this.rotuloDataDe.AutoSize = true;
            this.rotuloDataDe.Location = new System.Drawing.Point(242, 89);
            this.rotuloDataDe.Name = "rotuloDataDe";
            this.rotuloDataDe.Size = new System.Drawing.Size(24, 13);
            this.rotuloDataDe.TabIndex = 9;
            this.rotuloDataDe.Text = "De:";
            this.rotuloDataDe.Visible = false;
            // 
            // rotuloDataAte
            // 
            this.rotuloDataAte.AutoSize = true;
            this.rotuloDataAte.Location = new System.Drawing.Point(242, 114);
            this.rotuloDataAte.Name = "rotuloDataAte";
            this.rotuloDataAte.Size = new System.Drawing.Size(26, 13);
            this.rotuloDataAte.TabIndex = 10;
            this.rotuloDataAte.Text = "Até:";
            this.rotuloDataAte.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(31, 185);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(539, 241);
            this.dataGridView1.TabIndex = 11;
            this.dataGridView1.Visible = false;
            // 
            // FormPesquisarConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.rotuloDataAte);
            this.Controls.Add(this.rotuloDataDe);
            this.Controls.Add(this.inputDataAte);
            this.Controls.Add(this.inputDataDe);
            this.Controls.Add(this.pesquisarData);
            this.Controls.Add(this.btnPesquisar);
            this.Controls.Add(this.inputId);
            this.Controls.Add(this.rotuloIndentificador);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pesquisarPet);
            this.Controls.Add(this.pesquisarTutor);
            this.Name = "FormPesquisarConsulta";
            this.Text = "FormPesquisarConsulta";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox pesquisarTutor;
        private System.Windows.Forms.CheckBox pesquisarPet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label rotuloIndentificador;
        private System.Windows.Forms.TextBox inputId;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.CheckBox pesquisarData;
        private System.Windows.Forms.DateTimePicker inputDataDe;
        private System.Windows.Forms.DateTimePicker inputDataAte;
        private System.Windows.Forms.Label rotuloDataDe;
        private System.Windows.Forms.Label rotuloDataAte;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}