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
            this.gridEspecie.Location = new System.Drawing.Point(40, 271);
            this.gridEspecie.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gridEspecie.Name = "gridEspecie";
            this.gridEspecie.RowHeadersWidth = 62;
            this.gridEspecie.Size = new System.Drawing.Size(862, 460);
            this.gridEspecie.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(36, 203);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(189, 29);
            this.label3.TabIndex = 5;
            this.label3.Text = "Espécie do pet";
            // 
            // inputEspecie
            // 
            this.inputEspecie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputEspecie.Location = new System.Drawing.Point(248, 197);
            this.inputEspecie.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.inputEspecie.Name = "inputEspecie";
            this.inputEspecie.Size = new System.Drawing.Size(334, 35);
            this.inputEspecie.TabIndex = 8;
            // 
            // btnBuscarEspecie
            // 
            this.btnBuscarEspecie.BackColor = System.Drawing.Color.Gold;
            this.btnBuscarEspecie.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnBuscarEspecie.FlatAppearance.BorderSize = 2;
            this.btnBuscarEspecie.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarEspecie.Location = new System.Drawing.Point(592, 198);
            this.btnBuscarEspecie.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBuscarEspecie.Name = "btnBuscarEspecie";
            this.btnBuscarEspecie.Size = new System.Drawing.Size(126, 42);
            this.btnBuscarEspecie.TabIndex = 9;
            this.btnBuscarEspecie.Text = "Buscar";
            this.btnBuscarEspecie.UseVisualStyleBackColor = false;
            this.btnBuscarEspecie.Click += new System.EventHandler(this.btnBuscarEspecie_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Gold;
            this.label11.Location = new System.Drawing.Point(264, 46);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(360, 52);
            this.label11.TabIndex = 12;
            this.label11.Text = "Petshop PetAny";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(268, 123);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(329, 25);
            this.label2.TabIndex = 21;
            this.label2.Text = "Confira aqui os pets cadastrados";
            // 
            // FormFiltroEspecie
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateGray;
            this.ClientSize = new System.Drawing.Size(962, 768);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnBuscarEspecie);
            this.Controls.Add(this.inputEspecie);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gridEspecie);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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