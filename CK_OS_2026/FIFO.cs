using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CK_OS_2026
{
    public partial class FIFO : Form
    {
        public FIFO()
        {
            InitializeComponent();
        }

        private void runCode_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtFramesCount.Text, out int framesCount) || framesCount <= 0)
            {
                MessageBox.Show("Số Frame không hợp lệ! Vui lòng nhập số nguyên lớn hơn 0.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tách chuỗi nhập vào (cách nhau bởi dấu phẩy hoặc khoảng trắng)
            string[] pagesStr = txtPages.Text
                .Split(',')
                .Select(x => x.Trim())
                .Where(x => x != "")
                .ToArray();

            if (pagesStr.Length <= 2)
            {
                MessageBox.Show("Chuỗi trang quá ngắn! Vui lòng nhập nhiều hơn 2 trang.", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<int> pages = new List<int>();
            foreach (string p in pagesStr)
            {
                if (int.TryParse(p.Trim(), out int pageNumber))
                {
                    pages.Add(pageNumber);
                }
                else
                {
                    MessageBox.Show($"Giá trị '{p}' không phải là số hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            PageReplacementAlgorithm algorithm = new FIFOAlgorithm(pages, framesCount);

            // CHẠY THUẬT TOÁN
            if (algorithm != null)
            {
                PageReplacementResult result = algorithm.Run();

                UIHelper.DisplayToDataGridView(dgvResults, result);
            }
        }
    }
}
