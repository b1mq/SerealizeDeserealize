using System.Text.Json;

namespace Serealize.Domain.Entities
{
    public class FakePerson
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        private string _path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "..", "..", "Domain", "Entities", "DataBlank/");
        public FakePerson()
        {
            Name = string.Empty;
            Surname = string.Empty;
            Age = 0;
            Email = string.Empty;
            Adress = string.Empty;
        }
        public FakePerson(string name, string surname, int age, string email, string adress)
        {
            Name = name;
            Surname = surname;
            Age = age;
            Email = email;
            Adress = adress;
        }
        private  string GetPath() => _path; 
        public  FakePerson GeneratePerson()
        {
            var Names = File.ReadAllText(GetPath() + "Names.json");
            var Surnames = File.ReadAllText(GetPath() + "Surnames.json");
            var Ages = File.ReadAllText(GetPath() + "Ages.json");
            var Emails = File.ReadAllText(GetPath() + "Emails.json");
            var Adresses = File.ReadAllText(GetPath() + "Adress.json");
            var JsonNames = JsonSerializer.Deserialize<List<string>>(Names);
            var JsonSurnames = JsonSerializer.Deserialize<List<string>>(Surnames);
            var JsonAges = JsonSerializer.Deserialize<List<int>>(Ages);
            var JsonEmails = JsonSerializer.Deserialize<List<string>>(Emails);
            var JsonAdresses = JsonSerializer.Deserialize<List<string>>(Adresses);
            Random rand = new Random();
            return new FakePerson(JsonNames![rand.Next(0,JsonNames.Count)], JsonSurnames![rand.Next(0, JsonSurnames.Count)], JsonAges![rand.Next(0,JsonAges.Count)], JsonEmails![rand.Next(0, JsonEmails.Count)], JsonAdresses![rand.Next(0, JsonAdresses.Count)]);
        }
        public void SavePersonInJson()
        {
            var Json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
            string FullPath = GetPath() + "Person.json";
            File.WriteAllText(FullPath, Json);
        }
        public void SavePersonInJson(FakePerson person)
        {
            person.SavePersonInJson();
        }
        public override string ToString()
        {
            return $"Name :{Name}\nSurname :{Surname}\nAge :{Age}\nAdress :{Adress}\nEmail :{Email}";
        }
    }
}
