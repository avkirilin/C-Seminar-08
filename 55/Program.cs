int[,] GetArray(int rows, int columns, int minValue, int maxValue)                      //метод получения двумерного массива с рандомными значениями
{
    int[,] result = new int[rows, columns];
    for (int i = 0; i < columns; i++)
    {
        for (int j = 0; j < rows; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue + 1);
        }
    }
    return result;
}
void PrintArray(int[,] inArray)                                                         //метод вывода двумерного массива с корректными отступами
{
    Console.WriteLine();
    for (int i = 0; i < inArray.GetLength(1); i++)
    {
        for (int j = 0; j < inArray.GetLength(0); j++)
        {
            if (inArray[i, j] >= 0 && inArray[i, j] < 10) Console.Write($"     {inArray[i, j]}");
            if (inArray[i, j] >= 10 && inArray[i, j] < 100) Console.Write($"    {inArray[i, j]}");
            if (inArray[i, j] >= 100 && inArray[i, j] < 1000) Console.Write($"   {inArray[i, j]}");
            if (inArray[i, j] >= 1000 && inArray[i, j] < 10000) Console.Write($"  {inArray[i, j]}");
        }
        Console.WriteLine();
    }
}
int[,] ChangeMyArray(int[,] array, int rows, int columns)                               //метод создания нового массива
{                                                                                       //с заменой значений строк массива на его столбцы                                               
    int[,] result = new int[columns, rows];
    for (int i = 0; i < columns; i++)
    {
        for (int j = 0; j < rows; j++)
        {
            result[i, j] = array[j, i];
        }
    }
        return result;
}
Console.Clear();
Console.WriteLine("Введите кол-во строк и кол-во столбцов массива через пробел");
string[] f = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries);
int rowsArray = int.Parse(f[0]);
int columnsArray = int.Parse(f[1]);
if (rowsArray == columnsArray)
{
    Console.WriteLine("Введите минимальное и максимальное значения элементов массива в диапазоне 0-9999, через пробел");
    string[] d = Console.ReadLine()!.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    int minNum = int.Parse(d[0]);
    int maxNum = int.Parse(d[1]);
    int[,] myArray = GetArray(rowsArray, columnsArray, minNum, maxNum);
    PrintArray(myArray);
    Console.WriteLine();
    int[,] newArray = ChangeMyArray(myArray, rowsArray, columnsArray);
    PrintArray(newArray);
}
else
{
    System.Console.WriteLine("Ошибка! Невозможно заменить значения в массиве с заданным кол-вом строк и столбцов");
}