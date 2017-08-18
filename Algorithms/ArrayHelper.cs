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
                var pivot = array[(left + right) / 2];

                var i = left;
                var j = right;

                while(i <= j)
                {
                    while (array[i].CompareTo(pivot) < 0)
                        i++;

                    while (array[j].CompareTo(pivot) > 0)
                        j--;

                    if (i < j)
                    {
                        Swap(array, i, j);
						i++;
						j--;
                    }
                    else if(i == j)
                    {
                        i++;
                        j--;
                    }
                }

                if (i < right)
                    QuickSort(array, i, right);

                if (j > left)
                    QuickSort(array, left, j);
            }
		}

        public static void Swap<T>(T[] array, int a, int b)
		{
			var aux = array[a];
			array[a] = array[b];
			array[b] = aux;
		}

		public static void MergeSort<T>(T[] array)
			where T : IComparable
		{
			ArrayHelper.MergeSort(array, 0, array.Length - 1);
		}

        private static void MergeSort<T>(T[] array, int start, int end)
            where T : IComparable
		{
            if (start < end)
            {
                int middle = (start + end) / 2;

                MergeSort(array, start, middle);
                MergeSort(array, middle + 1, end);

                Merge(array, start, middle, end);
            }
        }

        private static void Merge<T>(T[] array, int beginning, int middle, int end)
            where T : IComparable
        {
            var auxArray = new T[array.Length];
            Array.Copy(array, auxArray, array.Length);

            var i = beginning;
            var j = middle + 1;
            var k = beginning;

            while (i <= middle && j <= end)
            {
                if (auxArray[i].CompareTo(auxArray[j]) < 0)
                {
                    array[k] = auxArray[i];
                    i++;
                }
                else
                {
                    array[k] = auxArray[j];
                    j++;
                }
                k++;
            }

            while (i <= middle)
            {
                array[k] = auxArray[i];
                i++;
                k++;
            }

            while (j <= end)
            {
                array[k] = auxArray[j];
                j++;
                k++;
            }
        }
    }
}