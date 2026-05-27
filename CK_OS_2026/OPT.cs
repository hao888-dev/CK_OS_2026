using CK_OS_2026.PageReplacement;
using CK_OS_2026.UI_check;
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
    public partial class OPT : Form
    {
        public OPT()
        {
            InitializeComponent();
        }

        private void runCode_Click_1(object sender, EventArgs e)
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
            }

            PageReplacementAlgorithm algorithm = new OPTAlgorithm(pages, framesCount);

            // CHẠY THUẬT TOÁN
            if (algorithm != null)
            {
                PageReplacementResult result = algorithm.Run();

                UIHelper.DisplayToDataGridView(dgvResults, result);
            }
        }
    }
}