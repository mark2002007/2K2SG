using System;
using System.Collections.Generic;
using System.Text;

namespace PS._3
{
    class Tools
    {
        public static int ToBinary(int num)
        {
            string res = "";
            while (num > 0)
            {
                res = (num % 2).ToString() + res;
                num /= 2;
            }
            return int.Parse(res);
        }
    }
}
