<Query Kind="Program" />

void Main()
{
	List<Book> bookList = new List<Book>()
	{
		new Book("Les Miserables", "Victor Hugo", 1862), 
		new Book("L'Etranger", "Albert Camus", 1942), 
		new Book("Madame Bovary", "Gustave Flaubert", 1857), 
		new Book("Notre-Dame de Paris", "Victor Hugo", 1831), 
		new Book("Vingt mille lieues sous les mers", "Jules Verne", 1872), 
		new Book("Le Tour du monde en quatre-vingts jours", "Jules Verne", 1869), 
		new Book("Voyage au centre de la Terre", "Jules Verne", 1864)
	}; 
	
	Book book4 = new Book("Le Comte de Monte-Cristo", "Alexandre Dumas", 1844); 
	bookList.Add(book4); 
	
	Book book5 = new Book("MyStriving", "Yaolin Ge", 2024); 
	bookList.Add(book5); 
	
	var subList = bookList.Where(p => p.Author=="Jules Verne" || p.Author == "Victor Hugo").OrderBy(p => p.Author).ThenBy(p => p.PubDate); 
	
	Console.WriteLine($"{subList.Count()} books match your search criteria; "); 
	
	foreach(Book book in subList)
	{
		Console.WriteLine($"     {book.Author} - {book.Title} ({book.PubDate})"); 
	}
}

class Book 
{
	public string Title { get; set; }
	public string Author { get; set; }
	public int PubDate { get; set; }
	
	public Book(string title, string author, int pubDate)
	{
		Title = title; 
		Author = author; 
		PubDate = pubDate; 
	}
}
