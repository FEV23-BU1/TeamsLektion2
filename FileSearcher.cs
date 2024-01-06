namespace Search;

public class FileSearcher
{
    public static void Search(string text)
    {
        DirectoryInfo directory = new DirectoryInfo("./");
        List<string> files = new List<string>();

        foreach (var file in directory.GetFiles("*.txt"))
        {
            StreamReader reader = file.OpenText();

            string fileContent = reader.ReadToEnd();
            string[] lines = fileContent.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(text))
                {
                    files.Add(file.Name + ":" + (i + 1));
                }
            }
        }

        Console.WriteLine("Search input is in the following files:");
        foreach (var file in files)
        {
            Console.WriteLine(" - " + file);
        }
    }
}
