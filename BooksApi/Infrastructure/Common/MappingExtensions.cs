using BooksApi.Domain;
using BooksApi.Domain.ValueObjects;
using BooksApi.Infrastructure.DTOs;

namespace BooksApi.Infrastructure.Common
{
    internal static class MappingExtensions
    {
        internal static Review MapToReview(this ReviewDto reviewDto) => new Review
        {
            Id = reviewDto.Id,
            BookId = reviewDto.BookId,
            Rating = UserRating.From(reviewDto.Rating),
            Name = reviewDto.Name,
            ReviewBody = reviewDto.ReviewBody
        };

        internal static ReviewDto MapToReviewDto(this Review review) => new ReviewDto
        {
            BookId = review.BookId,
            Id = review.Id,
            Rating = review.Rating,
            Name = review.Name,
            ReviewBody = review.ReviewBody
        };
    }
}