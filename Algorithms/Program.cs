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
            //Question B
            //Console.WriteLine(QuestionB(new[] { "apple", "ape", "apricot" }));
            //Console.WriteLine(QuestionB(new[] { "banana", "bandido" }));
            //Console.WriteLine(QuestionB(new[] { "banana", "banana" }));

            //Question C
            //Console.WriteLine(string.Join(", ", QuestionC(new[] { 40, 30, 31, 20, 18, 14, 16, 8, 19 })));
            //Console.WriteLine(string.Join(", ", QuestionC(new[] { 6, 2, 7, 3, 1, 5 })));

            //Question D
            //Console.WriteLine(QuestionD("Hello World!", "I`m  happy! Hello World baby!"));
            //Console.WriteLine(QuestionD("I've kidnapped your dog! I wanna a million dollars!", "No way baby! No way baby! No way baby! No way baby! No way baby!"));

            //Question F
            //Console.WriteLine(QuestionF("((()()))(())()()"));
			//Console.WriteLine(QuestionF("())"));
			//Console.WriteLine(QuestionF("))("));
            //Console.WriteLine(QuestionF("((((()))(())))"));

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
            if (ransomNote.Length > magazineText.Length)
                return false;
            
            var ransomNoteArray = ransomNote.ToLower().Replace(" ","").ToCharArray();
            var magazineTextArray = magazineText.ToLower().Replace(" ", "").ToCharArray();

            ArrayHelper.QuickSort(ransomNoteArray);
            ArrayHelper.QuickSort(magazineTextArray);

            int j = 0;
            for (int i = 0; i < ransomNoteArray.Length; i++)
            {
                while (ransomNoteArray[i] > magazineTextArray[j])
                    j++;

                if (ransomNoteArray[i] == magazineTextArray[j])
                    j++;
                else
                    return false; 
            }

            return true;
        }

        static bool QuestionF(string text){
            var arrayText = text.ToArray();

            int openParenthesis = 0;
            foreach (var item in arrayText)
            {
                if (item == '(')
                    openParenthesis++;
                else
                {
                    if (openParenthesis == 0)
                        return false;
                    else if (openParenthesis > 0)
                        openParenthesis--;
                }
            }

            return openParenthesis == 0;
        }
    }
}
