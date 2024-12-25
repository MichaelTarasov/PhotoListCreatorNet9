using System;
using System.IO;

class Program
{
    static void Main()
    {
        string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string rootFolder = Path.GetDirectoryName(currentDirectory) ?? throw new InvalidOperationException
        ("No root folder.");


        string[] jpgFiles = Directory.GetFiles(rootFolder, "*.jpg", SearchOption.TopDirectoryOnly);

        string outputFile = Path.Combine(rootFolder, "PhotoList.txt");

        using (var writer = new StreamWriter(outputFile))
        {
            int i = 1;
            foreach (string jpgFile in jpgFiles)
            {
                string fileName = Path.GetFileName(jpgFile);
                fileName = $"{i}. {fileName[..^4]}";
                writer.WriteLine(fileName);
                i++;
            }
        }

        Console.WriteLine("List of .jpg files saved in PhotoList.txt.");
        // Waiting for user input before program terminat
        Console.WriteLine("Press any key to complete...");
        Console.ReadLine();
    }
}
