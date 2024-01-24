using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Merkle_Hellman_knapsack
{
    public partial class Form1 : Form
    {
        string text;
        string publickey;
        string privatekey;
        int q;
        int r;
        int n;
        public Form1()
        {
            InitializeComponent();
        }
        private int Euclid(int n , int m)
        {
            while (n != m)
                if (n > m)
                    n -= m;
                else
                    m -= n;
            return n;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                n = Convert.ToInt32(textBox2.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid number of bits!");
                n = 8;
                textBox2.Text = "8";
            }
            if (n > 28)
            {
                MessageBox.Show("Number of bits is too large!");
                n = 8;
                textBox2.Text = "8";
            }
            text = richTextBox1.Text;
            publickey = textBox5.Text;
            char[] space = { ' ' };
            string[] sirkey = publickey.Split(space, StringSplitOptions.RemoveEmptyEntries);
            if (sirkey.Length != n)
            {
                MessageBox.Show("Number of bits doesnt match public key!");
            }
            else
            {
                int[] pubkey = new int[sirkey.Length];
                for(int i=0; i<sirkey.Length; i++)
                {
                    pubkey[i] = Convert.ToInt32(sirkey[i]);
                }
                char[] sirtext = text.ToCharArray();
                text = "";
                for(int i=0; i<sirtext.Length; i++)
                {
                    if (sirtext[i]!=' ')
                    {
                        text+= Convert.ToString(sirtext[i], 2);
                        text += ' ';
                    }
                }
                string[] tokens = text.Split(space, StringSplitOptions.RemoveEmptyEntries);
                text = "";
                char[] sirtoken = new char[n];
                char[] normalised = new char[n];
                int poz;
                int sum;
                foreach(string token in tokens)
                {
                    sirtoken = token.ToCharArray();
                    poz = n-sirtoken.Length;
                    for(int i=0; i<sirtoken.Length; i++)
                    {
                        normalised[poz] = sirtoken[i];
                        poz++;
                    }
                    poz=n-sirtoken.Length-1;
                    while(poz!=-1)
                    {
                        normalised[poz]='0';
                        poz--;
                    }
                    sum = 0;
                    int a, b;
                    for(int i=0; i<n; i++)
                    {
                        a = normalised[i] - '0';
                        b = Convert.ToInt32(sirkey[i]);
                        sum += a * b;
                    }
                    text += Convert.ToString(sum);
                    text +=" ";
                }
                richTextBox2.Text = text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                n = Convert.ToInt32(textBox2.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid number of bits!");
                n = 8;
                textBox2.Text = "8";
            }
            if (n > 28)
            {
                MessageBox.Show("Number of bits is too large!");
                n = 8;
                textBox2.Text = "8";
            }
            q = Convert.ToInt32(textBox3.Text);
            r = Convert.ToInt32(textBox4.Text);
            privatekey = textBox1.Text;
            char[] space = { ' ' };
            string[] sirkey = privatekey.Split(space, StringSplitOptions.RemoveEmptyEntries);
            if (sirkey.Length != n)
            {
                MessageBox.Show("Number of bits doesnt match private key!");
            }
            else
            {
                int rprime=0;
                for(int i=0; i<q; i++)
                {
                    if((r * i) % q == 1)
                    {
                        rprime = i;
                        break;
                    }
                }
                text = richTextBox1.Text;
                string[] tokens = text.Split(space, StringSplitOptions.RemoveEmptyEntries);
                int c=0, cprime=0;
                string output = "";
                double auxus = 0;
                int outputsum = 0;
                foreach(string token in tokens)
                {
                    c = Convert.ToInt32(token);
                    cprime = (c * rprime) % q;
                    for(int i=n-1; i>=0; i--)
                    {
                        int aux = int.Parse(sirkey[i]);
                        if (aux <= cprime)
                        {
                            cprime -= aux;
                            auxus = Math.Pow(2 ,n-(i+1));
                            outputsum += Convert.ToInt32(auxus);
                            if(cprime==0)
                            {
                                output += Convert.ToString(outputsum);
                                output += " ";
                                break;
                            }
                        }
                    }
                }
                richTextBox2.Text = output;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                n = Convert.ToInt32(textBox2.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid number of bits!");
                n = 8;
                textBox2.Text = "8";
            }
            if(n>28)
            {
                MessageBox.Show("Number of bits is too large!");
                n = 8;
                textBox2.Text = "8";
            }
            Random rnd= new Random();
            int[] result = new int[n];
            string W="";
            result[0] = rnd.Next(1, 9);
            int sum = result[0];
            W += result[0].ToString();
            W += " ";
            for(int i=1; i<n; i++)
            {
                result[i] = rnd.Next(sum+1, sum + 15);
                sum += result[i];
                W += result[i].ToString();
                W += " ";
            }
            textBox1.Text = W;
            q = rnd.Next(sum + 1, sum + 150);
            textBox3.Text = q.ToString();
            int aux=0;
            r = 0;
            while(r==0)
            {
                aux = rnd.Next(10, q);
                if(Euclid(q, aux)==1)
                {
                    r = aux;
                    textBox4.Text = r.ToString();
                }
            }
            string B = "";
            for (int i = 0; i < n; i++)
            {
                B += ((result[i]*r)%q).ToString();
                B += " ";
            }
            textBox5.Text = B;
        }
    }
}
