using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BooksApi.Domain;
using BooksApi.Infrastructure.Common;
using BooksApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.Infrastructure.Services
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext _dbContext;
        public ReviewService(ApplicationDbContext dbContext) => _dbContext = dbContext;

        //TODO: change result to ReviewServiceResult
        //  | Ok
        //  | DoesNotExistError
        //  | InternalServerError

        public async Task<Result<IList<Review>>> GetAllReviewsByBookAsync(string bookId)
        {
            try
            {
                return await _dbContext.Reviews
                    .Where(reviewDto => reviewDto.BookId == bookId)
                    .Select(reviewDto => reviewDto.MapToReview())
                    .ToListAsync();
            }
            catch (Exception e)
            {
                return new Error(e.ToString());
            }
        }

        public async Task<Result<Review>> GetReviewById(Guid reviewId)
        {
            try
            {
                var reviewDto = await _dbContext.Reviews.FindAsync(reviewId);
                return reviewDto.MapToReview();
            }
            catch (Exception e)
            {
                return new Error(e.ToString());
            }
        }

        public async Task<Result<Review>> CreateReviewAsync(Review newReview)
        {
            try
            {
                await _dbContext.Reviews.AddAsync(newReview.MapToReviewDto());
                await _dbContext.SaveChangesAsync();
                return newReview;
            }
            catch (Exception e)
            {
                return new Error(e.ToString());
            }
        }
    }
}