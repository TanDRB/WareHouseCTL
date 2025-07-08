using System;
using System.Drawing;
using System.Windows.Forms;
using WareHouseCTL.Models;
using WareHouseCTL.Data;
using Microsoft.EntityFrameworkCore;

namespace WareHouseCTL.Views
{
    public partial class Home : Form
    {
        private WareHouseCTLContext _context; // Loại bỏ readonly để cho phép gán lại

        public Home()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(1600, 900);

            _context = new WareHouseCTLContext();
            LoadShelfData();
            // Đăng ký sự kiện làm mới khi form được kích hoạt
            this.Activated += Home_Activated;
        }

        private void Home_Activated(object sender, EventArgs e)
        {
            // Làm mới context và dữ liệu khi form được kích hoạt
            _context = new WareHouseCTLContext(); // Gán lại context để làm mới
            LoadShelfData();
        }

        private void LoadShelfData()
        {
            try
            {
                // Xóa tất cả các điều khiển hiện tại trong panelMainShelf
                panelMainShelf.Controls.Clear();

                // Kiểm tra kết nối CSDL
                Console.WriteLine("--- Kiểm tra kết nối CSDL ---");
                if (!_context.Database.CanConnect())
                {
                    MessageBox.Show("Không thể kết nối đến cơ sở dữ liệu. Kiểm tra chuỗi kết nối.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Console.WriteLine("Kết nối thất bại.");
                    return;
                }
                Console.WriteLine("Kết nối thành công.");

                // Kiểm tra bảng Shelves
                Console.WriteLine("--- Kiểm tra bảng Shelves ---");
                var shelfCount = _context.Shelves.Count(); // Đếm số bản ghi để kiểm tra
                Console.WriteLine($"Số bản ghi trong Shelves: {shelfCount}");

                // Lấy dữ liệu từ context
                Console.WriteLine("--- Lấy dữ liệu từ bảng Shelves ---");
                var shelves = _context.Shelves
                    .Include(s => s.Chemical)
                    .OrderByDescending(s => s.DateAdded) // Sắp xếp mới nhất lên đầu
                    .ToList();

                // Debug log chi tiết
                Console.WriteLine("--- Bắt đầu debug LoadShelfData ---");
                Console.WriteLine($"Context state: {(_context.Database.CanConnect() ? "Connected" : "Not Connected")}");
                Console.WriteLine($"Số lượng kệ lấy được: {shelves?.Count ?? 0}");
                if (shelves != null)
                {
                    foreach (var shelf in shelves)
                    {
                        Console.WriteLine($"Kệ ID: {shelf.ShelfID}, Tên: {shelf.ShelfName}, Chemical: {shelf.Chemical?.ChemicalName}");
                    }
                }
                else
                {
                    Console.WriteLine("Danh sách shelves là null.");
                }

                if (shelves == null || shelves.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu kệ để hiển thị. Kiểm tra CSDL hoặc migration.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                int columnCount = 3; // Giới hạn 3 cột mỗi hàng
                int rowCount = (int)Math.Ceiling((double)shelves.Count / columnCount); // Tính số hàng cần

                // Tạo panel cho từng kệ
                Console.WriteLine("--- Tạo panel cho từng kệ ---");
                for (int i = 0; i < shelves.Count; i++)
                {
                    var shelf = shelves[i];
                    int row = i / columnCount;
                    int col = i % columnCount;

                    // Tính toán vị trí và kích thước của Shelf
                    int shelfWidth = (int)(panelMainShelf.Width * 0.32); // Tăng lên 32% của chiều ngang panelMainShelf ≈ 312px
                    int totalWidth = shelfWidth * columnCount; // Tổng chiều rộng của 3 kệ
                    int remainingWidth = panelMainShelf.Width - totalWidth; // Phần còn lại cho padding và khoảng cách
                    int spacingWidth = 10; // Giảm khoảng cách xuống 10px
                    int paddingWidth = (remainingWidth - (columnCount - 1) * spacingWidth) / 2; // Padding mép trái/phải
                    int x = col * (shelfWidth + spacingWidth) + paddingWidth; // Vị trí x hợp lý

                    // Chiều cao với padding-top 10px và padding-bottom 10px
                    int paddingTop = 10; // Padding-top cố định 10px
                    int paddingBottom = 10; // Padding-bottom cố định 10px
                    int shelfHeight = panelMainShelf.Height - paddingTop - paddingBottom; // Chiều cao kệ 634px
                    int spacingBetweenShelves = 10; // Khoảng cách giữa padding-bottom của kệ trên và padding-top của kệ dưới
                    int y = row * (shelfHeight + spacingBetweenShelves) + paddingTop; // Vị trí y, bắt đầu từ padding-top

                    Panel panel = new Panel
                    {
                        BorderStyle = BorderStyle.FixedSingle,
                        Size = new Size(shelfWidth, shelfHeight), // Chiều rộng 32% và chiều cao 634px
                        Location = new Point(x, y),
                        Margin = new Padding(0) // Loại bỏ margin
                    };

                    // Tạo 3 ShelfContainer vuông nằm dưới header với kích thước giảm 5px
                    int headerHeight = 100; // Chiều cao của pnShelfHeader
                    int availableHeight = shelfHeight - headerHeight; // Chiều cao còn lại cho ShelfContainer
                    int containerSize = Math.Min((shelfWidth - 2 * 8 - 2 * 5) / 3, availableHeight / 1) - 5; // Điều chỉnh padding-left/right = 8px, giảm 5px, ≈ 92px
                    int containerPadding = 5; // Padding 5px quanh mỗi ShelfContainer
                    int containerStartY = headerHeight + paddingTop; // Bắt đầu dưới header

                    for (int j = 0; j < 3; j++)
                    {
                        int containerX = 8 + j * (containerSize + containerPadding); // Bắt đầu từ padding-left 8px
                        int containerY = containerStartY; // Vị trí y bắt đầu từ dưới header

                        Panel containerPanel = new Panel
                        {
                            BorderStyle = BorderStyle.FixedSingle,
                            Size = new Size(containerSize, containerSize), // Kích thước vuông 92px
                            Location = new Point(containerX, containerY),
                            Margin = new Padding(0),
                            BackColor = Color.LightGray // Màu nền để dễ nhận diện
                        };

                        panel.Controls.Add(containerPanel);
                    }

                    Panel pnShelfHeader = new Panel
                    {
                        BackColor = Color.LightGray,
                        Location = new Point(0, 0), // Đặt ở đầu Shelf
                        Size = new Size(shelfWidth, headerHeight), // Full chiều ngang của Shelf
                        Padding = new Padding(5)
                    };

                    Label lbShelfName = new Label
                    {
                        AutoSize = true,
                        Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                        Location = new Point(5, 5),
                        Name = $"lbShelfName_{shelf.ShelfID}",
                        Text = shelf.ShelfName ?? "Chưa có tên kệ",
                        Tag = shelf.ShelfID,
                        ForeColor = Color.DarkBlue
                    };

                    Label lbChemicalName = new Label
                    {
                        AutoSize = true,
                        Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                        ForeColor = Color.Red,
                        Location = new Point(5, 50),
                        Name = $"lbChemicalName_{shelf.ShelfID}",
                        Text = $"({shelf.Chemical?.ChemicalName ?? "Chưa có hóa chất"})",
                        Tag = shelf.ShelfID
                    };

                    pnShelfHeader.Controls.Add(lbShelfName);
                    pnShelfHeader.Controls.Add(lbChemicalName);
                    panel.Controls.Add(pnShelfHeader);

                    panelMainShelf.Controls.Add(panel);
                    Console.WriteLine($"Thêm panel cho kệ ID: {shelf.ShelfID} tại vị trí ({x}, {y}) với kích thước {shelfWidth}x{shelfHeight}");
                }
                Console.WriteLine("--- Kết thúc debug LoadShelfData ---");

                // Đảm bảo panelMainShelf được làm mới giao diện
                panelMainShelf.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}\nStackTrace: {ex.StackTrace}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LbChemicalName_Click(object sender, EventArgs e)
        {
            if (sender is Label label && label.Tag is string shelfId)
            {
                MessageBox.Show($"Clicked ChemicalName for Shelf ID: {shelfId}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Thêm logic mở form hoặc xử lý khác tại đây
            }
        }

        private void LbShelfName_Click(object sender, EventArgs e)
        {
            if (sender is Label label && label.Tag is string shelfId)
            {
                MessageBox.Show($"Clicked ShelfName for Shelf ID: {shelfId}", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Thêm logic mở form hoặc xử lý khác tại đây
            }
        }

        private void lbChemicalManager_Click(object sender, EventArgs e)
        {
            OpenChemicalManager();
        }

        private void lbShelfManager_Click(object sender, EventArgs e)
        {
            OpenShelfManager();
        }

        private void lbShelfContainerManager_Click(object sender, EventArgs e)
        {
            OpenShelfContainerManager();
        }

        private void OpenChemicalManager()
        {
            using (var chemicalManagerForm = new ChemicalManager())
            {
                chemicalManagerForm.StartPosition = FormStartPosition.CenterScreen;
                chemicalManagerForm.ShowDialog();
            }
        }

        private void OpenShelfManager()
        {
            using (var shelfManagerForm = new ShelfManager())
            {
                shelfManagerForm.StartPosition = FormStartPosition.CenterScreen;
                shelfManagerForm.ShowDialog();
                // Làm mới dữ liệu sau khi đóng ShelfManager
                _context = new WareHouseCTLContext(); // Làm mới context
                LoadShelfData();
            }
        }

        private void OpenShelfContainerManager()
        {
            using (var shelfContainerManagerForm = new ShelfContainerManager())
            {
                shelfContainerManagerForm.StartPosition = FormStartPosition.CenterScreen;
                shelfContainerManagerForm.ShowDialog();
            }
        }

        private void lbChemicalManager_MouseEnter(object sender, EventArgs e)
        {
            lbChemicalManager.BackColor = Color.FromArgb(100, 149, 237); // Hover effect
        }

        private void lbChemicalManager_MouseLeave(object sender, EventArgs e)
        {
            lbChemicalManager.BackColor = Color.FromArgb(70, 130, 180); // Default color
        }

        private void lbShelfManager_MouseEnter(object sender, EventArgs e)
        {
            lbShelfManager.BackColor = Color.FromArgb(100, 149, 237); // Hover effect
        }

        private void lbShelfManager_MouseLeave(object sender, EventArgs e)
        {
            lbShelfManager.BackColor = Color.FromArgb(70, 130, 180); // Default color
        }

        private void lbShelfContainerManager_MouseEnter(object sender, EventArgs e)
        {
            lbShelfContainerManager.BackColor = Color.FromArgb(100, 149, 237); // Hover effect
        }

        private void lbShelfContainerManager_MouseLeave(object sender, EventArgs e)
        {
            lbShelfContainerManager.BackColor = Color.FromArgb(70, 130, 180); // Default color
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            AdjustPanelShelfHeight();
        }

        private void AdjustPanelShelfHeight()
        {
            if (panelMainShelf != null)
            {
                int availableHeight = panelMainShelf.ClientSize.Height;
                int paddingTotal = panelMainShelf.Padding.Top + panelMainShelf.Padding.Bottom;
                int rowCount = (int)Math.Ceiling((double)panelMainShelf.Controls.Count / 3); // 3 kệ mỗi hàng
                int desiredHeightPerRow = availableHeight - 10 - 10; // Chừa 10px padding-top và 10px padding-bottom
                int totalHeight = desiredHeightPerRow * rowCount + (rowCount - 1) * 10; // Tổng chiều cao với khoảng cách 10px
                int remainingHeight = availableHeight - totalHeight; // Phần còn lại cho padding
                int paddingTop = 10; // Padding-top cố định 10px
                int paddingBottom = 10; // Padding-bottom cố định 10px

                foreach (Control control in panelMainShelf.Controls)
                {
                    if (control is Panel panel)
                    {
                        int shelfWidth = (int)(panelMainShelf.Width * 0.32); // Tăng lên 32% của chiều ngang panelMainShelf ≈ 312px
                        int totalWidth = shelfWidth * 3; // Tổng chiều rộng của 3 kệ
                        int remainingWidth = panelMainShelf.Width - totalWidth; // Phần còn lại cho padding và khoảng cách
                        int spacingWidth = 10; // Giảm khoảng cách xuống 10px
                        int paddingWidth = (remainingWidth - (3 - 1) * spacingWidth) / 2; // Padding mép trái/phải
                        int x = Array.IndexOf(panelMainShelf.Controls.Cast<Control>().ToArray(), panel) % 3 * (shelfWidth + spacingWidth) + paddingWidth;
                        int y = Array.IndexOf(panelMainShelf.Controls.Cast<Control>().ToArray(), panel) / 3 * (desiredHeightPerRow + 10) + paddingTop;
                        panel.Location = new Point(x, y);
                        panel.Size = new Size(shelfWidth, desiredHeightPerRow); // Chiều rộng 32% và chiều cao 634px
                        foreach (Control innerControl in panel.Controls)
                        {
                            if (innerControl is Panel containerPanel)
                            {
                                int headerHeight = 100; // Chiều cao của pnShelfHeader
                                int availableHeightForContainers = desiredHeightPerRow - headerHeight; // Chiều cao còn lại
                                int containerSize = Math.Min((shelfWidth - 2 * 8 - 2 * 5) / 3, availableHeightForContainers / 1) - 5; // Điều chỉnh padding-left/right = 8px, giảm 5px, ≈ 92px
                                int containerPadding = 5; // Padding 5px quanh mỗi ShelfContainer
                                containerPanel.Size = new Size(containerSize, containerSize); // Kích thước vuông 92px
                                containerPanel.Location = new Point(8 + Array.IndexOf(panel.Controls.Cast<Control>().ToArray(), containerPanel) * (containerSize + containerPadding), headerHeight + paddingTop); // Bắt đầu từ padding-left 8px
                            }
                            else if (innerControl is Panel headerPanel)
                            {
                                headerPanel.Size = new Size(shelfWidth, 100); // Full chiều ngang của Shelf
                                headerPanel.Padding = new Padding(5); // Giữ padding trong header
                            }
                        }
                    }
                }
            }
        }
    }
}