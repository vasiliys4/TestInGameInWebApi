namespace TestInGameInWebApi.Model
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public DateTime YearOfPublication { get; set; }
        public string Genre { get; set; }        
        //public Author Authors { get; set; }
        public string Edition { get; set; }
    }
}
