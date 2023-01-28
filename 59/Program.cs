// Задайте двумерный массив из целых чисел. Напишите программу, которая удалит строку и столбец на пересечении которых расположен наименьший элемент массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Наименьший элемент: 1, на выходе получим следующий массив:
// 9 4 2
// 2 2 6
// 3 4 7

int[,] GetArray(int rows, int columns, int minValue, int maxValue)                      //метод получения двумерного массива с рандомными значениями
{
    int[,] result = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return result;
}
void PrintArray(int[,] inArray)                                     //метод вывода двумерного массива с корректными отступами
{
    Console.WriteLine();
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            if (inArray[i, j] >= 0 && inArray[i, j] < 10) Console.Write($"     {inArray[i, j]}");
            if (inArray[i, j] >= 10 && inArray[i, j] < 100) Console.Write($"    {inArray[i, j]}");
            if (inArray[i, j] >= 100 && inArray[i, j] < 1000) Console.Write($"   {inArray[i, j]}");
            if (inArray[i, j] >= 1000 && inArray[i, j] < 10000) Console.Write($"  {inArray[i, j]}");
        }
        Console.WriteLine();
    }
}
int[] FindIndexMinValue(int[,] array)                               //метод поиска индексов минимального значения в двумерном массиве
{
    int[] minCountIndex = new int[2];
    minCountIndex[0] = 0;
    minCountIndex[1] = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] < array[minCountIndex[0], minCountIndex[1]])
            {
                minCountIndex[0] = i;
                minCountIndex[1] = j;
            }
        }
    }
    return minCountIndex;
}

int[,] CoppyChangedArray(int[,] array, int[] indexOfMinValue)
{
    int rows = array.GetLength(0), columns = array.GetLength(1);
    int[,] newArray = new int[rows - 1, columns - 1];
    int x = 0, y = 0;
    for (int i = 0; i < rows; i++)
    {
        if (i == indexOfMinValue[0])
        {
            x = 1;
            continue;
        }
        for (int j = 0; j < columns; j++)
        {
            if (j == indexOfMinValue[1])
            {
                y = 1;
                continue;
            }
            if (i == 0) newArray[i, j - y] = array[i, j];
            else if (j == 0) newArray[i - x, j] = array[i, j];
            else newArray[i - x, j - y] = array[i, j];
        }
    }
    return newArray;
}
int[,] GetResultArray(int[,] inArray, int[] indexes)
{
    int[,] result = new int[inArray.GetLength(0) - 1, inArray.GetLength(1) - 1];
    int row = 0;
    int column = 0;
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        if (i == indexes[0]) continue;
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
            if (j == indexes[1]) continue;
            result[row, column] = inArray[i, j];
            column++;
        }
        column = 0;
        row++;
    }
    return result;
}
Console.Clear();
Console.WriteLine("Введите кол-во строк и кол-во столбцов массива через пробел");
string[] f = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries);
int rowsArray = int.Parse(f[0]);
int columnsArray = int.Parse(f[1]);
Console.WriteLine("Введите минимальное и максимальное значения элементов массива в диапазоне 0-9999, через пробел");
string[] d = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries);
int minNum = int.Parse(d[0]);
int maxNum = int.Parse(d[1]);
int[,] myArray = GetArray(rowsArray, columnsArray, minNum, maxNum);
PrintArray(myArray);
Console.WriteLine();
int[] indexOfMinValue = FindIndexMinValue(myArray);
System.Console.WriteLine($"Min index Value = [{String.Join(", ", indexOfMinValue)}]");
System.Console.WriteLine();
int[,] newArray = CoppyChangedArray(myArray, indexOfMinValue);
PrintArray(newArray);