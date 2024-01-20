using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Cifru_Playfair
{
    public partial class Form1 : Form
    {
        Cifru_Playfair cifru = new Cifru_Playfair();
        string text;
        string key;
        public Form1()
        {
            InitializeComponent();
        }
        private char[] prepareText(string text)
        {
            char[] sirtext = text.ToCharArray();
            char[] output = new char[sirtext.Length+1];
            int poz = 0;
            for(int i=0; i<sirtext.Length; i++)
            {
                if(sirtext[i] >= 65 && sirtext[i] <= 90)
                {
                    output[poz] = sirtext[i];
                    poz++;
                    if (i != sirtext.Length - 1 && (sirtext[i] == sirtext[i + 1] || sirtext[i] == Convert.ToChar(sirtext[i + 1] + 32)))
                    {
                        output[poz] = 'X';
                        poz++;
                    }
                }
                if(sirtext[i] >= 97 && sirtext[i] <= 122)
                {
                    sirtext[i] = Convert.ToChar(sirtext[i] - 32);
                    output[poz] = sirtext[i];
                    poz++;
                    if(i!=sirtext.Length-1 && (sirtext[i] == sirtext[i+1] || sirtext[i] == Convert.ToChar(sirtext[i+1] - 32)))
                    {
                        output[poz] = 'X';
                        poz++;
                    }
                }
            }
            if(poz%2!=0)
            {
                output[poz] = 'X';
                poz++;
            }
            return output;
        }
        private char[] prepareKey(char[] sirkey)
        {
            string alfabet = "ABCDEFGHIKLMNOPQRSTUVWXYZ"; //fara J
            char[] siralfabet = alfabet.ToCharArray();
            char[] output = new char[siralfabet.Length];
            bool ok;
            int poz = 0;
            for (int i = 0; i < sirkey.Length; i++)
            {
                ok = true;
                if (sirkey[i] >= 97 && sirkey[i] <= 122)
                {
                    sirkey[i] = Convert.ToChar(sirkey[i] - 32);
                }
                if (sirkey[i] == 'J') sirkey[i] = 'I';
                if (sirkey[i] == 32) ok = false; //spatiu
                for(int j=0; j<poz; j++)
                {
                    if(output[j] == sirkey[i])
                    {
                        ok = false;
                        break;
                    }
                }
                if(ok==true)
                {
                    output[poz]=sirkey[i];
                    poz++;
                }
            }
            for (int i = 0; i < siralfabet.Length; i++)
            {
                ok = true;
                for (int j = 0; j < poz; j++)
                {
                    if (output[j] == siralfabet[i])
                    {
                        ok = false;
                        break;
                    }
                }
                if(ok==true)
                {
                    output[poz]=siralfabet[i];
                    poz++;
                }
            }
            return output;
        }
        private bool isKeyValid(string key)
        {
            char[] sirkey = key.ToCharArray();
            if (key.Length == 0) return false;
            for (int i = 0; i < key.Length; i++)
            {
                if (!(sirkey[i] >= 65 && sirkey[i] <= 90 || sirkey[i] >= 97 && sirkey[i] <= 122) && sirkey[i] != 32)
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
            if (isKeyValid(key) == false)
            {
                MessageBox.Show("Invalid key!");
            }
            else
            {
                char[] sirtext = prepareText(text);
                char[] sirkey = key.ToCharArray();
                richTextBox2.Text = cifru.Criptare(sirtext, prepareKey(sirkey));
                richTextBox3.Text = cifru.MatrixtoString();
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
                char[] sirtext = prepareText(text);
                char[] sirkey = key.ToCharArray();
                richTextBox2.Text = cifru.Decriptare(sirtext, prepareKey(sirkey));
                richTextBox3.Text = cifru.MatrixtoString();
            }
        }
    }
}
