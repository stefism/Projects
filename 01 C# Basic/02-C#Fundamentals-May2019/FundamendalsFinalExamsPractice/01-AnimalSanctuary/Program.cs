using System;
using System.Text;
using System.Linq;

namespace _01_AnimalSanctuary
{
    class Program
    {
        static void Main(string[] args)
        {
            // Technology Fundamentals Retake Final Exam - 18 April 2018

            int numberOfInput = int.Parse(Console.ReadLine());

            int totalWeight = 0;

            for (int i = 0; i < numberOfInput; i++)
            {
                string[] currentInput = Console.ReadLine().Split(";");
                // Евентуално може да има проблем ако ни подадат ; където не трябва.
                // Може да има проблем и при сплита.

                if (currentInput.Length == 3)
                {
                    string animalName = currentInput[0];
                    string animalKind = currentInput[1];
                    string animalCountry = currentInput[2];

                    bool isNameValid = IsNameValid(animalName);
                    bool isKindValid = IsKindValid(animalKind);
                    bool isCountryValid = IsCountryValid(animalCountry);

                    string name = string.Empty;
                    string kind = string.Empty;
                    string country = string.Empty;

                    if (isNameValid && isKindValid && isCountryValid)
                    {
                        name = ExtractNameAndKind(animalName);
                        kind = ExtractNameAndKind(animalKind);
                        country = animalCountry.Substring(3);

                        totalWeight += CalculateCurrentWeight(animalName, animalKind);

                        Console.WriteLine($"{name} is a {kind} from {country}");
                    }
                }
            }

            Console.WriteLine($"Total weight of animals: {totalWeight}KG");
        }

        static int CalculateCurrentWeight(string name, string kind)
        {
            int currentWeight = 0;

            for (int i = 2; i < name.Length; i++)
            {
                if (char.IsDigit(name[i]))
                {
                    string digit = name[i].ToString();
                    int currentDigit = int.Parse(digit);
                    currentWeight += currentDigit;
                }
            }

            for (int i = 2; i < kind.Length; i++)
            {
                if (char.IsDigit(kind[i]))  
                {
                    string digit = kind[i].ToString();
                    int currentDigit = int.Parse(digit);
                    currentWeight += currentDigit;
                }
            }

            return currentWeight;
        }
        static string ExtractNameAndKind(string nameToExtract)
        {
            string name = string.Empty;

            for (int i = 2; i < nameToExtract.Length; i++)
            {
                if (char.IsLetter(nameToExtract[i]) || char.IsWhiteSpace(nameToExtract[i]))
                {
                    name += nameToExtract[i];
                }
            }

            return name;
        }
        static bool IsCountryValid(string country)
        {
            if (country[0] != 'c' || country[1] != '-' || country[2] != '-')
            {
                return false;
            }

            for (int i = 3; i < country.Length; i++)
            {

                if (country[i] != ' ' && !char.IsLetter(country[i]))
                {
                    return false;
                }
            }

            return true;
        }

        static bool IsKindValid(string kind)
        {
            if (kind[0] != 't' && kind[1] != ':')
            {
                return false;
            }

            //for (int i = 2; i < kind.Length; i++)
            //{
            //    if (kind[i] == ';')
            //    {
            //        return false;
            //    }
            //}

            // Тука също като долното.

            return true;
        }
        static bool IsNameValid(string name)
        {
            if (name[0] != 'n' && name[1] != ':')
            {
                return false;
            }

            //for (int i = 2; i < name.Length; i++)
            //{
            //    if (name[i] == ';')
            //    {
            //        return false;
            //    }
            //}

            // Нема нужда от нея щото като го сплитне по ; то така или иначе ги маха и няма как да има ; във вече сплитнатото име.

            return true;
        }
    }
}
