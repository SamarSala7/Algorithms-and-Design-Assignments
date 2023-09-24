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
    public static class FindExtraElement
    {
        #region YOUR CODE IS HERE
        /// <summary>
        /// Find index of extra element in first array
        /// </summary>
        /// <param name="arr1">first sorted array with an extra element</param>
        /// <param name="arr2">second sorted array</param>
        /// <returns>index of the extra element in arr1</returns>

        //Use Binary Search Algorithm
        public static int FindIndexOfExtraElement(int[] arr1, int[] arr2)
        {
            int n = arr2.Length;
            int Ind = n;
            int R = n - 1;
            int L = 0;
            int Mid; 
            while (L <= R){
                Mid = (L + R) / 2;
                if (arr2[Mid] == arr1[Mid])
                    L = Mid + 1;
                else{
                    Ind = Mid;
                    R = Mid - 1;
                }
            }
            int Result = Ind;
            return Result;
        }
        #endregion
    }
}
