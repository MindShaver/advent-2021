using Advent2021.Interfaces;
using Advent2021.Solvers;
using Advent2021.Utilities;
using System;

namespace Advent2021
{
    class Program
    {
        static void Main(string[] args)
        {
            var format = new Format();
            var validDay = false;
            ISolver solver;
            var fileReader = new InputReader();

            format.Header("Advent of Code 2021", "Please enter the day you want to solve.");

            var day = Console.ReadLine();

            while (!validDay)
            {

                try
                {
                    var parsedDay = Int32.Parse(day);

                    switch(parsedDay)
                    {
                        case 1: {
                                validDay = true;
                                solver = new DayOneSolver(fileReader, format);
                                solver.SolveDayOne();
                                break;
                            }
                        default: {
                                validDay = false;
                                break;
                            }
                    }
                } catch(Exception e)
                {
                    format.CenterText($"Error {e.Message}");
                    format.Header("Advent of Code 2021", "Please enter the day you want to solve.");

                }
            }

        }
    }
}
