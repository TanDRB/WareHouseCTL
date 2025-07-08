using System;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using WareHouseCTL.Data;
using WareHouseCTL.Models;

namespace WareHouseCTL.Views
{
    public partial class MainShelf : Form
    {
        private readonly WareHouseCTLContext _context;
        private FlowLayoutPanel flowLayoutPanel;

        public MainShelf()
        {
            InitializeComponent();
            _context = new WareHouseCTLContext();
            SetupUI();
            LoadShelves();
        }

        private void SetupUI()
        {
            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10) // Khoảng cách lề tổng thể
            };

            flowLayoutPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                WrapContents = true,
                AutoScroll = true,
                Padding = new Padding(20, 0, 20, 0), // Căn lề trái/phải 20 pixel
                Margin = new Padding(0),
                Width = this.ClientSize.Width,
                Height = 0,
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };

            mainPanel.Controls.Add(flowLayoutPanel);
            this.Controls.Add(mainPanel);

            this.Resize += (s, e) =>
            {
                flowLayoutPanel.Width = this.ClientSize.Width;
                flowLayoutPanel.Location = new Point(0, 50);
            };
        }

        private void LoadShelves()
        {
            var shelves = _context.Shelves.ToList();
            if (shelves == null || !shelves.Any())
            {
                MessageBox.Show("Không tìm thấy dữ liệu Shelves.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (var shelf in shelves)
            {
                Panel shelfPanel = new Panel
                {
                    Size = new Size(150, 150), // Hình vuông 150x150
                    BackColor = Color.LightGray,
                    Margin = new Padding(20, 0, 20, 0) // Tăng khoảng cách giữa các Panel lên 20 pixel (trái/phải)
                };

                int radius = 15;
                GraphicsPath path = new GraphicsPath();
                path.AddArc(0, 0, radius, radius, 180, 90);
                path.AddArc(shelfPanel.Width - radius, 0, radius, radius, 270, 90);
                path.AddArc(shelfPanel.Width - radius, shelfPanel.Height - radius, radius, radius, 0, 90);
                path.AddArc(0, shelfPanel.Height - radius, radius, radius, 90, 90);
                path.CloseFigure();
                shelfPanel.Region = new Region(path);

                // Label duy nhất kết hợp ShelfName và ChemicalName
                Label combinedLabel = new Label
                {
                    Text = $"{shelf.ShelfName ?? "Chưa có tên"}\n({shelf.Chemical?.ChemicalName ?? "Chưa có hóa chất"})",
                    Tag = shelf.ShelfID,
                    Size = new Size(130, 130),
                    TextAlign = ContentAlignment.MiddleCenter,
                    ForeColor = Color.Black,
                    Font = new Font("Arial", 14, FontStyle.Bold),
                    Location = new Point(10, 10)
                };

                shelfPanel.Controls.Add(combinedLabel);
                flowLayoutPanel.Controls.Add(shelfPanel);
            }
        }

        public void AddNewShelf(string shelfName, string shelfId, string chemicalName)
        {
            Panel shelfPanel = new Panel
            {
                Size = new Size(150, 150), // Hình vuông 150x150
                BackColor = Color.LightGray,
                Margin = new Padding(20, 0, 20, 0) // Tăng khoảng cách giữa các Panel lên 20 pixel (trái/phải)
            };

            int radius = 15;
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(shelfPanel.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(shelfPanel.Width - radius, shelfPanel.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, shelfPanel.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();
            shelfPanel.Region = new Region(path);

            // Label duy nhất kết hợp ShelfName và ChemicalName
            Label combinedLabel = new Label
            {
                Text = $"{shelfName}\n({chemicalName ?? "Chưa có hóa chất"})",
                Tag = shelfId,
                Size = new Size(130, 130),
                TextAlign = ContentAlignment.MiddleCenter,
                ForeColor = Color.Black,
                Font = new Font("Arial", 14, FontStyle.Bold), // Font to và đậm
                Location = new Point(10, 10)
            };

            shelfPanel.Controls.Add(combinedLabel);
            flowLayoutPanel.Controls.Add(shelfPanel);

            flowLayoutPanel.Width = this.ClientSize.Width;
            flowLayoutPanel.Location = new Point(0, 50);
        }
    }
}