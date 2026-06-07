namespace AppPetShop
{
    partial class FormPet
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
            this.btnFoto = new System.Windows.Forms.Button();
            this.inputFoto = new System.Windows.Forms.PictureBox();
            this.btnCadastrarPet = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.inputRaca = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.inputNome = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tutorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.petToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serviçosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.pesquisarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tutorToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.petToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.serviçosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultasToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.ajudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inputNascimento = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.inputCpf = new System.Windows.Forms.TextBox();
            this.rdMacho = new System.Windows.Forms.RadioButton();
            this.rdFemea = new System.Windows.Forms.RadioButton();
            this.inputEspecie = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.inputFoto)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFoto
            // 
            this.btnFoto.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFoto.Location = new System.Drawing.Point(711, 411);
            this.btnFoto.Name = "btnFoto";
            this.btnFoto.Size = new System.Drawing.Size(283, 51);
            this.btnFoto.TabIndex = 42;
            this.btnFoto.Text = "Adicionar Foto do Pet";
            this.btnFoto.UseVisualStyleBackColor = true;
            this.btnFoto.Click += new System.EventHandler(this.btnFoto_Click);
            // 
            // inputFoto
            // 
            this.inputFoto.Location = new System.Drawing.Point(711, 141);
            this.inputFoto.Name = "inputFoto";
            this.inputFoto.Size = new System.Drawing.Size(283, 246);
            this.inputFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.inputFoto.TabIndex = 41;
            this.inputFoto.TabStop = false;
            // 
            // btnCadastrarPet
            // 
            this.btnCadastrarPet.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrarPet.Location = new System.Drawing.Point(37, 503);
            this.btnCadastrarPet.Name = "btnCadastrarPet";
            this.btnCadastrarPet.Size = new System.Drawing.Size(600, 51);
            this.btnCadastrarPet.TabIndex = 39;
            this.btnCadastrarPet.Text = "Cadastrar Pet";
            this.btnCadastrarPet.UseVisualStyleBackColor = true;
            this.btnCadastrarPet.Click += new System.EventHandler(this.btnCadastrarPet_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(31, 430);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(193, 31);
            this.label11.TabIndex = 37;
            this.label11.Text = "Especie do pet";
            // 
            // inputRaca
            // 
            this.inputRaca.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputRaca.Location = new System.Drawing.Point(291, 376);
            this.inputRaca.Name = "inputRaca";
            this.inputRaca.Size = new System.Drawing.Size(346, 38);
            this.inputRaca.TabIndex = 36;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(31, 376);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(163, 31);
            this.label10.TabIndex = 35;
            this.label10.Text = "Raça do Pet";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(31, 317);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(186, 31);
            this.label9.TabIndex = 33;
            this.label9.Text = "Genero do pet";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(31, 259);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(243, 31);
            this.label8.TabIndex = 31;
            this.label8.Text = "Nascimento do Pet";
            // 
            // inputNome
            // 
            this.inputNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputNome.Location = new System.Drawing.Point(291, 197);
            this.inputNome.Name = "inputNome";
            this.inputNome.Size = new System.Drawing.Size(346, 38);
            this.inputNome.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(31, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(171, 31);
            this.label7.TabIndex = 29;
            this.label7.Text = "Nome do Pet";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(398, 56);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(182, 31);
            this.label6.TabIndex = 28;
            this.label6.Text = "Cadastrar Pet";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem,
            this.pesquisarToolStripMenuItem,
            this.ajudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1102, 24);
            this.menuStrip1.TabIndex = 43;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tutorToolStripMenuItem,
            this.petToolStripMenuItem,
            this.consultasToolStripMenuItem,
            this.serviçosToolStripMenuItem1});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // tutorToolStripMenuItem
            // 
            this.tutorToolStripMenuItem.Name = "tutorToolStripMenuItem";
            this.tutorToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.tutorToolStripMenuItem.Text = "Tutor";
            this.tutorToolStripMenuItem.Click += new System.EventHandler(this.tutorToolStripMenuItem_Click);
            // 
            // petToolStripMenuItem
            // 
            this.petToolStripMenuItem.Name = "petToolStripMenuItem";
            this.petToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.petToolStripMenuItem.Text = "Pet";
            this.petToolStripMenuItem.Click += new System.EventHandler(this.petToolStripMenuItem_Click);
            // 
            // consultasToolStripMenuItem
            // 
            this.consultasToolStripMenuItem.Name = "consultasToolStripMenuItem";
            this.consultasToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.consultasToolStripMenuItem.Text = "Consultas";
            // 
            // serviçosToolStripMenuItem1
            // 
            this.serviçosToolStripMenuItem1.Name = "serviçosToolStripMenuItem1";
            this.serviçosToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.serviçosToolStripMenuItem1.Text = "Serviços";
            // 
            // pesquisarToolStripMenuItem
            // 
            this.pesquisarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tutorToolStripMenuItem1,
            this.petToolStripMenuItem1,
            this.serviçosToolStripMenuItem,
            this.consultasToolStripMenuItem1});
            this.pesquisarToolStripMenuItem.Name = "pesquisarToolStripMenuItem";
            this.pesquisarToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.pesquisarToolStripMenuItem.Text = "Pesquisar";
            // 
            // tutorToolStripMenuItem1
            // 
            this.tutorToolStripMenuItem1.Name = "tutorToolStripMenuItem1";
            this.tutorToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.tutorToolStripMenuItem1.Text = "Tutor";
            // 
            // petToolStripMenuItem1
            // 
            this.petToolStripMenuItem1.Name = "petToolStripMenuItem1";
            this.petToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.petToolStripMenuItem1.Text = "Pet";
            // 
            // serviçosToolStripMenuItem
            // 
            this.serviçosToolStripMenuItem.Name = "serviçosToolStripMenuItem";
            this.serviçosToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.serviçosToolStripMenuItem.Text = "Serviços";
            // 
            // consultasToolStripMenuItem1
            // 
            this.consultasToolStripMenuItem1.Name = "consultasToolStripMenuItem1";
            this.consultasToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.consultasToolStripMenuItem1.Text = "Consultas";
            // 
            // ajudaToolStripMenuItem
            // 
            this.ajudaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobreToolStripMenuItem});
            this.ajudaToolStripMenuItem.Name = "ajudaToolStripMenuItem";
            this.ajudaToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.ajudaToolStripMenuItem.Text = "Ajuda";
            // 
            // sobreToolStripMenuItem
            // 
            this.sobreToolStripMenuItem.Name = "sobreToolStripMenuItem";
            this.sobreToolStripMenuItem.Size = new System.Drawing.Size(104, 22);
            this.sobreToolStripMenuItem.Text = "Sobre";
            // 
            // inputNascimento
            // 
            this.inputNascimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputNascimento.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.inputNascimento.Location = new System.Drawing.Point(291, 253);
            this.inputNascimento.Name = "inputNascimento";
            this.inputNascimento.Size = new System.Drawing.Size(346, 38);
            this.inputNascimento.TabIndex = 44;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 31);
            this.label1.TabIndex = 45;
            this.label1.Text = "Cpf Tutor";
            // 
            // inputCpf
            // 
            this.inputCpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputCpf.Location = new System.Drawing.Point(291, 141);
            this.inputCpf.Name = "inputCpf";
            this.inputCpf.Size = new System.Drawing.Size(346, 38);
            this.inputCpf.TabIndex = 46;
            // 
            // rdMacho
            // 
            this.rdMacho.AutoSize = true;
            this.rdMacho.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdMacho.Location = new System.Drawing.Point(291, 317);
            this.rdMacho.Name = "rdMacho";
            this.rdMacho.Size = new System.Drawing.Size(113, 35);
            this.rdMacho.TabIndex = 47;
            this.rdMacho.TabStop = true;
            this.rdMacho.Text = "Macho";
            this.rdMacho.UseVisualStyleBackColor = true;
            // 
            // rdFemea
            // 
            this.rdFemea.AutoSize = true;
            this.rdFemea.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdFemea.Location = new System.Drawing.Point(438, 317);
            this.rdFemea.Name = "rdFemea";
            this.rdFemea.Size = new System.Drawing.Size(116, 35);
            this.rdFemea.TabIndex = 48;
            this.rdFemea.TabStop = true;
            this.rdFemea.Text = "Femea";
            this.rdFemea.UseVisualStyleBackColor = true;
            // 
            // inputEspecie
            // 
            this.inputEspecie.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputEspecie.Location = new System.Drawing.Point(291, 440);
            this.inputEspecie.Name = "inputEspecie";
            this.inputEspecie.Size = new System.Drawing.Size(346, 38);
            this.inputEspecie.TabIndex = 49;
            // 
            // FormPet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1102, 749);
            this.Controls.Add(this.inputEspecie);
            this.Controls.Add(this.rdFemea);
            this.Controls.Add(this.rdMacho);
            this.Controls.Add(this.inputCpf);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.inputNascimento);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.btnFoto);
            this.Controls.Add(this.inputFoto);
            this.Controls.Add(this.btnCadastrarPet);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.inputRaca);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.inputNome);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Name = "FormPet";
            this.Text = "FormPet";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fecharApp);
            this.Load += new System.EventHandler(this.FormPet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.inputFoto)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnFoto;
        private System.Windows.Forms.PictureBox inputFoto;
        private System.Windows.Forms.Button btnCadastrarPet;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox inputRaca;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox inputNome;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tutorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem petToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serviçosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem pesquisarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tutorToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem petToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem serviçosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultasToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem ajudaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobreToolStripMenuItem;
        private System.Windows.Forms.DateTimePicker inputNascimento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inputCpf;
        private System.Windows.Forms.RadioButton rdMacho;
        private System.Windows.Forms.RadioButton rdFemea;
        private System.Windows.Forms.TextBox inputEspecie;
    }
}