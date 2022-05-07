
/* Постройте график функции для своего варианта из лабораторной
работы № 4.Таблицу данных получить путем изменения параметра X 
с шагом dx. Добавьте второй график для произвольной функции.
y = 10^(-2)b*c/x + cos(sqrt(a^3x))
x0 = -1,5; xk = 3,5; dx = 0,5;
a = -1.25; b = -1.5; c = 0.75; */
// Поменяла числа a, b, c, теперь в интервале от 0,1 и выше работает

using System;
using System.Windows.Forms;

namespace WindowsFormsApp21
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                const double a = 5.3, b = 3.5, c = 7.2;
                double Xmin = double.Parse(textBox1.Text);
                double Xmax = double.Parse(textBox2.Text);
                double Step = double.Parse(textBox3.Text);
                int count = (int)Math.Ceiling((Xmax - Xmin) / Step) + 1;
                double[] x = new double[count];
                double[] y1 = new double[count];
                double[] y2 = new double[count];
                for (int i = 0; i < count; i++)
                {
                    x[i] = Xmin + Step * i;
                    y1[i] = Math.Pow(10, -2) * b * c / x[i] + Math.Cos(Math.Sqrt(Math.Pow(a, 3) * x[i]));
                    y2[i] = Math.Cos(x[i]);
                }
                chart1.ChartAreas[0].AxisX.Minimum = Xmin;
                chart1.ChartAreas[0].AxisX.Maximum = Xmax;
                chart1.ChartAreas[0].AxisX.MajorGrid.Interval = Step;
                chart1.Series[0].Points.DataBindXY(x, y1);
                chart1.Series[1].Points.DataBindXY(x, y2);

            }
            catch (Exception ex)
            {
                textBox4.Text = ex.Message;
            }
        }
    }
}
