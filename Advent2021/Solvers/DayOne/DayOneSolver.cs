using Advent2021.Interfaces;
using Advent2021.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2021.Solvers
{
    public class DayOneSolver : ISolver
    {
        private InputReader _inputReader;
        private Format _formatter;
        private string inputPath = "Solvers/DayOne/dayOneInput.txt";
        private IEnumerable<string> _input;
        private int _previousMeasurement;
        private int _higherMeasurementCount;
        private bool _firstMeasurement;

        public DayOneSolver(InputReader reader, Format formatter)
        {
            _inputReader = reader;
            _formatter = formatter;
        }

        public void SolveDayOne()
        {
            foreach (var depth in _input)
            {
                var parsedDepth = Int32.Parse(depth);

                if (_firstMeasurement)
                {
                    _previousMeasurement = parsedDepth;
                    _firstMeasurement = false;
                }
                else
                {
                    ChartDepth(parsedDepth);
                }
            }

            _formatter.Header("Part One", _formatter.CenterText($"The total number of times Depth increased = {_higherMeasurementCount}"));
            Console.ReadKey();
        }

        public void SolveDayTwo()
        {
            var inputArray = _input.ToArray();

            for (var i = 0; i < inputArray.Length - 2; i++)
            {
                var windowOne = Int32.Parse(inputArray[i]);
                var windowTwo = Int32.Parse(inputArray[i + 1]);
                var windowThree = Int32.Parse(inputArray[i + 2]);

                ChartDepth(windowOne + windowTwo + windowThree);
            };

            _formatter.Header("Part One", _formatter.CenterText($"The total number of times Depth increased = {_higherMeasurementCount}"));
            Console.ReadKey();
        }

        public void InitializeData()
        {
            _input = _inputReader.ReadLine(inputPath);
            _higherMeasurementCount = 0;
            _firstMeasurement = true;
        }

        private void ChartDepth(int depth)
        {
            if (depth > _previousMeasurement)
            {
                _higherMeasurementCount++;
            }

            _previousMeasurement = depth;
        }
    }
}
