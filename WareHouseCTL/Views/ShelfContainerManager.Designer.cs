namespace WareHouseCTL.Views
{
    partial class ShelfContainerManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected void Dispose(bool disposing)
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
            this.dataGridViewShelfContainers = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.cmbShelf = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtContainerName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.lblChemicalInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShelfContainers)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewShelfContainers
            // 
            this.dataGridViewShelfContainers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShelfContainers.Location = new Point(13, 346);
            this.dataGridViewShelfContainers.Margin = new Padding(4, 3, 4, 3);
            this.dataGridViewShelfContainers.Name = "dataGridViewShelfContainers";
            this.dataGridViewShelfContainers.Size = new Size(1141, 346);
            this.dataGridViewShelfContainers.TabIndex = 0;
            this.dataGridViewShelfContainers.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.dataGridViewShelfContainers.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dataGridViewShelfContainers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(226)))), ((int)(((byte)(230)))));
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new Point(860, 20);
            this.btnAdd.Margin = new Padding(4, 3, 4, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new Size(138, 28);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(120)))), ((int)(((byte)(50)))));
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new Point(860, 60);
            this.btnUpdate.Margin = new Padding(4, 3, 4, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new Size(138, 28);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(86)))), ((int)(((byte)(179)))));
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new Point(860, 100);
            this.btnDelete.Margin = new Padding(4, 3, 4, 3);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new Size(138, 28);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            // 
            // cmbShelf
            // 
            this.cmbShelf.FormattingEnabled = true;
            this.cmbShelf.Location = new Point(150, 20);
            this.cmbShelf.Margin = new Padding(4, 3, 4, 3);
            this.cmbShelf.Name = "cmbShelf";
            this.cmbShelf.Size = new Size(700, 28);
            this.cmbShelf.TabIndex = 6;
            this.cmbShelf.SelectedIndexChanged += cmbShelf_SelectedIndexChanged;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.label1.Location = new Point(50, 20);
            this.label1.Margin = new Padding(0, 0, 0, 10);
            this.label1.Name = "label1";
            this.label1.Size = new Size(86, 20); // Điều chỉnh kích thước theo font
            this.label1.TabIndex = 7;
            this.label1.Text = "Chọn Kệ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.label2.Location = new Point(50, 60);
            this.label2.Margin = new Padding(0, 0, 0, 10);
            this.label2.Name = "label2";
            this.label2.Size = new Size(144, 20); // Điều chỉnh kích thước theo font
            this.label2.TabIndex = 8;
            this.label2.Text = "Tên Ngăn Chứa:";
            // 
            // txtContainerName
            // 
            this.txtContainerName.Location = new Point(150, 60);
            this.txtContainerName.Margin = new Padding(4, 3, 4, 3);
            this.txtContainerName.Name = "txtContainerName";
            this.txtContainerName.Size = new Size(700, 28);
            this.txtContainerName.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.label4.Location = new Point(50, 100);
            this.label4.Margin = new Padding(0, 0, 0, 10);
            this.label4.Name = "label4";
            this.label4.Size = new Size(104, 20); // Điều chỉnh kích thước theo font
            this.label4.TabIndex = 12;
            this.label4.Text = "Trạng Thái:";
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new Point(150, 100);
            this.txtStatus.Margin = new Padding(4, 3, 4, 3);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.Size = new Size(700, 28);
            this.txtStatus.TabIndex = 13;
            // 
            // lblChemicalInfo
            // 
            this.lblChemicalInfo.AutoSize = true;
            this.lblChemicalInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(236)))), ((int)(((byte)(239)))));
            this.lblChemicalInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblChemicalInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point); // Áp dụng font tương tự
            this.lblChemicalInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(58)))), ((int)(((byte)(64)))));
            this.lblChemicalInfo.Location = new Point(150, 50);
            this.lblChemicalInfo.Margin = new Padding(0, 0, 0, 10);
            this.lblChemicalInfo.Name = "lblChemicalInfo";
            this.lblChemicalInfo.Padding = new Padding(5);
            this.lblChemicalInfo.Size = new Size(400, 30);
            this.lblChemicalInfo.TabIndex = 16;
            this.lblChemicalInfo.Text = "Hóa chất quy định: [Chọn kệ để xem]";
            // 
            // ShelfContainerManager
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.ClientSize = new Size(1167, 692);
            this.Controls.Add(this.lblChemicalInfo);
            this.Controls.Add(this.txtStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtContainerName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbShelf);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dataGridViewShelfContainers);
            this.Margin = new Padding(4, 3, 4, 3);
            this.Name = "ShelfContainerManager";
            this.Text = "ShelfContainerManager";
            this.Load += ShelfContainerManager_Load;
            ((System.ComponentModel.ISupportInitialize)this.dataGridViewShelfContainers).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewShelfContainers;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.ComboBox cmbShelf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtContainerName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePickerStorage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.Label lblChemicalInfo;
    }
}