using System;
using CodingCampusCSharpHomework;

namespace HomeworkTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<Task4, char[,]> TaskSolver = task =>
             {
                // Your solution goes here
                // You can get all needed inputs from task.[Property]
                // Good luck!
                char[,] board = task.Board;

                 uint height = (uint)board.GetLength(0);
                 uint width = (uint)board.GetLength(1);

                 char[,] result = new Char[height, width];

                 for (uint i = 0; i < height; i++)
                 {
                     for (uint j = 0; j < width; j++)
                     {
                         uint leftEdge;
                         uint rightEdge;
                         uint topEdge;
                         uint bottomEdge;
                         uint numberOfAlives = 0;
                         if (j == 0)
                         {
                             leftEdge = 0;
                         }
                         else
                         {
                             leftEdge = j - 1;
                         }

                         if (j == width - 1)
                         {
                             rightEdge = j;
                         }
                         else
                         {
                             rightEdge = j + 1;
                         }

                         if (i == 0)
                         {
                             topEdge = 0;
                         }
                         else
                         {
                             topEdge = i - 1;
                         }

                         if (i == height - 1)
                         {
                             bottomEdge = i;
                         }
                         else
                         {
                             bottomEdge = i + 1;
                         }

                         for (uint k = leftEdge; k <= rightEdge; k++)
                         {
                             for (uint p = topEdge; p <= bottomEdge; p++)
                             {
                                 if (k == j && p == i)
                                 {
                                     continue;
                                 }

                                 if (board[p, k] == '1')
                                 {
                                     numberOfAlives++;
                                 }
                             }
                         }
                         if (numberOfAlives < 2)
                         {
                             result[i, j] = '0';
                         }
                         else if ((numberOfAlives == 2 || numberOfAlives == 3) && board[i, j] == '1')
                         {
                             result[i, j] = '1';
                         }
                         else if (numberOfAlives == 3 && board[i, j] == '0')
                         {
                             result[i, j] = '1';
                         }
                         else if (numberOfAlives > 3 && board[i, j] == '1')
                         {
                             result[i, j] = '0';
                         }
                         else
                         {
                             result[i, j] = '0';
                         }
                     }
                 }

                 return result;
             };

            Task4.CheckSolver(TaskSolver);
        }
    }
}
