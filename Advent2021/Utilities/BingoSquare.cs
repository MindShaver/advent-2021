namespace Advent2021.Utilities
{
    public struct BingoSquare
    {
        public int squareNumber;
        public bool isChecked;

        public BingoSquare(int _squareNumber)
        {
            squareNumber = _squareNumber;
            isChecked = false;
        }
    }
}
