/*  ****************************************************************************************
        Héctor Ochoa    
        @herko8a
        herko8a@hotmail.com
    ****************************************************************************************/

namespace Zudoku.Engine;

public enum Level
{
    basic, middle, advanced
}

public class Engine
{
    Random rnd;
    Level level;
    public int[,] zudo;
    public int[,] mat;

    public Engine(Level l)
    {
        rnd = new Random();
        level = l;
        NewGame();
    }

    public void NewGame()
    {
        NewZudoku();
        zudo = mat;

    }

    public void NewZudoku()
    {
        int n = 9;
        int col = 0;
        int posrow = 0;
        int poscol = 0;
        int steps = 0;
        int stepsrow = 0;

        bool finish = false;
        bool unique = false;
        bool repeatedrow = false;
        bool repeatedcol = false;
        bool repeatedmat = false;

        mat = new int[n, n];

        while (!finish)
        {
            steps = 0;

            for (int row = 0; row < n; row++)
            {
                col = 0;

                while (col < n && steps < 80)
                {
                    mat[row, col] = rnd.Next(1, 10);
                    stepsrow = 1;

                    // Validate cell of the generated number
                    if (row > 0 || col > 0)
                    {
                        unique = false;
                        while (!unique && stepsrow < 60)
                        {
                            repeatedrow = false;
                            repeatedcol = false;
                            repeatedmat = false;

                            // Validate that the number does not already exist in the row
                            if (col > 1)
                            {
                                for (int i = 0; i < col; i++)
                                {
                                    if (mat[row, col] == mat[row, i])
                                    {
                                        repeatedrow = true;
                                        break;
                                    }
                                }
                            }

                            // Validate that the number does not already exist in the column
                            if (row >= 1)
                            {
                                for (int k = 0; k < row; k++)
                                {
                                    if (mat[row, col] == mat[k, col])
                                    {
                                        repeatedcol = true;
                                        break;
                                    }
                                }
                            }

                            // Validate that the number does not already exist in the 3x3 matrix
                            if (!repeatedcol && !repeatedrow)
                            {
                                poscol = (col / 3) + 1;
                                posrow = (row / 3) + 1;

                                if (row > (posrow * 3 - 3))
                                {
                                    for (int i = (posrow * 3 - 3); i < row; i++)
                                    {
                                        for (int j = (poscol * 3 - 3); j < (poscol * 3); j++)
                                        {
                                            if (mat[row, col] == mat[i, j])
                                            {
                                                repeatedmat = true;
                                                break;
                                            }
                                        }
                                        if (repeatedmat) break;
                                    }
                                }
                            }

                            // The value is unique in the row, column, and matrix
                            if (!repeatedrow && !repeatedcol && !repeatedmat)
                            {
                                // Meets all the rules
                                unique = true;
                            }
                            else
                            {
                                // Take a new random number and repeat the process
                                mat[row, col] = rnd.Next(1, 10);
                                stepsrow++;
                            }
                        }
                    }

                    if (stepsrow >= 60 && !unique)
                    {
                        col = 1;
                        stepsrow = 0;
                        steps++;
                    }
                    else
                        col++;
                }
            }

            finish = mat[8, 8] == 0 ? false : true;
        }

    }

}
