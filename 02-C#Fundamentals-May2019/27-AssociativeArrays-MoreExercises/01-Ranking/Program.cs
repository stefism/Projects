using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            var contestsAndPasswords = new Dictionary<string, string>();
            var contestInfo = new Dictionary<string, List<Contest>>();

            var finalResult = new Dictionary<string, List<ContestAndPoints>>();

            while (true)
            {
                string[] currentContestAndPass = Console.ReadLine().Split(":");
                string contestName = currentContestAndPass[0];

                if (contestName == "end of contests")
                {
                    break;
                }

                string contestPassword = currentContestAndPass[1];

                contestsAndPasswords[contestName] = contestPassword;
            }

            while (true)
            {
                string[] contestInformation = Console.ReadLine().Split("=>");
                string contestName = contestInformation[0];

                if (contestName == "end of submissions")
                {
                    var studentsAndPoints = new Dictionary<string, int>();

                    studentsAndPoints = CalculateStudentPoints(contestInfo);
                    studentsAndPoints = studentsAndPoints.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                    Console.WriteLine($"Best candidate is {studentsAndPoints.ElementAt(0).Key} with total {studentsAndPoints.ElementAt(0).Value} points.");

                    Console.WriteLine("Ranking:");
                    AddToFinalResult(contestInfo, finalResult);

                    foreach (var item in finalResult.OrderBy(x => x.Key))
                    {
                        Console.WriteLine(item.Key);

                        if (item.Value.Count > 0)
                        {
                            Console.WriteLine(string.Join(Environment.NewLine, item.Value
                                .OrderByDescending(x => x.ContestPoints)
                                .Select(x => $"#  {x.ContestName} -> {x.ContestPoints}")));
                        }
                    }

                    break;
                }

                string contestPassword = contestInformation[1];
                string userName = contestInformation[2];
                int userPoints = int.Parse(contestInformation[3]);



                bool isContestNameValid = IsContestValid(contestsAndPasswords, contestName);

                if (isContestNameValid)
                {
                    bool isPasswordValid = IsPasswordValid(contestsAndPasswords, contestName, contestPassword);

                    if (isPasswordValid)
                    {
                        if (!contestInfo.ContainsKey(contestName))
                        {
                            contestInfo[contestName] = new List<Contest>();
                        }

                        bool isUserExist = IsUserExist(contestInfo, userName, contestName); // Тука.

                        if (!isUserExist)
                        {
                            Contest currentInfo = new Contest();
                            currentInfo.StudentUserName = userName;
                            currentInfo.StudentPoints = userPoints;

                            contestInfo[contestName].Add(currentInfo);
                        }
                        else
                        {
                            AddPointsIfIsBigger(contestInfo, contestName, userPoints, userName);
                        }
                    }
                }
            }
        }

        private static void AddToFinalResult(Dictionary<string, List<Contest>> contestInfo, Dictionary<string, List<ContestAndPoints>> finalResult)
        {
           
            foreach (var contestInfoItem in contestInfo)
            {
                foreach (var studentInfo in contestInfoItem.Value)
                {
                    
                    if (!finalResult.Keys.Contains(studentInfo.StudentUserName))
                    {
                        finalResult[studentInfo.StudentUserName] = new List<ContestAndPoints>();
                    }

                    finalResult[studentInfo.StudentUserName].Add(new ContestAndPoints
                    {
                        ContestName = contestInfoItem.Key,
                        ContestPoints = studentInfo.StudentPoints
                    });
                }
            }
        }

        static Dictionary<string, int> CalculateStudentPoints(Dictionary<string, List<Contest>> students)
        {
            var studentsAndPointsInfo = new Dictionary<string, int>();

            List<Contest> pointsInfo = students.SelectMany(x => x.Value).ToList();

            foreach (var item in pointsInfo)
            {
                if (!studentsAndPointsInfo.ContainsKey(item.StudentUserName))
                {
                    studentsAndPointsInfo[item.StudentUserName] = 0;
                }

                studentsAndPointsInfo[item.StudentUserName] += item.StudentPoints;
            }

            return studentsAndPointsInfo;
        }

        static void AddPointsIfIsBigger(Dictionary<string, List<Contest>> contestInfo, string contestName, int point, string name)
        {
            foreach (var item in contestInfo)
            {
                if (item.Key == contestName)
                {
                    foreach (var element in item.Value)
                    {
                        if (element.StudentUserName == name)
                        {
                            if (element.StudentPoints < point)
                            {
                                element.StudentPoints = point;
                            }
                        }
                    }
                }
            }
        }

        static bool IsUserExist(Dictionary<string, List<Contest>> contestInfo, string userName, string contestName)
        {
            foreach (var item in contestInfo)
            {
                if (item.Key == contestName)
                {
                    foreach (var names in item.Value)
                    {
                        if (names.StudentUserName == userName)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        static bool IsPasswordValid(Dictionary<string, string> contests, string contestName, string password)
        {
            if (contests[contestName] == password)
            {
                return true;
            }

            return false;
        }

        static bool IsContestValid(Dictionary<string, string> contests, string contestName)
        {
            foreach (var item in contests)
            {
                if (item.Key == contestName)
                {
                    return true;
                }
            }

            return false;
        }
    }

    class Contest
    {
        public string StudentUserName { get; set; }
        public int StudentPoints { get; set; }
    }

    class ContestAndPoints
    {
        public string ContestName { get; set; }
        public int ContestPoints { get; set; }

        public ContestAndPoints()
        {
            ContestName = " ";
            ContestPoints = 0;
        }
    }
}
