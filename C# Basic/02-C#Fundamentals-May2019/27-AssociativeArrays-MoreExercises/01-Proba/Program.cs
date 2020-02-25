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
                        AddToFinalResult(finalResult, userName, contestName, userPoints);
                        // finalResult, string studentName, string contestName, int points

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
                            AddPointsIfIsBuger(contestInfo, contestName, userPoints);
                        }
                    }
                }
            }

            var studentsAndPoints = new Dictionary<string, int>();

            studentsAndPoints = CalculateStudentPoints(contestInfo);
            studentsAndPoints = studentsAndPoints.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in studentsAndPoints)
            {
                Console.WriteLine($"Best candidate is {item.Key} with total {item.Value} points.");
                break;
            }

            Console.WriteLine("Ranking:");

            foreach (var item in contestInfo)
            {
                Console.WriteLine(item.Value.Select(x => $"{x.StudentUserName}"));


                //Console.WriteLine($"# {item.Key} => {item.Value.Select(x => $"{x.StudentPoints}")}");

                //Console.WriteLine($"{item.Key}");
                //Console.WriteLine(string.Join(Environment.NewLine, item.Value
                //    .Select(x => $"# {x.StudentUserName} -> {x.StudentPoints}")));
            }

        }

        static void AddToFinalResult(Dictionary<string, List<ContestAndPoints>> finalResult, string studentName, string contestName, int points)
        {
            if (!finalResult.ContainsKey(studentName))
            {
                finalResult[studentName] = new List<ContestAndPoints>();
            }

            ContestAndPoints currentInfo = new ContestAndPoints();
            finalResult[studentName].Add(currentInfo);

            //if (currentInfo.ContestPoints < points)
            //{
            //    currentInfo.ContestPoints = points;
            //}

            foreach (var item in finalResult)
            {
                if (item.Key == studentName)
                {
                    foreach (var atrubutes in item.Value)
                    {
                        if (atrubutes.ContestPoints < points)
                        {
                            atrubutes.ContestPoints = points;
                        }
                        else
                        {
                            currentInfo.ContestName = contestName;
                        }
                    }
                }
            }

            finalResult[studentName].Add(currentInfo);
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

        static void AddPointsIfIsBuger(Dictionary<string, List<Contest>> info, string contestName, int point)
        {
            foreach (var item in info)
            {
                if (item.Key == contestName)
                {
                    foreach (var element in item.Value)
                    {
                        if (element.StudentPoints < point)
                        {
                            element.StudentPoints = point;
                        }
                    }
                }
            }
        }

        static void AddPointsIfIsBuger(Dictionary<string, List<ContestAndPoints>> info, string contestName, int point)
        {
            foreach (var item in info)
            {
                if (item.Key == contestName)
                {
                    foreach (var element in item.Value)
                    {
                        if (element.ContestPoints < point)
                        {
                            element.ContestPoints = point;
                        }
                    }
                }
            }
        }

        static bool IsUserExist(Dictionary<string, List<Contest>> students, string userName, string contestName)
        {
            foreach (var item in students)
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
