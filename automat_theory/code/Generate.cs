using System;
using System.Collections.Generic;

namespace WindowsFormsApp1
{
    internal class Generate
    {
        public int[,] grid;
        private static int size = 9; // Size of the grid (9x9 for standard Sudoku)
        private static int subGridSize = 3; // Size of the sub-grid (3x3 for standard Sudoku)
        private Random random;

        public Generate()
        {
            this.grid = new int[size, size];
            this.random = new Random();
        }


        // Generate a complete Sudoku grid
        public void GenerateGrid()
        {
            FillDiagonalBlocks();
            FillRemaining(0, subGridSize);
        }

        public void ClearSud()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (grid[i, j] == 0)
                        grid[i, j] = 12;
                }
            }
        }

        public void GridToZero()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    grid[i, j] = 12;
                }
            }
        }

        // 
        private void FillDiagonalBlocks()
        {
            for (int i = 0; i < size; i += subGridSize)
            {
                FillBlock(i, i);
            }
        }

        // заполяется блок 3 на 3
        private void FillBlock(int row, int col)
        {
            HashSet<int> usedNumbers = new HashSet<int>();
            for (int i = 0; i < subGridSize; i++)
            {
                for (int j = 0; j < subGridSize; j++)
                {
                    int num;
                    do
                    {
                        num = random.Next(1, size + 1);
                    } 
                    while (usedNumbers.Contains(num));

                    usedNumbers.Add(num);
                    grid[row + i, col + j] = num;
                }
            }
        }

        // проверка есть ли значение в окресностях
        private bool IsSafe(int row, int col, int num)
        {
            return !IsInRow(row, num) && !IsInCol(col, num) && !IsInBlock(row - row % subGridSize, col - col % subGridSize, num);
        }

        // проверка вторая
        private bool IsInRow(int row, int num)
        {
            for (int col = 0; col < size; col++)
            {
                if (grid[row, col] == num)
                {
                    return true;
                }
            }
            return false;
        }

        // проверка втрая
        private bool IsInCol(int col, int num)
        {
            for (int row = 0; row < size; row++)
            {
                if (grid[row, col] == num)
                {
                    return true;
                }
            }
            return false;
        }

        // блок
        private bool IsInBlock(int startRow, int startCol, int num)
        {
            for (int i = 0; i < subGridSize; i++)
            {
                for (int j = 0; j < subGridSize; j++)
                {
                    if (grid[startRow + i, startCol + j] == num)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        // 
        private bool FillRemaining(int row, int col)
        {
            if (col >= size && row < size - 1)
            {
                row++;
                col = 0;
            }

            if (row >= size && col >= size)
            {
                return true;
            }

            if (row < subGridSize && col < subGridSize)
            {
                col = subGridSize;
            }
            else if (row < size - subGridSize && col == (row / subGridSize) * subGridSize)
            {
                col += subGridSize;
            }
            else if (row >= size - subGridSize && col == size - subGridSize)
            {
                row++;
                col = 0;
                if (row >= size)
                {
                    return true;
                }
            }

            for (int num = 1; num <= size; num++)
            {
                if (IsSafe(row, col, num))
                {
                    grid[row, col] = num;
                    if (FillRemaining(row, col + 1))
                    {
                        return true;
                    }
                    grid[row, col] = 0;
                }
            }

            return false;
        }

        // 
        public void RemoveCells(int clues)
        {
            int cellsToRemove = size * size - clues;

            while (cellsToRemove > 0)
            {
                int row = random.Next(0, size);
                int col = random.Next(0, size);

                if (grid[row, col] != 0)
                {
                    grid[row, col] = 0;
                    cellsToRemove--;
                }
            }
        }

    }



}