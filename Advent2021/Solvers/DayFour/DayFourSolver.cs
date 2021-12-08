using Advent2021.Interfaces;
using Advent2021.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Advent2021.Solvers.DayFour
{
    public class DayFourSolver : ISolver
    {
        private InputReader _inputReader;
        private Format _formatter;
        private string inputPath = "Solvers/DayFour/dayFourInput.txt";
        private IEnumerable<string> _input;

        public DayFourSolver(InputReader reader, Format formatter)
        {
            _inputReader = reader;
            _formatter = formatter;
        }

        public void InitializeData()
        {
            _input = _inputReader.ReadLine(inputPath);
        }

        public void SolveDayOne()
        {
            var inputArray = _input.ToArray();

            var bingoNumbers = inputArray[0].Split(',').Select(x => int.Parse(x)).ToArray();

            var bingoCards = new List<BingoCard>();

            for(var i = 2; i < inputArray.Length; i += 6)
            {
                var rowOne = inputArray[i].Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                var rowTwo = inputArray[i + 1].Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                var rowThree = inputArray[i + 2].Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                var rowFour = inputArray[i + 3].Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                var rowFive = inputArray[i + 4].Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();

                bingoCards.Add(new BingoCard(rowOne, rowTwo, rowThree, rowFour, rowFive));
            }

            foreach(var bingoNum in bingoNumbers)
            {
                var winner = false;
                foreach(var bingoCard in bingoCards)
                {
                    bingoCard.CheckNumber(bingoNum);

                    if(bingoCard.CheckCardForWinner())
                    {
                        var cardScore = bingoCard.GetBoardScore();
                        var result = cardScore * bingoNum;

                        _formatter.Header($"The solution for Day 4 Part 1 is {result}");
                        Console.ReadKey();

                        winner = true;

                        break;
                    }
                }

                if(winner)
                {
                    break;
                }
            }

        }

        public void SolveDayTwo()
        {
            var inputArray = _input.ToArray();

            var bingoNumbers = inputArray[0].Split(',').Select(x => int.Parse(x)).ToArray();

            var bingoCards = new List<BingoCard>();

            for (var i = 2; i < inputArray.Length; i += 6)
            {
                var rowOne = inputArray[i].Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                var rowTwo = inputArray[i + 1].Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                var rowThree = inputArray[i + 2].Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                var rowFour = inputArray[i + 3].Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();
                var rowFive = inputArray[i + 4].Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToArray();

                bingoCards.Add(new BingoCard(rowOne, rowTwo, rowThree, rowFour, rowFive));
            }

            var remainingBoards = bingoCards.ToList();

            foreach (var bingoNum in bingoNumbers)
            {
                foreach (var bingoCard in remainingBoards)
                {
                    bingoCard.CheckNumber(bingoNum);
                }

                if(remainingBoards.Count() > 1)
                {
                    var tempList = remainingBoards.Where(x => !x.CheckCardForWinner()).ToList();

                    remainingBoards = new List<BingoCard>();
                    remainingBoards.AddRange(tempList);
                }
                else
                {
                    var currentCard = remainingBoards.FirstOrDefault();

                    if(currentCard.CheckCardForWinner())
                    {
                        var cardScore = remainingBoards.FirstOrDefault().GetBoardScore();
                        var result = cardScore * bingoNum;

                        _formatter.Header($"The solution for Day 4 Part 2 is {result}");
                        Console.ReadKey();

                        break;
                    }
                }
            }
        }
    }
}
