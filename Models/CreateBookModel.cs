namespace Library.API.Models
{
    public class CreateBookModel
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int NumberOfPages { get; set; }
        public string Description { get; set; }
    }
}
