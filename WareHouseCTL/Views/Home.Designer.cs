namespace WareHouseCTL.Views
{
    partial class Home
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
            panelMain = new Panel();
            panelBody = new Panel();
            paneBody = new Panel();
            panelOptions = new Panel();
            lbShelfContainerManager = new Label();
            lbShelfManager = new Label();
            lbChemicalManager = new Label();
            panelMainShelf = new Panel();
            panelHeader = new Panel();
            lbMainTitle = new Label();
            lbLogo = new Label();
            panelMain.SuspendLayout();
            panelBody.SuspendLayout();
            paneBody.SuspendLayout();
            panelOptions.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = SystemColors.Highlight;
            panelMain.Controls.Add(panelBody);
            panelMain.Controls.Add(panelHeader);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1391, 754);
            panelMain.TabIndex = 0;
            // 
            // panelBody
            // 
            panelBody.BackColor = SystemColors.ActiveCaption;
            panelBody.Controls.Add(paneBody);
            panelBody.Dock = DockStyle.Fill;
            panelBody.Location = new Point(0, 100);
            panelBody.Name = "panelBody";
            panelBody.Size = new Size(1391, 654);
            panelBody.TabIndex = 1;
            // 
            // paneBody
            // 
            paneBody.BackColor = Color.White;
            paneBody.Controls.Add(panelOptions);
            paneBody.Controls.Add(panelMainShelf);
            paneBody.Dock = DockStyle.Fill;
            paneBody.Location = new Point(0, 0);
            paneBody.Name = "paneBody";
            paneBody.Size = new Size(1391, 654);
            paneBody.TabIndex = 1;
            // 
            // panelOptions
            // 
            panelOptions.BackColor = Color.FromArgb(135, 206, 250);
            panelOptions.BorderStyle = BorderStyle.FixedSingle;
            panelOptions.Controls.Add(lbShelfContainerManager);
            panelOptions.Controls.Add(lbShelfManager);
            panelOptions.Controls.Add(lbChemicalManager);
            panelOptions.Dock = DockStyle.Right;
            panelOptions.Location = new Point(974, 0);
            panelOptions.Name = "panelOptions";
            panelOptions.Size = new Size(417, 654);
            panelOptions.TabIndex = 1;
            // 
            // lbShelfContainerManager
            // 
            lbShelfContainerManager.BackColor = Color.FromArgb(70, 130, 180);
            lbShelfContainerManager.Cursor = Cursors.Hand;
            lbShelfContainerManager.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbShelfContainerManager.ForeColor = Color.White;
            lbShelfContainerManager.Location = new Point(0, 115);
            lbShelfContainerManager.Name = "lbShelfContainerManager";
            lbShelfContainerManager.Size = new Size(417, 50);
            lbShelfContainerManager.TabIndex = 2;
            lbShelfContainerManager.Text = "QUẢN LÝ NGĂN CHỨA";
            lbShelfContainerManager.TextAlign = ContentAlignment.MiddleCenter;
            lbShelfContainerManager.Click += lbShelfContainerManager_Click;
            lbShelfContainerManager.MouseEnter += lbShelfContainerManager_MouseEnter;
            lbShelfContainerManager.MouseLeave += lbShelfContainerManager_MouseLeave;
            // 
            // lbShelfManager
            // 
            lbShelfManager.BackColor = Color.FromArgb(70, 130, 180);
            lbShelfManager.Cursor = Cursors.Hand;
            lbShelfManager.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbShelfManager.ForeColor = Color.White;
            lbShelfManager.Location = new Point(0, 176);
            lbShelfManager.Name = "lbShelfManager";
            lbShelfManager.Size = new Size(417, 50);
            lbShelfManager.TabIndex = 1;
            lbShelfManager.Text = "QUẢN LÝ KỆ";
            lbShelfManager.TextAlign = ContentAlignment.MiddleCenter;
            lbShelfManager.Click += lbShelfManager_Click;
            lbShelfManager.MouseEnter += lbShelfManager_MouseEnter;
            lbShelfManager.MouseLeave += lbShelfManager_MouseLeave;
            // 
            // lbChemicalManager
            // 
            lbChemicalManager.BackColor = Color.FromArgb(70, 130, 180);
            lbChemicalManager.Cursor = Cursors.Hand;
            lbChemicalManager.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbChemicalManager.ForeColor = Color.White;
            lbChemicalManager.Location = new Point(0, 55);
            lbChemicalManager.Name = "lbChemicalManager";
            lbChemicalManager.Size = new Size(417, 50);
            lbChemicalManager.TabIndex = 0;
            lbChemicalManager.Text = "QUẢN LÝ HÓA CHẤT";
            lbChemicalManager.TextAlign = ContentAlignment.MiddleCenter;
            lbChemicalManager.Click += lbChemicalManager_Click;
            lbChemicalManager.MouseEnter += lbChemicalManager_MouseEnter;
            lbChemicalManager.MouseLeave += lbChemicalManager_MouseLeave;
            // 
            // panelMainShelf
            // 
            panelMainShelf.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelMainShelf.AutoScroll = true;
            panelMainShelf.BackColor = Color.LightCyan;
            panelMainShelf.Location = new Point(0, 0);
            panelMainShelf.Name = "panelMainShelf";
            panelMainShelf.Size = new Size(974, 654);
            panelMainShelf.TabIndex = 3;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(203, 10, 46);
            panelHeader.Controls.Add(lbMainTitle);
            panelHeader.Controls.Add(lbLogo);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(5);
            panelHeader.Size = new Size(1391, 100);
            panelHeader.TabIndex = 0;
            // 
            // lbMainTitle
            // 
            lbMainTitle.Anchor = AnchorStyles.Top;
            lbMainTitle.BackColor = Color.Transparent;
            lbMainTitle.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbMainTitle.ForeColor = Color.White;
            lbMainTitle.Location = new Point(459, 37);
            lbMainTitle.Name = "lbMainTitle";
            lbMainTitle.Size = new Size(419, 34);
            lbMainTitle.TabIndex = 1;
            lbMainTitle.Text = "QUẢN LÝ KHO HÓA CHẤT";
            // 
            // lbLogo
            // 
            lbLogo.Anchor = AnchorStyles.Left;
            lbLogo.BackColor = Color.Transparent;
            lbLogo.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbLogo.ForeColor = Color.White;
            lbLogo.Location = new Point(29, 37);
            lbLogo.Name = "lbLogo";
            lbLogo.Size = new Size(202, 34);
            lbLogo.TabIndex = 0;
            lbLogo.Text = "DRB Vietnam";
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1391, 754);
            Controls.Add(panelMain);
            Name = "Home";
            Text = "Demo";
            panelMain.ResumeLayout(false);
            panelBody.ResumeLayout(false);
            paneBody.ResumeLayout(false);
            panelOptions.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;
        private Panel panelHeader;
        private Label lbLogo;
        private Label lbMainTitle;
        private Panel panelBody;
        private Panel paneBody;
        private Panel panelMainShelf;
        private Panel panelOptions;
        private Label lbShelfContainerManager;
        private Label lbShelfManager;
        private Label lbChemicalManager;
    }
}