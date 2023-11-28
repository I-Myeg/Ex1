class Ex1
{
    static void Main()
    {
        string filePath = @"C:\Users\litpu\OneDrive\Desktop\Words.txt";

        string[] words = File.ReadAllLines(filePath);

        if (words.Length < 3)
        {
            Console.WriteLine("В файле должно быть как минимум 3 слова");
            return;
        }

        string password = GeneratePassword(words);
        
        Console.WriteLine("Полученный пароль: " + password);
    }

    static string GeneratePassword(string[] words)
    {
        Random random = new Random();
        
        string[] selectedWords = words.OrderBy(w => random.Next()).Take(random.Next(3, 5)).ToArray();
        
        string password = string.Join("", selectedWords.Select(w => w.Substring(0, Math.Min(3, w.Length))));

        return password;
    }
}