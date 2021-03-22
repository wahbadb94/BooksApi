using BooksApi.Domain.Exceptions;
using ValueOf;

namespace BooksApi.Domain.ValueObjects
{
    // wrapper around 'int' type to validate user ratings are between 1 - 5 inclusive
    public class UserRating : ValueOf<int, UserRating>
    {
        protected override void Validate()
        {
            if (Value < 1 || Value > 5)
            {
                throw new InvalidUserRatingException(Value);
            }
        }
    }
}
