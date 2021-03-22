using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using BooksApi.Contracts;
using BooksApi.Domain;
using BooksApi.Domain.Exceptions;
using BooksApi.Domain.ValueObjects;
using BooksApi.Infrastructure.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        // api/reviews/1
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return (await _reviewService.GetReviewById(id))
                .Match<IActionResult>(
                    Ok,
                    error => BadRequest(error.Message));
        }

        // api/reviews?bookId=1
        [HttpGet]
        public async Task<IActionResult> GetAll(string bookId)
        {
            if (string.IsNullOrEmpty(bookId)) return BadRequest("bookId parameter is required");

            return (await _reviewService.GetAllReviewsByBookAsync(bookId))
                .Match<IActionResult>(
                    Ok,
                    error => BadRequest(error));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ReviewRequest reviewRequest)
        {
            try
            {
                // map request to domain object
                var newReview = reviewRequest.MapToReview();

                return (await _reviewService.CreateReviewAsync(newReview))
                    .Match<IActionResult>(
                        review =>
                        {
                            var baseUrl = $"{Request.Scheme}://{Request.Host.ToUriComponent()}";
                            var locationUri = $"{baseUrl}{Request.Path}/{review.Id}";
                            return Created(locationUri, review.MapToReviewResponse());
                        },
                        error => BadRequest(error));
            }
            catch (InvalidUserRatingException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

    internal static class RequestResponseMappingExtensions
    {
        internal static Review MapToReview(this ReviewRequest reviewRequest) =>
            new Review
            {
                Id = Guid.NewGuid(),
                Name = reviewRequest.Name,
                ReviewBody = reviewRequest.ReviewBody,
                Rating = UserRating.From(reviewRequest.Rating),
                BookId = reviewRequest.BookId
            };

        internal static ReviewResponse MapToReviewResponse(this Review review) =>
            new ReviewResponse()
            {
                Id = review.Id.ToString(),
                Rating = review.Rating.Value,
                Name = review.Name,
                ReviewBody = review.ReviewBody,
                BookId = review.BookId
            };
    }
}
