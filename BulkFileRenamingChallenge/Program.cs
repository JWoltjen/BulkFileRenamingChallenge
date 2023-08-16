using System.Globalization;

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

                if(newFileName.StartsWith("acme ", StringComparison.InvariantCultureIgnoreCase))
                {
                    newFileName = "JeffCo " + newFileName.Substring(5);
                }
                if(newFileName.EndsWith(" acme", StringComparison.InvariantCultureIgnoreCase))
                {
                    newFileName = newFileName.Substring(0, newFileName.Length - 5) + " JeffCo";
                }

                Console.WriteLine(newFileName);
            }
        }
    }
}