using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace hosh_genetic
{
    
    public partial class Form1 : Form
    {
        ga ga = new ga();
        double[] temp = new double[1000];
        int Repeat;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            listBox1.Items.Clear();
            if (textBox1.Text != "")
            {
                try
                {
                    Repeat = Convert.ToInt32(textBox1.Text);
                    string qq;
                    Gen[] gen = new Gen[100];
                    string[] w1 = new string[20];
                    double[] w2 = new double[20];
                    for (int i = 0; i < Repeat; i++)
                    {
                        if (i == 0)
                        {
                            gen = ga.first();
                            for (int q = 0; q < 100; q++)
                            {
                                qq = "";
                                foreach (string s in gen[q].Genv)
                                    qq += s + " ";
                                qq += "     " + gen[q].Fitness;
                                listBox1.Items.Add(qq);
                            }
                            temp[i] = gen[0].Fitness;
                            for (int q = 0; q < 10; q++)
                            {
                                qq = "";
                                foreach (string s in gen[q].Genv)
                                    qq += s + " ";
                                qq += "     ";
                                w1[q] = qq;
                                w2[q] = gen[q].Fitness;
                            }


                        }
                        else
                        {
                            listBox1.Items.Add(" ");
                            listBox1.Items.Add(i);
                            gen = ga.genpop(gen);
                            temp[i] = gen[0].Fitness;
                            for (int q = 0; q < 100; q++)
                            {
                                qq = "";
                                foreach (string s in gen[q].Genv)
                                    qq += s + " ";
                                qq += "     " + gen[q].Fitness;
                                listBox1.Items.Add(qq);
                            }
                            int r = 0;
                            for (int q = 10; q < 20; q++)
                            {

                                qq = "";
                                foreach (string s in gen[r].Genv)
                                    qq += s + " ";
                                qq += "     ";
                                w1[q] = qq;
                                w2[q] = gen[r].Fitness;
                                r++;
                            }
                            double tempp;
                            string temppp;
                            for (int j = 19; j >= 0; j--)
                                for (int ii = 0; ii <= j - 1; ii++)
                                    if (w2[ii] > w2[ii + 1])
                                    {
                                        tempp = w2[ii];
                                        w2[ii] = w2[ii + 1];
                                        w2[ii + 1] = tempp;
                                        temppp = w1[ii];
                                        w1[ii] = w1[ii + 1];
                                        w1[ii + 1] = temppp;
                                    }
                        }
                    }


                    listBox2.Items.Add("");
                    for (int i = 0; i < 5; i++)
                    {
                        qq = w1[i] + w2[i].ToString();
                        listBox2.Items.Add(qq);
                    }
                }
                catch
                {
                    MessageBox.Show("please enter a correct value.");
                }
                
            }
            else
                MessageBox.Show("please enter times of Repeat.");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.chart1.Palette = ChartColorPalette.Berry;
            form2.chart1.Titles.Clear();
            form2.chart1.Titles.Add("روند رشد fitnes");
            form2.chart1.Series.Clear();
            Series series = new Series();
            series.ChartType = SeriesChartType.Column;
            for (int i = 0; i < Repeat; i++)
                series.Points.AddXY(i+1,temp[i]);
            form2.chart1.Series.Add(series);
            form2.chart1.Update();
            form2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                string s = listBox2.SelectedItem.ToString();
                Form3 form3 = new Form3(s);
                form3.Show();
            }
            else
                MessageBox.Show("please select a way in the right list.");
           
        }
    }
}
