using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Game01
{
    class GameCore
    {
        private int[,] GameMainFrame = new int[18, 10];

        private Square model = new Square();

        public GameCore()
        {
            for (int i = 0; i < 18; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    this.GameMainFrame[i, j] = 0;
                }
            }


        }

        public void NextStep()
        {
            if (this.model.Position.Y + this.model.Height >= 18)
            {
                for (int i = 0; i < this.model.Width; i++)
                {
                    for (int j = 0; j < this.model.Height; j++)
                    {
                        this.GameMainFrame[this.model.Position.Y + i, this.model.Position.X + j] = this.model.Model[i, j];

                        //System.Windows.Forms.MessageBox.Show("jfladljf");
                    }
                }

                this.model.Position.Y = 0;
            }
            else
            {

                if (this.GameMainFrame[this.model.Position.Y + this.model.Height, this.model.Position.X] == 1 || this.GameMainFrame[this.model.Position.Y + this.model.Height, this.model.Position.X + 1] == 1)
                {
                    for (int i = 0; i < this.model.Width; i++)
                    {
                        for (int j = 0; j < this.model.Height; j++)
                        {
                            this.GameMainFrame[this.model.Position.Y + i, this.model.Position.X + j] = this.model.Model[i, j];

                            Console.WriteLine(this.GameMainFrame[this.model.Position.Y + i, this.model.Position.X + j]);

                        }
                    }

                    this.model.Position.Y = 0;

                    this.model.Position.X = 4;
                }
                this.model.Position.Y++;
            }

            bool flag = true;

            int rowID = 17;

            while (rowID >= 0)
            {


                flag = true;

                for (int j = 0; j < 10; j++)
                {
                    if (this.GameMainFrame[rowID, j] == 0)
                    {
                        flag = false;

                        break;
                    }
                }

                if (flag == true)
                {
                    int rowNID = rowID - 1;

                    while (rowNID > 0)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            this.GameMainFrame[rowNID + 1, j] = this.GameMainFrame[rowNID, j];
                        }

                        rowNID--;
                    }

                    for (int j = 0; j < 10; j++)
                    {
                        this.GameMainFrame[0, j] = 0;
                    }
                }
                else
                {
                    rowID--;
                }
            }

        }

        public void Left()
        {
            if (this.model.Position.X > 0)
            {
                this.model.Position.X--;
            }
        }

        public void Right()
        {
            if (this.model.Position.X + this.model.Width - 1 < 9)
            {
                this.model.Position.X++;
            }
        }

        public Bitmap GetFrame()
        {
            Bitmap result = null;
            try
            {
                //this.NextStep();

                result = new Bitmap(300, 540);

                Graphics g = Graphics.FromImage(result);

                for (int i = 0; i < 9; i++)
                {
                    g.DrawLine(new Pen(Color.Gray, 1), new Point(29 + i * 30, 0), new Point(29 + i * 30, 539));
                }

                for (int i = 0; i < 17; i++)
                {
                    g.DrawLine(new Pen(Color.Gray, 1), new Point(0, 29 + i * 30), new Point(299, 29 + i * 30));
                }




                for (int i = 0; i < this.model.Width; i++)
                {
                    for (int j = 0; j < this.model.Height; j++)
                    {
                        if (this.model.Model[i, j] == 1)

                            g.FillRectangle(new SolidBrush(Color.Black), 30 * (this.model.Position.X + i), 30 * (this.model.Position.Y + j), 30, 30);
                    }
                }

                for (int i = 0; i < 18; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (this.GameMainFrame[i, j] == 1)
                        {
                            g.FillRectangle(new SolidBrush(Color.Green), 30 * (j), 30 * i, 30, 30);

                            Console.WriteLine("jlfdsal");
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            return result;
        }
    }
}
