

using Serealize.Domain.Entities;

//var songA = new Song("Magnolia", "PlayBoy Carti", 2.52);
//var songB = new Song("Void", "Poloko", 3.51);
//List<Song> MySongs = new List<Song> { songA, songB };
//var AlbumA = new Album("MyAlbum", MySongs, 2025);
//var MyManager = new AlbumManagaer()
//{
//    Name = "Carti Collection",
//    Albums = new List<Album> { AlbumA }
//};
////MyManager.SaveAlbumsInJson(MyManager,@"C:/Users/Admin/Desktop/Receipt", "Album");
//MyManager.LoadAlbumsFromJson(@"C:/Users/Admin/Desktop/Receipt", "Album");

var fp = new FakePerson();
var s = fp.GeneratePerson();
Console.WriteLine(s);