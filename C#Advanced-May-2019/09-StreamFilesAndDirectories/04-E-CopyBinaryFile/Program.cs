using System;
using System.IO;

namespace _04_E_CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var fileStream = new FileStream("copyMe.png", FileMode.Open))
            {
                using (FileStream fileWriter = new FileStream("copyMe-copy.png", FileMode.Create))
                {
                    while (true)
                    {
                        byte[] byteArray = new byte[4096];

                        int size = fileStream.Read(byteArray, 0, byteArray.Length); // Това го правиме за да му кажем по-долу
                                                                                    // да запише точно толкова, колкото е прочело.  Иначе в последното парче може да има
                                                                                    // празни байтове.

                        if (size == 0)
                        {
                            break;
                        }

                        fileWriter.Write(byteArray, 0, size);
                    }
                }
            }
        }
    }
}
