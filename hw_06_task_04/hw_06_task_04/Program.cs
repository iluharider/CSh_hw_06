class Program
{
    public static class TableReader
    {
        public static ILookup<string, List<string>> CreateTable(string path)
        {
            List<string> lines = File.ReadAllLines(path).ToList();
            List<List<string>> records = lines.ConvertAll(line => line.Trim().Split('\t').ToList());
            return records.ToLookup(record => record[0], record => record.Skip(1).ToList());
        }
    }
    static void Main()
    {
        var fstTxtFile = Console.ReadLine();
        var tableA = TableReader.CreateTable(fstTxtFile);
        var sndTxtFile = Console.ReadLine();
        var tableB = TableReader.CreateTable(sndTxtFile);
        foreach (var lineA in tableA)
        {
            var key = lineA.Key;
            if (tableB.Contains(key))
            {
                var lineB = tableB[key];
                foreach (var entry1 in lineA)
                {
                    foreach (var entry2 in lineB)
                    {
                        Console.WriteLine($"{key} {string.Join(" ", entry1)} {string.Join(" ", entry2)}");

                    }
                }
            }
        }
    }
}
