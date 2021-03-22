using System;

namespace BooksApi.Domain.Exceptions
{
    public class InvalidUserRatingException : Exception
    {
        public InvalidUserRatingException(int rating)
            : base($"Provided rating of {rating} is not in range of 1 - 5") {}
    }
}