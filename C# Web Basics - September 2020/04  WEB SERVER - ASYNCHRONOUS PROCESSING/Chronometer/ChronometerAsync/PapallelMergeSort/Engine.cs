using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PapallelMergeSort
{
    public class Engine
    {
        List<List<int>> Lists = new List<List<int>>();
        public void Run()
        {
            //00:00:00.1059919 - me
            //00:00:00.0176845 - sort

            List<int> numbers = Console.ReadLine()
                .Split().Select(int.Parse).ToList();

            Lists.Add(numbers);

            SlyceLists(Lists, 6);
            Sort(Lists);

            ;

            //Stopwatch sw = Stopwatch.StartNew();
                                          
            //Console.WriteLine(string.Join(", ", numbers));
            //Console.WriteLine(sw.Elapsed);
        }

        private void SlyceLists(List<List<int>> lists, int sliceCountNumber)
        {
            while (true)
            {
                bool isSliced = false;

                for (int i = 0; i < lists.Count; i++)
                {
                    if (lists[i].Count > sliceCountNumber)
                    {
                        List<int> listToAdd = lists[i].GetRange(0, lists[i].Count / 2);

                        lists[i].RemoveRange(0, lists[i].Count / 2);
                        lists.Add(listToAdd);
                        i--;
                    }
                    else
                    {
                        isSliced = true;
                    }
                }

                if (isSliced)
                {
                    break;
                }
            }            
        }

        private async Task Sort(List<List<int>> lists)
        {
            foreach (var list in lists)
            {
                SortList(list);
            }
        }

        private async Task SortList(List<int> numbers)
        {            
            while (true)
            {
                bool isChanged = false;

                for (int i = 1; i < numbers.Count; i++)
                {
                    int firstNumber = numbers[i - 1];

                    if (numbers[i] < firstNumber)
                    {
                        isChanged = true;

                        int secondNumber = numbers[i];
                        numbers.RemoveAt(i);

                        if (i - 2 < 0)
                        {
                            numbers.Insert(0, secondNumber);
                        }
                        else
                        {
                            numbers.Insert(i - 2, secondNumber);
                        }

                        i--;
                    }                   
                }

                if (!isChanged)
                {
                    break;
                }
            }            
        }
    }
}
