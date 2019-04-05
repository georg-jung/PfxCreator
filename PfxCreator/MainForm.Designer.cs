namespace PfxCreator
{
    partial class MainForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.certGroupBox = new System.Windows.Forms.GroupBox();
            this.certTextBox = new System.Windows.Forms.TextBox();
            this.privateKeyGroupBox = new System.Windows.Forms.GroupBox();
            this.privateKeyTextBox = new System.Windows.Forms.TextBox();
            this.controlsPanel = new System.Windows.Forms.Panel();
            this.pfxPasswordTextBox = new System.Windows.Forms.TextBox();
            this.exportPasswordLabel = new System.Windows.Forms.Label();
            this.savePfxButton = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.certGroupBox.SuspendLayout();
            this.privateKeyGroupBox.SuspendLayout();
            this.controlsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // certGroupBox
            // 
            this.certGroupBox.Controls.Add(this.certTextBox);
            this.certGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.certGroupBox.Location = new System.Drawing.Point(6, 6);
            this.certGroupBox.Name = "certGroupBox";
            this.certGroupBox.Padding = new System.Windows.Forms.Padding(9);
            this.certGroupBox.Size = new System.Drawing.Size(572, 330);
            this.certGroupBox.TabIndex = 0;
            this.certGroupBox.TabStop = false;
            this.certGroupBox.Text = "Certificate (PEM)";
            // 
            // certTextBox
            // 
            this.certTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.certTextBox.Location = new System.Drawing.Point(9, 22);
            this.certTextBox.Multiline = true;
            this.certTextBox.Name = "certTextBox";
            this.certTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.certTextBox.Size = new System.Drawing.Size(554, 299);
            this.certTextBox.TabIndex = 0;
            // 
            // privateKeyGroupBox
            // 
            this.privateKeyGroupBox.Controls.Add(this.privateKeyTextBox);
            this.privateKeyGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.privateKeyGroupBox.Location = new System.Drawing.Point(6, 346);
            this.privateKeyGroupBox.Name = "privateKeyGroupBox";
            this.privateKeyGroupBox.Padding = new System.Windows.Forms.Padding(9);
            this.privateKeyGroupBox.Size = new System.Drawing.Size(572, 121);
            this.privateKeyGroupBox.TabIndex = 1;
            this.privateKeyGroupBox.TabStop = false;
            this.privateKeyGroupBox.Text = "Private Key (PEM)";
            // 
            // privateKeyTextBox
            // 
            this.privateKeyTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.privateKeyTextBox.Location = new System.Drawing.Point(9, 22);
            this.privateKeyTextBox.Multiline = true;
            this.privateKeyTextBox.Name = "privateKeyTextBox";
            this.privateKeyTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.privateKeyTextBox.Size = new System.Drawing.Size(554, 90);
            this.privateKeyTextBox.TabIndex = 0;
            // 
            // controlsPanel
            // 
            this.controlsPanel.Controls.Add(this.pfxPasswordTextBox);
            this.controlsPanel.Controls.Add(this.exportPasswordLabel);
            this.controlsPanel.Controls.Add(this.savePfxButton);
            this.controlsPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.controlsPanel.Location = new System.Drawing.Point(6, 467);
            this.controlsPanel.Name = "controlsPanel";
            this.controlsPanel.Size = new System.Drawing.Size(572, 38);
            this.controlsPanel.TabIndex = 2;
            // 
            // pfxPasswordTextBox
            // 
            this.pfxPasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pfxPasswordTextBox.Location = new System.Drawing.Point(88, 14);
            this.pfxPasswordTextBox.MaximumSize = new System.Drawing.Size(300, 20);
            this.pfxPasswordTextBox.MinimumSize = new System.Drawing.Size(50, 20);
            this.pfxPasswordTextBox.Name = "pfxPasswordTextBox";
            this.pfxPasswordTextBox.Size = new System.Drawing.Size(300, 20);
            this.pfxPasswordTextBox.TabIndex = 2;
            this.pfxPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // exportPasswordLabel
            // 
            this.exportPasswordLabel.AutoSize = true;
            this.exportPasswordLabel.Location = new System.Drawing.Point(3, 17);
            this.exportPasswordLabel.Name = "exportPasswordLabel";
            this.exportPasswordLabel.Size = new System.Drawing.Size(79, 13);
            this.exportPasswordLabel.TabIndex = 1;
            this.exportPasswordLabel.Text = "PFX-Password:";
            // 
            // savePfxButton
            // 
            this.savePfxButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.savePfxButton.Location = new System.Drawing.Point(469, 12);
            this.savePfxButton.Name = "savePfxButton";
            this.savePfxButton.Size = new System.Drawing.Size(100, 23);
            this.savePfxButton.TabIndex = 0;
            this.savePfxButton.Text = "Save PFX...";
            this.savePfxButton.UseVisualStyleBackColor = true;
            this.savePfxButton.Click += new System.EventHandler(this.savePfxButton_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(6, 336);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(572, 10);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 511);
            this.Controls.Add(this.certGroupBox);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.privateKeyGroupBox);
            this.Controls.Add(this.controlsPanel);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.ShowIcon = false;
            this.Text = "PfxCreator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.certGroupBox.ResumeLayout(false);
            this.certGroupBox.PerformLayout();
            this.privateKeyGroupBox.ResumeLayout(false);
            this.privateKeyGroupBox.PerformLayout();
            this.controlsPanel.ResumeLayout(false);
            this.controlsPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox certGroupBox;
        private System.Windows.Forms.GroupBox privateKeyGroupBox;
        private System.Windows.Forms.Panel controlsPanel;
        private System.Windows.Forms.Button savePfxButton;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TextBox certTextBox;
        private System.Windows.Forms.TextBox privateKeyTextBox;
        private System.Windows.Forms.TextBox pfxPasswordTextBox;
        private System.Windows.Forms.Label exportPasswordLabel;
    }
}

