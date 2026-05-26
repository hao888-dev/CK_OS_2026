using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK_OS_2026
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
                    dgv.Rows[rowIndex].Cells[j + 1].Value = result.Grid[i, j];
                }
            }

            // 3. In dòng trạng thái kết quả (Page Fault)
            int statusRowIndex = dgv.Rows.Add("Page Fault");
            for (int j = 0; j < result.Pages.Count; j++)
            {
                string status = result.StatusRow[j];
                dgv.Rows[statusRowIndex].Cells[j + 1].Value = (status == "F") ? "F" : "";
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
