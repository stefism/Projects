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
                    Console.WriteLine("Results:");

                    List<LanguagesAndPoints> listOfLanguagesAndPoints = studentsInformation
                        .SelectMany(x => x.Value).ToList();

                    listOfLanguagesAndPoints = listOfLanguagesAndPoints
                        .OrderByDescending(x => x.StudentPoints).ThenBy(y => y.StudentName).ToList();

                    foreach (var item in listOfLanguagesAndPoints)
                    {
                        Console.WriteLine($"{item.StudentName} | {item.StudentPoints}");
                    }

                    languagesCount = languagesCount.OrderByDescending(x => x.Value)
                        .ThenBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

                    Console.WriteLine("Submissions:");

                    foreach (var item in languagesCount)
                    {
                        Console.WriteLine($"{item.Key} - {item.Value}");
                    }

                    break;
                }

                // break

                string languageKey = currentStudentInfo[1];

                if (languageKey == "banned")
                {
                    foreach (var student in studentsInformation)
                    {
                        foreach (var studentValues in student.Value)
                        {
                            if (studentValues.StudentName == studentNameValue)
                            {
                                string key = student.Key;
                                studentsInformation[key].Remove(studentValues);
                                break;
                            }
                        }
                    }

                    continue;
                }

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
