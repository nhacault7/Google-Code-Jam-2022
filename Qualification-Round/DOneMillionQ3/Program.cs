using System;
using System.Text;
using System.Collections.Generic;

namespace DOneMillionQ3
{
    class Program
    {
        static void Main(string[] args)
        {
            int T = ReadInt();
            StringBuilder output = new StringBuilder();

            for (int i = 0; i < T; i++)
            {
                int numberOfDice = ReadInt();
                int[] diceFaceCounts = ReadIntCollection();

                OccuranceSort(diceFaceCounts);
                int straightCount = CalculateStraight(diceFaceCounts, numberOfDice);

                output.AppendLine($"Case #{i + 1}: {straightCount}");
            }

            PrintResult(output.ToString());
        }

        static int CalculateStraight(int[] arr, int numberOfDice)
        {

            int index = 0;
            int difference = 1;
            List<int> checkList = new List<int>();

            do
            {
                if (index == 0)
                {
                    checkList.Add(index + 1);
                }
                else
                {
                    if (arr[index] > checkList[checkList.Count - 1])
                    {
                        checkList.Add(index + difference);
                    }
                    else
                    {
                        difference--;
                    }
                }
                index++;
            } while (index != arr.Length);
            return checkList.Count;
        }

        public static void OccuranceSort(int[] arr)
        {
            int r = 1000001;

            int[] freq = new int[r];

            foreach (int i in arr)
            {
                freq[i]++;
            }

            int k = 0;
            for (int i = 0; i < r; i++)
            {
                while (freq[i]-- > 0)
                {
                    arr[k++] = i;
                }
            }
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