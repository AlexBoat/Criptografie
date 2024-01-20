using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cifru_Cezar
{
    internal abstract class Cipher_template
    {
        public abstract string Criptare(string text);
        public abstract string Decriptare(string text);
    }
}
