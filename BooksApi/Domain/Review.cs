using System;
using BooksApi.Domain.ValueObjects;

namespace BooksApi.Domain
{
    public class Review
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ReviewBody { get; set; }
        public UserRating Rating { get; set; }
        public string BookId { get; set; }
    }
}
