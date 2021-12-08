using System;
using System.Collections.Generic;

namespace Advent2021.Utilities
{
    public struct BingoCard
    {
        BingoSquare[] RowOne;
        BingoSquare[] RowTwo;
        BingoSquare[] RowThree;
        BingoSquare[] RowFour;
        BingoSquare[] RowFive;

        public bool IsWinner;

        public BingoCard(string[] rowOne, string[] rowTwo, string[] rowThree, string[] rowFour, string[] rowFive)
        {
            IsWinner = false;

            RowOne = new BingoSquare[5];
            RowTwo = new BingoSquare[5];
            RowThree = new BingoSquare[5];
            RowFour = new BingoSquare[5];
            RowFive = new BingoSquare[5];

            for (var i = 0; i < 5; i++)
            {
                var currentNumber = Int32.Parse(rowOne[i].ToString());
                RowOne[i] = new BingoSquare(currentNumber);
            }

            for (var i = 0; i < 5; i++)
            {
                var currentNumber = Int32.Parse(rowTwo[i].ToString());
                RowTwo[i] = new BingoSquare(currentNumber);
            }

            for (var i = 0; i < 5; i++)
            {
                var currentNumber = Int32.Parse(rowThree[i].ToString());
                RowThree[i] = new BingoSquare(currentNumber);
            }

            for (var i = 0; i < 5; i++)
            {
                var currentNumber = Int32.Parse(rowFour[i].ToString());
                RowFour[i] = new BingoSquare(currentNumber);
            }

            for (var i = 0; i < 5; i++)
            {
                var currentNumber = Int32.Parse(rowFive[i].ToString());
                RowFive[i] = new BingoSquare(currentNumber);
            }
        }

        public void SetIsWinner()
        {
            IsWinner = true;
        }
        
        public bool CheckCardForWinner()
        {
            var checkHorizontals = CheckHorizontals();
            var checkVerticals = CheckVerticals();

            return checkHorizontals || checkVerticals;
        }

        public void CheckNumber(int number)
        {
            for(var i = 0; i < RowOne.Length; i++)
            {
                if (RowOne[i].squareNumber == number)
                {
                    RowOne[i].isChecked = true;
                }
            }

            for (var i = 0; i < RowOne.Length; i++)
            {
                if (RowTwo[i].squareNumber == number)
                {
                    RowTwo[i].isChecked = true;
                }
            }

            for (var i = 0; i < RowOne.Length; i++)
            {
                if (RowThree[i].squareNumber == number)
                {
                    RowThree[i].isChecked = true;
                }
            }

            for (var i = 0; i < RowOne.Length; i++)
            {
                if (RowFour[i].squareNumber == number)
                {
                    RowFour[i].isChecked = true;
                }
            }

            for (var i = 0; i < RowOne.Length; i++)
            {
                if (RowFive[i].squareNumber == number)
                {
                    RowFive[i].isChecked = true;
                }
            }
        }

        private bool CheckVerticals()
        {
            for(var i = 0; i < 5; i++)
            {
                var winner = true;

                if (!RowOne[i].isChecked)
                {
                    winner = false;
                }

                if(!RowTwo[i].isChecked)
                {
                    winner = false;
                }

                if (!RowThree[i].isChecked)
                {
                    winner = false;
                }

                if (!RowFour[i].isChecked)
                {
                    winner = false;
                }

                if (!RowFive[i].isChecked)
                {
                    winner = false;
                }

                if(winner)
                {
                    return winner;
                }
            }

            return false;
        }

        private bool CheckHorizontals()
        {
            var rowOneWins = true;
            var rowTwoWins = true;
            var rowThreeWins = true;
            var rowFourWins = true;
            var rowFiveWins = true;

            foreach(var box in RowOne)
            {
                if(!box.isChecked)
                {
                    rowOneWins = false;
                }
            }

            foreach (var box in RowTwo)
            {
                if (!box.isChecked)
                {
                    rowTwoWins = false;
                }
            }

            foreach (var box in RowThree)
            {
                if (!box.isChecked)
                {
                    rowThreeWins = false;
                }
            }

            foreach (var box in RowFour)
            {
                if (!box.isChecked)
                {
                    rowFourWins = false;
                }
            }

            foreach (var box in RowFive)
            {
                if (!box.isChecked)
                {
                    rowFiveWins = false;
                }
            }

            return rowOneWins || rowTwoWins || rowThreeWins || rowFourWins || rowFiveWins;
        }

        public int GetBoardScore()
        {
            var uncheckedBoxes = new List<BingoSquare>();

            foreach(var box in RowOne)
            {
                if(!box.isChecked)
                {
                    uncheckedBoxes.Add(box);
                }
            }

            foreach (var box in RowTwo)
            {
                if (!box.isChecked)
                {
                    uncheckedBoxes.Add(box);
                }
            }

            foreach (var box in RowThree)
            {
                if (!box.isChecked)
                {
                    uncheckedBoxes.Add(box);
                }
            }

            foreach (var box in RowFour)
            {
                if (!box.isChecked)
                {
                    uncheckedBoxes.Add(box);
                }
            }

            foreach (var box in RowFive)
            {
                if (!box.isChecked)
                {
                    uncheckedBoxes.Add(box);
                }
            }

            var sum = 0;

            uncheckedBoxes.ForEach(x => sum += x.squareNumber);

            return sum;
        }
    }
}
