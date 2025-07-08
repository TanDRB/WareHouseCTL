namespace WareHouseCTL.Views
{
    partial class ShelfManager
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dataGridViewShelves = new DataGridView();
            panelControls = new Panel();
            btnDelete = new Button();
            btnUpdate = new Button();
            btnAdd = new Button();
            cbChemicalName = new ComboBox();
            lbChemicalName = new Label();
            txtShelfName = new TextBox();
            lbShelfName = new Label();
            txtShelfId = new TextBox();
            lbShelfId = new Label();
            txtSearch = new TextBox();
            lbSearch = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridViewShelves).BeginInit();
            panelControls.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridViewShelves
            // 
            dataGridViewShelves.AllowUserToAddRows = false;
            dataGridViewShelves.AllowUserToDeleteRows = false;
            dataGridViewShelves.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewShelves.BackgroundColor = Color.FromArgb(248, 249, 250);
            dataGridViewShelves.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewShelves.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dataGridViewShelves.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewShelves.EnableHeadersVisualStyles = false;
            dataGridViewShelves.Location = new Point(20, 306);
            dataGridViewShelves.Name = "dataGridViewShelves";
            dataGridViewShelves.ReadOnly = true;
            dataGridViewShelves.RowHeadersVisible = false;
            dataGridViewShelves.RowTemplate.Height = 35;
            dataGridViewShelves.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewShelves.Size = new Size(910, 274);
            dataGridViewShelves.TabIndex = 0;
            dataGridViewShelves.SelectionChanged += dataGridViewShelves_SelectionChanged;
            // 
            // panelControls
            // 
            panelControls.BackColor = Color.FromArgb(248, 249, 250);
            panelControls.Controls.Add(btnDelete);
            panelControls.Controls.Add(btnUpdate);
            panelControls.Controls.Add(btnAdd);
            panelControls.Controls.Add(cbChemicalName);
            panelControls.Controls.Add(lbChemicalName);
            panelControls.Controls.Add(txtShelfName);
            panelControls.Controls.Add(lbShelfName);
            panelControls.Controls.Add(txtShelfId);
            panelControls.Controls.Add(lbShelfId);
            panelControls.Controls.Add(txtSearch);
            panelControls.Controls.Add(lbSearch);
            panelControls.Location = new Point(20, 20);
            panelControls.Name = "panelControls";
            panelControls.Size = new Size(910, 280);
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
            btnDelete.Location = new Point(740, 195);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(150, 50);
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
            btnUpdate.Location = new Point(740, 114);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(150, 50);
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
            btnAdd.Location = new Point(740, 30);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(150, 50);
            btnAdd.TabIndex = 6;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // cbChemicalName
            // 
            cbChemicalName.Font = new Font("Microsoft Sans Serif", 11F);
            cbChemicalName.FormattingEnabled = true;
            cbChemicalName.Location = new Point(263, 195);
            cbChemicalName.Name = "cbChemicalName";
            cbChemicalName.Size = new Size(350, 26);
            cbChemicalName.TabIndex = 5;
            // 
            // lbChemicalName
            // 
            lbChemicalName.AutoSize = true;
            lbChemicalName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lbChemicalName.ForeColor = Color.FromArgb(52, 58, 64);
            lbChemicalName.Location = new Point(83, 195);
            lbChemicalName.Margin = new Padding(0, 0, 0, 10);
            lbChemicalName.Name = "lbChemicalName";
            lbChemicalName.Size = new Size(119, 20);
            lbChemicalName.TabIndex = 4;
            lbChemicalName.Text = "Tên hóa chất:";
            // 
            // txtShelfName
            // 
            txtShelfName.BackColor = Color.FromArgb(242, 242, 242);
            txtShelfName.BorderStyle = BorderStyle.FixedSingle;
            txtShelfName.Font = new Font("Microsoft Sans Serif", 11F);
            txtShelfName.Location = new Point(263, 140);
            txtShelfName.Name = "txtShelfName";
            txtShelfName.Size = new Size(350, 24);
            txtShelfName.TabIndex = 3;
            // 
            // lbShelfName
            // 
            lbShelfName.AutoSize = true;
            lbShelfName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lbShelfName.ForeColor = Color.FromArgb(52, 58, 64);
            lbShelfName.Location = new Point(83, 140);
            lbShelfName.Margin = new Padding(0, 0, 0, 10);
            lbShelfName.Name = "lbShelfName";
            lbShelfName.Size = new Size(68, 20);
            lbShelfName.TabIndex = 2;
            lbShelfName.Text = "Tên kệ:";
            // 
            // txtShelfId
            // 
            txtShelfId.BackColor = Color.FromArgb(242, 242, 242);
            txtShelfId.BorderStyle = BorderStyle.FixedSingle;
            txtShelfId.Enabled = false;
            txtShelfId.Font = new Font("Microsoft Sans Serif", 11F);
            txtShelfId.Location = new Point(263, 85);
            txtShelfId.Name = "txtShelfId";
            txtShelfId.Size = new Size(350, 24);
            txtShelfId.TabIndex = 1;
            // 
            // lbShelfId
            // 
            lbShelfId.AutoSize = true;
            lbShelfId.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lbShelfId.ForeColor = Color.FromArgb(52, 58, 64);
            lbShelfId.Location = new Point(83, 85);
            lbShelfId.Margin = new Padding(0, 0, 0, 10);
            lbShelfId.Name = "lbShelfId";
            lbShelfId.Size = new Size(62, 20);
            lbShelfId.TabIndex = 0;
            lbShelfId.Text = "Mã kệ:";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Microsoft Sans Serif", 11F);
            txtSearch.Location = new Point(263, 30);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(350, 24);
            txtSearch.TabIndex = 9;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lbSearch
            // 
            lbSearch.AutoSize = true;
            lbSearch.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            lbSearch.ForeColor = Color.FromArgb(52, 58, 64);
            lbSearch.Location = new Point(83, 30);
            lbSearch.Margin = new Padding(0, 0, 0, 10);
            lbSearch.Name = "lbSearch";
            lbSearch.Size = new Size(84, 20);
            lbSearch.TabIndex = 10;
            lbSearch.Text = "Tìm kiếm:";
            // 
            // ShelfManager
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 242, 242);
            ClientSize = new Size(950, 600);
            Controls.Add(dataGridViewShelves);
            Controls.Add(panelControls);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ShelfManager";
            Text = "Quản lý kệ";
            ((System.ComponentModel.ISupportInitialize)dataGridViewShelves).EndInit();
            panelControls.ResumeLayout(false);
            panelControls.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewShelves;
        private System.Windows.Forms.Panel panelControls;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ComboBox cbChemicalName;
        private System.Windows.Forms.Label lbChemicalName;
        private System.Windows.Forms.TextBox txtShelfName;
        private System.Windows.Forms.Label lbShelfName;
        private System.Windows.Forms.TextBox txtShelfId;
        private System.Windows.Forms.Label lbShelfId;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lbSearch;
    }
}