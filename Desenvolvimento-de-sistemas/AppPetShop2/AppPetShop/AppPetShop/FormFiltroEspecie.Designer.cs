namespace AppPetShop
{
    partial class FormFiltroEspecie
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
            this.gridEspecie = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.inputEspecie = new System.Windows.Forms.TextBox();
            this.btnBuscarEspecie = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridEspecie)).BeginInit();
            this.SuspendLayout();
            // 
            // gridEspecie
            // 
            this.gridEspecie.BackgroundColor = System.Drawing.SystemColors.Info;
            this.gridEspecie.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEspecie.Location = new System.Drawing.Point(27, 176);
            this.gridEspecie.Name = "gridEspecie";
            this.gridEspecie.Size = new System.Drawing.Size(575, 299);
            this.gridEspecie.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(24, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "Espécie do pet";
            // 
            // inputEspecie
            // 
            this.inputEspecie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputEspecie.Location = new System.Drawing.Point(165, 128);
            this.inputEspecie.Name = "inputEspecie";
            this.inputEspecie.Size = new System.Drawing.Size(224, 26);
            this.inputEspecie.TabIndex = 8;
            // 
            // btnBuscarEspecie
            // 
            this.btnBuscarEspecie.BackColor = System.Drawing.Color.Gold;
            this.btnBuscarEspecie.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBuscarEspecie.FlatAppearance.BorderSize = 2;
            this.btnBuscarEspecie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarEspecie.Location = new System.Drawing.Point(395, 129);
            this.btnBuscarEspecie.Name = "btnBuscarEspecie";
            this.btnBuscarEspecie.Size = new System.Drawing.Size(84, 27);
            this.btnBuscarEspecie.TabIndex = 9;
            this.btnBuscarEspecie.Text = "Buscar";
            this.btnBuscarEspecie.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Gold;
            this.label11.Location = new System.Drawing.Point(176, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(244, 36);
            this.label11.TabIndex = 12;
            this.label11.Text = "Petshop PetAny";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(179, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(236, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Confira aqui os pets cadastrados";
            // 
            // FormFiltroEspecie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(641, 499);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnBuscarEspecie);
            this.Controls.Add(this.inputEspecie);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gridEspecie);
            this.Name = "FormFiltroEspecie";
            this.Text = "FormListaUm";
            ((System.ComponentModel.ISupportInitialize)(this.gridEspecie)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridEspecie;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox inputEspecie;
        private System.Windows.Forms.Button btnBuscarEspecie;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
    }
}