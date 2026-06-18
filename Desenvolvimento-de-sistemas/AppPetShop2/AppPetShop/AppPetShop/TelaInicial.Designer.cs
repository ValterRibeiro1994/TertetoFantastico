namespace AppPetShop
{
    partial class TelaInicial
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tutorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarTutorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesquisarTutorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.petsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cadastrarPetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pesquisarPetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Gold;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tutorToolStripMenuItem,
            this.petsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tutorToolStripMenuItem
            // 
            this.tutorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarTutorToolStripMenuItem,
            this.pesquisarTutorToolStripMenuItem});
            this.tutorToolStripMenuItem.Name = "tutorToolStripMenuItem";
            this.tutorToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.tutorToolStripMenuItem.Text = "Tutor";
            // 
            // cadastrarTutorToolStripMenuItem
            // 
            this.cadastrarTutorToolStripMenuItem.Name = "cadastrarTutorToolStripMenuItem";
            this.cadastrarTutorToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.cadastrarTutorToolStripMenuItem.Text = "Cadastrar Tutor";
            this.cadastrarTutorToolStripMenuItem.Click += new System.EventHandler(this.cadastrarTutorToolStripMenuItem_Click);
            // 
            // pesquisarTutorToolStripMenuItem
            // 
            this.pesquisarTutorToolStripMenuItem.Name = "pesquisarTutorToolStripMenuItem";
            this.pesquisarTutorToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.pesquisarTutorToolStripMenuItem.Text = "Pesquisar Tutor";
            this.pesquisarTutorToolStripMenuItem.Click += new System.EventHandler(this.pesquisarTutorToolStripMenuItem_Click);
            // 
            // petsToolStripMenuItem
            // 
            this.petsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cadastrarPetToolStripMenuItem,
            this.pesquisarPetToolStripMenuItem});
            this.petsToolStripMenuItem.Name = "petsToolStripMenuItem";
            this.petsToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.petsToolStripMenuItem.Text = "Pets";
            // 
            // cadastrarPetToolStripMenuItem
            // 
            this.cadastrarPetToolStripMenuItem.Name = "cadastrarPetToolStripMenuItem";
            this.cadastrarPetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cadastrarPetToolStripMenuItem.Text = "Cadastrar Pet";
            this.cadastrarPetToolStripMenuItem.Click += new System.EventHandler(this.cadastrarPetToolStripMenuItem_Click);
            // 
            // pesquisarPetToolStripMenuItem
            // 
            this.pesquisarPetToolStripMenuItem.Name = "pesquisarPetToolStripMenuItem";
            this.pesquisarPetToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pesquisarPetToolStripMenuItem.Text = "Pesquisar Pet";
            this.pesquisarPetToolStripMenuItem.Click += new System.EventHandler(this.pesquisarPetToolStripMenuItem_Click);
            // 
            // TelaInicial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CadetBlue;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TelaInicial";
            this.Text = "TelaInicial";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fecharApp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tutorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarTutorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pesquisarTutorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem petsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cadastrarPetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pesquisarPetToolStripMenuItem;
    }
}