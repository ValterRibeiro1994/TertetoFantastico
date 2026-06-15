namespace AppPetShop
{
    partial class FormBuscarTutor
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
            this.campoCpf = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.campoNome = new System.Windows.Forms.TextBox();
            this.campoEmail = new System.Windows.Forms.TextBox();
            this.campoTelefone = new System.Windows.Forms.TextBox();
            this.btnFiltrarCpf = new System.Windows.Forms.Button();
            this.btnPesquisarTodos = new System.Windows.Forms.Button();
            this.gridTutor = new System.Windows.Forms.DataGridView();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridTutor)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(327, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Localizar Tutores";
            // 
            // campoCpf
            // 
            this.campoCpf.Location = new System.Drawing.Point(148, 96);
            this.campoCpf.Name = "campoCpf";
            this.campoCpf.Size = new System.Drawing.Size(165, 20);
            this.campoCpf.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "CPF Tutor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nome Tutor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Email Tutor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 231);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Telefone Tutor";
            // 
            // campoNome
            // 
            this.campoNome.Location = new System.Drawing.Point(148, 140);
            this.campoNome.Name = "campoNome";
            this.campoNome.Size = new System.Drawing.Size(165, 20);
            this.campoNome.TabIndex = 6;
            // 
            // campoEmail
            // 
            this.campoEmail.Location = new System.Drawing.Point(148, 182);
            this.campoEmail.Name = "campoEmail";
            this.campoEmail.Size = new System.Drawing.Size(165, 20);
            this.campoEmail.TabIndex = 7;
            // 
            // campoTelefone
            // 
            this.campoTelefone.Location = new System.Drawing.Point(148, 224);
            this.campoTelefone.Name = "campoTelefone";
            this.campoTelefone.Size = new System.Drawing.Size(165, 20);
            this.campoTelefone.TabIndex = 8;
            // 
            // btnFiltrarCpf
            // 
            this.btnFiltrarCpf.Location = new System.Drawing.Point(51, 285);
            this.btnFiltrarCpf.Name = "btnFiltrarCpf";
            this.btnFiltrarCpf.Size = new System.Drawing.Size(103, 23);
            this.btnFiltrarCpf.TabIndex = 9;
            this.btnFiltrarCpf.Text = "Buscar CPF";
            this.btnFiltrarCpf.UseVisualStyleBackColor = true;
            this.btnFiltrarCpf.Click += new System.EventHandler(this.btnFiltrarCpf_Click);
            // 
            // btnPesquisarTodos
            // 
            this.btnPesquisarTodos.Location = new System.Drawing.Point(184, 285);
            this.btnPesquisarTodos.Name = "btnPesquisarTodos";
            this.btnPesquisarTodos.Size = new System.Drawing.Size(93, 23);
            this.btnPesquisarTodos.TabIndex = 10;
            this.btnPesquisarTodos.Text = "Buscar Todos";
            this.btnPesquisarTodos.UseVisualStyleBackColor = true;
            this.btnPesquisarTodos.Click += new System.EventHandler(this.btnPesquisarTodos_Click);
            // 
            // gridTutor
            // 
            this.gridTutor.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridTutor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTutor.Location = new System.Drawing.Point(319, 96);
            this.gridTutor.Name = "gridTutor";
            this.gridTutor.Size = new System.Drawing.Size(474, 241);
            this.gridTutor.TabIndex = 11;
            this.gridTutor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridTutor_CellClick);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(51, 314);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(103, 23);
            this.btnAlterar.TabIndex = 12;
            this.btnAlterar.Text = "Alterar Tutor";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(184, 314);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(103, 23);
            this.btnLimpar.TabIndex = 13;
            this.btnLimpar.Text = "Limpar Campos";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // FormBuscarTutor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 361);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.gridTutor);
            this.Controls.Add(this.btnPesquisarTodos);
            this.Controls.Add(this.btnFiltrarCpf);
            this.Controls.Add(this.campoTelefone);
            this.Controls.Add(this.campoEmail);
            this.Controls.Add(this.campoNome);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.campoCpf);
            this.Controls.Add(this.label1);
            this.Name = "FormBuscarTutor";
            this.Text = "FormBuscarTutor";
            ((System.ComponentModel.ISupportInitialize)(this.gridTutor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox campoCpf;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox campoNome;
        private System.Windows.Forms.TextBox campoEmail;
        private System.Windows.Forms.TextBox campoTelefone;
        private System.Windows.Forms.Button btnFiltrarCpf;
        private System.Windows.Forms.Button btnPesquisarTodos;
        private System.Windows.Forms.DataGridView gridTutor;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnLimpar;
    }
}