namespace AppPetShop
{
    partial class FormCadastrarPet
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
            this.fotoPet = new System.Windows.Forms.PictureBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.btnFoto = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.rbMacho = new System.Windows.Forms.RadioButton();
            this.rbFemea = new System.Windows.Forms.RadioButton();
            this.inputRaca = new System.Windows.Forms.TextBox();
            this.inputNome = new System.Windows.Forms.TextBox();
            this.inputEspecie = new System.Windows.Forms.TextBox();
            this.inputCpf = new System.Windows.Forms.TextBox();
            this.inputCodigo = new System.Windows.Forms.TextBox();
            this.inputNascimento = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.fotoPet)).BeginInit();
            this.SuspendLayout();
            // 
            // fotoPet
            // 
            this.fotoPet.Location = new System.Drawing.Point(502, 85);
            this.fotoPet.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.fotoPet.Name = "fotoPet";
            this.fotoPet.Size = new System.Drawing.Size(400, 311);
            this.fotoPet.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.fotoPet.TabIndex = 0;
            this.fotoPet.TabStop = false;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(18, 432);
            this.btnCadastrar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(422, 35);
            this.btnCadastrar.TabIndex = 1;
            this.btnCadastrar.Text = "Cadastrar Pet";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // btnFoto
            // 
            this.btnFoto.Location = new System.Drawing.Point(502, 432);
            this.btnFoto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFoto.Name = "btnFoto";
            this.btnFoto.Size = new System.Drawing.Size(400, 35);
            this.btnFoto.TabIndex = 2;
            this.btnFoto.Text = "Adicionar Foto";
            this.btnFoto.UseVisualStyleBackColor = true;
            this.btnFoto.Click += new System.EventHandler(this.btnFoto_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 85);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Código Pet";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 132);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Cpf Tutor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 225);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nome do Pet";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 272);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(143, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nascimento do Pet";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 375);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Genero do Pet";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 188);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Especie do Pet";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 320);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 20);
            this.label7.TabIndex = 9;
            this.label7.Text = "Raça do Pet";
            // 
            // rbMacho
            // 
            this.rbMacho.AutoSize = true;
            this.rbMacho.Location = new System.Drawing.Point(176, 369);
            this.rbMacho.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbMacho.Name = "rbMacho";
            this.rbMacho.Size = new System.Drawing.Size(82, 24);
            this.rbMacho.TabIndex = 10;
            this.rbMacho.TabStop = true;
            this.rbMacho.Text = "Macho";
            this.rbMacho.UseVisualStyleBackColor = true;
            // 
            // rbFemea
            // 
            this.rbFemea.AutoSize = true;
            this.rbFemea.Location = new System.Drawing.Point(312, 369);
            this.rbFemea.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.rbFemea.Name = "rbFemea";
            this.rbFemea.Size = new System.Drawing.Size(84, 24);
            this.rbFemea.TabIndex = 11;
            this.rbFemea.TabStop = true;
            this.rbFemea.Text = "Femea";
            this.rbFemea.UseVisualStyleBackColor = true;
            // 
            // inputRaca
            // 
            this.inputRaca.Location = new System.Drawing.Point(176, 320);
            this.inputRaca.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.inputRaca.Name = "inputRaca";
            this.inputRaca.Size = new System.Drawing.Size(264, 26);
            this.inputRaca.TabIndex = 13;
            // 
            // inputNome
            // 
            this.inputNome.Location = new System.Drawing.Point(176, 225);
            this.inputNome.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.inputNome.Name = "inputNome";
            this.inputNome.Size = new System.Drawing.Size(264, 26);
            this.inputNome.TabIndex = 14;
            // 
            // inputEspecie
            // 
            this.inputEspecie.Location = new System.Drawing.Point(176, 183);
            this.inputEspecie.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.inputEspecie.Name = "inputEspecie";
            this.inputEspecie.Size = new System.Drawing.Size(264, 26);
            this.inputEspecie.TabIndex = 15;
            // 
            // inputCpf
            // 
            this.inputCpf.Location = new System.Drawing.Point(176, 132);
            this.inputCpf.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.inputCpf.Name = "inputCpf";
            this.inputCpf.Size = new System.Drawing.Size(264, 26);
            this.inputCpf.TabIndex = 16;
            // 
            // inputCodigo
            // 
            this.inputCodigo.Location = new System.Drawing.Point(176, 85);
            this.inputCodigo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.inputCodigo.Name = "inputCodigo";
            this.inputCodigo.Size = new System.Drawing.Size(264, 26);
            this.inputCodigo.TabIndex = 17;
            // 
            // inputNascimento
            // 
            this.inputNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.inputNascimento.Location = new System.Drawing.Point(176, 272);
            this.inputNascimento.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.inputNascimento.Name = "inputNascimento";
            this.inputNascimento.Size = new System.Drawing.Size(264, 26);
            this.inputNascimento.TabIndex = 18;
            // 
            // FormCadastrarPet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 692);
            this.Controls.Add(this.inputNascimento);
            this.Controls.Add(this.inputCodigo);
            this.Controls.Add(this.inputCpf);
            this.Controls.Add(this.inputEspecie);
            this.Controls.Add(this.inputNome);
            this.Controls.Add(this.inputRaca);
            this.Controls.Add(this.rbFemea);
            this.Controls.Add(this.rbMacho);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFoto);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.fotoPet);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormCadastrarPet";
            this.Text = "FormCadastrarPet";
            ((System.ComponentModel.ISupportInitialize)(this.fotoPet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox fotoPet;
        private System.Windows.Forms.Button btnCadastrar;
        private System.Windows.Forms.Button btnFoto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rbMacho;
        private System.Windows.Forms.RadioButton rbFemea;
        private System.Windows.Forms.TextBox inputRaca;
        private System.Windows.Forms.TextBox inputNome;
        private System.Windows.Forms.TextBox inputEspecie;
        private System.Windows.Forms.TextBox inputCpf;
        private System.Windows.Forms.TextBox inputCodigo;
        private System.Windows.Forms.DateTimePicker inputNascimento;
    }
}