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
            this.inputData = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.gridAlunos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputFoto)).BeginInit();
            this.SuspendLayout();
            // 
            // gridAlunos
            // 
            this.gridAlunos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridAlunos.Location = new System.Drawing.Point(12, 33);
            this.gridAlunos.Name = "gridAlunos";
            this.gridAlunos.Size = new System.Drawing.Size(537, 405);
            this.gridAlunos.TabIndex = 0;
            this.gridAlunos.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridAlunos_MouseClick);
            // 
            // outputFoto
            // 
            this.outputFoto.Location = new System.Drawing.Point(593, 33);
            this.outputFoto.Name = "outputFoto";
            this.outputFoto.Size = new System.Drawing.Size(195, 176);
            this.outputFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.outputFoto.TabIndex = 1;
            this.outputFoto.TabStop = false;
            // 
            // btnListarAlunos
            // 
            this.btnListarAlunos.Location = new System.Drawing.Point(593, 234);
            this.btnListarAlunos.Name = "btnListarAlunos";
            this.btnListarAlunos.Size = new System.Drawing.Size(195, 23);
            this.btnListarAlunos.TabIndex = 2;
            this.btnListarAlunos.Text = "Listar Alunos";
            this.btnListarAlunos.UseVisualStyleBackColor = true;
            this.btnListarAlunos.Click += new System.EventHandler(this.btnListarAlunos_Click);
            // 
            // btnAniversariantes
            // 
            this.btnAniversariantes.Location = new System.Drawing.Point(593, 286);
            this.btnAniversariantes.Name = "btnAniversariantes";
            this.btnAniversariantes.Size = new System.Drawing.Size(195, 23);
            this.btnAniversariantes.TabIndex = 3;
            this.btnAniversariantes.Text = "Aniversariantes do Mês";
            this.btnAniversariantes.UseVisualStyleBackColor = true;
            this.btnAniversariantes.Click += new System.EventHandler(this.btnAniversariantes_Click);
            // 
            // inputData
            // 
            this.inputData.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.inputData.Location = new System.Drawing.Point(593, 263);
            this.inputData.Name = "inputData";
            this.inputData.Size = new System.Drawing.Size(200, 20);
            this.inputData.TabIndex = 4;
            // 
            // ListarAlunos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.inputData);
            this.Controls.Add(this.btnAniversariantes);
            this.Controls.Add(this.btnListarAlunos);
            this.Controls.Add(this.outputFoto);
            this.Controls.Add(this.gridAlunos);
            this.Name = "ListarAlunos";
            this.Text = "listarAlunos";
            ((System.ComponentModel.ISupportInitialize)(this.gridAlunos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.outputFoto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridAlunos;
        private System.Windows.Forms.PictureBox outputFoto;
        private System.Windows.Forms.Button btnListarAlunos;
        private System.Windows.Forms.Button btnAniversariantes;
        private System.Windows.Forms.DateTimePicker inputData;
    }
}