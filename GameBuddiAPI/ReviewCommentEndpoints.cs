using Microsoft.EntityFrameworkCore;
using GameBuddiAPI.Data;
using GameBuddiAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
namespace GameBuddiAPI;

public static class ReviewCommentEndpoints
{
    public static void MapReviewCommentEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/ReviewComment").WithTags(nameof(ReviewComment));

        group.MapGet("/", async (GameBuddiAPIContext db) =>
        {
            return await db.ReviewComment.ToListAsync();
        })
        .WithName("GetAllReviewComments")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<ReviewComment>, NotFound>> (int id, GameBuddiAPIContext db) =>
        {
            return await db.ReviewComment.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is ReviewComment model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetReviewCommentById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, ReviewComment reviewComment, GameBuddiAPIContext db) =>
        {
            var affected = await db.ReviewComment
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.Id, reviewComment.Id)
                  .SetProperty(m => m.ReviewId, reviewComment.ReviewId)
                  .SetProperty(m => m.PosterId, reviewComment.PosterId)
                  .SetProperty(m => m.Comment, reviewComment.Comment)
                  .SetProperty(m => m.CommentScore, reviewComment.CommentScore)
                  .SetProperty(m => m.PostDate, reviewComment.PostDate)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateReviewComment")
        .WithOpenApi();

        group.MapPost("/", async (ReviewComment reviewComment, GameBuddiAPIContext db) =>
        {
            db.ReviewComment.Add(reviewComment);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/ReviewComment/{reviewComment.Id}",reviewComment);
        })
        .WithName("CreateReviewComment")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, GameBuddiAPIContext db) =>
        {
            var affected = await db.ReviewComment
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteReviewComment")
        .WithOpenApi();
    }
}
