using System;
using System.Collections.Generic;
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

        public static void Draw(Panel panel, List<GanttEntry> ganttData)
        {
            Graphics g = panel.CreateGraphics();
            g.Clear(panel.BackColor);

            if (ganttData == null || ganttData.Count == 0) return;

            Font font = new Font("Arial", 10, FontStyle.Bold);
            Pen pen = new Pen(Color.Black, 2);

            int xOffset = XStart;

            for (int i = 0; i < ganttData.Count; i++)
            {
                var item = ganttData[i];
                int width = (item.End - item.Start) * CellWidth;
                Rectangle rect = new Rectangle(xOffset, YStart, width, CellHeight);

                // Tô màu: vàng nhạt
                Brush brush = Brushes.LightYellow;
                g.FillRectangle(brush, rect);
                g.DrawRectangle(pen, rect);

                // Tên tiến trình căn giữa ô
                g.DrawString(item.ProcessId, font, Brushes.Black, xOffset + (width / 4), YStart + 10);

                // Mốc thời gian bắt đầu
                g.DrawString(item.Start.ToString(), font, Brushes.Red, xOffset - 5, YStart + CellHeight + 5);

                xOffset += width;

                // Mốc thời gian kết thúc (phần tử cuối)
                if (i == ganttData.Count - 1)
                {
                    g.DrawString(item.End.ToString(), font, Brushes.Red, xOffset - 5, YStart + CellHeight + 5);
                }
            }
        }
    }
}

