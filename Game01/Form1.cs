using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private GameCore gc = new GameCore();

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                gc.NextStep();

                this.pictureBox1.Image = gc.GetFrame();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this.timer1.Enabled == false)
            {
                this.btnStart.Text = "Start";

                this.timer1.Enabled = true;
            }
            else
            {
                this.btnStart.Text = "Stop";

                this.timer1.Enabled = false;
            }

        }

        private void btnStart_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == 'a')
                {
                    gc.Left();
                }
                else if (e.KeyChar == 'd')
                {
                    gc.Right();
                }

                this.pictureBox1.Image = gc.GetFrame();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gc.Left();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gc.Right();
        }
    }
}
