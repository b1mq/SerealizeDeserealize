namespace Serealize.Domain.Entities
{
    public sealed record Magazine(string Name,string Publisher,int Year,List<Article> Articles)
    {
        public void DisplayMagazine() 
        {
            Console.WriteLine(Name);
            Console.WriteLine(Publisher);
            Console.WriteLine(Year);
            Console.WriteLine("Articles: ");
            Articles.ForEach(x => Console.WriteLine(x));

        }
        public void AddArticle(Article article) => Articles.Add(article);   
        public void AddArticle(string title,string autor,int year,int countofpages,string desc) => Articles.Add( new Article (title, autor,year,countofpages,desc));
        public void RemoveArticle(Article article) => Articles.Remove(article);
        public void RemoveArticle(string name) => Articles.RemoveAll(x => x.Title == name);
        public bool IsInMagazine(Article article) => Articles.Contains(article);
        public Article FindArticle(string title) => Articles.First(x => x.Title == title);
        public int GetCountOfArticlesInMagazine() => Articles.Count();
        public int GetCountOfPagesInMagazine() => Articles.Sum(x => x.CountOfPages);
    
    
    }
 
}
