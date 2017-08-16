using System;

namespace Algorithms
{
    public static class ArrayHelper
    {
        public static void QuickSort<T>(T[] array)
            where T : IComparable
        {
            ArrayHelper.QuickSort(array, 0, array.Length - 1);
        }

        private static void QuickSort<T>(T[] array, int left, int right)
            where T : IComparable
        {
            if (left < right)
            {
                var pivot = array[left];
                var i = left + 1;
                var j = right;

                while (i < j)
                {
                    while (i <= right && array[i].CompareTo(pivot) < 0) i++;

                    while (j >= left && array[j].CompareTo(pivot) > 0) j--;

                    if (i < j)
                    {
                        Switch(array, j, i);

                        i++;
                        j--;
                    }
                }

                if (i == j && array[j].CompareTo(pivot) > 0) j--;

                Switch(array, left, j);

                QuickSort(array, left, j - 1);
                QuickSort(array, j + 1, right);
            }
        }

        public static void Switch<T>(T[] array, int a, int b)
        {
            var aux = array[a];
            array[a] = array[b];
            array[b] = aux;
        }
    }
}
