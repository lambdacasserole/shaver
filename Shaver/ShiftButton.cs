using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shaver
{
    class ShiftButton : KeyboardButton
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int s = 10;
            List<Point> p = new List<Point>();
            p.Add(new Point((Width / 2) - (s / 2), (Height / 2) + (s / 2)));
            p.Add(new Point((Width / 2) + (s / 2), (Height / 2) + (s / 2)));
            p.Add(new Point((Width / 2) + (s / 2), (Height / 2) - (s / 2)));
            p.Add(new Point((Width / 2) + s, (Height / 2) - (s / 2)));
            p.Add(new Point((Width / 2), (Height / 2) - (int)(s * 1.5)));
            p.Add(new Point((Width / 2) - s, (Height / 2) - (s / 2)));
            p.Add(new Point((Width / 2) - (s / 2), (Height / 2) - (s / 2)));
            e.Graphics.FillPolygon(new SolidBrush(Color.White), p.ToArray());
            e.Graphics.FillRectangle(new SolidBrush(Color.White), new Rectangle((Width / 2) - (s / 2), (Height / 2) + (int)(s / 1.3), s, (s / 4)));
        }
    }
}
