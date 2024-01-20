using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cifru_Playfair
{
    internal class Cifru_Playfair
    {
        
        char[,] keymatrix= new char[5, 5];
        public string MatrixtoString()
        {
            string output = "";
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    output+=keymatrix[i, j];
                    output+=' ';
                }
                output += System.Environment.NewLine;
            }
            return output;
        }
        public void buildMatrix(char[] key)
        {
            int poz = 0;
            for(int i=0; i<5; i++)
            {
                for(int j=0; j<5; j++)
                {
                    keymatrix[i, j] = key[poz];
                    poz++;
                }
            }
        }
        public string Criptare(char[] sirtext, char[] sirkey)
        {
            string output="";
            buildMatrix(sirkey);
            int poz1x=0, poz1y=0, poz2x=0, poz2y=0;
            for(int e=0; e<sirtext.Length-1; e=e+2)
            {
                if (sirtext[e] == 0) continue;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if(keymatrix[i, j] == sirtext[e])
                        {
                            poz1x = i;
                            poz1y = j;
                        }
                        if (keymatrix[i,j] == sirtext[e+1])
                        {
                            poz2x = i;
                            poz2y = j;
                        }
                    }
                }
                if(poz1x==poz2x)
                {
                    if(poz1y==4)
                    {
                        output += keymatrix[poz1x, 0];
                    }
                    else output += keymatrix[poz1x, poz1y+1];
                    if (poz2y == 4)
                    {
                        output += keymatrix[poz2x, 0];
                    }
                    else output += keymatrix[poz2x, poz2y+1];
                }
                else
                {
                    if(poz1y==poz2y)
                    {
                        if (poz1x == 4)
                        {
                            output += keymatrix[0, poz1y];
                        }
                        else output += keymatrix[poz1x+1, poz1y];
                        if (poz2x == 4)
                        {
                            output += keymatrix[0, poz2y];
                        }
                        else output += keymatrix[poz2x+1, poz2y];
                    }
                    else
                    {
                        output += keymatrix[poz1x, poz2y];
                        output += keymatrix[poz2x, poz1y];
                    }
                }
                output += ' ';
            }
            return output;
        }
        public string Decriptare(char[] sirtext, char[] sirkey)
        {
            string output = "";
            buildMatrix(sirkey);
            int poz1x = 0, poz1y = 0, poz2x = 0, poz2y = 0;
            for (int e=0; e<sirtext.Length-1; e=e+2)
            {
                if (sirtext[e] == 0) continue;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (keymatrix[i, j] == sirtext[e])
                        {
                            poz1x = i;
                            poz1y = j;
                        }
                        if (keymatrix[i, j] == sirtext[e + 1])
                        {
                            poz2x = i;
                            poz2y = j;
                        }
                    }
                }
                if (poz1x == poz2x)
                {
                    if (poz1y == 0)
                    {
                        output += keymatrix[poz1x, 4];
                    }
                    else output += keymatrix[poz1x, poz1y - 1];
                    if (poz2y == 0)
                    {
                        output += keymatrix[poz2x, 4];
                    }
                    else output += keymatrix[poz2x, poz2y - 1];
                }
                else
                {
                    if (poz1y == poz2y)
                    {
                        if (poz1x == 0)
                        {
                            output += keymatrix[4, poz1y];
                        }
                        else output += keymatrix[poz1x - 1, poz1y];
                        if (poz2x == 0)
                        {
                            output += keymatrix[4, poz2y];
                        }
                        else output += keymatrix[poz2x - 1, poz2y];
                    }
                    else
                    {
                        output += keymatrix[poz1x, poz2y];
                        output += keymatrix[poz2x, poz1y];
                    }
                }
                output += ' ';
            }
            return output;
        }
    }
}
