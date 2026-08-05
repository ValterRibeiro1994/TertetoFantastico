namespace AppPetShop
{
    partial class FormFiltroTipoData
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
            this.label11 = new System.Windows.Forms.Label();
            this.btnBuscarServico = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.gridServico = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.inputDataServico = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.inputServico = new System.Windows.Forms.ComboBox();
            this.btnBuscarData = new System.Windows.Forms.Button();
            this.btnBuscarDataServico = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridServico)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Gold;
            this.label11.Location = new System.Drawing.Point(220, 33);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(301, 42);
            this.label11.TabIndex = 17;
            this.label11.Text = "Petshop PetAny";
            // 
            // btnBuscarServico
            // 
            this.btnBuscarServico.BackColor = System.Drawing.Color.Gold;
            this.btnBuscarServico.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBuscarServico.FlatAppearance.BorderSize = 2;
            this.btnBuscarServico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarServico.Location = new System.Drawing.Point(563, 140);
            this.btnBuscarServico.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuscarServico.Name = "btnBuscarServico";
            this.btnBuscarServico.Size = new System.Drawing.Size(165, 30);
            this.btnBuscarServico.TabIndex = 16;
            this.btnBuscarServico.Text = "Buscar por serviço";
            this.btnBuscarServico.UseVisualStyleBackColor = false;
            this.btnBuscarServico.Click += new System.EventHandler(this.btnBuscarServico_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(48, 155);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(155, 24);
            this.label3.TabIndex = 14;
            this.label3.Text = "Tipo do serviço";
            // 
            // gridServico
            // 
            this.gridServico.BackgroundColor = System.Drawing.SystemColors.Info;
            this.gridServico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridServico.Location = new System.Drawing.Point(39, 315);
            this.gridServico.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridServico.Name = "gridServico";
            this.gridServico.RowHeadersWidth = 51;
            this.gridServico.Size = new System.Drawing.Size(780, 262);
            this.gridServico.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(48, 222);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 24);
            this.label1.TabIndex = 18;
            this.label1.Text = "Data do serviço";
            // 
            // inputDataServico
            // 
            this.inputDataServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputDataServico.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.inputDataServico.Location = new System.Drawing.Point(236, 222);
            this.inputDataServico.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.inputDataServico.Name = "inputDataServico";
            this.inputDataServico.Size = new System.Drawing.Size(297, 30);
            this.inputDataServico.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(199, 96);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(343, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "Confira aqui seus serviços cadastrados";
            // 
            // inputServico
            // 
            this.inputServico.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputServico.FormattingEnabled = true;
            this.inputServico.ItemHeight = 22;
            this.inputServico.Location = new System.Drawing.Point(236, 156);
            this.inputServico.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.inputServico.Name = "inputServico";
            this.inputServico.Size = new System.Drawing.Size(297, 30);
            this.inputServico.TabIndex = 21;
            // 
            // btnBuscarData
            // 
            this.btnBuscarData.BackColor = System.Drawing.Color.Gold;
            this.btnBuscarData.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBuscarData.FlatAppearance.BorderSize = 2;
            this.btnBuscarData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarData.Location = new System.Drawing.Point(563, 178);
            this.btnBuscarData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuscarData.Name = "btnBuscarData";
            this.btnBuscarData.Size = new System.Drawing.Size(165, 30);
            this.btnBuscarData.TabIndex = 22;
            this.btnBuscarData.Text = "Buscar por data";
            this.btnBuscarData.UseVisualStyleBackColor = false;
            this.btnBuscarData.Click += new System.EventHandler(this.btnBuscarData_Click);
            // 
            // btnBuscarDataServico
            // 
            this.btnBuscarDataServico.BackColor = System.Drawing.Color.Gold;
            this.btnBuscarDataServico.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBuscarDataServico.FlatAppearance.BorderSize = 2;
            this.btnBuscarDataServico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarDataServico.Location = new System.Drawing.Point(563, 216);
            this.btnBuscarDataServico.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuscarDataServico.Name = "btnBuscarDataServico";
            this.btnBuscarDataServico.Size = new System.Drawing.Size(165, 52);
            this.btnBuscarDataServico.TabIndex = 23;
            this.btnBuscarDataServico.Text = "Buscar por serviço e data";
            this.btnBuscarDataServico.UseVisualStyleBackColor = false;
            this.btnBuscarDataServico.Click += new System.EventHandler(this.btnBuscarDataServico_Click);
            // 
            // FormFiltroTipoData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(853, 593);
            this.Controls.Add(this.btnBuscarDataServico);
            this.Controls.Add(this.btnBuscarData);
            this.Controls.Add(this.inputServico);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inputDataServico);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnBuscarServico);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gridServico);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormFiltroTipoData";
            this.Text = "FormFiltroTipoData";
            this.Load += new System.EventHandler(this.FormFiltroTipoData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridServico)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnBuscarServico;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView gridServico;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker inputDataServico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox inputServico;
        private System.Windows.Forms.Button btnBuscarData;
        private System.Windows.Forms.Button btnBuscarDataServico;
    }
}