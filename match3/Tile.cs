using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace match3
{

    public class Tile
    {

        public Button Button { get; }
        public FigureType Type { get; set; }

        public Tile(Size size, Point point, Bitmap sprite, FigureType type)
        {
            Type = type;
            Button = new Button();
            Button.Size = size;
            Button.Location = point;
            Image part = new Bitmap(size.Width, size.Height);
            Graphics g = Graphics.FromImage(part);
            g.DrawImage(sprite, new Rectangle(0, 0, size.Width, size.Height));
            Button.BackgroundImage = part;
            Button.BackColor = Color.White;
        }
    }
}
