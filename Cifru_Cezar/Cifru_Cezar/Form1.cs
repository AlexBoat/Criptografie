using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cifru_Cezar
{
    public partial class Form1 : Form
    {
        Cifru_Cezar cipher = new Cifru_Cezar();
        string input;
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            input = richTextBox1.Text;
            richTextBox2.Text = cipher.Criptare(input);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            input = richTextBox1.Text;
            richTextBox2.Text = cipher.Decriptare(input);
        }
    }
}
