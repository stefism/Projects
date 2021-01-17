using System;
using System.Collections.Generic;
using System.Linq;

namespace SetCover
{
    class SetCover
    {
        static List<int[]> ChooseSets(IList<int[]> sets, IList<int> universe)
        {
            var result = new List<int[]>();
            var universeSet = new HashSet<int>(universe);
            var setsSet = new HashSet<int[]>(sets);

            while (universe.Count > 0)
            {
                int[] currentSet = setsSet
                    .OrderByDescending(s => s.Count(s => 
                    universeSet.Contains(s)))
                    .First(); //Първият сет да бъде този, който съдържа най-много елементи от universe.

                result.Add(currentSet);
                setsSet.Remove(currentSet);

                foreach (var number in currentSet)
                {
                    universeSet.Remove(number);
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            
        }
    }
}
