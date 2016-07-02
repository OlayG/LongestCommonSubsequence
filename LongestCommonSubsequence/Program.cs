using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LongestCommonSubsequence
{
    class Program
    {
        //        CHALLENGE DESCRIPTION:

        //You are given two sequences. Write a program to determine the longest common subsequence between the two strings
        //(each string can have a maximum length of 50 characters). NOTE: This subsequence need not be contiguous.The 
        //input file may contain empty lines, these need to be ignored.

        //INPUT SAMPLE:
        //The first argument will be a path to a filename that contains two strings per line, semicolon delimited. 
        //You can assume that there is only one unique subsequence per test case. E.g.

        //XMJYAUZ;MZJAWXU//

        //OUTPUT SAMPLE:
        //The longest common subsequence.Ensure that there are no trailing empty spaces on each line you print. E.g.

        //MJAU//
        static void Main(string[] args)
        {
            bool checkFirst = false, checkSecond = false;
            string firstSequence = null, secondSequence = null;
            do
            {
                if (!checkFirst)
                {
                    Console.WriteLine("Input your first sequence");
                    firstSequence = Console.ReadLine();
                    checkFirst = CheckStringLength(firstSequence);
                }

                if (!checkSecond)
                {
                    Console.WriteLine("Input your second sequence");
                    secondSequence = Console.ReadLine();
                    checkSecond = CheckStringLength(secondSequence);
                }
                
            } while (!checkFirst && !checkSecond);


            Console.WriteLine("{0};{1}",firstSequence , secondSequence);

            Console.ReadKey();

        }

        private static bool CheckStringLength(string Sequence)
        {
            bool underMax = false;
            try
            {
                if (Sequence.Length > 50)
                {
                    throw new Exception();
                }
                else
                {
                    return underMax = true;
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Sequnce can't be longer than 50 characters");
                return underMax; 
            }
            
        }
    }
}
