namespace GEdit
{
    partial class Editer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Editer));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newTab = new System.Windows.Forms.ToolStripButton();
            this.openFile = new System.Windows.Forms.ToolStripButton();
            this.saveFile = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openThemes = new System.Windows.Forms.ToolStripButton();
            this.openConsole = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabIcons = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RunItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onlineDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTab,
            this.openFile,
            this.saveFile,
            this.toolStripSeparator1,
            this.openThemes,
            this.openConsole});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(764, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // newTab
            // 
            this.newTab.AutoToolTip = false;
            this.newTab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newTab.Image = ((System.Drawing.Image)(resources.GetObject("newTab.Image")));
            this.newTab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newTab.Name = "newTab";
            this.newTab.Size = new System.Drawing.Size(23, 22);
            this.newTab.Text = "toolStripButton1";
            this.newTab.Click += new System.EventHandler(this.addNewTab);
            // 
            // openFile
            // 
            this.openFile.AutoToolTip = false;
            this.openFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openFile.Image = ((System.Drawing.Image)(resources.GetObject("openFile.Image")));
            this.openFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(23, 22);
            this.openFile.Text = "toolStripButton2";
            this.openFile.Click += new System.EventHandler(this.OpenFile);
            // 
            // saveFile
            // 
            this.saveFile.AutoToolTip = false;
            this.saveFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveFile.Image = ((System.Drawing.Image)(resources.GetObject("saveFile.Image")));
            this.saveFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveFile.Name = "saveFile";
            this.saveFile.Size = new System.Drawing.Size(23, 22);
            this.saveFile.Click += new System.EventHandler(this.SaveFile);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // openThemes
            // 
            this.openThemes.AutoToolTip = false;
            this.openThemes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openThemes.Image = ((System.Drawing.Image)(resources.GetObject("openThemes.Image")));
            this.openThemes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openThemes.Name = "openThemes";
            this.openThemes.Size = new System.Drawing.Size(23, 22);
            this.openThemes.Text = "toolStripButton4";
            this.openThemes.Click += new System.EventHandler(this.openSettings);
            // 
            // openConsole
            // 
            this.openConsole.AutoToolTip = false;
            this.openConsole.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openConsole.Image = ((System.Drawing.Image)(resources.GetObject("openConsole.Image")));
            this.openConsole.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.openConsole.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openConsole.Name = "openConsole";
            this.openConsole.Size = new System.Drawing.Size(23, 22);
            this.openConsole.Text = "toolStripButton5";
            this.openConsole.Click += new System.EventHandler(this.toolStripButton5_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl1.ImageList = this.TabIcons;
            this.tabControl1.Location = new System.Drawing.Point(0, 49);
            this.tabControl1.MinimumSize = new System.Drawing.Size(100, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(15, 3);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(764, 392);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.drawX);
            this.tabControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.closeTab);
            // 
            // TabIcons
            // 
            this.TabIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TabIcons.ImageStream")));
            this.TabIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.TabIcons.Images.SetKeyName(0, "text-plain-icon.png");
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.GhostWhite;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMenu,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(764, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.OpenItem,
            this.SaveItem,
            this.SaveAsItem,
            this.ExitItem});
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(37, 20);
            this.FileMenu.Text = "File";
            // 
            // OpenItem
            // 
            this.OpenItem.Name = "OpenItem";
            this.OpenItem.Size = new System.Drawing.Size(114, 22);
            this.OpenItem.Text = "Open";
            this.OpenItem.Click += new System.EventHandler(this.OpenFile);
            // 
            // SaveItem
            // 
            this.SaveItem.Name = "SaveItem";
            this.SaveItem.Size = new System.Drawing.Size(114, 22);
            this.SaveItem.Text = "Save";
            this.SaveItem.Click += new System.EventHandler(this.saveMenu);
            // 
            // SaveAsItem
            // 
            this.SaveAsItem.Name = "SaveAsItem";
            this.SaveAsItem.Size = new System.Drawing.Size(114, 22);
            this.SaveAsItem.Text = "Save As";
            this.SaveAsItem.Click += new System.EventHandler(this.save);
            // 
            // ExitItem
            // 
            this.ExitItem.Name = "ExitItem";
            this.ExitItem.Size = new System.Drawing.Size(114, 22);
            this.ExitItem.Text = "Exit";
            this.ExitItem.Click += new System.EventHandler(this.exit);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RunItem,
            this.onlineDataToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // RunItem
            // 
            this.RunItem.Name = "RunItem";
            this.RunItem.Size = new System.Drawing.Size(136, 22);
            this.RunItem.Text = "Run";
            this.RunItem.Click += new System.EventHandler(this.runItem);
            // 
            // onlineDataToolStripMenuItem
            // 
            this.onlineDataToolStripMenuItem.Name = "onlineDataToolStripMenuItem";
            this.onlineDataToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.onlineDataToolStripMenuItem.Text = "Online Data";
            this.onlineDataToolStripMenuItem.Click += new System.EventHandler(this.loadOnlineData);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutItem
            // 
            this.aboutItem.Name = "aboutItem";
            this.aboutItem.Size = new System.Drawing.Size(107, 22);
            this.aboutItem.Text = "About";
            this.aboutItem.Click += new System.EventHandler(this.openAbout);
            // 
            // Editer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 441);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Editer";
            this.Text = "GEditor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripButton newTab;
        private System.Windows.Forms.ToolStripButton openFile;
        private System.Windows.Forms.ToolStripButton saveFile;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem OpenItem;
        private System.Windows.Forms.ToolStripMenuItem SaveItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAsItem;
        private System.Windows.Forms.ToolStripButton openThemes;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutItem;
        private System.Windows.Forms.ToolStripMenuItem ExitItem;
        private System.Windows.Forms.ImageList TabIcons;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RunItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem onlineDataToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton openConsole;
    }
}

