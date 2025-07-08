using System;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using WareHouseCTL.Data;
using WareHouseCTL.Models;

namespace WareHouseCTL.Views
{
    public partial class ShelfContainerManager : Form
    {
        private readonly WareHouseCTLContext _context;
        private ShelfContainer selectedContainer;

        public ShelfContainerManager()
        {
            InitializeComponent();
            _context = new WareHouseCTLContext();
            LoadData();
            LoadShelves();
        }

        private void ShelfContainerManager_Load(object sender, EventArgs e)
        {
            // Phương thức rỗng, chờ thêm logic sau
        }

        private void LoadData()
        {
            try
            {
                var shelfContainers = _context.ShelfContainers
                    .Include(sc => sc.Shelf)
                    .Include(sc => sc.Chemical)
                    .Include(sc => sc.ChemicalDetails)
                    .ThenInclude(cd => cd.Chemical)
                    .ToList();

                dataGridViewShelfContainers.DataSource = shelfContainers;
                dataGridViewShelfContainers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewShelfContainers.ReadOnly = true;
                dataGridViewShelfContainers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                foreach (DataGridViewColumn column in dataGridViewShelfContainers.Columns)
                {
                    switch (column.Name)
                    {
                        case "ShelfContainerId":
                            column.HeaderText = "ID Ngăn Chứa";
                            break;
                        case "ShelfContainerName":
                            column.HeaderText = "Tên Ngăn Chứa";
                            break;
                        case "ShelfName":
                            column.HeaderText = "Tên Kệ";
                            break;
                        case "ChemicalName":
                            column.HeaderText = "Tên Hóa Chất";
                            if (column.DataPropertyName != "Chemical.ChemicalName")
                            {
                                column.DataPropertyName = "Chemical.ChemicalName";
                            }
                            break;
                        case "StorageDate":
                            column.HeaderText = "Ngày Lưu Trữ";
                            column.DefaultCellStyle.Format = "dd/MM/yyyy";
                            break;
                        case "Status":
                            column.HeaderText = "Trạng Thái";
                            break;
                        case "ShelfID":
                            column.Visible = false;
                            break;
                        case "ChemicalId":
                            column.Visible = false;
                            break;
                        case "ChemicalDetails":
                            column.Visible = false;
                            break;
                        case "Shelf":
                            column.Visible = false;
                            break;
                        case "Chemical":
                            column.Visible = false;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadShelves()
        {
            try
            {
                var shelves = _context.Shelves.ToList();
                cmbShelf.DataSource = shelves;
                cmbShelf.DisplayMember = "ShelfName";
                cmbShelf.ValueMember = "ShelfID";
                cmbShelf.SelectedIndex = -1; // Đặt mặc định không chọn
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách kệ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbShelf.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtStatus.Text))
                {
                    MessageBox.Show("Vui lòng chọn kệ và trạng thái!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int newShelfContainerId = GenerateRandomShelfContainerId();
                while (_context.ShelfContainers.Any(sc => sc.ShelfContainerId == newShelfContainerId))
                {
                    newShelfContainerId = GenerateRandomShelfContainerId();
                }

                // Lấy Shelf và ChemicalId từ kệ đã chọn
                string shelfId = cmbShelf.SelectedValue.ToString();
                var shelf = _context.Shelves.Include(s => s.Chemical).FirstOrDefault(s => s.ShelfID == shelfId);
                if (shelf == null) throw new Exception("Kệ không tồn tại!");
                string chemicalId = shelf.ChemicalId; // Giả định Shelf có ChemicalId quy định
                if (string.IsNullOrEmpty(chemicalId)) throw new Exception("Kệ này không có hóa chất quy định!");

                // Lấy ChemicalName từ ChemicalId
                var chemical = _context.Chemicals.FirstOrDefault(c => c.ChemicalId == chemicalId);
                if (chemical == null) throw new Exception("Hóa chất không tồn tại!");
                string chemicalName = chemical.ChemicalName;

                // Tính toán ShelfContainerName dựa trên ShelfName và ChemicalName
                string shelfName = shelf.ShelfName;
                var existingContainers = _context.ShelfContainers
                    .Where(sc => sc.Shelf.ShelfName == shelfName && sc.Chemical.ChemicalName == chemicalName)
                    .Select(sc => sc.ShelfContainerName)
                    .ToList();
                int maxSuffix = existingContainers
                    .Select(name => name.Split('-').Length > 1 ? int.Parse(name.Split('-')[1]) : 0)
                    .DefaultIfEmpty(0)
                    .Max();
                string shelfContainerName = $"{chemicalName}-{maxSuffix + 1}";

                var shelfContainer = new ShelfContainer
                {
                    ShelfContainerId = newShelfContainerId,
                    ShelfContainerName = shelfContainerName,
                    ShelfID = shelfId,
                    ChemicalId = chemicalId,
                    StorageDate = DateTime.Now,
                    Status = txtStatus.Text
                };

                _context.ShelfContainers.Add(shelfContainer);
                _context.SaveChanges();
                LoadData();
                ClearInputs();
                MessageBox.Show("Thêm ngăn chứa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thêm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedContainer == null || cmbShelf.SelectedIndex == -1 || string.IsNullOrWhiteSpace(txtStatus.Text))
                {
                    MessageBox.Show("Vui lòng chọn một ngăn chứa và điền đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                selectedContainer.ShelfID = cmbShelf.SelectedValue.ToString();
                selectedContainer.ShelfContainerName = txtContainerName.Text;
                selectedContainer.Status = txtStatus.Text;

                _context.SaveChanges();
                LoadData();
                ClearInputs();
                MessageBox.Show("Cập nhật ngăn chứa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedContainer == null)
                {
                    MessageBox.Show("Vui lòng chọn một ngăn chứa để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Bạn có chắc chắn muốn xóa ngăn chứa này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    _context.ShelfContainers.Remove(selectedContainer);
                    _context.SaveChanges();
                    LoadData();
                    ClearInputs();
                    MessageBox.Show("Xóa ngăn chứa thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xóa: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewShelfContainers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedContainer = dataGridViewShelfContainers.Rows[e.RowIndex].DataBoundItem as ShelfContainer;
                if (selectedContainer != null)
                {
                    cmbShelf.SelectedValue = selectedContainer.ShelfID;
                    txtContainerName.Text = selectedContainer.ShelfContainerName;
                    txtStatus.Text = selectedContainer.Status;
                }
            }
        }

        private void ClearInputs()
        {
            cmbShelf.SelectedIndex = -1;
            txtContainerName.Text = "";
            txtStatus.Text = "";
            selectedContainer = null;
        }

        private int GenerateRandomShelfContainerId()
        {
            return new Random().Next(1000, 9999);
        }

        private void cmbShelf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbShelf.SelectedIndex != -1)
            {
                string shelfId = cmbShelf.SelectedValue.ToString();
                var shelf = _context.Shelves.Include(s => s.Chemical).FirstOrDefault(s => s.ShelfID == shelfId);
                if (shelf != null && !string.IsNullOrEmpty(shelf.ChemicalId))
                {
                    var chemical = _context.Chemicals.FirstOrDefault(c => c.ChemicalId == shelf.ChemicalId);
                    if (chemical != null)
                    {
                        lblChemicalInfo.Text = $"Hóa chất quy định: {chemical.ChemicalName}";
                    }
                    else
                    {
                        lblChemicalInfo.Text = "Hóa chất không tìm thấy.";
                    }
                }
                else
                {
                    lblChemicalInfo.Text = "Kệ này không có hóa chất quy định.";
                }
            }
            else
            {
                lblChemicalInfo.Text = "Hóa chất quy định: [Chọn kệ để xem]";
            }
        }
    }
}