using System;
using System.Collections.Generic;
using System.Linq;

namespace _10_SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentsInformation = new Dictionary<string, List<LanguagesAndPoints>>();
            var languagesCount = new Dictionary<string, int>();

            while (true)
            {
                string[] currentStudentInfo = Console.ReadLine().Split("-");

                string studentNameValue = currentStudentInfo[0];

                // break

                if (studentNameValue == "exam finished")
                {

                    break;
                }

                // break

                string languageKey = currentStudentInfo[1];
                int pointsValue = int.Parse(currentStudentInfo[2]);

                if (!studentsInformation.ContainsKey(languageKey))
                {
                    studentsInformation[languageKey] = new List<LanguagesAndPoints>();
                    languagesCount[languageKey] = 0;
                }

                LanguagesAndPoints currentInfo = new LanguagesAndPoints();

                bool isPointsIsBigger = false;
                bool isStudentExist = false;

                foreach (var item in studentsInformation[languageKey])
                {
                    if (item.StudentName == studentNameValue)
                    {
                        isStudentExist = true;

                        if (item.StudentPoints < pointsValue)
                        {
                            item.StudentPoints = pointsValue;

                            languagesCount[languageKey]++;

                            isPointsIsBigger = true;
                            break;
                        }
                    }
                }

                if (!isStudentExist)
                {
                    currentInfo.StudentName = studentNameValue;
                    studentsInformation[languageKey].Add(currentInfo);
                }
                
                if (!isPointsIsBigger)
                {
                    currentInfo.StudentPoints = pointsValue;
                    languagesCount[languageKey]++;
                }

            }
        }
    }
    class LanguagesAndPoints
    {
        public string StudentName { get; set; }
        public int StudentPoints { get; set; }

        public LanguagesAndPoints()
        {
            StudentPoints = 0;
            StudentName = string.Empty;
        }
    }
}
