using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace hosh_genetic
{
    public partial class Form3 : Form
    {
        string s;
        public Form3(string a)
        {
            InitializeComponent();
            s = a;

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            char[] a = { ' ' };
            string[] q = s.Split(a, count: 13);
            int[] x = new int[12];
            int[] y = new int[12];
            string[] w = new string[2];
            for (int i = 0; i < 12; i++)
            {
                w = q[i].Split(',');
                x[i] = Convert.ToInt32(w[1]);
                y[i] = Convert.ToInt32(w[0]);
            }
            label1.Text = "Fitness: " + q[12];
            var myPen = new Pen(Color.Black);
            Graphics g = panel1.CreateGraphics();
            g.Clear(Color.White);
            var mypen1 = new Pen(Color.GreenYellow);
            for (int i = 40; i <= 490; i += 30)
                g.DrawLine(mypen1, 10, i, 490, i);
            for (int i = 40; i <= 490; i += 30)
                g.DrawLine(mypen1, i, 10, i, 490);
            mypen1.Dispose();
            g.DrawLine(myPen, 10, 10, 250, 10);
            g.DrawLine(myPen, 310, 10, 490, 10);
            g.DrawLine(myPen, 10, 10, 10, 370);
            g.DrawLine(myPen, 10, 430, 10, 490);
            g.DrawLine(myPen, 490, 10, 490, 490);
            g.DrawLine(myPen, 10, 490, 490, 490);
            var myRectangle = new Rectangle(100,70,150,180);
            var myRectangle1 = new Rectangle(340, 250, 90, 180);
            g.DrawRectangle(myPen, myRectangle);
            g.DrawRectangle(myPen, myRectangle1);
            myPen.Dispose();
            var mypen2 = new Pen(Color.Red);
            int x1=0, x2=0, y1=0, y2=0;
            for (int i = 0; i < 11; i++)
            {
                if (x[i] == 0)
                {
                    if (y[i] == 13)
                    {
                        x1 = 10;
                        y1 = 385;
                    }
                    else if (y[i] == 14)
                    {
                        x1 = 10;
                        y1 = 415;
                    }
                }
                else if(y[i]==0)
                {
                    if (x[i] == 9)
                    {
                        x1 = 265;
                        y1 = 10;
                    }
                    else if (x[i] == 10)
                    {
                        x1 = 295;
                        y1 = 10;
                    }
                }
                else
                {
                    x1 = (x[i] * 30) - 5;
                    y1 = (y[i] * 30) - 5;
                }
                if(x[i+1] == 0)
                {
                    if (y[i+1] == 13)
                    {
                        x2 = 10;
                        y2 = 385;
                    }
                    else if (y[i+1] == 14)
                    {
                        x2 = 10;
                        y2 = 415;
                    }
                }
                else if (y[i+1] == 0)
                {
                    if (x[i+1] == 9)
                    {
                        x2 = 265;
                        y2 = 10;
                    }
                    else if (x[i+1] == 10)
                    {
                        x2 = 295;
                        y2 = 10;
                    }
                }
                else
                {
                    x2 = (x[i+1] * 30) - 5;
                    y2 = (y[i+1] * 30) - 5;
                }
                g.DrawLine(mypen2, x1, y1, x2, y2);
            }
            g.Dispose();
        }
    }
}