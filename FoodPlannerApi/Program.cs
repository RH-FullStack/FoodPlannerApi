using Business.IService;
using Business.Services;
using Data.Contracts;
using Data.Data;
using Data.Models;
using Data.Repositories;
using FluentAssertions.Common;
using FoodPlannerApi.Controllers;
using Microsoft.EntityFrameworkCore;
internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        //Database Connection
        var connectionString = builder.Configuration.GetConnectionString("FoodPlannerDatabase");
        builder.Services.AddDbContext<PlannerContext>(options => options.UseSqlServer(connectionString));


        builder.Services.AddCors(c =>
        {
            c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        });
        builder.Services.AddScoped<RecipeRepository>();
        builder.Services.AddScoped<IngrediantsRepository>();
        builder.Services.AddScoped<WeekRepository>();
        builder.Services.AddScoped<DayRepository>();
        builder.Services.AddScoped<IRecipeService, RecipeService>();
        builder.Services.AddScoped<IIngrediantsService, IngrediantsService>();
        builder.Services.AddScoped<IWeekService, WeekService>();
        builder.Services.AddScoped<IDayService, DayService>();

        builder.Services.AddHttpClient();
        
        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseCors(builder =>
        {
            builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });

        app.UseAuthorization();

        app.MapControllers();
        
        app.Run();
    }
}