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
            ((System.ComponentModel.ISupportInitialize)(this.gridPet)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNascimento
            // 
            this.btnNascimento.Location = new System.Drawing.Point(12, 26);
            this.btnNascimento.Name = "btnNascimento";
            this.btnNascimento.Size = new System.Drawing.Size(159, 23);
            this.btnNascimento.TabIndex = 0;
            this.btnNascimento.Text = "Ordenar por nascimento";
            this.btnNascimento.UseVisualStyleBackColor = true;
            this.btnNascimento.Click += new System.EventHandler(this.btnNascimento_Click);
            // 
            // gridPet
            // 
            this.gridPet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPet.Location = new System.Drawing.Point(12, 81);
            this.gridPet.Name = "gridPet";
            this.gridPet.Size = new System.Drawing.Size(540, 357);
            this.gridPet.TabIndex = 1;
            // 
            // btnPetTutor
            // 
            this.btnPetTutor.Location = new System.Drawing.Point(202, 26);
            this.btnPetTutor.Name = "btnPetTutor";
            this.btnPetTutor.Size = new System.Drawing.Size(159, 23);
            this.btnPetTutor.TabIndex = 2;
            this.btnPetTutor.Text = "Pet + tutor";
            this.btnPetTutor.UseVisualStyleBackColor = true;
            this.btnPetTutor.Click += new System.EventHandler(this.btnPetTutor_Click);
            // 
            // btnConsulta
            // 
            this.btnConsulta.Location = new System.Drawing.Point(403, 25);
            this.btnConsulta.Name = "btnConsulta";
            this.btnConsulta.Size = new System.Drawing.Size(106, 23);
            this.btnConsulta.TabIndex = 3;
            this.btnConsulta.Text = "Consultas";
            this.btnConsulta.UseVisualStyleBackColor = true;
            this.btnConsulta.Click += new System.EventHandler(this.btnConsulta_Click);
            // 
            // FiltrarPet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnConsulta);
            this.Controls.Add(this.btnPetTutor);
            this.Controls.Add(this.gridPet);
            this.Controls.Add(this.btnNascimento);
            this.Name = "FiltrarPet";
            this.Text = "FiltrarPet";
            ((System.ComponentModel.ISupportInitialize)(this.gridPet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNascimento;
        private System.Windows.Forms.DataGridView gridPet;
        private System.Windows.Forms.Button btnPetTutor;
        private System.Windows.Forms.Button btnConsulta;
    }
}