using System;
using System.Collections.Generic;
using System.Text;

namespace PS
{
    //==================================================1

    class _1
    {
        static int BitWeight(short num)
        {
            int cnt = 0;
            if (num < 0)
            {
                num = Math.Abs(num);
                while (num % 2 != 1 && num > 0) num /= 2;
                cnt++;
                while (num > 0)
                {
                    if (num % 2 == 0) cnt++;
                    num /= 2;
                }
            }
            else
            {
                while (num > 0)
                {
                    cnt += num % 2;
                    num /= 2;
                }
            }
            return cnt;
        }


        static int BitWeight(double num)
        {
            int cnt = 0;
            if (num < 0) num = Math.Abs(num);
            cnt += BitWeight((short)num);
            double s = Math.Round(num - Math.Floor(num), 15);
            for (int i = 0; ; i++)
            {
                if (s == 1.0)
                {
                    cnt++;
                    break;
                }
                else if (i > 15)
                    return 0;

                cnt += (int)(s * 2);
                s *= 2;

                if (s != 1.0) s = Math.Round(s - Math.Floor(s), 15);
            }
            return cnt;
        }

        static int Int32ToBin(int num)
        {
            int res = 0;
            for (int i = 0; num > 0; i++)
            {
                res += (int)Math.Pow(10, i) * (num % 2);
                num /= 2;
            }
            return res;
        }

        static double FracToBin(double num)
        {
            double res = 0;
            for (int i = 0; num != 0 && i < 15; i++)
            {
                num *= 2;
                res += Math.Pow(10, -i - 1) * Math.Floor(num);
                num = Math.Round(num - Math.Floor(num), 15);
            }
            return res;
        }
        static int GetDigitAfterComa(double num, int i) => (int)(num % Math.Pow(10, -i) - num % Math.Pow(10, -i - 1) * Math.Pow(10, i + 1));
        static double ToIEEE745x32(double num)
        {
            //Constants
            const int BIAS = 127;
            const int FracRound = 15;
            //Parts
            bool SIGN = num < 0 ? true : false;
            double Exp = 0;
            double Mantissa = 0;
            //Setup
            num = Math.Abs(num);
            int Int = Int32ToBin((int)num);
            double Frac = FracToBin(Math.Round(num - Math.Floor(num), FracRound));
            //SIGN
            double res = 0;
            if (SIGN) res++;
            //MANTISSA + EXP
            Mantissa = Int + Frac;
            for (int i = 0; ; i++)
            {
                if (Int < Math.Pow(10, i))
                {
                    Exp = Int32ToBin(BIAS + (i - 1)); //EXP
                    Mantissa = Mantissa * Math.Pow(10, -i + 1); //Mantissa in i.ffffff...
                    Mantissa = Mantissa - 1.0;
                    break;
                }
            }

            return -123;
        }
    }
}
