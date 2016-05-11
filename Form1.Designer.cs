namespace ProjectSchool
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.achatGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichiersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chargerDesDonnéesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chargerDesDonnéesDéjàImputéesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sauvegarderDesDonnéesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gestionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utilisateursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aProposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.achatTreeView = new System.Windows.Forms.TreeView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.modeBox = new System.Windows.Forms.ComboBox();
            this.groupFilter = new System.Windows.Forms.GroupBox();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.dateFilter = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.achatGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.SuspendLayout();
            // 
            // achatGridView
            // 
            this.achatGridView.AllowUserToAddRows = false;
            this.achatGridView.AllowUserToDeleteRows = false;
            this.achatGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.achatGridView.Location = new System.Drawing.Point(12, 86);
            this.achatGridView.Name = "achatGridView";
            this.achatGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.achatGridView.ShowEditingIcon = false;
            this.achatGridView.Size = new System.Drawing.Size(436, 494);
            this.achatGridView.TabIndex = 1;
            this.achatGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.achatGridView_MouseDown);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichiersToolStripMenuItem,
            this.gestionToolStripMenuItem,
            this.aProposToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(854, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichiersToolStripMenuItem
            // 
            this.fichiersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chargerDesDonnéesToolStripMenuItem,
            this.chargerDesDonnéesDéjàImputéesToolStripMenuItem,
            this.sauvegarderDesDonnéesToolStripMenuItem});
            this.fichiersToolStripMenuItem.Name = "fichiersToolStripMenuItem";
            this.fichiersToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.fichiersToolStripMenuItem.Text = "Fichiers";
            // 
            // chargerDesDonnéesToolStripMenuItem
            // 
            this.chargerDesDonnéesToolStripMenuItem.Name = "chargerDesDonnéesToolStripMenuItem";
            this.chargerDesDonnéesToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.chargerDesDonnéesToolStripMenuItem.Text = "Charger des données brut";
            this.chargerDesDonnéesToolStripMenuItem.Click += new System.EventHandler(this.chargerDesDonnéesToolStripMenuItem_Click);
            // 
            // chargerDesDonnéesDéjàImputéesToolStripMenuItem
            // 
            this.chargerDesDonnéesDéjàImputéesToolStripMenuItem.Name = "chargerDesDonnéesDéjàImputéesToolStripMenuItem";
            this.chargerDesDonnéesDéjàImputéesToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.chargerDesDonnéesDéjàImputéesToolStripMenuItem.Text = "Charger des données déjà imputées";
            this.chargerDesDonnéesDéjàImputéesToolStripMenuItem.Click += new System.EventHandler(this.chargerDesDonnéesDéjàImputéesToolStripMenuItem_Click);
            // 
            // sauvegarderDesDonnéesToolStripMenuItem
            // 
            this.sauvegarderDesDonnéesToolStripMenuItem.Name = "sauvegarderDesDonnéesToolStripMenuItem";
            this.sauvegarderDesDonnéesToolStripMenuItem.Size = new System.Drawing.Size(262, 22);
            this.sauvegarderDesDonnéesToolStripMenuItem.Text = "Sauvegarder des données";
            this.sauvegarderDesDonnéesToolStripMenuItem.Click += new System.EventHandler(this.sauvegarderDesDonnéesToolStripMenuItem_Click);
            // 
            // gestionToolStripMenuItem
            // 
            this.gestionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.utilisateursToolStripMenuItem});
            this.gestionToolStripMenuItem.Name = "gestionToolStripMenuItem";
            this.gestionToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.gestionToolStripMenuItem.Text = "Gestion";
            // 
            // utilisateursToolStripMenuItem
            // 
            this.utilisateursToolStripMenuItem.Name = "utilisateursToolStripMenuItem";
            this.utilisateursToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.utilisateursToolStripMenuItem.Text = "Utilisateurs";
            // 
            // aProposToolStripMenuItem
            // 
            this.aProposToolStripMenuItem.Name = "aProposToolStripMenuItem";
            this.aProposToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.aProposToolStripMenuItem.Text = "A propos";
            // 
            // achatTreeView
            // 
            this.achatTreeView.AllowDrop = true;
            this.achatTreeView.LabelEdit = true;
            this.achatTreeView.Location = new System.Drawing.Point(452, 86);
            this.achatTreeView.Name = "achatTreeView";
            this.achatTreeView.Size = new System.Drawing.Size(390, 494);
            this.achatTreeView.TabIndex = 3;
            this.achatTreeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.achatTreeView_AfterLabelEdit);
            this.achatTreeView.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.achatTreeView_ItemDrag);
            this.achatTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.achatTreeView_NodeMouseClick);
            this.achatTreeView.DragDrop += new System.Windows.Forms.DragEventHandler(this.achatTreeView_DragDrop);
            this.achatTreeView.DragEnter += new System.Windows.Forms.DragEventHandler(this.achatTreeView_DragEnter);
            this.achatTreeView.DragOver += new System.Windows.Forms.DragEventHandler(this.achatTreeView_DragOver);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.modeBox);
            this.groupBox1.Location = new System.Drawing.Point(13, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(138, 52);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mode";
            // 
            // modeBox
            // 
            this.modeBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.modeBox.DisplayMember = "Edition";
            this.modeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeBox.FormattingEnabled = true;
            this.modeBox.Items.AddRange(new object[] {
            "Edition",
            "Bilan"});
            this.modeBox.Location = new System.Drawing.Point(6, 19);
            this.modeBox.Name = "modeBox";
            this.modeBox.Size = new System.Drawing.Size(121, 21);
            this.modeBox.TabIndex = 0;
            this.modeBox.SelectedIndexChanged += new System.EventHandler(this.modeBox_SelectedIndexChanged);
            // 
            // groupFilter
            // 
            this.groupFilter.Controls.Add(this.dateFilter);
            this.groupFilter.Location = new System.Drawing.Point(157, 28);
            this.groupFilter.Name = "groupFilter";
            this.groupFilter.Size = new System.Drawing.Size(130, 52);
            this.groupFilter.TabIndex = 5;
            this.groupFilter.TabStop = false;
            this.groupFilter.Text = "Option tri";
            // 
            // eventLog1
            // 
            this.eventLog1.SynchronizingObject = this;
            // 
            // dateFilter
            // 
            this.dateFilter.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFilter.Location = new System.Drawing.Point(7, 19);
            this.dateFilter.Name = "dateFilter";
            this.dateFilter.Size = new System.Drawing.Size(117, 20);
            this.dateFilter.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 592);
            this.Controls.Add(this.groupFilter);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.achatTreeView);
            this.Controls.Add(this.achatGridView);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Budget Manager";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.achatGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView achatGridView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichiersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chargerDesDonnéesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chargerDesDonnéesDéjàImputéesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sauvegarderDesDonnéesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gestionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem utilisateursToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aProposToolStripMenuItem;
        private System.Windows.Forms.TreeView achatTreeView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox modeBox;
        private System.Windows.Forms.GroupBox groupFilter;
        private System.Windows.Forms.DateTimePicker dateFilter;
        private System.Diagnostics.EventLog eventLog1;
    }
}

