namespace AppPetShop
{
    partial class FiltrarPet
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
            this.btnNascimento = new System.Windows.Forms.Button();
            this.gridPet = new System.Windows.Forms.DataGridView();
            this.btnPetTutor = new System.Windows.Forms.Button();
            this.btnConsulta = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridPet)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNascimento
            // 
            this.btnNascimento.BackColor = System.Drawing.Color.Gold;
            this.btnNascimento.FlatAppearance.BorderSize = 2;
            this.btnNascimento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNascimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNascimento.Location = new System.Drawing.Point(45, 105);
            this.btnNascimento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNascimento.Name = "btnNascimento";
            this.btnNascimento.Size = new System.Drawing.Size(212, 37);
            this.btnNascimento.TabIndex = 0;
            this.btnNascimento.Text = "Ordenar por nascimento";
            this.btnNascimento.UseVisualStyleBackColor = false;
            this.btnNascimento.Click += new System.EventHandler(this.btnNascimento_Click);
            // 
            // gridPet
            // 
            this.gridPet.BackgroundColor = System.Drawing.SystemColors.Info;
            this.gridPet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPet.Location = new System.Drawing.Point(45, 150);
            this.gridPet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridPet.Name = "gridPet";
            this.gridPet.RowHeadersWidth = 51;
            this.gridPet.Size = new System.Drawing.Size(677, 332);
            this.gridPet.TabIndex = 1;
            // 
            // btnPetTutor
            // 
            this.btnPetTutor.BackColor = System.Drawing.Color.Gold;
            this.btnPetTutor.FlatAppearance.BorderSize = 2;
            this.btnPetTutor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPetTutor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPetTutor.Location = new System.Drawing.Point(277, 105);
            this.btnPetTutor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPetTutor.Name = "btnPetTutor";
            this.btnPetTutor.Size = new System.Drawing.Size(212, 37);
            this.btnPetTutor.TabIndex = 2;
            this.btnPetTutor.Text = "Pet + tutor";
            this.btnPetTutor.UseVisualStyleBackColor = false;
            this.btnPetTutor.Click += new System.EventHandler(this.btnPetTutor_Click);
            // 
            // btnConsulta
            // 
            this.btnConsulta.BackColor = System.Drawing.Color.Gold;
            this.btnConsulta.FlatAppearance.BorderSize = 2;
            this.btnConsulta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConsulta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsulta.Location = new System.Drawing.Point(511, 105);
            this.btnConsulta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(211, 37);
            this.btnConsulta.TabIndex = 3;
            this.btnConsulta.Text = "Consultas";
            this.btnConsulta.UseVisualStyleBackColor = false;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Gold;
            this.label11.Location = new System.Drawing.Point(244, 38);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(301, 42);
            this.label11.TabIndex = 18;
            this.label11.Text = "Petshop PetAny";
            // 
            // FiltrarPet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(761, 512);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnConsulta);
            this.Controls.Add(this.btnPetTutor);
            this.Controls.Add(this.gridPet);
            this.Controls.Add(this.btnNascimento);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FiltrarPet";
            this.Text = "FiltrarPet";
            ((System.ComponentModel.ISupportInitialize)(this.gridPet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNascimento;
        private System.Windows.Forms.DataGridView gridPet;
        private System.Windows.Forms.Button btnPetTutor;
        private System.Windows.Forms.Button btnConsulta;
        private System.Windows.Forms.Label label11;
    }
}