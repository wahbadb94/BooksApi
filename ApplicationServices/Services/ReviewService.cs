using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationServices.Common;
using ApplicationServices.Data;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace ApplicationServices.Services
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext _dbContext;

        public ReviewService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //TODO: change result to ReviewServiceResult
        //  | Ok
        //  | DoesNotExistError
        //  | InternalServerError


        public async Task<Result<IList<Review>>> GetAllReviewsByBookAsync(string bookId)
        {
            try
            {
                return await _dbContext.Reviews
                    .Where(r => r.BookId == bookId)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                return new Error(e.ToString());
            }
        }

        public async Task<Result<Review>> GetReviewById(string reviewId)
        {
            try
            {
                return await _dbContext.Reviews.FindAsync(reviewId);
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
                await _dbContext.Reviews.AddAsync(newReview);
                await _dbContext.SaveChangesAsync();
                return newReview;
            }
            catch (Exception e)
            {
                return new Error(e.Message);
            }
        }
    }
}