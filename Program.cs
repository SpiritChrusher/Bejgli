var builder = WebApplication.CreateBuilder(args);

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

app.MapPost("/christmas", ([FromBody] ChristmasTextRequest request) =>
{
    if(request is null) {
        return Results.BadRequest("Invalid request");
    }

    var numberOfTexts = request.MaxNumber > 1 ? request.MaxNumber : 42;

    var christmasTexts = Enumerable.Repeat(
        request.ChristmasText ?? "Bad user", Random.Shared.Next(2, numberOfTexts))
        .ToList();
    return Results.Ok(new ChrismasTextsDto(christmasTexts));
})
.WithName("GeChristmasText")
.WithOpenApi();

app.Run();

record ChristmasTextRequest(string? ChristmasText, int MaxNumber);
record ChrismasTextsDto(List<string> ChrismasTexts);