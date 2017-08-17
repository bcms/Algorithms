using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(QuestionB(new[] { "apple", "ape", "apricot" }));
            //Console.WriteLine(QuestionB(new[] { "banana", "bandido" }));
            //Console.WriteLine(QuestionB(new[] { "banana", "banana" }));

            //Console.WriteLine(string.Join(", ", QuestionC(new[] { 40, 30, 31, 20, 18, 14, 16, 8, 19 })));
            //Console.WriteLine(string.Join(", ", QuestionC(new[] { 6, 2, 7, 3, 1, 5 })));

            var array1 = new[] { 30, 31, 20, 18, 40, 14, 16, 8, 19 };
            ArrayHelper.QuickSort(array1);
            Console.WriteLine(string.Join(", ", array1));

            var array2 = new[] { 30, 31, 20, 18, 22, 18, 40, 17, 14, 16, 8, 19, 10, 25, 65 };
            ArrayHelper.QuickSort(array2);
            Console.WriteLine(string.Join(", ", array2));

            var array3 = "bhdjklspormbjdhaalçssss  ".ToCharArray();
            ArrayHelper.QuickSort(array3);
            Console.WriteLine(string.Join(", ", array3));

            Console.ReadKey();
        }

        static string QuestionB(string[] input)
        {
            if (input.Length > 0)
            {
                var result = input[0];

                if (!string.IsNullOrEmpty(result))
                {
                    for (int i = 1; i < input.Length; i++)
                    {
                        var item = input[i];

                        if (result == item)
                            break;

                        var charArray = result.ToArray();
                        result = string.Empty;

                        for (int j = 0; j < charArray.Length; j++)
                        {
                            if (j >= item.Length)
                                break;

                            if (charArray[j] == item[j])
                                result += charArray[j];
                            else
                                break;
                        }

                    }
                }

                return result;
            }

            return null;
        }

        static int[] QuestionC(int[] input)
        {
            var x = (int?)null;
            var y = (int?)null;
            var z = (int?)null;

            for (int a = 0; a < input.Length; a++)
            {
                var xValue = input[a];

                for (int b = a + 1; b < input.Length; b++)
                {
                    var yValue = input[b];

                    if (xValue < yValue)
                    {
                        for (int c = b + 1; c < input.Length; c++)
                        {
                            var zValue = input[c];

                            if (yValue < zValue)
                            {
                                z = c;
                                break;
                            }
                        }

                        if (z.HasValue)
                        {
                            y = b;
                            break;
                        }
                    }
                }

                if (y.HasValue)
                {
                    x = a;
                    break;
                }
            }

            if (x.HasValue && y.HasValue && z.HasValue)
                return new[] { x.Value, y.Value, z.Value };
            else
                return new int[0];
        }

        static bool QuestionD(string ransomNote, string magazineText)
        {
            return false;
        }

        static void QuickSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Separate(array, left, right);

                QuickSort(array, left, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, right);
            }
        }

        private static int Separate(int[] array, int left, int right)
        {
            var pivot = array[left];
            int i = left + 1, j = right;

            while (i < j)
            {
                while (i < right && array[i] <= pivot) i++;

                while (j >= left && array[j] > pivot) j--;

                if (i < j)
                {
                    Switch(array, i, j);

                    i++;
                    j--;
                }
            }

            if (i == j && array[j] > pivot)
                j--;

            Switch(array, left, j);

            return j;
        }

        private static void Switch(int[] array, int i, int j)
        {
            var aux = array[i];
            array[i] = array[j];
            array[j] = aux;
        }
    }
}
