using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Felix_Lu_Digital_Outcome_2._8
{
    internal class Card
    {
        public Image cardPic;
        public int width;
        public int height;
        public Point position = new Point();
        public bool active = false;
        public Rectangle rect;

        public Card(string imageLocation)
        {
            cardPic = Image.FromFile(imageLocation);
            width = 200;
            height = 200;
            rect = new Rectangle(position.X, position.Y, width, height);
        }
    }
}
