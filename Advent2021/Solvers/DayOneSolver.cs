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
        private string inputPath = "Solvers/dayOneInput.txt";
        private IEnumerable<string> _input;
        private int _previousMeasurement;
        private int _higherMeasurementCount;
        private bool _firstMeasurement;

        public DayOneSolver(InputReader reader, Format formatter)
        {
            _inputReader = reader;
            _formatter = formatter;
            _firstMeasurement = true;
            _higherMeasurementCount = 0;
        }

        public void SolveDayOne()
        {
            _input = _inputReader.ReadLine(inputPath).ToArray();

            foreach (var depth in _input)
            {
                var parsedDepth = Int32.Parse(depth);

                if(_firstMeasurement)
                {
                    _previousMeasurement = parsedDepth;
                    _firstMeasurement = false;
                } else
                {
                    ChartDepth(parsedDepth);
                }
            }

            _formatter.Header("Part One", _formatter.CenterText($"The total number of times Depth increased = {_higherMeasurementCount}"));
            Console.ReadKey();
        }

        public void SolveDayTwo()
        {
            throw new NotImplementedException();
        }

        private void ChartDepth(int depth)
        {
            if(depth > _previousMeasurement)
            {
                _higherMeasurementCount++;
            }

            _previousMeasurement = depth;
        }
    }
}
