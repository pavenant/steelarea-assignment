using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CodifyTests
{
    public class SteelSheetCalc
    {
        public string EvaluateSteelArea(int t, int n, int[] input)
        {
            string returnMsg = "";
            int[,] grid = GetGrid(input);

            Dictionary<int, int> scoresAreas = new Dictionary<int, int>();
            
            //i cannot remmeber what the asked here but I assume,
            //from index position t test n items and return grid positions and their strength in decending order?

            for (int i = t; i < (t + n); i++)
            {
                var points = GetPointsFromIndex(i, grid);
                var score1 = GetScore(points.x, points.y, grid);
                if (!scoresAreas.ContainsKey(score1)) //we want only the first occurance of a score
                {
                    scoresAreas.Add(score1, i);
                }
            }

            foreach (var item in scoresAreas.OrderByDescending(key => key.Key))
            {
                var points = GetPointsFromIndex(item.Value, grid);
                returnMsg += string.Concat("(", points.x, ",", points.y, ",", item.Key, ")");
            }
            return returnMsg;
           
        }

        public (int x,int y) GetPointsFromIndex(int index, int[,] grd)
        {
            var length = (int)Math.Sqrt(grd.Length);
            int row = (index / length);
            int col = index - (row * length);
            return (row,col);
        }

        public int GetScore(int row, int col, int[,] input)
        {
            var length = (int)Math.Sqrt( input.Length);
            int score = 0;

            for (int rowOffset = -1; rowOffset <= 1; rowOffset++)
            {
                for (int colOffset = -1; colOffset <= 1; colOffset++)
                {
                    int calcRow = rowOffset + row;
                    int calcCol = colOffset + col;
                    if ((calcRow >= 0 && calcCol >= 0 ) && (calcRow < length && calcCol < length))
                    {
                        score += input[calcRow, calcCol];
                    }
                }
            }
            return score;
        }

        public static int[,] GetGrid(int[] input)
        {
            int gridRowLength = (int)Math.Sqrt(input.Length);
            int[,] grid = new int[gridRowLength, gridRowLength];
            int rowNumber = 0;
            int colNumber = 0;
            int prevRow = 0;

            for (int i = 0; i < input.Length; i++)
            {
                var row = (i / gridRowLength);

                if (prevRow != row)
                {
                    colNumber = 0;
                    rowNumber += 1;
                }

                grid[rowNumber, colNumber] = input[i];

                colNumber += 1;
                prevRow = row;
            }
            return grid;
        }
    }
}
