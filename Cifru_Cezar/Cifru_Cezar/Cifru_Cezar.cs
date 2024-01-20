using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cifru_Cezar
{
    internal class Cifru_Cezar:Cipher_template
    {
        public override string Criptare(string text)
        {
            char[] sir = text.ToCharArray();
            for (int i = 0; i < sir.Length; i++)
            {
                if (sir[i] >= 97 && sir[i] <= 122)
                {
                    sir[i] = Convert.ToChar(sir[i] + 3);
                    if (sir[i] > 122)
                    {
                        sir[i] = Convert.ToChar(sir[i] - 26);
                    }
                }
                if (sir[i] >= 65 && sir[i] <= 90)
                {
                    sir[i] = Convert.ToChar(sir[i] + 3);
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
        public override string Decriptare(string text)
        {
            char[] sir = text.ToCharArray();
            for (int i = 0; i < sir.Length; i++)
            {
                if (sir[i] >= 97 && sir[i] <= 122)
                {
                    sir[i] = Convert.ToChar(sir[i] - 3);
                    if (sir[i] < 97)
                    {
                        sir[i] = Convert.ToChar(sir[i] + 26);
                    }
                }
                if (sir[i] >= 65 && sir[i] <= 90)
                {
                    sir[i] = Convert.ToChar(sir[i] - 3);
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
    }
}
