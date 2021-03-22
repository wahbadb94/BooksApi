using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BooksApi.Domain;
using BooksApi.Infrastructure.Common;

namespace BooksApi.Infrastructure.Services
{
    public interface IReviewService
    {
        public Task<Result<IList<Review>>> GetAllReviewsByBookAsync(string bookId);
        public Task<Result<Review>> GetReviewById(Guid reviewId);
        public Task<Result<Review>> CreateReviewAsync(Review newReview);
    }
}
