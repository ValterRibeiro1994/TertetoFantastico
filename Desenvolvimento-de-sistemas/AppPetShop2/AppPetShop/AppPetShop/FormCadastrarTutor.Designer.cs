namespace AppPetShop
{
    partial class FormCadastrarTutor
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
            this.inputNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.inputCpf = new System.Windows.Forms.TextBox();
            this.inputEmail = new System.Windows.Forms.TextBox();
            this.inputTelefone = new System.Windows.Forms.TextBox();
            this.btnCadastrar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome do Tutor";
            // 
            // inputNome
            // 
            this.inputNome.Location = new System.Drawing.Point(148, 44);
            this.inputNome.Name = "inputNome";
            this.inputNome.Size = new System.Drawing.Size(174, 20);
            this.inputNome.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CPF do Tutor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Email do Tutor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Telefone do Tutor";
            // 
            // inputCpf
            // 
            this.inputCpf.Location = new System.Drawing.Point(148, 88);
            this.inputCpf.Name = "inputCpf";
            this.inputCpf.Size = new System.Drawing.Size(174, 20);
            this.inputCpf.TabIndex = 5;
            // 
            // inputEmail
            // 
            this.inputEmail.Location = new System.Drawing.Point(148, 134);
            this.inputEmail.Name = "inputEmail";
            this.inputEmail.Size = new System.Drawing.Size(174, 20);
            this.inputEmail.TabIndex = 6;
            // 
            // inputTelefone
            // 
            this.inputTelefone.Location = new System.Drawing.Point(148, 185);
            this.inputTelefone.Name = "inputTelefone";
            this.inputTelefone.Size = new System.Drawing.Size(174, 20);
            this.inputTelefone.TabIndex = 7;
            // 
            // btnCadastrar
            // 
            this.btnCadastrar.Location = new System.Drawing.Point(41, 226);
            this.btnCadastrar.Name = "btnCadastrar";
            this.btnCadastrar.Size = new System.Drawing.Size(281, 23);
            this.btnCadastrar.TabIndex = 8;
            this.btnCadastrar.Text = "Cadastrar Tutor";
            this.btnCadastrar.UseVisualStyleBackColor = true;
            this.btnCadastrar.Click += new System.EventHandler(this.btnCadastrar_Click);
            // 
            // FormCadastrarTutor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCadastrar);
            this.Controls.Add(this.inputTelefone);
            this.Controls.Add(this.inputEmail);
            this.Controls.Add(this.inputCpf);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.inputNome);
            this.Controls.Add(this.label1);
            this.Name = "FormCadastrarTutor";
            this.Text = "FormCadastrarTutor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox inputNome;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox inputCpf;
        private System.Windows.Forms.TextBox inputEmail;
        private System.Windows.Forms.TextBox inputTelefone;
        private System.Windows.Forms.Button btnCadastrar;
    }
}