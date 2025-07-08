using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using WareHouseCTL.Models;
using WareHouseCTL.Data;
using Microsoft.EntityFrameworkCore;

namespace WareHouseCTL.Views
{
    public partial class ShelfManager : Form
    {
        private readonly WareHouseCTLContext _context;

        public ShelfManager()
        {
            InitializeComponent();
            _context = new WareHouseCTLContext();
            ClearControls(); // Clear dữ liệu khi form khởi chạy
            LoadShelfData();
            LoadChemicalNames(); // Tải danh sách ChemicalName vào ComboBox
        }

        private void LoadShelfData()
        {
            try
            {
                // Truy vấn dữ liệu từ bảng Shelves và bao gồm thông tin từ Chemical, sắp xếp theo DateAdded giảm dần
                var shelves = _context.Shelves
                    .Include(s => s.Chemical) // Tải dữ liệu liên quan từ Chemical
                    .OrderByDescending(s => s.DateAdded) // Sắp xếp mới nhất lên đầu
                    .ToList();

                // Kiểm tra nếu có dữ liệu
                if (shelves == null || shelves.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu kệ để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Gán dữ liệu vào DataGridView
                dataGridViewShelves.DataSource = shelves;
                dataGridViewShelves.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Xóa lựa chọn mặc định sau khi ràng buộc dữ liệu
                dataGridViewShelves.ClearSelection();

                // Gán sự kiện DataBindingComplete để tùy chỉnh cột sau khi dữ liệu được ràng buộc
                dataGridViewShelves.DataBindingComplete += DataGridViewShelves_DataBindingComplete;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadChemicalNames()
        {
            try
            {
                var chemicals = _context.Chemicals.ToList();
                cbChemicalName.DataSource = chemicals;
                cbChemicalName.DisplayMember = "ChemicalName"; // Hiển thị ChemicalName
                cbChemicalName.ValueMember = "ChemicalID"; // Giá trị thực tế là ChemicalID
                cbChemicalName.SelectedIndex = -1; // Không chọn mặc định
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách hóa chất: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewShelves_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Loại bỏ cột Chemical và ShelfContainers mặc định
            if (dataGridViewShelves.Columns["Chemical"] != null) 
            {
                dataGridViewShelves.Columns["Chemical"].Visible = false;
            }
            if (dataGridViewShelves.Columns["ShelfContainers"] != null)
            {
                dataGridViewShelves.Columns["ShelfContainers"].Visible = false;
            }

            // Loại bỏ cột ChemicalName nếu có
            if (dataGridViewShelves.Columns["ChemicalName"] != null)
            {
                dataGridViewShelves.Columns["ChemicalName"].Visible = false;
            }

            // Tùy chỉnh hiển thị cột sau khi dữ liệu được ràng buộc
            if (dataGridViewShelves.Columns["ShelfID"] != null)
            {
                dataGridViewShelves.Columns["ShelfID"].HeaderText = "Mã kệ";
                dataGridViewShelves.Columns["ShelfID"].ReadOnly = true;
                dataGridViewShelves.Columns["ShelfID"].Visible = true;
                dataGridViewShelves.Columns["ShelfID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dataGridViewShelves.Columns["ShelfName"] != null)
            {
                dataGridViewShelves.Columns["ShelfName"].HeaderText = "Tên kệ";
                dataGridViewShelves.Columns["ShelfName"].ReadOnly = true;
                dataGridViewShelves.Columns["ShelfName"].Visible = true;
                dataGridViewShelves.Columns["ShelfName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dataGridViewShelves.Columns["ChemicalId"] != null)
            {
                dataGridViewShelves.Columns["ChemicalId"].HeaderText = "Mã hóa chất";
                dataGridViewShelves.Columns["ChemicalId"].ReadOnly = true;
                dataGridViewShelves.Columns["ChemicalId"].Visible = true;
                dataGridViewShelves.Columns["ChemicalId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            // Thêm và điền cột Tên hóa chất từ quan hệ Chemical
            if (dataGridViewShelves.Columns["Tên hóa chất"] == null)
            {
                var chemicalNameColumn = new DataGridViewTextBoxColumn
                {
                    Name = "Tên hóa chất",
                    HeaderText = "Tên hóa chất",
                    ReadOnly = true,
                    Visible = true,
                    DefaultCellStyle = new DataGridViewCellStyle
                    {
                        Alignment = DataGridViewContentAlignment.MiddleCenter
                    }
                };
                dataGridViewShelves.Columns.Add(chemicalNameColumn);
            }

            // Điền dữ liệu cho cột Tên hóa chất
            foreach (DataGridViewRow row in dataGridViewShelves.Rows)
            {
                var shelf = row.DataBoundItem as Shelf;
                if (shelf != null && shelf.Chemical != null)
                {
                    row.Cells["Tên hóa chất"].Value = shelf.Chemical.ChemicalName;
                }
                else
                {
                    row.Cells["Tên hóa chất"].Value = "Chưa xác định"; // Giá trị mặc định nếu không có Chemical
                }
            }

            // Điều chỉnh chiều cao hàng để hiển thị toàn bộ nội dung
            dataGridViewShelves.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewShelves.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Logic thêm mới với ShelfID ngẫu nhiên và ShelfName tự động
            if (string.IsNullOrWhiteSpace(txtShelfName.Text) || cbChemicalName.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newShelfId = GenerateRandomShelfId();
            string shelfName = GenerateShelfName();
            string chemicalId = cbChemicalName.SelectedValue.ToString();
            var chemical = _context.Chemicals.FirstOrDefault(c => c.ChemicalId == chemicalId);
            string chemicalName = chemical?.ChemicalName ?? "Chưa xác định"; // Lấy ChemicalName từ Chemical

            // Kiểm tra xem ChemicalId đã tồn tại trong Shelves chưa
            var existingShelf = _context.Shelves.FirstOrDefault(s => s.ChemicalId == chemicalId);
            if (existingShelf != null)
            {
                MessageBox.Show($"Hóa chất '{chemicalName}' đã ở Kệ {existingShelf.ShelfName}, vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var shelf = new Shelf
            {
                ShelfID = newShelfId,
                ShelfName = shelfName,
                ChemicalId = chemicalId,
                DateAdded = DateTime.Now // Gán thời gian thêm
            };

            _context.Shelves.Add(shelf);
            _context.SaveChanges();
            LoadShelfData();
            ClearControls();
            MessageBox.Show($"Thêm kệ thành công! Mã kệ: {newShelfId}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Logic sửa
            if (dataGridViewShelves.SelectedRows.Count == 0 || string.IsNullOrWhiteSpace(txtShelfId.Text))
            {
                MessageBox.Show("Vui lòng chọn một kệ để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var shelf = _context.Shelves.Find(txtShelfId.Text);
            if (shelf != null)
            {
                shelf.ShelfName = txtShelfName.Text;
                string newChemicalId = cbChemicalName.SelectedValue?.ToString();
                var chemical = _context.Chemicals.FirstOrDefault(c => c.ChemicalId == newChemicalId);
                string chemicalName = chemical?.ChemicalName ?? "Chưa xác định";

                // Kiểm tra xem ChemicalId mới có đang được sử dụng bởi kệ khác không (trừ kệ hiện tại)
                var existingShelf = _context.Shelves.FirstOrDefault(s => s.ChemicalId == newChemicalId && s.ShelfID != shelf.ShelfID);
                if (existingShelf != null)
                {
                    MessageBox.Show($"Hóa chất '{chemicalName}' đã ở Kệ {existingShelf.ShelfName}, vui lòng kiểm tra lại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                shelf.ChemicalId = newChemicalId;
                _context.SaveChanges();
                LoadShelfData();
                ClearControls();
                MessageBox.Show("Cập nhật kệ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Logic xóa với xác nhận
            if (dataGridViewShelves.SelectedRows.Count == 0 || string.IsNullOrWhiteSpace(txtShelfId.Text))
            {
                MessageBox.Show("Vui lòng chọn một kệ để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string shelfId = txtShelfId.Text;
            var shelf = _context.Shelves.Find(shelfId);
            if (shelf == null)
            {
                MessageBox.Show("Kệ không tồn tại trong cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // k n
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa kệ này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    var trackedShelf = _context.Shelves.Local.FirstOrDefault(s => s.ShelfID == shelfId) ?? shelf;
                    _context.Shelves.Remove(trackedShelf);
                    _context.SaveChanges();
                    LoadShelfData();
                    ClearControls();
                    MessageBox.Show("Xóa kệ thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (DbUpdateException ex)
                {
                    string innerMessage = ex.InnerException != null ? ex.InnerException.Message : "Không thể xóa do ràng buộc dữ liệu.";
                    MessageBox.Show($"Lỗi khi xóa kệ: {innerMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa kệ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridViewShelves_SelectionChanged(object sender, EventArgs e)
        {
            // Hiển thị dữ liệu được chọn lên TextBox và ComboBox chỉ khi click vào hàng
            ClearControls();
            if (dataGridViewShelves.SelectedRows.Count > 0)
            {
                var row = dataGridViewShelves.SelectedRows[0];
                txtShelfId.Text = row.Cells["ShelfID"].Value?.ToString();
                txtShelfName.Text = row.Cells["ShelfName"].Value?.ToString();
                string chemicalId = row.Cells["ChemicalId"].Value?.ToString();
                if (!string.IsNullOrEmpty(chemicalId))
                {
                    var chemical = _context.Chemicals.FirstOrDefault(c => c.ChemicalId == chemicalId);
                    if (chemical != null)
                    {
                        cbChemicalName.SelectedValue = chemical.ChemicalId;
                    }
                }
            }
        }

        private void ClearControls()
        {
            txtShelfId.Text = "";
            txtShelfName.Text = "";
            cbChemicalName.SelectedIndex = -1;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string searchText = txtSearch.Text.ToLower();
                var shelves = _context.Shelves
                    .Include(s => s.Chemical)
                    .Where(s => s.ShelfID.ToLower().Contains(searchText) ||
                               s.ShelfName.ToLower().Contains(searchText) ||
                               (s.Chemical != null && s.Chemical.ChemicalName.ToLower().Contains(searchText)) ||
                               (s.ChemicalId != null && s.ChemicalId.ToLower().Contains(searchText)))
                    .OrderByDescending(s => s.DateAdded) // Sắp xếp mới nhất lên đầu khi tìm kiếm
                    .ToList();

                dataGridViewShelves.DataSource = shelves;
                dataGridViewShelves.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dataGridViewShelves.ClearSelection();

                // Gán lại sự kiện DataBindingComplete để tùy chỉnh cột
                dataGridViewShelves.DataBindingComplete += DataGridViewShelves_DataBindingComplete;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tìm kiếm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateRandomShelfId()
        {
            Random random = new Random();
            string randomPart = Guid.NewGuid().ToString("N").Substring(0, 6).ToUpper(); // 6 ký tự ngẫu nhiên
            return "S-" + randomPart; // Ví dụ: S-AB12CD
        }

        private string GenerateShelfName()
        {
            var existingShelves = _context.Shelves.ToList();
            char nextLetter = 'A';
            if (existingShelves.Any(s => s.ShelfName == "Kệ A"))
            {
                nextLetter = 'B';
                while (existingShelves.Any(s => s.ShelfName == $"Kệ {nextLetter}"))
                {
                    nextLetter++;
                }
            }
            return $"Kệ {nextLetter}";
        }
    }
}