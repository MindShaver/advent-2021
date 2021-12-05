using Advent2021.Interfaces;
using Advent2021.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2021.Solvers.DayTwo
{
    public class DayTwoSolver : ISolver
    {
        private InputReader _inputReader;
        private Format _formatter;
        private string inputPath = "Solvers/DayTwo/dayTwoInput.txt";
        private IEnumerable<string> _input;

        private int _horizontalPosition;
        private int _depth;
        private int _aim;

        public DayTwoSolver(InputReader fileReader, Format formatter)
        {
            _inputReader = fileReader;
            _formatter = formatter;
        }

        public void InitializeData()
        {
            _input = _inputReader.ReadLine(inputPath);
            _horizontalPosition = 0;
            _depth = 0;
            _aim = 0;
        }

        public void SolveDayOne()
        {
            var parsedInput = _input.ToArray();

            foreach(var reading in parsedInput)
            {
                var splitReading = reading.Split(' ');
                var direction = splitReading[0];
                var distance = Int32.Parse(splitReading[1]);

                ProcessCommand(direction, distance);
            }

            var result = _horizontalPosition * _depth;

            _formatter.Header($"The solution for Day 2 Part 1 is {result}");
            Console.ReadKey();
        }

        public void SolveDayTwo()
        {
            var parsedInput = _input.ToArray();

            foreach (var reading in parsedInput)
            {
                var splitReading = reading.Split(' ');
                var direction = splitReading[0];
                var distance = Int32.Parse(splitReading[1]);

                AdvancedProcessCommand(direction, distance);
            }

            var result = _horizontalPosition * _depth;

            _formatter.Header($"The solution for Day 2 Part 1 is {result}");
            Console.ReadKey();
        }

        private void AdvancedProcessCommand(string direction, int distance)
        {
            switch (direction)
            {
                case "forward":
                    {
                        _horizontalPosition += distance;
                        _depth += _aim * distance;
                        break;
                    }
                case "up":
                    {
                        _aim -= distance;
                        break;
                    }
                case "down":
                    {
                        _aim += distance;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        private void ProcessCommand(string direction, int distance)
        {
            switch (direction)
            {
                case "forward":
                    {
                        _horizontalPosition += distance;
                        break;
                    }
                case "up":
                    {
                        _depth -= distance;
                        break;
                    }
                case "down":
                    {
                        _depth += distance;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}
