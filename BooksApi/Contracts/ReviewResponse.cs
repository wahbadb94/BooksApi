namespace BooksApi.Contracts
{
    public class ReviewResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ReviewBody { get; set; }
        public int Rating { get; set; }
        public string BookId { get; set; }
    }
}
