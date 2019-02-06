using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hosh_genetic
{
    class ga
    {
        Boolean isdone = false;
        int waycount = 0;
        char[,] map = { {'1','1','1','1','1','1','1','1','1','0','0','1','1','1','1','1','1','1'},
                            {'1','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','1'},
                            {'1','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','1'},
                            {'1','0','0','0','1','1','1','1','1','0','0','0','0','0','0','0','0','1'},
                            {'1','0','0','0','1','1','1','1','1','0','0','0','0','0','0','0','0','1'},
                            {'1','0','0','0','1','1','1','1','1','0','0','0','0','0','0','0','0','1'},
                            {'1','0','0','0','1','1','1','1','1','0','0','0','0','0','0','0','0','1'},
                            {'1','0','0','0','1','1','1','1','1','0','0','0','0','0','0','0','0','1'},
                            {'1','0','0','0','1','1','1','1','1','0','0','0','0','0','0','0','0','1'},
                            {'1','0','0','0','0','0','0','0','0','0','0','0','1','1','1','0','0','1'},
                            {'1','0','0','0','0','0','0','0','0','0','0','0','1','1','1','0','0','1'},
                            {'1','0','0','0','0','0','0','0','0','0','0','0','1','1','1','0','0','1'},
                            {'1','0','0','0','0','0','0','0','0','0','0','0','1','1','1','0','0','1'},
                            {'0','0','0','0','0','0','0','0','0','0','0','0','1','1','1','0','0','1'},
                            {'0','0','0','0','0','0','0','0','0','0','0','0','1','1','1','0','0','1'},
                            {'1','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','1'},
                            {'1','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','1'},
                            {'1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1','1'}};
        public Gen[] first()
        {
            Random random = new Random();
            int x, y;
            Gen[] temp = new Gen[100];
            for (int i = 0; i < 25; i++)
            {
                temp[i] = new Gen();
                temp[i].Genv[0] = "13,0";
                temp[i].Genv[11] = "0,9";
                for (int j = 1; j < 11; j++)
                {
                    x = random.Next(1, 16);
                    y = random.Next(1, 16);
                    temp[i].Genv[j] = x.ToString() + "," + y.ToString();
                }
            }
            for (int i = 25; i < 50; i++)
            {
                temp[i] = new Gen();
                temp[i].Genv[0] = "13,0";
                temp[i].Genv[11] = "0,10";
                for (int j = 1; j < 11; j++)
                {
                    x = random.Next(1, 16);
                    y = random.Next(1, 16);
                    temp[i].Genv[j] = x.ToString() + "," + y.ToString();
                }
            }
            for (int i = 50; i < 75; i++)
            {
                temp[i] = new Gen();
                temp[i].Genv[0] = "14,0";
                temp[i].Genv[11] = "0,9";
                for (int j = 1; j < 11; j++)
                {
                    x = random.Next(1, 16);
                    y = random.Next(1, 16);
                    temp[i].Genv[j] = x.ToString() + "," + y.ToString();
                }
            }
            for (int i = 50; i < 100; i++)
            {
                temp[i] = new Gen();
                temp[i].Genv[0] = "14,0";
                temp[i].Genv[11] = "0,10";
                for (int j = 1; j < 11; j++)
                {
                    x = random.Next(1, 16);
                    y = random.Next(1, 16);
                    temp[i].Genv[j] = x.ToString() + "," + y.ToString();
                }
            }
            temp = fitness(temp);
            temp = Sortga(temp);
            return temp;

        }
        public Gen[] genpop(Gen[] a)
        {
            int i = 49;
            int n = 0;
            for (int j = 1; j < 50; j += 2)
            {
                n = a[j].Genv.Length / 2;

                for (int q = 0; q < n; q++)
                {
                    a[i].Genv[q] = a[j].Genv[q];
                }
                for (int q = n; q < 12; q++)
                {
                    a[i].Genv[q] = a[j - 1].Genv[q];
                }
                i++;
                for (int q = 0; q < n; q++)
                {
                    a[i].Genv[q] = a[j - 1].Genv[q];
                }
                for (int q = n; q < 12; q++)
                {
                    a[i].Genv[q] = a[j].Genv[q];
                }
            }
            a = mutation(a);
            a = fitness(a);
            a = Sortga(a);
            return a;
        }
        public Gen[] fitness(Gen[] a)
        {


            double d;
            double f = 0;
            int x, y, x1, y1;
            int tt,ee;
            string[] s = new string[2];
            for (int i = 0; i < a.Length; i++)
            {
                d = 0;
                tt = 0;
                ee = 0;
                for (int j = 0; j < 11; j++)
                {
                    s = a[i].Genv[j].Split(',');

                    x = Convert.ToInt32(s[0]);
                    y = Convert.ToInt32(s[1]);
                    s = a[i].Genv[j + 1].Split(',');
                    x1 = Convert.ToInt32(s[0]);
                    y1 = Convert.ToInt32(s[1]);
                    d += Math.Sqrt(Math.Pow(x - x1, 2) + Math.Pow(y - y1, 2));
                    if (lineSegmentIntersection(x, y, x1, y1, 3, 4, 3, 8) == true)
                        ee++;
                    if (lineSegmentIntersection(x, y, x1, y1, 3, 4, 8, 4) == true)
                        ee++;
                    if (lineSegmentIntersection(x, y, x1, y1, 3, 8, 8, 8) == true)
                        ee++;
                    if (lineSegmentIntersection(x, y, x1, y1, 8, 4, 8, 8) == true)
                        ee++;
                    if (lineSegmentIntersection(x, y, x1, y1, 9, 12, 9, 14) == true)
                        ee++;
                    if (lineSegmentIntersection(x, y, x1, y1, 9, 12, 14, 12) == true)
                        ee++;
                    if (lineSegmentIntersection(x, y, x1, y1, 9, 14, 14, 14) == true)
                        ee++;
                    if (lineSegmentIntersection(x, y, x1, y1, 14, 12, 14, 14) == true)
                        ee++;
                    if (map[x, y] == '1')
                        tt++;
                   
                }
                f = (tt * 10000) + d +(ee*100);

                a[i].Fitness = f;
            }
            return a;
        }
        public Gen[] mutation(Gen[] a)
        {
            int q = 0;
            Boolean b = true;
            int x = 0, y = 0, x1, y1;
            Random random = new Random();
            string[] s = new string[2];
           /* for (int i = 0; i < 100; i++)
            {
                while (b)
                {
                    x = random.Next(1, 16);
                    y = random.Next(1, 16);
                    if (map[x, y] != '1')
                        b = false;
                }

                for (int j = 1; j < 9; j++)
                {
                    s = a[i].Genv[j].Split(',');
                    x1 = Convert.ToInt32(s[0]);
                    y1 = Convert.ToInt32(s[1]);
                    if (map[x1, y1] == '1')
                    {
                        q = j;
                        j = 25;
                    }
                }
                if (q != 0)
                    a[i].Genv[q] = x.ToString() + "," + y.ToString();
                else
                {
                    q = random.Next(1, 23);
                    a[i].Genv[q] = x.ToString() + "," + y.ToString();
                }
            }*/
            for (int i = 0; i < 100; i++)
            {
                x = random.Next(1, 16);
                y = random.Next(1, 16);
                q = random.Next(1, 10);
                a[i].Genv[q] = x.ToString() + "," + y.ToString();
            }
            return a;
        }

        public Gen[] Sortga(Gen[] a)
        {
            Gen temp;
            for (int j = a.Length-1; j >= 0; j--)
                for (int i = 0; i <= j - 1; i++)
                    if (a[i].Fitness > a[i + 1].Fitness)
                    {
                        temp = a[i];
                        a[i] = a[i + 1];
                        a[i + 1] = temp;
                    }
            return a;
        }
        
        public static bool lineSegmentIntersection(double Ax, double Ay,double Bx, double By,double Cx, double Cy,double Dx, double Dy)
        {
            double distAB, theCos, theSin, newX, ABpos;
            if (Ax == Bx && Ay == By || Cx == Dx && Cy == Dy) return false;
            if (Ax == Cx && Ay == Cy || Bx == Cx && By == Cy
            || Ax == Dx && Ay == Dy || Bx == Dx && By == Dy)
            {
                return false;
            }
            Bx -= Ax; By -= Ay;
            Cx -= Ax; Cy -= Ay;
            Dx -= Ax; Dy -= Ay;
            distAB = Math.Sqrt(Bx * Bx + By * By);
            theCos = Bx / distAB;
            theSin = By / distAB;
            newX = Cx * theCos + Cy * theSin;
            Cy = Cy * theCos - Cx * theSin; Cx = newX;
            newX = Dx * theCos + Dy * theSin;
            Dy = Dy * theCos - Dx * theSin; Dx = newX;
            if (Cy < 0 && Dy < 0 || Cy >= 0 && Dy >= 0) return false;
            ABpos = Dx + (Cx - Dx) * Dy / (Dy - Cy);
            if (ABpos < 0 || ABpos > distAB) return false;
            return true;
        }
    }
}
