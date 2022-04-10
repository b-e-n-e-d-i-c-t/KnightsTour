using System;

namespace Knights_Tour
{
    class Program
    {

        static int boardSize = 8;
        static int attemptedMoves = 0;


        //All 8 possible moves the Knight Chess piece can make
        static int[] xMove = { 2, 2, 1, 1, -1, -1, -2, -2 };
        static int[] yMove = { 1, -1, 2, -2, 2, -2, 1, -1 };

        //Creating the board
        static int[,] boardGrid = new int[boardSize, boardSize];
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            solveKT();
        }

        static void solveKT()
        {
            //init all squared not visited
            for (int i = 0; i < boardSize; i++)
            {
                for(int j = 0; j < boardSize; j++)
                {
                    //-1 will indicate a square that has not been visited 
                    boardGrid[i, j] = -1;
                }
            }
            //Pick starting point
            int xStart = 1;
            int yStart = 1;

            boardGrid[xStart, yStart] = 0;
            attemptedMoves = 0;


            //Solve Recursively
            if (!solveKTUtil(xStart, yStart, 1)){
                Console.WriteLine("No solution found for {0} {1}", xStart, yStart);
            }
            else
            {
                printBoard(boardGrid);
                Console.WriteLine("Attempt Number: {0}", attemptedMoves);
            }

            bool solveKTUtil(int x, int y, int movecount)
            {
                attemptedMoves++;
                if(attemptedMoves % 10000000 == 0)
                {
                    Console.WriteLine("Attempted Moves {0}", attemptedMoves);
                }

                //counter for moving through the 8 possible moves
                int k;

                //Performing check to see if game is solved
                int next_x, next_y;
                if(movecount == boardSize * boardSize)
                {
                    return true;
                }

                //Cycle through all of the possible next moves for the knight
                for (k = 0; k < 8; k++)
                {
                    next_x = x + xMove[k];
                    next_y = y + yMove[k];

                    //Check if move is within the boards boundaries
                    if(safeSquare(next_x, next_y))
                    {
                        boardGrid[next_x, next_y] = movecount;
                        if(solveKTUtil(next_x,next_y, movecount + 1))
                            return true;
                        else
                            boardGrid[next_x, next_y] = -1;
                        
                    }
                    
                }
                return false;
            }
            bool safeSquare(int x, int y)
            {
                //check to see if x,y is a valid square
                //Also checking to see if square has been visited

                return (x >= 0 && x < boardSize && y >= 0 && y < boardSize && boardGrid[x, y] == -1);
            }
            void printBoard(int[,] board)
            {
                for (int i = 0; i < boardSize; i++)
                {
                    for (int j = 0; j < boardSize; j++)
                    {
                        if(board[i,j] < 10)
                        {
                            Console.Write(" ");
                        }
                        Console.Write("{0}  ",board[i, j]);
                        
                    }
                    Console.WriteLine("");
                }
            }
        }
        
    }
}
