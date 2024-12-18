using FluentValidation;
using FluentValidation.AspNetCore;
using Validation.Models;
using Validation.Validation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IValidator<CreateUserModel>, UserValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var users = new List<CreateUserModel>();

app.MapPost("/create", async (IValidator<CreateUserModel> validator, CreateUserModel user) =>
{
    var validationResult = await validator.ValidateAsync(user);
    if (!validationResult.IsValid)
    {
        Console.WriteLine("Passou");
        return Results.ValidationProblem(validationResult.ToDictionary());
    }

    users.Add(user);
    return Results.Created($"/user", user);
});

app.UseHttpsRedirection();


app.Run();