using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Cifru_Polialfabetic_Vigenere_
{
    internal class Cifru_Vigenere
    {
        string alphabet = "abcdefghijklmnopqrstuvwxyz";
        public string Criptare(string text, char[] sirkey)
        {
            string output="";
            char[] sirtext = text.ToCharArray();
            char[] siralphabet = alphabet.ToCharArray();
            int poz = 0;
            int shift = 0;
            for(int i=0; i<sirtext.Length; i++)
            {
                if(sirtext[i] >= 65 && sirtext[i] <= 90)
                {
                    for(int j=0; j<alphabet.Length; j++)
                    {
                        if (siralphabet[j]==sirkey[poz])
                        {
                            shift = j;
                            break;
                        }
                    }
                    if (sirkey[i]+shift>90)
                    {
                        output += Convert.ToChar(sirtext[i] - (26 - shift));
                    }
                    else
                    {
                        output += Convert.ToChar(sirtext[i] + shift);
                    }
                    poz++;
                    if(poz==sirkey.Length)
                    {
                        poz = 0;
                    }
                }
                if(sirtext[i] >= 97 && sirtext[i] <= 122)
                {
                    for (int j = 0; j < alphabet.Length; j++)
                    {
                        if (siralphabet[j] == sirkey[poz])
                        {
                            shift = j;
                            break;
                        }
                    }
                    if (sirtext[i] + shift > 122)
                    {
                        output += Convert.ToChar(sirtext[i] - (26-shift));
                    }
                    else
                    {
                        output += Convert.ToChar(sirtext[i] + shift);
                    }
                    poz++;
                    if (poz == sirkey.Length)
                    {
                        poz = 0;
                    }
                }
                if (sirtext[i] == ' ') output += ' ';
            }
            return output;
        }
        public string Decriptare(string text, char[] sirkey)
        {
            string output = "";
            char[] sirtext = text.ToCharArray();
            char[] siralphabet = alphabet.ToCharArray();
            int poz = 0;
            int shift = 0;
            for (int i = 0; i < sirtext.Length; i++)
            {
                if (sirtext[i] >= 65 && sirtext[i] <= 90)
                {
                    for (int j = 0; j < alphabet.Length; j++)
                    {
                        if (siralphabet[j] == sirkey[poz])
                        {
                            shift = j;
                            break;
                        }
                    }
                    if (sirkey[i] - shift < 65)
                    {
                        output += Convert.ToChar(sirtext[i] + (26 - shift));
                    }
                    else
                    {
                        output += Convert.ToChar(sirtext[i] - shift);
                    }
                    poz++;
                    if (poz == sirkey.Length)
                    {
                        poz = 0;
                    }
                }
                if (sirtext[i] >= 97 && sirtext[i] <= 122)
                {
                    for (int j = 0; j < alphabet.Length; j++)
                    {
                        if (siralphabet[j] == sirkey[poz])
                        {
                            shift = j;
                            break;
                        }
                    }
                   if (sirtext[i] - shift <97)
                    {
                        output += Convert.ToChar(sirtext[i] + (26 - shift));
                    }
                    else
                    {
                        output += Convert.ToChar(sirtext[i] - shift);
                    }
                    poz++;
                    if (poz == sirkey.Length)
                    {
                        poz = 0;
                    }
                }
                if (sirtext[i] == ' ') output += ' ';
            }
            return output;
        }
    }
}
