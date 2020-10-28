using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02_SongEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            // Technology Fundamentals Final Exam - 16 December 2018

            while (true)
            {
                string[] input = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "end")
                {
                    break;
                }

                string artist = input[0];
                string song = input[1];

                bool isArtistNameValid = IsArtistValid(artist);
                bool isSongNameValid = IsSongValid(song);

                if (isArtistNameValid && isSongNameValid)
                {
                    int key = artist.Length;

                    string output = DecryptArtistAndSong(artist, key);
                    output += "@";
                    output += DecryptArtistAndSong(song, key);

                    Console.WriteLine($"Successful encryption: {output}");
                }

                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        static string DecryptArtistAndSong(string artistOrSong, int key)
        {
            string output = string.Empty;

            for (int i = 0; i < artistOrSong.Length; i++)
            {
                char currentChar = artistOrSong[i];

                if (currentChar == ' ' || currentChar == '\'')
                {
                    output += currentChar;
                    continue;
                }

                if (char.IsUpper(currentChar))
                {
                    if (currentChar + key > 'Z')
                    {
                        currentChar = (char)((currentChar + key) - 26);
                    }
                    else
                    {
                        currentChar += (char)key;
                    }
                }

                else
                {
                    if (currentChar + key > 'z')
                    {
                        currentChar = (char)((currentChar + key) - 26);
                    }
                    else
                    {
                        currentChar += (char)key;
                    }
                }

                output += currentChar;
            }

            return output;
        }

        static bool IsSongValid(string song)
        {
            for (int i = 0; i < song.Length; i++)
            {
                if (!char.IsUpper(song[i]) && song[i] != ' ')
                {
                    return false;
                }
            }

            return true;
        }
        static bool IsArtistValid(string artist)
        {
            if (!char.IsUpper(artist[0]))
            {
                return false;
            }

            for (int i = 1; i < artist.Length; i++)
            {
                if (!char.IsLower(artist[i]) && artist[i] != ' ' && artist[i] != '\'')
                {
                    return false;
                }
            }

            return true;
        }
    }
}
