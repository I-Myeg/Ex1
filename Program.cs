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

        string EngPassword = ConvertToEnglishLayout(password);
        
        Console.WriteLine("Полученный пароль в русской раскладке: " + password);
        
        Console.WriteLine("Полученный пароль в английской раскладке: " + EngPassword);
    }

    static string GeneratePassword(string[] words)
    {
        Random random = new Random();
        
        string[] selectedWords = words.OrderBy(w => random.Next()).Take(random.Next(3, 5)).ToArray();
        
        string password = string.Join("", selectedWords.Select(w => w.Substring(0, Math.Min(3, w.Length))));

        return password;
    }

    static string ConvertToEnglishLayout(string password)
    {
        Dictionary<char, char> layoutMapping = new Dictionary<char, char>
        {
            { 'а', 'f' }, { 'б', ',' }, { 'в', 'd' }, { 'г', 'u' }, { 'д', 'l' },
            { 'е', 't' }, { 'ё', '`' }, { 'ж', ';' }, { 'з', 'p' }, { 'и', 'b' },
            { 'й', 'q' }, { 'к', 'r' }, { 'л', 'k' }, { 'м', 'v' }, { 'н', 'y' },
            { 'о', 'j' }, { 'п', 'g' }, { 'р', 'h' }, { 'с', 'c' }, { 'т', 'n' },
            { 'у', 'e' }, { 'ф', 'a' }, { 'х', '[' }, { 'ц', 'w' }, { 'ч', 'x' },
            { 'ш', 'i' }, { 'щ', 'o' }, { 'ъ', 'm' }, { 'ы', 's' }, { 'ь', '\'' },
            { 'э', ']' }, { 'ю', '.' }, { 'я', 'z' }, { ' ', ' ' }
        };

        return new string(password.ToLower().ToCharArray().Select(c =>
            layoutMapping.ContainsKey(c) ? layoutMapping[c] : c).ToArray());
    }
    
}