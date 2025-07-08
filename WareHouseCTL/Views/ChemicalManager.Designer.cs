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
            this.components = new System.ComponentModel.Container();
            this.dataGridViewChemicals = new System.Windows.Forms.DataGridView();
            this.panelControls = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.richTextBoxChemicalDescribe = new System.Windows.Forms.RichTextBox();
            this.txtChemicalName = new System.Windows.Forms.TextBox();
            this.txtChemicalID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChemicals)).BeginInit();
            this.panelControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewChemicals
            // 
            this.dataGridViewChemicals.AllowUserToAddRows = false;
            this.dataGridViewChemicals.AllowUserToDeleteRows = false;
            this.dataGridViewChemicals.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewChemicals.BackgroundColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.dataGridViewChemicals.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridViewChemicals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewChemicals.EnableHeadersVisualStyles = false;
            this.dataGridViewChemicals.Location = new System.Drawing.Point(20, 306);
            this.dataGridViewChemicals.Name = "dataGridViewChemicals";
            this.dataGridViewChemicals.ReadOnly = true;
            this.dataGridViewChemicals.RowHeadersVisible = false;
            this.dataGridViewChemicals.RowTemplate.Height = 35;
            this.dataGridViewChemicals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewChemicals.Size = new System.Drawing.Size(910, 274);
            this.dataGridViewChemicals.TabIndex = 0;
            this.dataGridViewChemicals.SelectionChanged += new System.EventHandler(this.dataGridViewChemicals_SelectionChanged);
            // 
            // panelControls
            // 
            this.panelControls.BackColor = System.Drawing.Color.FromArgb(248, 249, 250);
            this.panelControls.Controls.Add(this.btnDelete);
            this.panelControls.Controls.Add(this.btnUpdate);
            this.panelControls.Controls.Add(this.btnAdd);
            this.panelControls.Controls.Add(this.richTextBoxChemicalDescribe);
            this.panelControls.Controls.Add(this.txtChemicalName);
            this.panelControls.Controls.Add(this.txtChemicalID);
            this.panelControls.Controls.Add(this.label3);
            this.panelControls.Controls.Add(this.label2);
            this.panelControls.Controls.Add(this.label1);
            this.panelControls.Location = new System.Drawing.Point(20, 20);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(910, 280);
            this.panelControls.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(128, 139, 150);
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(740, 195);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(150, 50);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(128, 139, 150);
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(740, 114);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(150, 50);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Sửa";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(73, 80, 87);
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(128, 139, 150);
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(740, 30);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(150, 50);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // richTextBoxChemicalDescribe
            // 
            this.richTextBoxChemicalDescribe.Location = new System.Drawing.Point(263, 140);
            this.richTextBoxChemicalDescribe.Name = "richTextBoxChemicalDescribe";
            this.richTextBoxChemicalDescribe.Size = new System.Drawing.Size(350, 60);
            this.richTextBoxChemicalDescribe.TabIndex = 5;
            this.richTextBoxChemicalDescribe.Text = "";
            // 
            // txtChemicalName
            // 
            this.txtChemicalName.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            this.txtChemicalName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChemicalName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtChemicalName.Location = new System.Drawing.Point(263, 85);
            this.txtChemicalName.Name = "txtChemicalName";
            this.txtChemicalName.Size = new System.Drawing.Size(350, 24);
            this.txtChemicalName.TabIndex = 4;
            // 
            // txtChemicalID
            // 
            this.txtChemicalID.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            this.txtChemicalID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtChemicalID.Enabled = false;
            this.txtChemicalID.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.txtChemicalID.Location = new System.Drawing.Point(263, 30);
            this.txtChemicalID.Name = "txtChemicalID";
            this.txtChemicalID.Size = new System.Drawing.Size(350, 24);
            this.txtChemicalID.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.label3.Location = new Point(83, 140);
            this.label3.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mô tả:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.label2.Location = new Point(83, 85);
            this.label2.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên hóa chất:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(52, 58, 64);
            this.label1.Location = new Point(83, 30);
            this.label1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã hóa chất:";
            // 
            // ChemicalManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(242, 242, 242);
            this.ClientSize = new System.Drawing.Size(950, 600);
            this.Controls.Add(this.dataGridViewChemicals);
            this.Controls.Add(this.panelControls);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ChemicalManager";
            this.Text = "ChemicalManager";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewChemicals)).EndInit();
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            this.ResumeLayout(false);
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