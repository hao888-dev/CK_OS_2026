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
    public partial class LRU : Form
    {
        public LRU()
        {
            InitializeComponent();
            button1.Click += new EventHandler(button1_Click!);
            button2.Click += new EventHandler(button2_Click!);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int soTrang) && soTrang > 0 && soTrang <= 50)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.AllowUserToAddRows = false;

                for (int i = 0; i < soTrang; i++)
                {
                    dataGridView1.Rows.Add();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập số lượng trang hợp lệ (> 0 hoặc <= 50)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button2_Click(object sender, EventArgs e) 
        {
            List<int> pages = new List<int>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && int.TryParse(row.Cells[0].Value!.ToString(), out int val))
                {
                    pages.Add(val);
                }
            }

            if (pages.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập chuỗi tham chiếu trang nhớ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(textBox2.Text, out int frames) || frames <= 0)
            {
                MessageBox.Show("Vui lòng nhập số frame hợp lệ (>0)!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LRUResult result = LRUAlgorithm.RunLRU(pages, frames);

            HienThiKetQuaThucTe(result);
        }

        private void HienThiKetQuaThucTe(LRUResult result)
        {
            dataGridView2.Columns.Clear();
            dataGridView2.Rows.Clear();
            dataGridView2.ScrollBars = ScrollBars.Both;
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.ReadOnly = true;

            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            DataGridViewTextBoxColumn colTieuDe = new DataGridViewTextBoxColumn();
            colTieuDe.Name = "Col_TieuDe";
            colTieuDe.HeaderText = $"Page Fault: {result.PageFaults}";
            colTieuDe.Width = 110;
            colTieuDe.Frozen = true;
            colTieuDe.DefaultCellStyle.Font = new Font(dataGridView2.Font, FontStyle.Bold);
            dataGridView2.Columns.Add(colTieuDe);

            colTieuDe.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

            for (int i = 0; i < result.Pages.Count; i++)
            {
                DataGridViewTextBoxColumn colBuoc = new DataGridViewTextBoxColumn();
                colBuoc.Name = $"Col_Buoc{i}";
                colBuoc.HeaderText = result.Pages[i].ToString();
                colBuoc.Width = 45;
                colBuoc.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns.Add(colBuoc);
            }

            for (int f = 0; f < result.FramesCount; f++)
            {
                int rIndex = dataGridView2.Rows.Add();
                dataGridView2.Rows[rIndex].Cells[0].Value = $"Khung số {f + 1}";

                for (int i = 0; i < result.Pages.Count; i++)
                {
                    int val = result.Grid[f, i];
                    dataGridView2.Rows[rIndex].Cells[i + 1].Value = (val != -1) ? val.ToString() : "";
                }
            }

            int rState = dataGridView2.Rows.Add();
            dataGridView2.Rows[rState].Cells[0].Value = "Trạng Thái";

            for (int i = 0; i < result.Pages.Count; i++)
            {
                if (result.IsReplacement[i]) 
                {
                    dataGridView2.Rows[rState].Cells[i + 1].Value = "F";
                    dataGridView2.Rows[rState].Cells[i + 1].Style.Font = new Font(dataGridView2.Font, FontStyle.Bold);
                    dataGridView2.Rows[rState].Cells[i + 1].Style.ForeColor = Color.Black;
                }
                else 
                {
                    dataGridView2.Rows[rState].Cells[i + 1].Value = "";
                }
            }
        }
    }
}