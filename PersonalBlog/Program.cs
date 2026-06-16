using Microsoft.EntityFrameworkCore;
using PersonalBlog.Data;
using Scalar.AspNetCore;
using PersonalBlog.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddOpenApi();
builder.Services.AddScoped<PostService>();
builder.Services.AddDbContext<BlogDbCotext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("PersonalBlog");
    options.UseNpgsql(connectionString);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
{
if (app.Environment.IsDevelopment())
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllers();

app.Run();
