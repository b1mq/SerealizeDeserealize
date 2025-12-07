using System.Text.Encodings.Web;
using System.Text.Json;

namespace Serealize.Domain.Entities
{
    public  class AlbumManagaer
    {
        public required string Name { get; set; }
        public required List<Album> Albums { get; set; } = new List<Album>();
        public void DisplayAlbums() => Albums.ForEach(album => album.DisplayAlbum());
        public void AddAlbum(Album a) => Albums.Add(a);
        public void AddAlbum(string name,List<Song> songs,int year) => Albums.Add(new Album(name,songs,year));
        public void RemoveAlbum(Album a) => Albums.Remove(a);
        public void RemoveAlbum(string name) => Albums.RemoveAll(a => a.Name == name );

        public void SaveAlbumsInJson(AlbumManagaer manager,string directory,string filename)
        {

            if (Directory.Exists(directory))
            {
                string path = Path.Combine(directory, filename + ".json");
                string json = JsonSerializer.Serialize(manager, new JsonSerializerOptions
                {
                    WriteIndented = true,                    
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping

                });
                File.WriteAllText(path, json);
            }
            else
            {
                throw new DirectoryNotFoundException($"Directory not found {directory}");
            }
        }
        public void LoadAlbumsFromJson(string directory,string filename)
        {
            string path = Path.Combine(directory, filename + ".json");
            if (File.Exists(path))
            {
                var content = File.ReadAllText(path);
                var manager = JsonSerializer.Deserialize<AlbumManagaer>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true   
                });
            }
        }
    }
}
