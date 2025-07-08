using System;
using System.Windows.Forms;
using WareHouseCTL.Models;
using WareHouseCTL.Data;
using Microsoft.EntityFrameworkCore;

namespace WareHouseCTL.Views
{
    public partial class ChemicalManager : Form
    {
        private readonly WareHouseCTLContext _context;

        public ChemicalManager()
        {
            InitializeComponent();
            _context = new WareHouseCTLContext();
            // Làm trống các ô TextBox khi khởi động
            ClearTextBoxes();
            LoadChemicalData();
        }

        private void ChemicalManager_Load(object sender, EventArgs e)
        {
            // Phương thức rỗng, chờ thêm logic sau
        }

        private void LoadChemicalData()
        {
            try
            {
                // Truy vấn dữ liệu từ bảng Chemical
                var chemicals = _context.Chemicals
                    .Include(c => c.Shelf)
                    .Include(c => c.ShelfContainers)
                    .Include(c => c.ChemicalDetails)
                    .ToList();

                // Kiểm tra nếu có dữ liệu
                if (chemicals == null || chemicals.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu hóa chất để hiển thị.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Gán dữ liệu vào DataGridView
                dataGridViewChemicals.DataSource = chemicals;
                dataGridViewChemicals.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // Xóa lựa chọn mặc định sau khi ràng buộc dữ liệu
                dataGridViewChemicals.ClearSelection();

                // Gán sự kiện DataBindingComplete để tùy chỉnh cột sau khi dữ liệu được ràng buộc
                dataGridViewChemicals.DataBindingComplete += DataGridViewChemicals_DataBindingComplete;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewChemicals_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Tùy chỉnh hiển thị cột sau khi dữ liệu được ràng buộc
            if (dataGridViewChemicals.Columns["ChemicalId"] != null)
            {
                dataGridViewChemicals.Columns["ChemicalId"].HeaderText = "Mã hóa chất";
                dataGridViewChemicals.Columns["ChemicalId"].Width = 180;
                dataGridViewChemicals.Columns["ChemicalId"].ReadOnly = true;
                dataGridViewChemicals.Columns["ChemicalId"].Visible = true;
                dataGridViewChemicals.Columns["ChemicalId"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dataGridViewChemicals.Columns["ChemicalName"] != null)
            {
                dataGridViewChemicals.Columns["ChemicalName"].HeaderText = "Tên hóa chất";
                dataGridViewChemicals.Columns["ChemicalName"].Width = 300;
                dataGridViewChemicals.Columns["ChemicalName"].ReadOnly = true;
                dataGridViewChemicals.Columns["ChemicalName"].Visible = true;
                dataGridViewChemicals.Columns["ChemicalName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            if (dataGridViewChemicals.Columns["ChemicalDescribe"] != null)
            {
                dataGridViewChemicals.Columns["ChemicalDescribe"].HeaderText = "Mô tả";
                dataGridViewChemicals.Columns["ChemicalDescribe"].Width = 310;
                dataGridViewChemicals.Columns["ChemicalDescribe"].ReadOnly = true;
                dataGridViewChemicals.Columns["ChemicalDescribe"].Visible = true;
                dataGridViewChemicals.Columns["ChemicalDescribe"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            // Thêm và ẩn cột ShelfContainers và ChemicalDetails
            if (dataGridViewChemicals.Columns["Shelf"] != null)
            {
                dataGridViewChemicals.Columns["Shelf"].Visible = false;
            }
            if (dataGridViewChemicals.Columns["ShelfContainers"] != null)
            {
                dataGridViewChemicals.Columns["ShelfContainers"].Visible = false;
            }
            if (dataGridViewChemicals.Columns["ChemicalDetails"] != null)
            {
                dataGridViewChemicals.Columns["ChemicalDetails"].Visible = false;
            }

            // Điều chỉnh chiều cao hàng để hiển thị toàn bộ nội dung
            dataGridViewChemicals.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridViewChemicals.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Logic thêm mới với ChemicalID ngẫu nhiên và kiểm tra trùng lặp tên
            if (string.IsNullOrWhiteSpace(txtChemicalName.Text) || string.IsNullOrWhiteSpace(richTextBoxChemicalDescribe.Text))
            {
                MessageBox.Show("Vui lòng nhập tên và mô tả hóa chất!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra trùng lặp tên hóa chất
            if (_context.Chemicals.Any(c => c.ChemicalName.ToLower() == txtChemicalName.Text.ToLower()))
            {
                MessageBox.Show("Hóa chất đã tồn tại! Vui lòng chọn tên khác.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string newChemicalID;
            do
            {
                newChemicalID = GenerateRandomChemicalID(); // Sinh ID ngẫu nhiên
            } while (_context.Chemicals.Any(c => c.ChemicalId == newChemicalID)); // Kiểm tra trùng lặp ID

            var chemical = new Chemical
            {
                ChemicalId = newChemicalID,
                ChemicalName = txtChemicalName.Text,
                ChemicalDescribe = richTextBoxChemicalDescribe.Text
            };

            _context.Chemicals.Add(chemical);
            _context.SaveChanges();
            LoadChemicalData();
            ClearTextBoxes();
            MessageBox.Show("Thêm hóa chất thành công! Mã hóa chất: " + newChemicalID, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Logic sửa
            if (dataGridViewChemicals.SelectedRows.Count == 0 || string.IsNullOrWhiteSpace(txtChemicalID.Text))
            {
                MessageBox.Show("Vui lòng chọn một hóa chất để sửa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var chemical = _context.Chemicals.Find(txtChemicalID.Text);
            if (chemical != null)
            {
                chemical.ChemicalName = txtChemicalName.Text;
                chemical.ChemicalDescribe = richTextBoxChemicalDescribe.Text;
                _context.SaveChanges();
                LoadChemicalData();
                ClearTextBoxes();
                MessageBox.Show("Cập nhật hóa chất thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Logic xóa với xác nhận
            if (dataGridViewChemicals.SelectedRows.Count == 0 || string.IsNullOrWhiteSpace(txtChemicalID.Text))
            {
                MessageBox.Show("Vui lòng chọn một hóa chất để xóa!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra xem hóa chất có đang được sử dụng trong Shelves không
            if (_context.Shelves.Any(s => s.ChemicalId == txtChemicalID.Text))
            {
                MessageBox.Show("Không thể xóa hóa chất này vì nó đang được sử dụng trong Kệ. Vui lòng kiểm tra lại hoặc cập nhật các thông tin liên quan!.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hiển thị thông báo xác nhận
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa hóa chất này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var chemical = _context.Chemicals.Find(txtChemicalID.Text);
                if (chemical != null)
                {
                    try
                    {
                        // Lấy lại bản ghi từ context để đảm bảo trạng thái
                        var trackedChemical = _context.Chemicals.Local.FirstOrDefault(c => c.ChemicalId == txtChemicalID.Text) ?? chemical;
                        _context.Chemicals.Remove(trackedChemical);
                        _context.SaveChanges();
                        LoadChemicalData();
                        ClearTextBoxes();
                        MessageBox.Show("Xóa hóa chất thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (DbUpdateException ex)
                    {
                        // Lấy chi tiết từ InnerException
                        string innerMessage = ex.InnerException != null ? ex.InnerException.Message : "Không có chi tiết bổ sung.";
                        MessageBox.Show($"Lỗi khi xóa: {innerMessage}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa hóa chất: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Hóa chất không tồn tại trong cơ sở dữ liệu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridViewChemicals_SelectionChanged(object sender, EventArgs e)
        {
            // Hiển thị dữ liệu được chọn lên TextBox chỉ khi có hàng được chọn
            ClearTextBoxes(); // Làm trống trước khi cập nhật
            if (dataGridViewChemicals.SelectedRows.Count > 0)
            {
                var row = dataGridViewChemicals.SelectedRows[0];
                txtChemicalID.Text = row.Cells["ChemicalId"].Value?.ToString();
                txtChemicalName.Text = row.Cells["ChemicalName"].Value?.ToString();
                richTextBoxChemicalDescribe.Text = row.Cells["ChemicalDescribe"].Value?.ToString();
            }
        }

        private void ClearTextBoxes()
        {
            txtChemicalID.Text = "";
            txtChemicalName.Text = "";
            richTextBoxChemicalDescribe.Text = "";
        }

        private string GenerateRandomChemicalID()
        {
            Random random = new Random();
            int randomNumber = random.Next(1000, 10000); // Sinh số ngẫu nhiên từ 1000 đến 9999
            return "CHEM" + randomNumber; // Ví dụ: CHEM1234
        }
    }
}