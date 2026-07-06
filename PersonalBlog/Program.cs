using Microsoft.EntityFrameworkCore;
using PersonalBlog.Data;
using Scalar.AspNetCore;
using PersonalBlog.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddOpenApi();
builder.Services.AddScoped<IPostService,PostService>();
builder.Services.AddScoped<ICommentService,CommentService>();
builder.Services.AddDbContext<BlogDbContext>(options =>
{    //development enviroment
    //var connectionString = builder.Configuration.GetConnectionString("PersonalBlog");
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
//The AddAuthentication service has been configured.
builder.Services.AddAuthentication("BlogCookies")
    .AddCookie("BlogCookies", options =>
    {
        options.LoginPath = "/Admin/Login";
        options.LogoutPath = "/Admin/Logout";
        options.ExpireTimeSpan = TimeSpan.FromDays(7);
    });


var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    app.UseHttpsRedirection();
}

app.UseStaticFiles();



app.UseAuthentication();//Who you are

app.UseAuthorization();//do you have authorization

app.MapRazorPages();

app.MapControllers();

app.Run();
