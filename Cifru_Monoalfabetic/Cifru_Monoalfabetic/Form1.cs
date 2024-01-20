using Cifru_monoalfabetic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cifru_Monoalfabetic
{
    public partial class Form1 : Form
    {
        Monoalfabetic cifru = new Monoalfabetic();
        string input;
        string key;
        public Form1()
        {
            InitializeComponent();
        }
        private bool checkAlphabet(string key)
        {
            if (key.Length != 26)
            {
                return false;
            }
            char[] alphabet = key.ToCharArray();
            for(int i=0; i < 26; i++)
            {
                if(!(alphabet[i] >= 97 && alphabet[i] <= 122))
                {
                    return false;
                }
                else
                {
                    for(int j=0; j<i; j++)
                    {
                        if(alphabet[j] == alphabet[i])
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            input = richTextBox1.Text;
            key = textBox1.Text;
            if(checkAlphabet(key)==false)
            {
                MessageBox.Show("Invalid key!");
            }
            else
            {
                richTextBox2.Text = cifru.Criptare(input, key);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            input = richTextBox1.Text;
            key = textBox1.Text;
            richTextBox2.Text = cifru.Decriptare(input, key);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            input = richTextBox1.Text;
            richTextBox2.Text = cifru.Criptanaliza(input);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = cifru.FisherYatesShuffle();
        }
    }
}
