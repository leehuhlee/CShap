namespace QuickSort
{
    public class LastAsPivot
    {
        public static int[] Run(int[] arr)
        {
            QuickSort(arr, 0, arr.Length - 1);
            return arr;
        }

        private static void QuickSort(int[] arr, int start, int end)
        {
            if (start > end) return;

            int pivot = end;
            int left = start;
            int right = end - 1;

            while (left < right)
            {
                while (left < end && arr[left] < arr[pivot]) left++;
                while (right > start && arr[right] > arr[pivot]) right--;

                if(left > right) Common.Swap(arr, pivot, left);
                else Common.Swap(arr, left, right);

                Common.Print(arr);
            }

            QuickSort(arr, start, left - 1);
            QuickSort(arr, left + 1, end);
        }
    }
}
