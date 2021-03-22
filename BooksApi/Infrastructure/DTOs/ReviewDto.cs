using System;

namespace BooksApi.Infrastructure.DTOs
{
    public class ReviewDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ReviewBody { get; set; }
        public int Rating { get; set; }
        public string BookId { get; set; }
    }
}
