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
    public static class TextPlagiarism
    {
        #region YOUR CODE IS HERE

        #region FUNCTION#1: Calculate the Value
        //Your Code is Here:
        //==================
        /// <summary>
        /// Given a paragraph and a complete text, find the plagiarism similarity of the give paragraph vs the given text.
        /// Plagiarism similarity = max common subsequence of words between the given paragraph and EACH paragraph in the given text
        /// Comparison is case IN-SENSITIVE (i.e. Cat = CAT = cat = CaT)
        /// Definitions:
        ///     Word: a set of continuous characters seperated by space or tab (Words seperator: ' ' '\t')
        ///     Paragraph in Text: any continuous set of words/chars ended by new line(s) (Paragraphs seperator: '\n' '\r')
        /// </summary>
        /// <param name="paragraph">query paragraph</param>
        /// <param name="text">complete text (consists of 1 or more paragraph(s)</param>
        /// <returns>Plagiarism similarity between the query paragraph and the complete text</returns>
        static public int SolveValue(string paragraph, string text)
        {
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();
            int Result = 0;
            string[] Para = paragraph.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            string[] Text = text.Split(new string[] {"\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
            int L1 = Para.Length;
            int L2 = Text.Length;
            int[] MaxV = new int[L2];
            int MaxV_Len = MaxV.Length;

            for (int X = 0; X < L2; X++){
                string[] Words = Text[X].Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                int Words_Len = Words.Length;
                int[,] Sub_SQ = new int[L1 + 1, Words_Len + 1];

                for (int Y = 1; Y <= L1; Y++){
                    for (int Z = 1; Z <= Words_Len; Z++){
                        if (string.Equals(Para[Y - 1], Words[Z - 1], StringComparison.OrdinalIgnoreCase))
                            Sub_SQ[Y, Z] = Sub_SQ[Y - 1, Z - 1] + 1;
                        else
                            Sub_SQ[Y, Z] = Math.Max(Sub_SQ[Y - 1, Z], Sub_SQ[Y, Z - 1]);
                    }
                }
                MaxV[X] = Sub_SQ[L1, Words_Len];
            }

            for (int i = 0; i < MaxV_Len; i++){
                if (Result <= MaxV[i]) Result = MaxV[i];
            }
            return Result;
        }
        #endregion

        #region FUNCTION#2: Construct the Solution

        //Your Code is Here:
        //==================
        /// <returns>the common subsequence words themselves (if any) or null if no common words </returns>
        static public string[] ConstructSolution(string paragraph, string text)
        {
            //REMOVE THIS LINE BEFORE START CODING
            //throw new NotImplementedException();

            //int Max = 0;

            //Init a dicitonary for the Final Result
            Dictionary<string[], int> Final_Res = new Dictionary<string[], int>();

            //Init strings for the parameters vales
            string[] Parag = paragraph.Split(new char[] { '\t', ' '}, StringSplitOptions.RemoveEmptyEntries);
            string[] Text = text.Split(new string[] {"\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);     
            //Init the length of them
            int L1 = Parag.Length;
            int L2 = Text.Length;

            //Make a for loop to loop on the Text 
            for (int x = 0; x < L2; x++){
                //Init string Words to split the Text
                string[] Words = Text[x].Split(new char[] {'\t', ' '}, StringSplitOptions.RemoveEmptyEntries);
                // Words length
                int WordsLen = Words.Length;
                //Init a SubSeq [L1 + 1, WordsLen + 1]
                int[,] SubSeq = new int[L1 + 1, WordsLen + 1];

                //Loop on the parag
                for (int y = 1; y <= L1; y++){
                    // An inner for loop to loop on WordsLen
                    for (int z = 1; z <= WordsLen; z++){
                        if (string.Equals(Parag[y - 1], Words[z - 1], StringComparison.OrdinalIgnoreCase))
                            //Save in SubSeq 
                            SubSeq[y, z] = SubSeq[y - 1, z - 1] + 1;
                        else
                            //Save in SubSeq
                            SubSeq[y, z] = Math.Max(SubSeq[y - 1, z], SubSeq[y, z - 1]);
                    }
                }
                //Init a small SubSubSeq
                string[] SubSubSeq = new string[SubSeq[L1, WordsLen]];
                //Save SubSubSeq Length
                int SubSubSeqLen = SubSubSeq.Length;
                //Init indices
                int Ind = SubSubSeqLen - 1;
                int Ind1 = L1;
                int Ind2 = WordsLen;

                //Loop if (Ind1 > 0 && Ind2 > 0) and sub the Ind, Ind1, Ind2
                while (Ind1 > 0 && Ind2 > 0){
                    if (SubSeq[Ind1 - 1, Ind2] > SubSeq[Ind1, Ind2 - 1]) Ind1--;
                    else if (string.Equals(Parag[Ind1 - 1], Words[Ind2 - 1], StringComparison.OrdinalIgnoreCase)){
                        SubSubSeq[Ind] = Parag[Ind1 - 1];
                        Ind--;
                        Ind1--;
                        Ind2--;
                    }
                    else Ind2--;
                }
                Final_Res.Add(SubSubSeq, SubSubSeqLen);
            }
            string[] S_Res = Final_Res.FirstOrDefault(x => x.Value == (Final_Res.Values.Max())).Key;
            //Then Return a String Result
            return S_Res;
        }
        #endregion

        #endregion
    }
}
