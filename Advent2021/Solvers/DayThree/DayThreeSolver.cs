using Advent2021.Interfaces;
using Advent2021.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Advent2021.Solvers.DayThree
{
    public class DayThreeSolver : ISolver
    {
        private InputReader _inputReader;
        private Format _formatter;
        private string inputPath = "Solvers/DayThree/dayThreeInput.txt";
        private IEnumerable<string> _input;

        public DayThreeSolver(InputReader fileReader, Format formatter)
        {
            _inputReader = fileReader;
            _formatter = formatter;
        }

        public void InitializeData()
        {
            _input = _inputReader.ReadLine(inputPath);

        }

        public void SolveDayOne()
        {
            var inputArray = _input.ToArray();
            var bitCounter = 0;
            var gammaStringBuilder = new StringBuilder();
            var epsilonStringBuilder = new StringBuilder();

            while(bitCounter < 12)
            {
                var one = 0;
                var zero = 0;

                foreach (var binaryCode in inputArray)
                {
                    var bit = binaryCode[bitCounter];
                    var parsedBit = Char.GetNumericValue(bit);

                    if(parsedBit == 0)
                    {
                        zero++;
                    } else
                    {
                        one++;
                    }
                }

                if(one > zero)
                {
                    gammaStringBuilder.Append("1");
                    epsilonStringBuilder.Append("0");
                } else
                {
                    gammaStringBuilder.Append("0");
                    epsilonStringBuilder.Append("1");
                }

                bitCounter++;
            }

            var gammaRate = Convert.ToInt32(gammaStringBuilder.ToString(), 2).ToString();
            var epsilonRate = Convert.ToInt32(epsilonStringBuilder.ToString(), 2).ToString();

            var result = Int32.Parse(gammaRate) * Int32.Parse(epsilonRate);

            _formatter.Header($"The solution for Day 3 Part 1 is {result}");
            Console.ReadKey();
        }

        public void SolveDayTwo()
        {
            var bitCounter = 0;
            var finalOxygen = "";
            var finalScrubber = "";

            var oxygenPossibilities = _input.ToArray();
            var scrubberPossibilities = _input.ToArray();

            while (bitCounter < 12)
            {
                if(!String.IsNullOrEmpty(finalOxygen) && !String.IsNullOrEmpty(finalScrubber))
                {
                    break;
                }

                if (String.IsNullOrEmpty(finalOxygen))
                {
                    oxygenPossibilities = GetOxygenGeneratorRating(oxygenPossibilities, bitCounter).ToArray();

                    if(oxygenPossibilities.Count() == 1)
                    {
                        finalOxygen = oxygenPossibilities.FirstOrDefault();
                    }
                }

                if(String.IsNullOrEmpty(finalScrubber))
                {
                    scrubberPossibilities = GetC02ScrubberRating(scrubberPossibilities, bitCounter).ToArray();

                    if(scrubberPossibilities.Count() == 1)
                    {
                        finalScrubber = scrubberPossibilities.FirstOrDefault();
                    }
                }

                bitCounter++;
            }

            var decimalOxygen = Convert.ToInt32(finalOxygen, 2);
            var decimalScrubber = Convert.ToInt32(finalScrubber, 2);

            _formatter.Header($"The solution for Day 3 Part 2 is {decimalOxygen * decimalScrubber}");
            Console.ReadKey();
        }

        private IEnumerable<string> GetC02ScrubberRating(IEnumerable<string> diagnostics, int bitCounter)
        {
            var ones = 0;
            var zeroes = 0;
            var remaningValues = new List<string>();

            foreach (var binaryCode in diagnostics)
            {
                var bit = binaryCode[bitCounter];
                var parsedBit = Char.GetNumericValue(bit);

                if (parsedBit == 0)
                {
                    zeroes++;
                }
                else
                {
                    ones++;
                }
            }

            if (ones == zeroes)
            {
                remaningValues.AddRange(diagnostics.Where(x => x[bitCounter] == '0'));
            }
            else if (ones > zeroes)
            {
                remaningValues.AddRange(diagnostics.Where(x => x[bitCounter] == '0'));
            }
            else
            {
                remaningValues.AddRange(diagnostics.Where(x => x[bitCounter] == '1'));
            }

            return remaningValues;
        }

        private IEnumerable<string> GetOxygenGeneratorRating(IEnumerable<string> diagnostics, int bitCounter)
        {
            var ones = 0;
            var zeroes = 0;
            var remaningValues = new List<string>();

            foreach (var binaryCode in diagnostics)
            {
                var bit = binaryCode[bitCounter];
                var parsedBit = Char.GetNumericValue(bit);

                if (parsedBit == 0)
                {
                    zeroes++;
                }
                else
                {
                    ones++;
                }
            }

            if (ones == zeroes)
            {
                remaningValues.AddRange(diagnostics.Where(x => x[bitCounter] == '1'));
            }
            else if (ones > zeroes)
            {
                remaningValues.AddRange(diagnostics.Where(x => x[bitCounter] == '1'));
            }
            else
            {
                remaningValues.AddRange(diagnostics.Where(x => x[bitCounter] == '0'));
            }

            return remaningValues;
        }
    }
}
