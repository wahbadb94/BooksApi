namespace BooksApi.Contracts
{
    public class ReviewRequest
    {
        public string Name { get; set; }
        public string ReviewBody { get; set; }
        public int Rating { get; set; }
        public string BookId { get; set; }
    }
}
