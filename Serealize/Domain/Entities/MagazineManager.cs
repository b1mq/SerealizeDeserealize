using System.Text.Encodings.Web;
using System.Text.Json;

namespace Serealize.Domain.Entities
{
    public class MagazineManager
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required List<Magazine> Magazines { get; set; }
        public void DisplayMagazines() => Magazines.ForEach(m => m.DisplayMagazine());
        public void AddMagazine(Magazine magazine) => Magazines.Add(magazine);
        public void AddMagazine(string name, string publisher, int year, List<Article> Articles) => Magazines.Add(new Magazine(name, publisher, year, Articles));
        public void RemoveMagazine(Magazine magazine ) => Magazines.Remove(magazine);
        public void RemoveMagazine(string name) => Magazines.RemoveAll(x => x.Name == name);
        public Magazine FindMagazine(string name) => Magazines.First(x => x.Name == name);
        public bool IsInMagazines(Magazine magazine) => Magazines.Contains(magazine);
        public void SerealizeInJson(MagazineManager MM,string directory,string filename)
        {
            if (Directory.Exists(directory))
            {
                string path = Path.Combine(directory, filename + ".json");
                string json = JsonSerializer.Serialize(MM, new JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping

                });
                File.WriteAllText(path, json);
            }else
            {
                throw new DirectoryNotFoundException($"Directory not found {directory}");
            }
        }
        public MagazineManager DeserealizeFromJson(string source)
        {
            if (File.Exists(source))
            {
                string content = File.ReadAllText(source);
                var json = JsonSerializer.Deserialize<MagazineManager>(content);
                return json;
            }else
            {
                throw new FileNotFoundException($"File not found {source}");
            }
        }
    }
}
