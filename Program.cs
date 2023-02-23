//Задача 47. Задайте двумерный массив размером m×n, 
//заполненный случайными вещественными числами.
//Задача 50. Напишите программу, которая на вход принимает 
//позиции элемента в двумерном массиве, и возвращает значение 
//этого элемента или же указание, что такого элемента нет.
//Задача 52. Задайте двумерный массив из целых чисел. 
//Найдите среднее арифметическое элементов в каждом столбце.
bool isWork = true;

while(isWork)
{
    Console.WriteLine("Choose task 1, 2 or 3. For exit enter '-1'");

    if (int.TryParse(Console.ReadLine(), out int j))
    {
        switch (j)
        {
            case 1:
            {
                int firstLength = ReadInt("First Length");
                int secondLength = ReadInt("Second Length");
                double[,] array = CreateTwoDementionDoubleArray(firstLength, secondLength);
                Console.WriteLine("Two-dimensional array:");
                PrintTwoDementionDoubleArray(array);
                break;
            }

            case 2:
            {
                double[,] array = CreateTwoDementionDoubleArray(6, 6);
                Console.WriteLine("Two-dimensional array:");
                PrintTwoDementionDoubleArray(array);
                int firstPos = ReadInt("Horizontal Position");
                int secondPos = ReadInt("Vertical Position ");
                if (array.GetLength(0) >= firstPos && array.GetLength(1) >= secondPos)
                {
                    if (firstPos <= 0 ^ secondPos <= 0)
                    {
                        Console.WriteLine("No such element");
                    }
                    else
                    {
                        Console.Write($"Element on position [{firstPos},{secondPos}]: {array[firstPos-1, secondPos-1]}");
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("No such element");
                }
                break;
            }

            case 3:
            {
                int firstLength = ReadInt("First Length");
                int secondLength = ReadInt("Second Length");
                int[,] array = CreateTwoDementionIntArray(firstLength, secondLength);
                Console.WriteLine("Two-dimensional array:");
                PrintTwoDementionIntArray(array);
                Console.WriteLine("Average of array's colums:");
                double[] average = AverageFromColumsTwoDementionArray(array);
                PrintIntArray(average);
                Console.WriteLine();
                break;
            }

            case -1: isWork = false; break;
        }
    }
}

double[,] CreateTwoDementionDoubleArray(int firstLength, int secondLength)
{
    double[,] result = new double[firstLength, secondLength];
    Random rnd = new Random();

    for (int i = 0; i < result.GetLength(0); i++)
    {
        for (int j = 0; j < result.GetLength(1); j++)
        {
            result[i, j] = Math.Round(rnd.NextDouble() * 10, 2);
        }
    }

    return result;
}

int[,] CreateTwoDementionIntArray(int firstLength, int secondLength)
{
    int[,] result = new int[firstLength, secondLength];
    Random rnd = new Random();

    for (int i = 0; i < result.GetLength(0); i++)
    {
        for (int j = 0; j < result.GetLength(1); j++)
        {
            result[i, j] = rnd.Next(-9, 9);
        }
    }

    return result;
}

int ReadInt(string argument)
{
    Console.WriteLine($"Input {argument}");
    int result = 0;

    while (!int.TryParse(Console.ReadLine(), out result))
    {
        Console.WriteLine("Try again");
    }

    return result;
}

void PrintTwoDementionDoubleArray(double[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }

        Console.WriteLine();   
    }
}

void PrintTwoDementionIntArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }

        Console.WriteLine();   
    }
}

double[] AverageFromColumsTwoDementionArray(int[,] array)
{
    double[] result = new double[array.GetLength(0)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            result[i] = result[i] + array[j, i];
        }

        result[i] = Math.Round(result[i] / array.GetLength(1), 2);
    }

    return result;
}

void PrintIntArray(double[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"{array[i]} ");
    }
}