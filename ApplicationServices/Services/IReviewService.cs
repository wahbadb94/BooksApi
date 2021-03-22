using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationServices.Common;
using Domain;

namespace ApplicationServices.Services
{
    public interface IReviewService
    {
        public Task<Result<IList<Review>>> GetAllReviewsByBookAsync(string bookId);
        public Task<Result<Review>> GetReviewById(string reviewId);
        public Task<Result<Review>> CreateReviewAsync(Review newReview);
    }
}
