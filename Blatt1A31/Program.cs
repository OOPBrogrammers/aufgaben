namespace Blatt1A31;

public class Program
{

    public static void Sortiere(int[] arr)
    {
        for (int j = 0; j < arr.Length - 1; j++)
        {
            int minIndex = j;
            for (int i = j + 1; i < arr.Length; i++)
            {
                if (arr[i] < arr[minIndex])
                {
                    minIndex = i;
                }
            }

            if (minIndex != j)
            {
                int buffer = arr[j];
                arr[j] = arr[minIndex];
                arr[minIndex] = buffer;
            }
        }
    }


    static void Main(string[] args)
    {
        int[] arr = { 8, 2, 3, 1505, 1, 2, 7, 10 };
        Sortiere(arr);
        foreach (int x in arr)
        {
            Console.Write(x + " ");
        }
    }
}