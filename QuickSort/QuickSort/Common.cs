namespace QuickSort
{
    public class Common
    {
        public static void Swap(int[] arr, int a, int b)
        {
            var temp = arr[a]; 
            arr[a] = arr[b]; 
            arr[b] = temp;
        }

        public static void Print(int[] arr)
        {
            foreach(var item in arr)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }
}
