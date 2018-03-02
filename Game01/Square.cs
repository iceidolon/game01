using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Game01
{
    class Square
    {
        public Point Position = new Point(4, 0);

        public int Width = 2;

        public int Height = 2;

        public int[,] Model = new int[2, 2] { { 1, 1, }, { 1, 1 } };

        public Square()
        {
           
        }
    }
}
