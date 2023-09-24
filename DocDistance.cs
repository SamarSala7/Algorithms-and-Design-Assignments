using System;
using System.Collections.Generic;
//using System.IO;
using System.Text.RegularExpressions;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;


namespace DocumentDistance
{
    class DocDistance
    {
        // *****************************************
        // DON'T CHANGE CLASS OR FUNCTION NAME
        // YOU CAN ADD FUNCTIONS IF YOU NEED TO
        // *****************************************
        /// <summary>
        /// Write an efficient algorithm to calculate the distance between two documents
        /// </summary>
        /// <param name="doc1FilePath">File path of 1st document</param>
        /// <param name="doc2FilePath">File path of 2nd document</param>
        /// <returns>The angle (in degree) between the 2 documents</returns>

        public static double CalculateDistance(string doc1FilePath, string doc2FilePath)
        {
            // TODO comment the following line THEN fill your code here
            //throw new NotImplementedException();

            //Inti dictionary
            Dictionary<string, long> Distance1, Distance2;

            //Inti Strings
            string D1, D2;

            //Read the data
            D1= System.IO.File.ReadAllText(doc1FilePath).ToLower();
            D2 = System.IO.File.ReadAllText(doc2FilePath).ToLower();

            //Preprocess files
            Distance1 = File(D1);
            Distance2 = File(D2);

            //Inti varibles
            double inprod1, inprod2, inprod3, Dist;

            //Calc the innerproduct for 1,2 and 1,1 and 2,2
            inprod1 = Product(Distance1, Distance2);
            inprod2 = Product(Distance1, Distance1);
            inprod3 = Product(Distance2, Distance2);

            //calc the distance
            Dist = (Math.Acos(inprod1 / Math.Sqrt(inprod2 * inprod3))) * (180 / (Math.PI));

            //Return the result
            return Dist;

        }
        public static double Product(Dictionary<string, long> D1, Dictionary<string, long> D2)
        {
            double S = 0;
            //string K;
            //Loop on the keys
            foreach (string K in D1.Keys)
            {
                //check if d2 cont in  k
                if (D2.ContainsKey(K))
                    S = S + ((D1[K]) * (D2[K]));
            }
            return S;
        }

        public static Dictionary<string, long> File(string D)
        {
            //Inti var

            //regex is text cleaning library
            Regex R = new Regex("[^A-Za-z0-9]", RegexOptions.Compiled);
            string Res = R.Replace(D, " ");
            string[] W = Res.Split(' ');
            Dictionary<string, long> Word_Count;
            Word_Count = new Dictionary<string, long>();
            
            //Foreach loops in W
            foreach (string Word in W)
            {
                //check if word count cont
                if (Word_Count.ContainsKey(Word))
                    Word_Count[Word] = Word_Count[Word] + 1;

                //else
                //{
                //    Word_Count.Add(Word, 1);
                //}
                else if (!Word.Equals(""))
                    Word_Count.Add(Word, 1);
            }

            //Return word count
            return Word_Count;
        }

    }
}
