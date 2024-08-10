using Zudoku.Engine;

// Basic example of how to use the Zudoku engine
// library to generate valid sudoku games


Engine eng = new Engine(Level.basic);

string matrix = "";

for (int i = 0; i < 9; i++)
{
    for (int j = 0; j < 9; j++)
    {
        matrix += eng.mat[i, j].ToString() + " ";
    }
    matrix += "\r\n";
}

Console.WriteLine(matrix);
