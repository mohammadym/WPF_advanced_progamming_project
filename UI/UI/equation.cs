using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI
{
    public class equation
    {
        public static double [] Answers = new double[2];
        public int a1;
        public int b1;
        public int c1;
        public int a2;
        public int b2;
        public int c2;
        public equation(int a1, int b1,int c1,int a2,int b2,int c2)
        {
            this.a1 = a1;
            this.b1 = b1;
            this.c1 = c1;
            this.a2 = a2;
            this.b2 = b2;
            this.c2 = c2;
        }
        public void Solve()
        {
            if(a1*b2-a2*b1==0)
            {
                Answers[0] = -100;
            }
            else
            {
                Answers[0]=(c1 * b2 - b1 * c2) / (a1 * b2 - b1 * a2);
                Answers[1]=(a1 * c2 - c1 * a2) / (a1 * b2 - b1 * a2);
            }
        }
    }
}
