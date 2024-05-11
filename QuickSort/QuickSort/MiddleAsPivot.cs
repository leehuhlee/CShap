namespace QuickSort
{
    public class MiddleAsPivot
    {
        public static int[] Run(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);

            return arr;
        }

        private static void QuickSort(int[] arr, int start, int end)
        {
            if (start >= end) return;

            int left = start;
            int right = end;
            int pivot = (start + end)/2;

            while (left < right)
            {
                while (arr[left] < arr[pivot]) left++;
                while (arr[right] > arr[pivot]) right--;

                if (left < right)
                {
                    Common.Swap(arr, left, right);
                    Common.Print(arr);
                }
            }

            QuickSort(arr, start, pivot);
            QuickSort(arr, pivot + 1, end);
        }
    }
}
