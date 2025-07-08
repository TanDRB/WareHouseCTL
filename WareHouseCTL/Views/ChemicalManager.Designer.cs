namespace WareHouseCTL.Views
{
    partial class ChemicalManager
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
            dataGridViewChemicals = new DataGridView();
            panelControls = new Panel();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            richTextBoxChemicalDescribe = new RichTextBox();
            txtChemicalName = new TextBox();
            txtChemicalID = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewChemicals).BeginInit();
            panelControls.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewChemicals
            // 
            dataGridViewChemicals.AllowUserToAddRows = false;
            dataGridViewChemicals.AllowUserToDeleteRows = false;
            dataGridViewChemicals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewChemicals.BackgroundColor = Color.FromArgb(248, 249, 250);
            dataGridViewChemicals.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewChemicals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewChemicals.EnableHeadersVisualStyles = false;
            dataGridViewChemicals.Location = new Point(20, 351);
            dataGridViewChemicals.Name = "dataGridViewChemicals";
            dataGridViewChemicals.ReadOnly = true;
            dataGridViewChemicals.RowHeadersVisible = false;
            dataGridViewChemicals.RowTemplate.Height = 35;
            dataGridViewChemicals.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewChemicals.Size = new Size(1195, 417);
            dataGridViewChemicals.TabIndex = 0;
            dataGridViewChemicals.SelectionChanged += dataGridViewChemicals_SelectionChanged;
            // 
            // panelControls
            // 
            panelControls.BackColor = Color.FromArgb(248, 249, 250);
            panelControls.Controls.Add(btnDelete);
            panelControls.Controls.Add(btnUpdate);
            panelControls.Controls.Add(btnAdd);
            panelControls.Controls.Add(richTextBoxChemicalDescribe);
            panelControls.Controls.Add(txtChemicalName);
            panelControls.Controls.Add(txtChemicalID);
            panelControls.Controls.Add(label3);
            panelControls.Controls.Add(label2);
            panelControls.Controls.Add(label1);
            panelControls.Location = new Point(20, 20);
            panelControls.Name = "panelControls";
            panelControls.Size = new Size(1195, 325);
            panelControls.TabIndex = 1;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(108, 117, 125);
            btnDelete.FlatAppearance.BorderColor = Color.FromArgb(73, 80, 87);
            btnDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 139, 150);
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(940, 232);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(195, 65);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(108, 117, 125);
            btnUpdate.FlatAppearance.BorderColor = Color.FromArgb(73, 80, 87);
            btnUpdate.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 139, 150);
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(940, 128);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(195, 65);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Sửa";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(108, 117, 125);
            btnAdd.FlatAppearance.BorderColor = Color.FromArgb(73, 80, 87);
            btnAdd.FlatAppearance.MouseOverBackColor = Color.FromArgb(128, 139, 150);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(940, 25);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(195, 65);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // richTextBoxChemicalDescribe
            // 
            richTextBoxChemicalDescribe.Location = new Point(343, 151);
            richTextBoxChemicalDescribe.Name = "richTextBoxChemicalDescribe";
            richTextBoxChemicalDescribe.Size = new Size(455, 130);
            richTextBoxChemicalDescribe.TabIndex = 5;
            richTextBoxChemicalDescribe.Text = "";
            // 
            // txtChemicalName
            // 
            txtChemicalName.BackColor = Color.FromArgb(242, 242, 242);
            txtChemicalName.BorderStyle = BorderStyle.FixedSingle;
            txtChemicalName.Font = new Font("Microsoft Sans Serif", 11F);
            txtChemicalName.Location = new Point(343, 91);
            txtChemicalName.Name = "txtChemicalName";
            txtChemicalName.Size = new Size(455, 24);
            txtChemicalName.TabIndex = 4;
            // 
            // txtChemicalID
            // 
            txtChemicalID.BackColor = Color.FromArgb(242, 242, 242);
            txtChemicalID.BorderStyle = BorderStyle.FixedSingle;
            txtChemicalID.Enabled = false;
            txtChemicalID.Font = new Font("Microsoft Sans Serif", 11F);
            txtChemicalID.Location = new Point(343, 35);
            txtChemicalID.Name = "txtChemicalID";
            txtChemicalID.Size = new Size(455, 24);
            txtChemicalID.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(52, 58, 64);
            label3.Location = new Point(192, 151);
            label3.Margin = new Padding(0, 0, 0, 10);
            label3.Name = "label3";
            label3.Size = new Size(59, 20);
            label3.TabIndex = 2;
            label3.Text = "Mô tả:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(52, 58, 64);
            label2.Location = new Point(132, 86);
            label2.Margin = new Padding(0, 0, 0, 10);
            label2.Name = "label2";
            label2.Size = new Size(119, 20);
            label2.TabIndex = 1;
            label2.Text = "Tên hóa chất:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(52, 58, 64);
            label1.Location = new Point(138, 35);
            label1.Margin = new Padding(0, 0, 0, 10);
            label1.Name = "label1";
            label1.Size = new Size(113, 20);
            label1.TabIndex = 0;
            label1.Text = "Mã hóa chất:";
            // 
            // ChemicalManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 242, 242);
            ClientSize = new Size(1235, 780);
            Controls.Add(dataGridViewChemicals);
            Controls.Add(panelControls);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ChemicalManager";
            Text = "ChemicalManager";
            Load += ChemicalManager_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewChemicals).EndInit();
            panelControls.ResumeLayout(false);
            panelControls.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewChemicals;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.RichTextBox richTextBoxChemicalDescribe;
        private System.Windows.Forms.TextBox txtChemicalName;
        private System.Windows.Forms.TextBox txtChemicalID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}