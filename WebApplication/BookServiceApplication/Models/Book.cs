namespace BookServiceApplication.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public Book()
        {
            // Default constructor
        }

        public Book(int id, string title, string author)
        {
            Id = id;
            Title = title;
            Author = author;
        }
    }
}