using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AoC2023
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputFile = File.ReadAllLines(@"D:\Code\Git\AoC2023\AoC2023\InputFiles\Day1_0_Input.txt");
            List<Int32> calibration_values = new List<Int32>();
            int Sum1 = 0, Sum2 = 0, n = 0;
            var allDigits = new Dictionary<string, int>()
            {
                { "one", 1 },
                { "two", 2 },
                { "three", 3 },
                { "four", 4 },
                { "five", 5 },
                { "six", 6 },
                { "seven", 7 },
                { "eight", 8 },
                { "nine", 9 },
            };

            for (int i = 1; i < 10; i++)
            {
                allDigits.Add(i.ToString(), i);
            }

            foreach (string isNumber in inputFile)
            {
                for (int i = 0; i < isNumber.Length; i++)
                {
                    if (int.TryParse(isNumber.ElementAt(i).ToString(), out n))
                    {
                        calibration_values.Add(n);
                    }
                }

                if (calibration_values.Count > 1)
                    Sum1 += Convert.ToInt32(calibration_values.First().ToString() + calibration_values.Last().ToString());
                else
                    Sum1 += Convert.ToInt32(calibration_values.First().ToString() + calibration_values.First().ToString());

                calibration_values.Clear();
            }

            Console.WriteLine("Sum part 1:" + Sum1.ToString());

            foreach (string isNumber in inputFile)
            {
            var firstIndex = isNumber.Length;
            var lastIndex = -1;
            var firstValue = 0;
            var lastValue = 0;

            foreach (var digit in allDigits)
            {
                var index = isNumber.IndexOf(digit.Key);
                if (index == -1)
                {
                    continue;
                }

                if (index < firstIndex)
                {
                    firstIndex = index;
                    firstValue = digit.Value;
                }

                index = isNumber.LastIndexOf(digit.Key);

                if (index > lastIndex)
                {
                    lastIndex = index;
                    lastValue = digit.Value;
                }
            }

            var fullNumber = firstValue * 10 + lastValue;
                Sum2 += fullNumber;
            }

            Console.WriteLine("Sum part 1:" + Sum2.ToString());

            Console.ReadKey();
        }
    }
}
