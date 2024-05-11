namespace QuickSort
{
    public class FirstAsPivot
    {
        public static int[] Run(int[] arr) 
        {
            QuickSort(arr, 0, arr.Length - 1);

            return arr;
        }

        private static void QuickSort(int[] arr, int start, int end)
        {
            if (start >= end) return;

            int pivot = start;
            int left = start + 1;
            int right = end;

            while(left <= right) 
            {
                while (left <= end && arr[left] < arr[pivot] ) left++;
                while (right > start && arr[right] > arr[pivot] ) right--;

                if (left > right) Common.Swap(arr, pivot, right);
                else Common.Swap(arr, left, right);

                Common.Print(arr);
            }

            QuickSort(arr, start, right - 1);
            QuickSort(arr, right + 1, end);
        }
    }
}
