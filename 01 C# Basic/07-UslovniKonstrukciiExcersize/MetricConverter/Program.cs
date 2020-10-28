using System;

namespace MetricConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            double numberForConvert = double.Parse(Console.ReadLine());
            string unitIn = (Console.ReadLine());
            string unitOut = (Console.ReadLine());

            //double meter = 1;
            //double milimeter = meter * 1000;
            //double centimeter = meter * 100;
            
            if (unitIn == "m" && unitOut == "mm")
            {
                double result = numberForConvert * 1000;
                Console.WriteLine("{0:F3}", result);
            }
            else if (unitIn == "mm" && unitOut == "m")
            {
                double result = numberForConvert / 1000;
                Console.WriteLine("{0:F3}", result);
            }
            else if (unitIn == "mm" && unitOut == "cm")
            {
                double result2 = numberForConvert / 10;
                Console.WriteLine("{0:F3}", result2);
            }
            else if (unitIn == "cm" && unitOut == "mm")
            {
                double result2 = numberForConvert * 10;
                Console.WriteLine("{0:F3}", result2);
            }
            else if (unitIn == "m" && unitOut == "cm")
            {
                double result3 = numberForConvert * 100;
                Console.WriteLine("{0:F3}", result3);
            }
            else if (unitIn == "cm" && unitOut == "m")
            {
                double result3 = numberForConvert / 100;
                Console.WriteLine("{0:F3}", result3);
            }

                //if (unitIn == "mm")
                //{
                //    numberForConvert = numberForConvert / 1000;
                //}
                //else if (unitIn == "cm")
                //{
                //    numberForConvert = numberForConvert / 100;
                //}


                //if (unitOut == "mm")
                //{
                //    numberForConvert = numberForConvert * 1000;
                //}
                //else if (unitOut == "cm")
                //{
                //    numberForConvert = numberForConvert * 100;
                //}

                //Console.WriteLine("{0:F3}", numberForConvert);
           
        
            }
        }
    }
