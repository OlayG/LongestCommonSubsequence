﻿using System;
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

            Console.WriteLine("{0};{1}\n", Sequences[0], Sequences[1]);

            LCS(Sequences);
            Console.ReadKey();
        }

        // method to get Longest Common Subsequence
        private static void LCS(string[] sequences)
        {
            char[] firstString = new char[sequences[0].Length];
            char[] secondString = new char[sequences[1].Length];

            firstString = sequences[0].ToArray();
            secondString = Sequences[1].ToArray();

            // Creates a matrix with the using the length of strings as the dimension
            // added one to length since the array must have 1 extra colum and row
            int[,] numArray = new int[firstString.Length + 1, secondString.Length + 1];

            
            // Fills matrix to calculate LCS
            // First string is used as row
            for (int i = 1; i < firstString.Length + 1; i++)
            {
                // Second string is used at column
                for (int j = 1; j < secondString.Length + 1; j++)
                {
                    // If char in both strings are equal this runs
                    if (firstString[i-1] == secondString[j-1])
                    {
                        // Goes to spot in array using the firstString as row and secondString and col
                        // gets the value NW positon to it and adds 1
                        // then assigned value to the spot
                        numArray[i,j] = numArray[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        // If they are not equal, takes value north and west
                        // and assigned the bigger value to the spot
                        numArray[i, j] = Math.Max(numArray[i-1,j],numArray[i,j-1]);
                    }
                }
            }

            // Prints out matrix solution
            for (int i = 0; i < firstString.Length + 1; i++)
            {
                for (int j = 0; j < secondString.Length + 1; j++)
                {
                    Console.Write("{0} ",numArray[i,j]);
                }
                Console.WriteLine();
            }

            int lcsLength = 0;
            // Gets the length of the longest common subsequence
            for (int i = firstString.Length; i >= 0; i--)
            {
                for (int j = secondString.Length; j >= 0; j--)
                {
                    if (firstString[i-1] == secondString[j-1])
                    {
                        lcsLength = numArray[i, j];
                        Console.WriteLine("\nThe LCS is {0}\n", numArray[i, j]);
                        break;
                    }
                }
                break;
            }

            
            char[] lcmString = new char[lcsLength];
            int m = 0;
            // Adds each LCS char into array
            for (int i = firstString.Length; i > 0; i--)
            {
                for (int j = secondString.Length; j > 0; j--)
                {
                    if (firstString[i - 1] == secondString[j - 1] && numArray[i,j] == lcsLength)
                    {
                        lcsLength--;
                        lcmString[m] = firstString[i - 1];
                        m++;
                    }
                }
            }

            // Prints each char in the Longest Common Subsequence
            printLCS(lcmString);
        }

        // Method to print LCS 
        private static void printLCS(char[] lcmString)
        {
            Console.Write("The LCS string is: ");
           for (int i = lcmString.Length-1; i >= 0; i--)
            {
                Console.Write(lcmString[i]);
            }
        }

        // Collects user input
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
            } while (!checkFirst);

            do
            {
                if (!checkSecond)
                {
                    Console.WriteLine("Input your second sequence");
                    secondSequence = Console.ReadLine();
                    checkSecond = CheckStringLength(secondSequence);
                    Sequences[1] = secondSequence;
                }
            } while (!checkSecond);


            return Sequences;
        }

        // Method to check string length
        private static bool CheckStringLength(string Sequence)
        {
            bool underMax = false;

            // If sequnce of string is over 50 this runs
            if (Sequence.Length > 50)
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

