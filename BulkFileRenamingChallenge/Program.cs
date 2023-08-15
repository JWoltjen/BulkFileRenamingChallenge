using System.Globalization;

namespace RenameFilesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.EnumerateFiles(@"C:\Users\Jeff's PC\source\repos\BulkFileRenamingChallenge\BulkFileRenamingChallenge\PrimaryChallengeFiles");

            foreach (var file in files)
            {
                Console.WriteLine(file);
            }
        }
    }
}