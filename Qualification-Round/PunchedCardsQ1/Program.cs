using System;
using System.Text;
using System.Collections.Generic;

namespace PunchedCardsQ1
{
    /* Input:
     *      T = Number of test cases
     *      R = Number of rows
     *      C = Number of columns
     *     
     * Note:
     *      The Matrix is (R * C) - 1 cells in total
     *      
     * For example, the following is a punched card with R=3 rows and C=4 columns:
     *
     *      ..+-+-+-+
     *      ..|.|.|.|
     *      +-+-+-+-+
     *      |.|.|.|.|
     *      +-+-+-+-+
     *      |.|.|.|.|
     *      +-+-+-+-+
     *      
     * Sample Input:
     * 
     *      3
     *      3 4
     *      2 2
     *      2 3
     */
    class Program
    {
        static void Main(string[] args)
        {
            int T = ReadInt();
            string output = string.Empty;

            for (int i = 0; i < T; i++)
            {
                int[] cardDimensions = ReadIntCollection();
                int R = cardDimensions[0];
                int C = cardDimensions[1];

                List<string> ascii = new List<string>();

                string initialString = BuildBreakLine(C, true);
                ascii.Add(initialString);

                for (int j = 0; j < R; j++)
                {
                    ascii.Add(BuildRowLine(C, j));
                    ascii.Add(BuildBreakLine(C, false));
                }

                output += BuildOutput(ascii, i);
            }

            PrintResult(output);
        }

        static string BuildBreakLine(int R, bool IsInitial)
        {
            StringBuilder builder = new StringBuilder();

            if (IsInitial == true)
            {
                builder.Append("..");
            }
            else
            {
                builder.Append("+-");
            }

            for (int i = 1; i < R; i++)
            {
                builder.Append("+-");
            }

            builder.Append("+");

            return builder.ToString();
        }

        static string BuildRowLine(int C, int rowNumber)
        {
            StringBuilder builder = new StringBuilder();

            if (rowNumber == 0)
            {
                builder.Append("..");
            }
            else
            {
                builder.Append("|.");
            }
            

            for (int i = 1; i < C; i++)
            {
                builder.Append("|.");
            }

            builder.Append("|");

            return builder.ToString();
        }

        static string BuildOutput(List<string> ascii, int caseNumber)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"Case #{caseNumber + 1}:");
            
            foreach(string line in ascii)
            {
                builder.AppendLine(line);
            }
            
            return builder.ToString();
        }

        static int ReadInt()
        {
            return Convert.ToInt32(Console.ReadLine().Trim());
        }

        static int[] ReadIntCollection()
        {
            string[] input = Console.ReadLine().Trim().Split(' ');
            int[] output = new int[input.Length];

            for (int i = 0; i < input.Length; i++)
            {
                output[i] = Convert.ToInt32(input[i]);
            }

            return output;
        }

        static void PrintResult(string output)
        {
            string trimmedOutput = output.Trim();

            Console.Write(trimmedOutput);
        }
    }
}