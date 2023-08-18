using Microsoft.EntityFrameworkCore;
using GameBuddiAPI;
using GameBuddiAPI.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<GameBuddiAPIContext>(options =>
    options.UseSqlServer("Data Source=tcp:gamebuddi.database.windows.net,1433;Initial Catalog=GameBuddiServer;User Id=GameBuddiAdmin@gamebuddi;Password=7T@eGHkNCJ!nPPp&"));
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureSwaggerGen(setup =>
{
    setup.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Game Buddi API",
        Version = "v2"
    });
});

var app = builder.Build();

app.UseSwagger();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.MapUserEndpoints();

app.MapReviewEndpoints();

app.MapReviewCommentEndpoints();




app.Run();
