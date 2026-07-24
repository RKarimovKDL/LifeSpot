var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => Results.Content(
    File.ReadAllText(Path.Combine(app.Environment.ContentRootPath, "index.html")),
    "text/html; charset=utf-8"));

app.MapGet("/about", () => Results.Content(
    File.ReadAllText(Path.Combine(app.Environment.ContentRootPath, "about.html")),
    "text/html; charset=utf-8"));

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

app.Run();
