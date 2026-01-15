var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapPost("/process", async (HttpContext ctx) =>
{
    var request = await ctx.Request.ReadFromJsonAsync<MyRequest>();

    if (request is null)
        return Results.BadRequest(new { error = "Invalid JSON" });

    var response = new MyResponse(
        Message: $"Hello {request.Name}, your value was {request.Value}"
    );

    return Results.Json(response);
});

app.Run();

public record MyRequest(string Name, int Value);
public record MyResponse(string Message);