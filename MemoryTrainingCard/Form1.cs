using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MemoryTrainingCard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string nums = "";
        int s;
        int sec;
        Random r = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            button2.Visible = false;
            nums = "";
            for(int i = 0; i < 10; i++)
            {
                nums += r.Next(0, 9).ToString() + " ";
            }
            label2.Text = "Порядок цифр " + nums;
            timer1.Enabled = true;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            try
            {
                sec = Convert.ToInt32(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Введите кол-во секунд");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            s += 1;
            if(s >= sec)
            {
                nums = nums.Replace(" ", "");
                List<char> new_nums = nums.ToList();
                List<string> data = new List<string>();
                foreach (var s in new_nums)
                {
                    int j = r.Next(data.Count + 1);
                    if (j == data.Count)
                    {
                        data.Add(s.ToString());
                    }
                    else
                    {
                        data.Add(data[j]);
                        data[j] = s.ToString();
                    }
                }
                for(int i = 0; i < data.Count; i++)
                {
                    data[i] += ' ';
                }
                label2.Text = "Порядок поменялся " + String.Join("", data);
                timer1.Enabled = false;
                s = 0;
                MessageBox.Show("Время вышло");
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                button2.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == nums)
            {
                MessageBox.Show("Правильно");
            }
            else
            {
                MessageBox.Show("Неправильно");
            }
        }
    }
}
