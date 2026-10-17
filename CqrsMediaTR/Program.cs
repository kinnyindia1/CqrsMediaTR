using CqrsMediaTR.Commands;
using CqrsMediaTR.Data;
using CqrsMediaTR.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);

// Database
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseSqlite("Data Source=notes.db"));

// MediatR — scans this project for all handlers
builder.Services.AddMediatR(cfg =>
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

var app = builder.Build();

// Create the database on startup (only for demo)
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();
}

// Endpoint: CREATE(write)
app.MapPost("/notes", async (CreateNoteCommand cmd, IMediator m) =>
{
    var id = await m.Send(cmd);
    return Results.Created($"/notes/{id}", id);
});

// Endpoint: GET by id (read)
app.MapGet("/notes/{id}", async (int id, IMediator m) =>
{
    var note = await m.Send(new GetNoteByIdQuery(id));
    return note is null ? Results.NotFound() : Results.Ok(note);
});

// Endpoint: GET all (read)
app.MapGet("/notes", async (IMediator m) =>
{
    var notes = await m.Send(new GetAllNotesQuery());
    return Results.Ok(notes);
});

app.Run();