using System;

namespace Horse
{
    class Program
    {
        const int SIZE = 8;
        static int[,] field = new int[SIZE, SIZE];
        static int[,] steps = { {  1,  2 }, {  2,  1 }, {  2, -1 }, {  1, -2 },
                                { -1, -2 }, { -2, -1 }, { -2,  1 }, { -1,  2 } };

        static void Print()
        {
            for (int y = SIZE-1; y >= 0; y--)
            {
                for (int x = 0; x < SIZE; x++)
                {
                    Console.Write("{0,3}", field[y,x]);
                }
                Console.Write("\n\n");
            }
        }

        static bool IsInside(int x, int y)
        {
            return x >= 0 && x < SIZE && y >= 0 && y < SIZE;
        }

        static bool TryStep(int x, int y, int step)
        {
            field[y,x] = step;
            if (step == SIZE * SIZE)
                return true;

            for (int i = 0; i < steps.GetLength(0); i++)
            {
                int newx = x + steps[i,0];
                int newy = y + steps[i,1];
                if (IsInside(newx, newy) && field[newy, newx] == 0)
                {
                    if (TryStep(newx, newy, step + 1))
                        return true;
                }
            }

            field[y,x] = 0;
            return false;
        }

        static void Main(string[] args)
        {
            if (TryStep(0, 0, 1))
                Print();

            Console.ReadKey(true);
        }
    }
}
