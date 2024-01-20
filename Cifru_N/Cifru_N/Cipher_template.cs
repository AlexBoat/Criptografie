using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cifru_N
{
    internal abstract class Cipher_template
    {
        public abstract string Criptare(string text, int key);
        public abstract string Decriptare(string text, int key);
        public abstract string Criptanaliza(string text);
    }
}
