var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => Results.Content(
    File.ReadAllText(Path.Combine(app.Environment.ContentRootPath, "index.html")),
    "text/html; charset=utf-8"));

app.MapGet("/about", () =>
{
    var page = File.ReadAllText(
        Path.Combine(app.Environment.ContentRootPath, "about.html"));
    var slider = File.ReadAllText(Path.Combine(
        app.Environment.ContentRootPath, "Views", "Shared", "slider.html"));

    return Results.Content(
        page.Replace("<!--SLIDER-->", slider),
        "text/html; charset=utf-8");
});

app.MapGet("/Static/CSS/index.css", () => Results.Content(
    File.ReadAllText(Path.Combine(
        app.Environment.ContentRootPath, "Static", "CSS", "index.css")),
    "text/css; charset=utf-8"));

app.MapGet("/Static/JS/index.js", () => Results.Content(
    File.ReadAllText(Path.Combine(
        app.Environment.ContentRootPath, "Static", "JS", "index.js")),
    "text/javascript; charset=utf-8"));

app.MapGet("/Static/JS/about.js", () => Results.Content(
    File.ReadAllText(Path.Combine(
        app.Environment.ContentRootPath, "Static", "JS", "about.js")),
    "text/javascript; charset=utf-8"));

app.MapGet("/Static/Images/{fileName}", (string fileName) =>
{
    var safeFileName = Path.GetFileName(fileName);
    var imagePath = Path.Combine(
        app.Environment.ContentRootPath, "Static", "Images", safeFileName);

    return File.Exists(imagePath)
        ? Results.File(imagePath, "image/svg+xml")
        : Results.NotFound();
});

app.Run();
