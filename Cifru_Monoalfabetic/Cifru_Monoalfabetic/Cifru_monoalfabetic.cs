using Cifru_Monoalfabetic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cifru_monoalfabetic
{
    internal class Monoalfabetic: Cipher_template
    {
        string alfabet = "abcdefghijklmnopqrstuvwxyz";
        public string FisherYatesShuffle()
        {
            char[] sir = alfabet.ToCharArray();
            Random rnd = new Random();
            int j;
            char aux;
            for (int i = 0; i <= sir.Length - 2; i++)
            {
                j = rnd.Next(i, sir.Length);
                aux = sir[i];
                sir[i] = sir[j];
                sir[j] = aux;
            }
            string rezultat = "";
            for (int i = 0; i < sir.Length; i++)
            {
                rezultat += sir[i];
            }
            return rezultat;
        }
        public override string Criptare(string text, string key)
        {
            char[] input = text.ToCharArray();
            char[] siralpha = alfabet.ToCharArray();
            char[] sirkey = key.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= 97 && input[i] <= 122)
                {
                    for(int a = 0; a < 26; a++)
                    {
                        if (siralpha[a] == input[i])
                        {
                            input[i] = sirkey[a];
                            break;
                        }
                    }
                }
                if (input[i] >= 65 && input[i] <= 90)
                {
                    for (int a = 0; a < 26; a++)
                    {
                        if (siralpha[a] == input[i]+32)
                        {
                            input[i] = sirkey[a];
                            input[i] = Convert.ToChar(input[i] - 32);
                            break;
                        }
                    }
                }
            }
            text = "";
            for (int i = 0; i < input.Length; i++)
            {
                text += input[i];
            }
            return text;
        }
        public override string Decriptare(string text, string key)
        {
            char[] input = text.ToCharArray();
            char[] siralpha = alfabet.ToCharArray();
            char[] sirkey = key.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] >= 97 && input[i] <= 122)
                {
                    for (int a = 0; a < 26; a++)
                    {
                        if (sirkey[a] == input[i])
                        {
                            input[i] = siralpha[a];
                            break;
                        }
                    }
                }
                if (input[i] >= 65 && input[i] <= 90)
                {
                    for (int a = 0; a < 26; a++)
                    {
                        if (sirkey[a] == input[i] + 32)
                        {
                            input[i] = siralpha[a];
                            input[i] = Convert.ToChar(input[i] - 32);
                            break;
                        }
                    }
                }
            }
            text = "";
            for (int i = 0; i < input.Length; i++)
            {
                text += input[i];
            }
            return text;
        }
        public override string Criptanaliza(string text)
        {
            return "";
        }
    }
}
