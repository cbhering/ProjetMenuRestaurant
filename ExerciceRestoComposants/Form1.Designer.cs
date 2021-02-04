namespace ExerciceRestoComposants
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.commandesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.montrerLesCommandesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ajouterUneLigneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifierUneLigneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerUneLigneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.composantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tdcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(153, 72);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(160, 97);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // bindingSource1
            // 
            this.bindingSource1.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commandesToolStripMenuItem,
            this.composantToolStripMenuItem,
            this.tdcToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(533, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // commandesToolStripMenuItem
            // 
            this.commandesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.montrerLesCommandesToolStripMenuItem,
            this.toolStripSeparator1,
            this.ajouterUneLigneToolStripMenuItem,
            this.modifierUneLigneToolStripMenuItem,
            this.supprimerUneLigneToolStripMenuItem});
            this.commandesToolStripMenuItem.Name = "commandesToolStripMenuItem";
            this.commandesToolStripMenuItem.Size = new System.Drawing.Size(90, 22);
            this.commandesToolStripMenuItem.Text = "Commandes ";
            // 
            // montrerLesCommandesToolStripMenuItem
            // 
            this.montrerLesCommandesToolStripMenuItem.Name = "montrerLesCommandesToolStripMenuItem";
            this.montrerLesCommandesToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.montrerLesCommandesToolStripMenuItem.Text = "Montrer les commandes";
            this.montrerLesCommandesToolStripMenuItem.Click += new System.EventHandler(this.montrerLesCommandesToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(200, 6);
            // 
            // ajouterUneLigneToolStripMenuItem
            // 
            this.ajouterUneLigneToolStripMenuItem.Name = "ajouterUneLigneToolStripMenuItem";
            this.ajouterUneLigneToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.ajouterUneLigneToolStripMenuItem.Text = "Ajouter une ligne";
            this.ajouterUneLigneToolStripMenuItem.Click += new System.EventHandler(this.ajouterUneLigneToolStripMenuItem_Click);
            // 
            // modifierUneLigneToolStripMenuItem
            // 
            this.modifierUneLigneToolStripMenuItem.Name = "modifierUneLigneToolStripMenuItem";
            this.modifierUneLigneToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.modifierUneLigneToolStripMenuItem.Text = "Modifier une ligne ";
            this.modifierUneLigneToolStripMenuItem.Click += new System.EventHandler(this.modifierUneLigneToolStripMenuItem_Click);
            // 
            // supprimerUneLigneToolStripMenuItem
            // 
            this.supprimerUneLigneToolStripMenuItem.Name = "supprimerUneLigneToolStripMenuItem";
            this.supprimerUneLigneToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.supprimerUneLigneToolStripMenuItem.Text = "Supprimer une ligne";
            this.supprimerUneLigneToolStripMenuItem.Click += new System.EventHandler(this.supprimerUneLigneToolStripMenuItem_Click);
            // 
            // composantToolStripMenuItem
            // 
            this.composantToolStripMenuItem.Name = "composantToolStripMenuItem";
            this.composantToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.composantToolStripMenuItem.Text = "Composants";
            this.composantToolStripMenuItem.Click += new System.EventHandler(this.composantToolStripMenuItem_Click);
            // 
            // tdcToolStripMenuItem
            // 
            this.tdcToolStripMenuItem.Name = "tdcToolStripMenuItem";
            this.tdcToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.tdcToolStripMenuItem.Text = "Type de composant";
            this.tdcToolStripMenuItem.Click += new System.EventHandler(this.tdcToolStripMenuItem_Click);
            // 
            // bindingSource2
            // 
            this.bindingSource2.CurrentChanged += new System.EventHandler(this.bindingSource2_CurrentChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 292);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Resto";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem commandesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem montrerLesCommandesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ajouterUneLigneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifierUneLigneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supprimerUneLigneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem composantToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tdcToolStripMenuItem;
        private System.Windows.Forms.BindingSource bindingSource2;
    }
}

