using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Cifru_N
{
    internal class Cifru_N:Cipher_template
    {
        public override string Criptare(string text, int key)
        {
            char[] sir = text.ToCharArray();
            for (int i = 0; i < sir.Length; i++)
            {
                if (sir[i] >= 97 && sir[i] <= 122)
                {
                    sir[i] = Convert.ToChar(sir[i] + key);
                    if (sir[i] > 122)
                    {
                        sir[i] = Convert.ToChar(sir[i] - 26);
                    }
                }
                if (sir[i] >= 65 && sir[i] <= 90)
                {
                    sir[i] = Convert.ToChar(sir[i] + key);
                    if (sir[i] > 90)
                    {
                        sir[i] = Convert.ToChar(sir[i] - 26);
                    }
                }

            }
            text = "";
            for (int i = 0; i < sir.Length; i++)
            {
                text += sir[i];
            }
            return text;
        }
        public override string Decriptare(string text, int key)
        {
            char[] sir = text.ToCharArray();
            for (int i = 0; i < sir.Length; i++)
            {
                if (sir[i] >= 97 && sir[i] <= 122)
                {
                    sir[i] = Convert.ToChar(sir[i] - key);
                    if (sir[i] < 97)
                    {
                        sir[i] = Convert.ToChar(sir[i] + 26);
                    }
                }
                if (sir[i] >= 65 && sir[i] <= 90)
                {
                    sir[i] = Convert.ToChar(sir[i] - key);
                    if (sir[i] < 65)
                    {
                        sir[i] = Convert.ToChar(sir[i] + 26);
                    }
                }

            }
            text = "";
            for (int i = 0; i < sir.Length; i++)
            {
                text += sir[i];
            }
            return text;
        }
        public override string Criptanaliza(string text)
        {
            StreamReader f = new StreamReader("dictionar.txt");
            string dictionar = f.ReadToEnd();
            string output = "";
            for (int i = 0; i < 26; i++)
            {
                string test = Decriptare(text, i).ToLower();
                char[] separatori = new char[] { ' ', '!', '.', ',', '?', ';' };
                string[] words = test.Split(separatori, StringSplitOptions.RemoveEmptyEntries);

                int count = 0;
                foreach (string word in words)
                {

                    if (dictionar.Contains(word)) count++;
                }

                float successRate = ((float)count / words.Length) * 100;

                if (successRate >= 70)
                {
                    output += i + " (" + successRate + "% success)";
                    return output;
                }
            }

            return "No success";
        }
    }
}
