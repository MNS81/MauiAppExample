using System.Text;

namespace MauiAppExample
{
    internal class Words
    {
        public List<String> words = new List<String>();
        public Words()
        {
            string path = Path.Combine(FileSystem.Current.AppDataDirectory, "words.db");   // Универсальный доступ к файлу
            if (!File.Exists(path))     // Копирование файла из ресурсов, если он отсутствует в целевой директории
            {
                using var source = FileSystem.OpenAppPackageFileAsync("words.db").Result;
                using var destination = File.Create(path);
                source.CopyTo(destination);
            }
            using (StreamReader sr = new StreamReader(path, Encoding.UTF8))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    words.Add(line.ToUpper().Replace("Ё", "Е"));
                }
            }
        }
    }
}
