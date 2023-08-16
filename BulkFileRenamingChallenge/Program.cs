using System.Globalization;
using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace RenameFilesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.EnumerateFiles(@"C:\Users\Jeff's PC\source\repos\BulkFileRenamingChallenge\BulkFileRenamingChallenge\PrimaryChallengeFiles");

            // file - \PrimaryChallengeFiles\acme by inc.txt
            // fileName - acme by acme inc
            // filePath - \BulkFileRenamingChallenge\PrimaryChallengeFiles
            // fileExtension - .txt

            foreach (var file in files)
            {
                string fileName = Path.GetFileNameWithoutExtension(file);
                string filePath = Path.GetDirectoryName(file);
                string fileExtension = Path.GetExtension(file);

                string newFileName = Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(fileName.ToLower());

                // by putting spaces around the thing to replace and the thing replacing, it will only replace cases where it is the entire word, not a portion of a random string
                newFileName = newFileName.Replace(" acme ", " JeffCo ", StringComparison.InvariantCultureIgnoreCase);

                if (newFileName.StartsWith("acme ", StringComparison.InvariantCultureIgnoreCase))
                {
                    newFileName = "JeffCo " + newFileName.Substring(5);
                }
                if (newFileName.EndsWith(" acme", StringComparison.InvariantCultureIgnoreCase))
                {
                    newFileName = newFileName.Substring(0, newFileName.Length - 5) + " JeffCo";
                }

                File.Move(file, Path.Combine(filePath, newFileName + fileExtension));
            }

            // Bonus Challenge
            var bonusFiles = Directory.EnumerateFiles(@"C:\Users\Jeff's PC\source\repos\BulkFileRenamingChallenge\BulkFileRenamingChallenge\BonusChallengeFiles\");

            foreach (var file in bonusFiles)
            {
                string filePath = Path.GetDirectoryName(file);
                string fileExtension = Path.GetExtension(file);
                // this is a performant way of grabbing the first line and disposing of the object
                string line1 = File.ReadLines(file).First();

                string newFullNameAndPath = Path.Combine(filePath, line1+ fileExtension);

                // this doesn't create duplicates, that's File.Copy, this will only move them
                File.Move(file, newFullNameAndPath);
            }
        }
    }
}