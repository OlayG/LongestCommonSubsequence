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
        static string[] Sequences = new string[2];
        static void Main(string[] args)
        {
            Sequences = getSequences();
            Console.WriteLine("{0};{1}", Sequences[0], Sequences[1]);

            Console.ReadKey();

        }

        private static string[] getSequences()
        {
            // Declared variables
            bool checkFirst = false, checkSecond = false;
            string firstSequence = null, secondSequence = null;

            //Loop to collect and check if sequence length. Keeps running till sequnce is under 50 characters
            do
            {
                if (!checkFirst)
                {
                    Console.WriteLine("Input your first sequence");
                    firstSequence = Console.ReadLine();
                    checkFirst = CheckStringLength(firstSequence);
                    Sequences[0] = firstSequence;
                }

                if (!checkSecond)
                {
                    Console.WriteLine("Input your second sequence");
                    secondSequence = Console.ReadLine();
                    checkSecond = CheckStringLength(secondSequence);
                    Sequences[1] = secondSequence;
                }

            } while (!checkFirst && !checkSecond);

            return Sequences;
        }

        // Method to check string length
        private static bool CheckStringLength(string Sequence)
        {
            bool underMax = false;

            // If sequnce of string is over 50 this runs
            if (Sequence.Length > 10)
            {
                Console.WriteLine("Sequnce can't be longer than 50 characters");
                return underMax;
            }
            // If less than 50 this runs
            else
            {
                return underMax = true;
            }
        }

    }
}

