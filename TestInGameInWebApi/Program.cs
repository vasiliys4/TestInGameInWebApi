using Microsoft.EntityFrameworkCore;
using TestInGameInWebApi;
using TestInGameInWebApi.Model;

var builder = WebApplication.CreateBuilder();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

// Add services to the container.

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGet("/weatherforecast", (ApplicationContext db) => db.Authors.ToList());
app.MapGet("/weatherforecast/{id}", (ApplicationContext db, int id ) => db.Authors.FirstOrDefault(x => x.AuthorId == id));

app.MapPost("/weatherforecast", (Author author, ApplicationContext db) =>
{
    db.Authors.Add(author);
    db.SaveChanges();
});

app.MapPut("/weatherforecast" , (ApplicationContext db, Author author) =>
{
    var s = db.Authors.FirstOrDefault(x => x.AuthorId == author.AuthorId);
    if (s is not null)
    {
        s.AuthorId = author.AuthorId;
        s.Name = author.Name;
        s.Birthday = author.Birthday;
        db.Authors.Update(s);
        db.SaveChanges();
    }
});

app.MapDelete("/weatherforecas/{id}", (int id, ApplicationContext db) =>
{
    var VremenPerem = db.Authors.FirstOrDefault(x => x.AuthorId == id);
    if (VremenPerem is null) return;
    db.Authors.Remove(VremenPerem);
    db.SaveChanges();
});


app.Run();

