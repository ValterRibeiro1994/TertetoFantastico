namespace AppPetShop
{
    partial class FormBuscarPet
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
            this.label1 = new System.Windows.Forms.Label();
            this.campoCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.campoImagem = new System.Windows.Forms.PictureBox();
            this.campoCpf = new System.Windows.Forms.TextBox();
            this.campoNome = new System.Windows.Forms.TextBox();
            this.campoEspecie = new System.Windows.Forms.TextBox();
            this.campoRaca = new System.Windows.Forms.TextBox();
            this.campoData = new System.Windows.Forms.DateTimePicker();
            this.gridPet = new System.Windows.Forms.DataGridView();
            this.btnBuscarPedCod = new System.Windows.Forms.Button();
            this.btnBuscarCpf = new System.Windows.Forms.Button();
            this.btnAlterarFoto = new System.Windows.Forms.Button();
            this.btnRemoverPet = new System.Windows.Forms.Button();
            this.btnListarPet = new System.Windows.Forms.Button();
            this.btnEditarPet = new System.Windows.Forms.Button();
            this.rbMacho = new System.Windows.Forms.RadioButton();
            this.rbFemea = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.campoImagem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPet)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(55, 83);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Código Pet";
            // 
            // campoCodigo
            // 
            this.campoCodigo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campoCodigo.Location = new System.Drawing.Point(197, 78);
            this.campoCodigo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.campoCodigo.Name = "campoCodigo";
            this.campoCodigo.Size = new System.Drawing.Size(348, 30);
            this.campoCodigo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(69, 137);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "Cpf Tutor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(67, 192);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 22);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nome Pet";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(47, 247);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 22);
            this.label4.TabIndex = 4;
            this.label4.Text = "Especie Pet";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(72, 302);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 22);
            this.label5.TabIndex = 5;
            this.label5.Text = "Raça Pet";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(52, 352);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 22);
            this.label6.TabIndex = 6;
            this.label6.Text = "Gênero Pet";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(14, 410);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 22);
            this.label7.TabIndex = 7;
            this.label7.Text = "Nascimento Pet";
            // 
            // campoImagem
            // 
            this.campoImagem.BackColor = System.Drawing.Color.White;
            this.campoImagem.Location = new System.Drawing.Point(570, 78);
            this.campoImagem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.campoImagem.Name = "campoImagem";
            this.campoImagem.Size = new System.Drawing.Size(196, 186);
            this.campoImagem.TabIndex = 8;
            this.campoImagem.TabStop = false;
            // 
            // campoCpf
            // 
            this.campoCpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campoCpf.Location = new System.Drawing.Point(197, 132);
            this.campoCpf.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.campoCpf.Name = "campoCpf";
            this.campoCpf.Size = new System.Drawing.Size(348, 30);
            this.campoCpf.TabIndex = 9;
            // 
            // campoNome
            // 
            this.campoNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campoNome.Location = new System.Drawing.Point(197, 187);
            this.campoNome.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.campoNome.Name = "campoNome";
            this.campoNome.Size = new System.Drawing.Size(348, 30);
            this.campoNome.TabIndex = 10;
            // 
            // campoEspecie
            // 
            this.campoEspecie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campoEspecie.Location = new System.Drawing.Point(197, 242);
            this.campoEspecie.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.campoEspecie.Name = "campoEspecie";
            this.campoEspecie.Size = new System.Drawing.Size(348, 30);
            this.campoEspecie.TabIndex = 11;
            // 
            // campoRaca
            // 
            this.campoRaca.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campoRaca.Location = new System.Drawing.Point(197, 297);
            this.campoRaca.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.campoRaca.Name = "campoRaca";
            this.campoRaca.Size = new System.Drawing.Size(348, 30);
            this.campoRaca.TabIndex = 12;
            // 
            // campoData
            // 
            this.campoData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.campoData.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.campoData.Location = new System.Drawing.Point(197, 403);
            this.campoData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.campoData.Name = "campoData";
            this.campoData.Size = new System.Drawing.Size(348, 30);
            this.campoData.TabIndex = 14;
            // 
            // gridPet
            // 
            this.gridPet.BackgroundColor = System.Drawing.SystemColors.Info;
            this.gridPet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPet.Location = new System.Drawing.Point(796, 78);
            this.gridPet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gridPet.Name = "gridPet";
            this.gridPet.RowHeadersWidth = 51;
            this.gridPet.Size = new System.Drawing.Size(538, 401);
            this.gridPet.TabIndex = 15;
            this.gridPet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.selecionarPet);
            // 
            // btnBuscarPedCod
            // 
            this.btnBuscarPedCod.BackColor = System.Drawing.Color.Gold;
            this.btnBuscarPedCod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarPedCod.Location = new System.Drawing.Point(570, 379);
            this.btnBuscarPedCod.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuscarPedCod.Name = "btnBuscarPedCod";
            this.btnBuscarPedCod.Size = new System.Drawing.Size(195, 28);
            this.btnBuscarPedCod.TabIndex = 16;
            this.btnBuscarPedCod.Text = "Buscar Pet Codigo";
            this.btnBuscarPedCod.UseVisualStyleBackColor = false;
            this.btnBuscarPedCod.Click += new System.EventHandler(this.btnBuscarPedCod_Click);
            // 
            // btnBuscarCpf
            // 
            this.btnBuscarCpf.BackColor = System.Drawing.Color.Gold;
            this.btnBuscarCpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarCpf.Location = new System.Drawing.Point(570, 415);
            this.btnBuscarCpf.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuscarCpf.Name = "btnBuscarCpf";
            this.btnBuscarCpf.Size = new System.Drawing.Size(195, 28);
            this.btnBuscarCpf.TabIndex = 17;
            this.btnBuscarCpf.Text = "Buscar Cpf Pet";
            this.btnBuscarCpf.UseVisualStyleBackColor = false;
            this.btnBuscarCpf.Click += new System.EventHandler(this.btnBuscarCpf_Click);
            // 
            // btnAlterarFoto
            // 
            this.btnAlterarFoto.BackColor = System.Drawing.Color.Gold;
            this.btnAlterarFoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlterarFoto.Location = new System.Drawing.Point(570, 272);
            this.btnAlterarFoto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAlterarFoto.Name = "btnAlterarFoto";
            this.btnAlterarFoto.Size = new System.Drawing.Size(195, 28);
            this.btnAlterarFoto.TabIndex = 18;
            this.btnAlterarFoto.Text = "Alterar Foto";
            this.btnAlterarFoto.UseVisualStyleBackColor = false;
            this.btnAlterarFoto.Click += new System.EventHandler(this.btnAlterarFoto_Click);
            // 
            // btnRemoverPet
            // 
            this.btnRemoverPet.BackColor = System.Drawing.Color.Gold;
            this.btnRemoverPet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoverPet.Location = new System.Drawing.Point(570, 308);
            this.btnRemoverPet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemoverPet.Name = "btnRemoverPet";
            this.btnRemoverPet.Size = new System.Drawing.Size(195, 27);
            this.btnRemoverPet.TabIndex = 19;
            this.btnRemoverPet.Text = "Remover Pet";
            this.btnRemoverPet.UseVisualStyleBackColor = false;
            this.btnRemoverPet.Click += new System.EventHandler(this.btnRemoverPet_Click);
            // 
            // btnListarPet
            // 
            this.btnListarPet.BackColor = System.Drawing.Color.Gold;
            this.btnListarPet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnListarPet.Location = new System.Drawing.Point(570, 343);
            this.btnListarPet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnListarPet.Name = "btnListarPet";
            this.btnListarPet.Size = new System.Drawing.Size(195, 28);
            this.btnListarPet.TabIndex = 20;
            this.btnListarPet.Text = "Listar Pet";
            this.btnListarPet.UseVisualStyleBackColor = false;
            this.btnListarPet.Click += new System.EventHandler(this.btnListarPet_Click);
            // 
            // btnEditarPet
            // 
            this.btnEditarPet.BackColor = System.Drawing.Color.Gold;
            this.btnEditarPet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarPet.Location = new System.Drawing.Point(570, 451);
            this.btnEditarPet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditarPet.Name = "btnEditarPet";
            this.btnEditarPet.Size = new System.Drawing.Size(195, 28);
            this.btnEditarPet.TabIndex = 21;
            this.btnEditarPet.Text = "Editar Pet";
            this.btnEditarPet.UseVisualStyleBackColor = false;
            this.btnEditarPet.Click += new System.EventHandler(this.btnEditarPet_Click);
            // 
            // rbMacho
            // 
            this.rbMacho.AutoSize = true;
            this.rbMacho.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbMacho.Location = new System.Drawing.Point(197, 352);
            this.rbMacho.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbMacho.Name = "rbMacho";
            this.rbMacho.Size = new System.Drawing.Size(84, 26);
            this.rbMacho.TabIndex = 22;
            this.rbMacho.TabStop = true;
            this.rbMacho.Text = "Macho";
            this.rbMacho.UseVisualStyleBackColor = true;
            // 
            // rbFemea
            // 
            this.rbFemea.AutoSize = true;
            this.rbFemea.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbFemea.Location = new System.Drawing.Point(324, 352);
            this.rbFemea.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rbFemea.Name = "rbFemea";
            this.rbFemea.Size = new System.Drawing.Size(86, 26);
            this.rbFemea.TabIndex = 23;
            this.rbFemea.TabStop = true;
            this.rbFemea.Text = "Femea";
            this.rbFemea.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.DarkSlateGray;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Gold;
            this.label8.Location = new System.Drawing.Point(418, 9);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(247, 42);
            this.label8.TabIndex = 24;
            this.label8.Text = "Localizar Pet";
            // 
            // FormBuscarPet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(1347, 560);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.rbFemea);
            this.Controls.Add(this.rbMacho);
            this.Controls.Add(this.btnEditarPet);
            this.Controls.Add(this.btnListarPet);
            this.Controls.Add(this.btnRemoverPet);
            this.Controls.Add(this.btnAlterarFoto);
            this.Controls.Add(this.btnBuscarCpf);
            this.Controls.Add(this.btnBuscarPedCod);
            this.Controls.Add(this.gridPet);
            this.Controls.Add(this.campoData);
            this.Controls.Add(this.campoRaca);
            this.Controls.Add(this.campoEspecie);
            this.Controls.Add(this.campoNome);
            this.Controls.Add(this.campoCpf);
            this.Controls.Add(this.campoImagem);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.campoCodigo);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormBuscarPet";
            this.Text = "FormBuscarPet";
            ((System.ComponentModel.ISupportInitialize)(this.campoImagem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridPet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox campoCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox campoImagem;
        private System.Windows.Forms.TextBox campoCpf;
        private System.Windows.Forms.TextBox campoNome;
        private System.Windows.Forms.TextBox campoEspecie;
        private System.Windows.Forms.TextBox campoRaca;
        private System.Windows.Forms.DateTimePicker campoData;
        private System.Windows.Forms.DataGridView gridPet;
        private System.Windows.Forms.Button btnBuscarPedCod;
        private System.Windows.Forms.Button btnBuscarCpf;
        private System.Windows.Forms.Button btnAlterarFoto;
        private System.Windows.Forms.Button btnRemoverPet;
        private System.Windows.Forms.Button btnListarPet;
        private System.Windows.Forms.Button btnEditarPet;
        private System.Windows.Forms.RadioButton rbMacho;
        private System.Windows.Forms.RadioButton rbFemea;
        private System.Windows.Forms.Label label8;
    }
}