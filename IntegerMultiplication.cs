using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem
{
    // *****************************************
    // DON'T CHANGE CLASS OR FUNCTION NAME
    // YOU CAN ADD FUNCTIONS IF YOU NEED TO
    // *****************************************
    public static class IntegerMultiplication
    {
        #region YOUR CODE IS HERE

        //Your Code is Here:
        //==================
        /// <summary>
        /// Multiply 2 large integers of N digits in an efficient way [Karatsuba's Method]
        /// </summary>
        /// <param name="X">First large integer of N digits [0: least significant digit, N-1: most signif. dig.]</param>
        /// <param name="Y">Second large integer of N digits [0: least significant digit, N-1: most signif. dig.]</param>
        /// <param name="N">Number of digits (power of 2)</param>
        /// <returns>Resulting large integer of 2xN digits (left padded with 0's if necessarily) [0: least signif., 2xN-1: most signif.]</returns>
        
        public static string String_Multiply(string S1, string S2)
        {
            string StrL1 = "", StrR1 = "", StrL2 = "", StrR2 = "";
            string Mult1 = "";
            string Mult2 = "";
            string Res = "";
            string Res_Str = "";
            string Ans = "";

            if (S1.Length > S2.Length)
            {
                string Str_Temp = S1;
                S1 = S2;
                S2 = Str_Temp;
            }

            // Make S1(digits) = S2(digits)
            int Num1 = S1.Length;
            int Num2 = S2.Length;
            while (Num2 > Num1){
                S1 = "0" + S1;
                Num1++;
            }
            // BaseCase
            if (Num1 == 1)
            {
                // If the length of strings is 1,then return their product
                Res_Str = Convert.ToString(Convert.ToInt32(S1) * Convert.ToInt32(S2));
                return Res_Str;
            }
            // if length is odd add zeros in the start of the strings 
            if (Num1 % 2 == 1)
            {
                S1 = "0" + S1;
                S2 = "0" + S2;
                Num1++;
            }

            // Calc StrL1, StrL2, StrR1, StrR2
            for (int i = 0; i < Num1 / 2; ++i)
            {
                StrR1 += S1[Num1 / 2 + i];
                StrL1 += S1[i];
                StrR2 += S2[Num1 / 2 + i];
                StrL2 += S2[i];
            }
            Mult1 = String_Multiply(StrL1, StrL2);
            Mult2 = String_Multiply(StrR1, StrR2);

            string Arg1 = String_Multiply(Sum_Str(StrL1, StrR1), Sum_Str(StrL2, StrR2));
            Res = Difference_Nums(Arg1, Sum_Str(Mult1, Mult2));

            for (int i = 0; i < Num1; ++i)
                Mult1 = Mult1 + "0";
            for (int i = 0; i < Num1 / 2; ++i)
                Res = Res + "0";
            Ans = Sum_Str(Mult1, Sum_Str(Mult2, Res));
            Ans = Remove_First_Zeros(Ans);
            return Ans;
        }

        static public byte[] IntegerMultiply(byte[] X, byte[] Y, int N)
        {
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();
            int[] Xi = Array.ConvertAll(X, c => (int)c);
            int[] Yi = Array.ConvertAll(Y, c => (int)c);
            Array.Reverse(Xi);
            Array.Reverse(Yi);
            string S = string.Join("", Xi);
            string H = string.Join("", Yi);
            string answer = String_Multiply(S, H);
            int pad = (N * 2) - (answer.Length);
            if (pad > 0)
                answer = answer.PadLeft(N*2, '0');
            char[] fResult = answer.ToCharArray();
            int[] Aint = Array.ConvertAll(fResult, c => (int)Char.GetNumericValue(c));
            byte[] result = Aint.Select(i => (byte) i).ToArray();
            result = result.Reverse().ToArray();
            return result;
        }

        // Remove_First_Zeros from a string
        public static string Remove_First_Zeros(string S)
        {
            int Len = S.Length;
            int i = 0;
            string S_Res = "";
            while (i < Len && S[i] == '0') i++;
            if (i == S.Length)
                return "0";
            else
            {
                S_Res = S.Substring(i);
                return S_Res;
            }
        }

        // Find difference of larger nums
        static string Difference_Nums(string S1, string S2)
        {
            string S = "";
            int carry = 0;
            int L1 = S1.Length;
            int L2 = S2.Length;
            S1 = new string(S1.Reverse().ToArray());
            S2 = new string(S2.Reverse().ToArray());

            for (int i = 0; i < L2; i++)
            {
                int Diff_Res = ((S1[i] - '0') - (S2[i] - '0')) - carry;
                // if Diff_Res < 0 add 10 and carry = 1
                if (Diff_Res < 0)
                {
                    Diff_Res = Diff_Res + 10;
                    carry = 1;
                }
                else carry = 0;

                S += Diff_Res;
            }
            for (int i = L2; i < L1; i++)
            {
                int Diff_Res = (S1[i] - '0') - carry;
                // if Diff_Res < 0 add 10 and carry = 1
                if (Diff_Res < 0)
                {
                    Diff_Res = Diff_Res + 10;
                    carry = 1;
                }
                else carry = 0;

                S += Diff_Res;
            }
            string Res_Str = new string(S.Reverse().ToArray());
            return Res_Str;
        }

        //Sum two Strings Numbers
        public static string Sum_Str(string S1, string S2)
        {
            string Res_Str = "";
            int C = 0;
            int Sum = 0;
            String Final_Res = "";

            if (S1.Length > S2.Length)
            {
                string Str_Temp = S1;
                S1 = S2;
                S2 = Str_Temp;
            }
            int Num1 = S1.Length;
            int Num2 = S2.Length;
            S1 = new string(S1.Reverse().ToArray());
            S2 = new string(S2.Reverse().ToArray());
            for (int i = 0; i < Num1; i++)
            {
                Sum = (S1[i] - '0') + (S2[i] - '0') + C;
                Res_Str += (char)(Sum % 10 + '0');
                C = Sum / 10;
            }
            for (int i = Num1; i < Num2; i++)
            {
                Sum = (S2[i] - '0') + C;
                Res_Str += (char)(Sum % 10 + '0');
                C = Sum / 10;
            }
            if (C != 0) Res_Str = Res_Str + (char)(C + '0');

            Final_Res = new string(Res_Str.Reverse().ToArray());
            return Final_Res;
        }

        #endregion
    }
}
