using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simbirsoft1
{
    public class GameLogic : InterfaceGameDescription
    {
        private static int n = 3;
        public int[,] arr;

        public GameLogic()
        {
            initMatrix();
        }
        public void initMatrix()
        {
            arr = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = 0;
                }
            }
        }
        public void fixNextStep(int i, int j, int num)
        {
            try
            {
                if (i < n && i >= 0)
                {
                    if (j < n && j >= 0)
                    {
                        if (num == 1 || num == 2)
                        {
                            if (arr[i, j] == 0)
                            {
                                arr[i, j] = num;
                            }
                            else
                            {
                                Console.WriteLine("Ячейка занята");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Введено неверное значение!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Введите значения от 0 до " + n);
                    }
                }
                else
                {
                    Console.WriteLine("Введите значения от 0 до " + n);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public bool isCompleted()
        {
            //проверяем одинаковые элементы в столбце
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = n - 1; j > 0; j--)
                {
                    if (arr[j, i] == arr[j - 1, i] && arr[j, i] != 0)
                    {
                        count++;
                    }
                }
                if (count == n - 1)
                {
                    return true;
                }
            }
            //проверяем одинаковые элементы в строке
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = n - 1; j > 0; j--)
                {
                    if (arr[i, j] == arr[i, j - 1] && arr[i, j] != 0)
                    {
                        count++;
                    }
                }
                if (count == n - 1)
                {
                    return true;
                }
            }
            //диагонали
            int c = 0;
            for (int i = n - 1; i > 0; i--)
            {
                if (arr[i - 1, i - 1] == arr[i, i] && arr[i, i] != 0)
                {
                    c++;
                }
                if (c == n - 1)
                {
                    return true;
                }
            }
            int k = 0;
            for (int i = 0; i < n - 1; i++)
            {
                if (arr[i, n - i - 1] == arr[i + 1, n - i - 1 - 1] && arr[i, n - i - 1] != 0)
                {
                    k++;
                }
                if (k == n - 1)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
