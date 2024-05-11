namespace QuickSort;

class Program
{
    public static void Main(string[] args)
    {
        int[] arr = { 1, 10, 5, 8, 7, 6, 4, 3, 2, 9 };
        Console.WriteLine("Original array : ");
        Common.Print(arr);
        Console.WriteLine();

        Console.WriteLine("Choose pivot: ");
        Console.WriteLine("[1] First as pivot");
        Console.WriteLine("[2] Middle as pivot");
        Console.WriteLine("[3] Last as pivot");
        var choice = Console.ReadLine();
        Console.WriteLine();

        switch (choice)
        {
            case "1":
                FirstAsPivot.Run(arr);
                break;
            case "2":
                MiddleAsPivot.Run(arr);
                break;
            case "3":
                LastAsPivot.Run(arr);
                break;
            default:
                Console.WriteLine("Choose 1 to 3");
                return;
        }

        Console.WriteLine();
        Console.WriteLine("Sorted array : ");
        Common.Print(arr);
    }
}