namespace Serealize.Domain.Entities
{
    public sealed record Album(string Name, List<Song> Songs, int Year)
    {
        public void DisplayAlbum()
        {
            Console.WriteLine($"Album:{Name}");
            Console.WriteLine("Song:");
            Songs.ForEach(s => Console.WriteLine(s));
            Console.WriteLine($"Year:{Year}");
        }
        public void AddSong(Song s) => Songs.Add(s);
        public void AddSong(string name,string autor,double duration) => Songs.Add(new Song(name,autor,duration));
        public void RemoveSong(Song s) => Songs.Remove(s);
        public void RemoveSong(string name) => Songs.RemoveAll(s => s.Name == name);
        public double GetAlbumDuration() => Songs.Sum(s => s.Duration);
        public void Clear() => Songs.Clear();
        public int GetCountOfSongs() => Songs.Count;

    };
}
