using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GameBuddiAPI;
using GameBuddiAPI.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<GameBuddiAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("GameBuddiAPI") ?? throw new InvalidOperationException("Connection string 'GameBuddiAPIContext' not found.")));
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapUserEndpoints();

app.MapReviewEndpoints();

app.MapReviewCommentEndpoints();




app.Run();
