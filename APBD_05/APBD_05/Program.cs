using APBD_05.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace APBD_05;

public class Program
{
    public static List<Animal> Animals = new List<Animal>
    {
        new Animal { Id = 1, Name = "Ryszard", Category = Animal.Categories.Kot, Weight = 5, FurColor = "Brązowy" },
        new Animal { Id = 2, Name = "Fredzia", Category = Animal.Categories.Pies, Weight = 8, FurColor = "Brązowy" },
        new Animal { Id = 3, Name = "Jon Doe", Category = Animal.Categories.Chomik, Weight = 5, FurColor = "Brązowy" },
        new Animal { Id = 4, Name = "Elon", Category = Animal.Categories.Szczur, Weight = 5, FurColor = "Szary" }
    };

    public static List<Visit> Visits = new List<Visit>
    {
        new Visit
        {
            Id = 1, Date = new DateOnly(2020, 04, 14), AnimalId = 1, Description = "Cos tam cos tam", price = 100
        },
        new Visit
        {
            Id = 2, Date = new DateOnly(2020, 04, 14), AnimalId = 3, Description = "Just buy new chomik", price = 100
        },
        new Visit { Id = 3, Date = new DateOnly(2020, 04, 14), AnimalId = 2, Description = "lalala", price = 200 }
    };

    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

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

        // ANIMALS
        app.MapGet("/api/animals", () => Results.Ok(Animals)).WithName("GetAnimals").WithOpenApi();

        app.MapGet("/api/animals/{id:int}", (int id) =>
        {
            var animal = Animals.FirstOrDefault(a => a.Id == id);
            return animal == null ? Results.NotFound($"Animal with id {id} was not found") : Results.Ok(animal);
        }).WithName("GetAnimal").WithOpenApi();

        app.MapPost("/api/animals", (Animal animal) =>
        {
            Animals.Add(animal);
            return Results.Created();
        }).WithName("AddAnimal").WithOpenApi();

        app.MapPut("/api/animals/{id:int}", (int id, Animal animal) =>
        {
            var toEdit = Animals.FirstOrDefault(a => a.Id == id);
            if (toEdit == null)
            {
                return Results.NotFound($"Animal with id {id} was not found");
            }

            Animals.Remove(toEdit);
            Animals.Add(animal);
            return Results.NoContent();
        }).WithName("ModifyAnimal").WithOpenApi();

        app.MapDelete("/api/animals/{id:int}", (int id) =>
        {
            var toDelete = Animals.FirstOrDefault(a => a.Id == id);
            if (toDelete == null)
            {
                return Results.NotFound($"Animal with id {id} was not found");
            }

            Animals.Remove(toDelete);
            return Results.NoContent();
        }).WithName("DeleteAnimal").WithOpenApi();


        // VISITS
        app.MapGet("/api/visits/{id:int}", (int id) =>
        {
            var visit = Visits.FirstOrDefault(v => v.AnimalId == id);
            return visit == null ? Results.NotFound($"Visit for animal with id {id} was not found") : Results.Ok(visit);
        }).WithName("GetVisit").WithOpenApi();

        app.MapPost("/api/visits", (Visit visit) =>
        {
            if (Animals.FindIndex(a => a.Id == visit.AnimalId) == -1)
                return Results.BadRequest("Trying to add visit for animal which does not exist in database");
            Visits.Add(visit);
            return Results.Created();
        }).WithName("AddVisit").WithOpenApi();
        app.Run();
    }
}