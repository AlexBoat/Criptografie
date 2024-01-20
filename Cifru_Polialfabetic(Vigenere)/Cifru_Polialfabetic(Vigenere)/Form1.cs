using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cifru_Polialfabetic_Vigenere_
{
    public partial class Form1 : Form
    {
        Cifru_Vigenere cifru = new Cifru_Vigenere();
        string text;
        string key;
        public Form1()
        {
            InitializeComponent();
        }

        private bool isKeyValid(string key)
        {
            char[] sirkey = key.ToCharArray();
            for(int i=0; i<key.Length; i++)
            {
                if(!(sirkey[i]>=65 && sirkey[i]<=90 || sirkey[i]>=97 && sirkey[i]<=122) && sirkey[i]!=32)
                {
                    return false;
                }
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            text = richTextBox1.Text;
            key = textBox1.Text;
            if(isKeyValid(key)==false)
            {
                MessageBox.Show("Invalid key!");
            }
            else
            {
                char[] sirkey = key.ToCharArray();
                for (int i=0; i<key.Length; i++)
                {
                    if(sirkey[i] >= 65 && sirkey[i] <= 90)
                    {
                        sirkey[i] = Convert.ToChar(sirkey[i] + 32);
                    }
                }
                richTextBox2.Text = cifru.Criptare(text, sirkey);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            text = richTextBox1.Text;
            key = textBox1.Text;
            if (isKeyValid(key) == false)
            {
                MessageBox.Show("Invalid key!");
            }
            else
            {
                char[] sirkey = key.ToCharArray();
                for (int i = 0; i < key.Length; i++)
                {
                    if (sirkey[i] >= 65 && sirkey[i] <= 90)
                    {
                        sirkey[i] = Convert.ToChar(sirkey[i] + 32);
                    }
                }
                richTextBox2.Text = cifru.Decriptare(text, sirkey);
            }
        }
    }
}
