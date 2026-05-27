using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCodeSRTF
{
    public class GanttRenderer
    {
        private const int XStart = 50;
        private const int YStart = 20;
        private const int CellWidth = 40;
        private const int CellHeight = 40;

        public static void Draw(Panel panelParent, PictureBox picGantt, List<GanttEntry> ganttData)
        {
            if (ganttData == null || ganttData.Count == 0)
            {
                picGantt.Image = null;
                return;
            }

            // 1. Tính toán tổng chiều rộng cần để vẽ toàn bộ tiến trình
            int totalWidth = XStart;
            foreach (var item in ganttData)
            {
                totalWidth += (item.End - item.Start) * CellWidth;
            }
            totalWidth += 50; // Khoảng trống rìa phải cho đẹp

            // 2. Tạo một bức ảnh Bitmap có kích thước "co giãn" theo chiều rộng vừa tính
            // Chiều cao lấy theo chiều cao của Panel cha trừ đi một chút khoảng trống
            Bitmap bmp = new Bitmap(totalWidth, Math.Max(panelParent.Height - 25, 120));

            // 3. Tiến hành vẽ lên bức ảnh Bitmap này
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(panelParent.BackColor); // Màu nền trùng với màu Panel

                Font font = new Font("Arial", 10, FontStyle.Bold);
                Pen pen = new Pen(Color.Black, 2);

                int xOffset = XStart;

                // --- GIỮ NGUYÊN 100% LOGIC VÒNG LẶP VẼ CŨ CỦA BẠN ---
                for (int i = 0; i < ganttData.Count; i++)
                {
                    var item = ganttData[i];
                    int width = (item.End - item.Start) * CellWidth;
                    Rectangle rect = new Rectangle(xOffset, YStart, width, CellHeight);

                    //Brush brush = Brushes.LightYellow;
                    bool isIdle = item.ProcessId.Equals("IDLE", StringComparison.OrdinalIgnoreCase);
                    Brush brush = isIdle ? Brushes.LightGray : Brushes.LightYellow;

                    g.FillRectangle(brush, rect);
                    g.DrawRectangle(pen, rect);

                    g.DrawString(item.ProcessId, font, Brushes.Black, xOffset + (width / 4), YStart + 10);
                    g.DrawString(item.Start.ToString(), font, Brushes.Red, xOffset - 5, YStart + CellHeight + 5);

                    xOffset += width;

                    if (i == ganttData.Count - 1)
                    {
                        g.DrawString(item.End.ToString(), font, Brushes.Red, xOffset - 5, YStart + CellHeight + 5);
                    }
                }
            }

            // 4. Đổ bức ảnh đã vẽ xong vào PictureBox
            // Vì PictureBox chọn AutoSize nên nó tự giãn ra -> Panel bọc ngoài tự sinh ra thanh cuộn (Scrollbar)
            picGantt.Image = bmp;
        }
    }
}

