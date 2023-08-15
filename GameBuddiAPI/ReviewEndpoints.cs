using Microsoft.EntityFrameworkCore;
using GameBuddiAPI.Data;
using GameBuddiAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
namespace GameBuddiAPI;

public static class ReviewEndpoints
{
    public static void MapReviewEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Review").WithTags(nameof(Review));

        group.MapGet("/", async (GameBuddiAPIContext db) =>
        {
            return await db.Review.ToListAsync();
        })
        .WithName("GetAllReviews")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Review>, NotFound>> (int id, GameBuddiAPIContext db) =>
        {
            return await db.Review.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Review model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetReviewById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, Review review, GameBuddiAPIContext db) =>
        {
            var affected = await db.Review
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, review.Id)
                  .SetProperty(m => m.GameId, review.GameId)
                  .SetProperty(m => m.PosterId, review.PosterId)
                  .SetProperty(m => m.PostDate, review.PostDate)
                  .SetProperty(m => m.Score, review.Score)
                  .SetProperty(m => m.ReviewTitle, review.ReviewTitle)
                  .SetProperty(m => m.ReviewContent, review.ReviewContent)
                  .SetProperty(m => m.ReviewReputation, review.ReviewReputation)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateReview")
        .WithOpenApi();

        group.MapPost("/", async (Review review, GameBuddiAPIContext db) =>
        {
            db.Review.Add(review);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Review/{review.Id}",review);
        })
        .WithName("CreateReview")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, GameBuddiAPIContext db) =>
        {
            var affected = await db.Review
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteReview")
        .WithOpenApi();
    }
}
