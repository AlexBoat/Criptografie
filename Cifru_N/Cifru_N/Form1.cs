using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cifru_N
{
    public partial class Form1 : Form
    {
        Cifru_N cifru = new Cifru_N();
        
        string input;
        int key;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            input = richTextBox1.Text;
            try
            {
                key = Convert.ToInt32(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Invalid number!");
                key = 0;
                textBox1.Text = "0";
            }
            richTextBox2.Text = cifru.Criptare(input, key);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            input = richTextBox1.Text;
            try
            {
                key = Convert.ToInt32(textBox1.Text);
            }
            catch
            {
                MessageBox.Show("Invalid number!");
                key = 0;
                textBox1.Text = "0";
            }
            richTextBox2.Text = cifru.Decriptare(input, key);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            input = richTextBox1.Text;
            richTextBox2.Text = cifru.Criptanaliza(input);
        }
    }
}
