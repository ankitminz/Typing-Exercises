using System.IO;

namespace Chunck
{
    public class Chuncky
    {
        public static void Main()
        {
            string file = GetPath("Enter file path = ");
            string chars = File.ReadAllText(file);
            int charsLen = chars.Length;
            Console.WriteLine($"\nTotal Characters = {charsLen}");
            Chunckify(file, chars);
        }


        private static string GetPath(string prompt)
        {
            // User input file name

            string path;
            do
            {
                Console.Write(prompt);
                path = Console.ReadLine();
                if (!File.Exists(path))
                {
                    Console.WriteLine("\nEnter a valid path");
                }
            }
            while(!File.Exists(path));

            return path;
        }


        private static int GetInt(string prompt)
        {
            // User input int

            int num;
            bool isInt;

            do
            {
                Console.Write(prompt);
                isInt = Int32.TryParse(Console.ReadLine(), out num);
                if(!isInt || num <= 0)
                {
                    Console.WriteLine("\nEnter a valid integer greater than 0");
                }
            }
            while (!isInt || num <= 0);

            return num;
        }


        private static void Chunckify(string file, string chars)
        {
            // Convert given file into chuncks of given size

            int chunckSize = GetInt("Enter chunck size = ");
            int end = chunckSize;
            int len = chars.Length;
            string current = "";
            int count = 1;
            string newFile = "";
            string fileName = "";
            string dir = "";

            for(int i = 0; i < len; i++)
            {
                if(i < end || (i >= end && chars[i] != ' '))
                {
                    current += chars[i];
                }
                else
                {
                    fileName = Path.GetFileNameWithoutExtension(file) + chunckSize + '_' + count + Path.GetExtension(file);
                    dir = Path.GetDirectoryName(file);
                    newFile = Path.Combine(dir, fileName);
                    File.WriteAllText(newFile, current);
                    end = (i + chunckSize < len) ? i + chunckSize : len;
                    count++;
                    current = "";
                }
            }

            fileName = Path.GetFileNameWithoutExtension(file) + chunckSize + '_' + count + Path.GetExtension(file);
            dir = Path.GetDirectoryName(file);
            newFile = Path.Combine(dir, fileName);
            File.WriteAllText(newFile, current);
        }
    }
}