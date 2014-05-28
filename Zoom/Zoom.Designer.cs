namespace WindowsFormsApplication1
{
    partial class Zoom
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
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defineHotkeysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoSaveModeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scriptSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.variablesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateTitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createJumpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.websiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gitHubToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox_task = new System.Windows.Forms.TextBox();
            this.label_task = new System.Windows.Forms.Label();
            this.textBox_primary = new System.Windows.Forms.TextBox();
            this.label_primary = new System.Windows.Forms.Label();
            this.comboBox_cmd = new System.Windows.Forms.ComboBox();
            this.label_secondary = new System.Windows.Forms.Label();
            this.textBox_secondary = new System.Windows.Forms.TextBox();
            this.comboBox_cmdOption = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.optionsToolStripMenuItem,
            this.scriptSettingsToolStripMenuItem,
            this.jumpToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(517, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(37, 20);
            this.toolStripMenuItem1.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defineHotkeysToolStripMenuItem,
            this.autoSaveModeToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // defineHotkeysToolStripMenuItem
            // 
            this.defineHotkeysToolStripMenuItem.Name = "defineHotkeysToolStripMenuItem";
            this.defineHotkeysToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.defineHotkeysToolStripMenuItem.Text = "Define Hotkeys...";
            // 
            // autoSaveModeToolStripMenuItem
            // 
            this.autoSaveModeToolStripMenuItem.CheckOnClick = true;
            this.autoSaveModeToolStripMenuItem.Name = "autoSaveModeToolStripMenuItem";
            this.autoSaveModeToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.autoSaveModeToolStripMenuItem.Text = "Auto Save Mode";
            this.autoSaveModeToolStripMenuItem.Click += new System.EventHandler(this.autoSaveModeToolStripMenuItem_Click);
            // 
            // scriptSettingsToolStripMenuItem
            // 
            this.scriptSettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modesToolStripMenuItem,
            this.variablesToolStripMenuItem,
            this.updateTitleToolStripMenuItem});
            this.scriptSettingsToolStripMenuItem.Name = "scriptSettingsToolStripMenuItem";
            this.scriptSettingsToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.scriptSettingsToolStripMenuItem.Text = "Script Settings";
            // 
            // modesToolStripMenuItem
            // 
            this.modesToolStripMenuItem.Name = "modesToolStripMenuItem";
            this.modesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.modesToolStripMenuItem.Text = "Modes...";
            // 
            // variablesToolStripMenuItem
            // 
            this.variablesToolStripMenuItem.Name = "variablesToolStripMenuItem";
            this.variablesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.variablesToolStripMenuItem.Text = "Variables...";
            // 
            // updateTitleToolStripMenuItem
            // 
            this.updateTitleToolStripMenuItem.Name = "updateTitleToolStripMenuItem";
            this.updateTitleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.updateTitleToolStripMenuItem.Text = "Update Title...";
            this.updateTitleToolStripMenuItem.Click += new System.EventHandler(this.updateTitleToolStripMenuItem_Click);
            // 
            // jumpToolStripMenuItem
            // 
            this.jumpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createJumpToolStripMenuItem});
            this.jumpToolStripMenuItem.Name = "jumpToolStripMenuItem";
            this.jumpToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.jumpToolStripMenuItem.Text = "Jump";
            // 
            // createJumpToolStripMenuItem
            // 
            this.createJumpToolStripMenuItem.Name = "createJumpToolStripMenuItem";
            this.createJumpToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.createJumpToolStripMenuItem.Text = "Create Jump";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.websiteToolStripMenuItem,
            this.gitHubToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // websiteToolStripMenuItem
            // 
            this.websiteToolStripMenuItem.Name = "websiteToolStripMenuItem";
            this.websiteToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.websiteToolStripMenuItem.Text = "Website";
            // 
            // gitHubToolStripMenuItem
            // 
            this.gitHubToolStripMenuItem.Name = "gitHubToolStripMenuItem";
            this.gitHubToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.gitHubToolStripMenuItem.Text = "Git Hub";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // textBox_task
            // 
            this.textBox_task.Location = new System.Drawing.Point(87, 43);
            this.textBox_task.Multiline = true;
            this.textBox_task.Name = "textBox_task";
            this.textBox_task.Size = new System.Drawing.Size(351, 63);
            this.textBox_task.TabIndex = 1;
            // 
            // label_task
            // 
            this.label_task.AutoSize = true;
            this.label_task.Location = new System.Drawing.Point(84, 27);
            this.label_task.Name = "label_task";
            this.label_task.Size = new System.Drawing.Size(38, 13);
            this.label_task.TabIndex = 2;
            this.label_task.Text = "Guide:";
            // 
            // textBox_primary
            // 
            this.textBox_primary.Location = new System.Drawing.Point(87, 134);
            this.textBox_primary.Name = "textBox_primary";
            this.textBox_primary.Size = new System.Drawing.Size(351, 20);
            this.textBox_primary.TabIndex = 3;
            this.textBox_primary.TextChanged += new System.EventHandler(this.textBox_cmd_TextChanged);
            // 
            // label_primary
            // 
            this.label_primary.AutoSize = true;
            this.label_primary.Location = new System.Drawing.Point(84, 118);
            this.label_primary.Name = "label_primary";
            this.label_primary.Size = new System.Drawing.Size(57, 13);
            this.label_primary.TabIndex = 4;
            this.label_primary.Text = "Command:";
            // 
            // comboBox_cmd
            // 
            this.comboBox_cmd.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBox_cmd.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_cmd.FormattingEnabled = true;
            this.comboBox_cmd.Items.AddRange(new object[] {
            "String",
            "Run",
            "Copy",
            "Delete",
            "Mouse"});
            this.comboBox_cmd.Location = new System.Drawing.Point(12, 134);
            this.comboBox_cmd.Name = "comboBox_cmd";
            this.comboBox_cmd.Size = new System.Drawing.Size(66, 21);
            this.comboBox_cmd.TabIndex = 5;
            this.comboBox_cmd.SelectedIndexChanged += new System.EventHandler(this.comboBox_cmd_SelectedIndexChanged);
            // 
            // label_secondary
            // 
            this.label_secondary.AutoSize = true;
            this.label_secondary.Location = new System.Drawing.Point(87, 157);
            this.label_secondary.Name = "label_secondary";
            this.label_secondary.Size = new System.Drawing.Size(23, 13);
            this.label_secondary.TabIndex = 6;
            this.label_secondary.Text = "To:";
            this.label_secondary.Visible = false;
            // 
            // textBox_secondary
            // 
            this.textBox_secondary.Location = new System.Drawing.Point(87, 174);
            this.textBox_secondary.Name = "textBox_secondary";
            this.textBox_secondary.Size = new System.Drawing.Size(351, 20);
            this.textBox_secondary.TabIndex = 7;
            this.textBox_secondary.Visible = false;
            // 
            // comboBox_cmdOption
            // 
            this.comboBox_cmdOption.FormattingEnabled = true;
            this.comboBox_cmdOption.Location = new System.Drawing.Point(12, 174);
            this.comboBox_cmdOption.Name = "comboBox_cmdOption";
            this.comboBox_cmdOption.Size = new System.Drawing.Size(69, 21);
            this.comboBox_cmdOption.TabIndex = 8;
            this.comboBox_cmdOption.Visible = false;
            // 
            // Zoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 217);
            this.Controls.Add(this.comboBox_cmdOption);
            this.Controls.Add(this.textBox_secondary);
            this.Controls.Add(this.label_secondary);
            this.Controls.Add(this.comboBox_cmd);
            this.Controls.Add(this.label_primary);
            this.Controls.Add(this.textBox_primary);
            this.Controls.Add(this.label_task);
            this.Controls.Add(this.textBox_task);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Zoom";
            this.Text = "Zoom";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defineHotkeysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoSaveModeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scriptSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem variablesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jumpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createJumpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem websiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gitHubToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox_task;
        private System.Windows.Forms.Label label_task;
        private System.Windows.Forms.TextBox textBox_primary;
        private System.Windows.Forms.Label label_primary;
        private System.Windows.Forms.ComboBox comboBox_cmd;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Label label_secondary;
        private System.Windows.Forms.TextBox textBox_secondary;
        private System.Windows.Forms.ComboBox comboBox_cmdOption;
        private System.Windows.Forms.ToolStripMenuItem updateTitleToolStripMenuItem;
    }
}

