using System;
using System.Text;
using System.Collections.Generic;

namespace ThreeDimensionalPrintingQ2
{
    class Program
    {
        const int UNITS_FOR_LETTER = 1000000;

        static void Main(string[] args)
        {
            int T = ReadInt();
            StringBuilder output = new StringBuilder();

            for (int testSet = 0; testSet < T; testSet++)
            {
                int[] printerOne = ReadIntCollection();
                int[] printerTwo = ReadIntCollection();
                int[] printerThree = ReadIntCollection();

                int[][] allPrinters = new int[][]
                {
                    printerOne,
                    printerTwo,
                    printerThree
                };

                int[] lowestSharedUnitValues = getLowestSharedUnitValues(allPrinters);

                int lowestSharedValuesSum = CalculateSum(lowestSharedUnitValues);

                if (lowestSharedValuesSum >= UNITS_FOR_LETTER)
                {
                    if (lowestSharedValuesSum != UNITS_FOR_LETTER)
                    {
                        int index = 0;
                        int difference = lowestSharedValuesSum - UNITS_FOR_LETTER;
                        do
                        {
                            lowestSharedUnitValues[index] -= difference;
                            difference = 0;
                            if (lowestSharedUnitValues[index] < 0)
                            {
                                difference = -1 * lowestSharedUnitValues[index];
                                lowestSharedUnitValues[index] = 0;
                            }

                            index++;
                        } while (difference > 0);
                    }

                    output.Append($"Case #{testSet + 1}: ");
                    for (int i = 0; i < lowestSharedUnitValues.Length; i++)
                    {
                        if (i != 3) 
                        {
                            output.Append($"{lowestSharedUnitValues[i]} ");
                        }
                        else
                        {
                            output.AppendLine($"{lowestSharedUnitValues[i]}");
                        }
                    }
                }
                else
                {
                    output.AppendLine($"Case #{testSet + 1}: IMPOSSIBLE");
                }
            }

            PrintResult(output.ToString());
        }

        static int[] getLowestSharedUnitValues(int[][] allPrinters)
        {
            int[] lowestSharedUnitValues = new int[4];

            for (int i = 0; i < 4; i++)
            {
                int lowestUnitValue = int.MaxValue;
                for (int j = 0; j < allPrinters.Length; j++)
                {
                    if (allPrinters[j][i] < lowestUnitValue)
                    {
                        lowestUnitValue = allPrinters[j][i];
                    }
                }
                lowestSharedUnitValues[i] = lowestUnitValue;
            }

            return lowestSharedUnitValues;
        }

        static int CalculateSum(int[] arr)
        {
            int lowestSharedValuesSum = 0;

            foreach (int i in arr)
            {
                lowestSharedValuesSum += i;
            }

            return lowestSharedValuesSum;
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