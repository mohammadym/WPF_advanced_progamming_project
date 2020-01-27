using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dc
{
    class Class1
    {
        private int x;
        private int y;
        private int area;
        private int prime;
        public int X
        {
            set { x = value; }
        }
        public int Y
        {
            set { y = value; }
        }
        public void CaculateArea()
        {
            area = x * y;
        }
        public void CalculatePrime()
        {
            prime = (x + y) * 2;
        }
        public int GetArea()
        {
            return area;
        }
        public int GetPrime()
        {
            return prime;
        }
    }
}
