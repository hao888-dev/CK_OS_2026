using CK_OS_2026.PageReplacement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CK_OS_2026.UI_check;

namespace CK_OS_2026.UI_check
{
    public static class UIHelper
    {
        public static void DisplayToDataGridView(DataGridView dgv, PageReplacementResult result)
        {
            dgv.Rows.Clear();
            dgv.Columns.Clear();

            // 1. Tạo cột: Cột đầu tiên là tên Frame, các cột sau là chuỗi tham chiếu
            dgv.Columns.Add("FrameCol", "Khung");
            for (int i = 0; i < result.Pages.Count; i++)
            {
                dgv.Columns.Add("C" + i, result.Pages[i].ToString());
            }

            // 2. In dữ liệu của các Frame
            for (int i = 0; i < result.FramesCount; i++)
            {
                int rowIndex = dgv.Rows.Add("Frame " + (i + 1));
                for (int j = 0; j < result.Pages.Count; j++)
                {
                    var cell = dgv.Rows[rowIndex].Cells[j + 1];
                    string val = result.Grid[i, j]?.ToString() ?? "";

                    if (val.Contains("->"))
                    {
                        cell.Value = val;
                        cell.Style.BackColor = Color.FromArgb(255, 182, 182); // đỏ nhẹ
                        cell.Style.ForeColor = Color.DarkRed;
                    }
                    else
                    {
                        cell.Value = val;
                    }
                }
            }

            // 3. In dòng trạng thái kết quả (Page Fault)
            int statusRowIndex = dgv.Rows.Add("Page Fault");
            for (int j = 0; j < result.Pages.Count; j++)
            {
                string status = result.StatusRow[j];
                if (status == "F")
                {
                    dgv.Rows[statusRowIndex].Cells[j + 1].Value = "F";
                    dgv.Rows[statusRowIndex].Cells[j + 1].Style.BackColor = Color.Yellow;
                    dgv.Rows[statusRowIndex].Cells[j + 1].Style.ForeColor = Color.Black;
                }
                else
                {
                    dgv.Rows[statusRowIndex].Cells[j + 1].Value = "";
                }
            }

            // Tùy chỉnh làm đẹp DataGridView cho gọn gàng, tinh tế
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Xóa dòng chọn mặc định để giao diện clean hơn
            dgv.ClearSelection();
        }
    }
}
