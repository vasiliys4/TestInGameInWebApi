using Microsoft.EntityFrameworkCore;
using TestInGameInWebApi.Model;

List<Author> authors= new() 
{ 
    new Author()
    {
        AuthorId = 1,
        Name = "kolya",
        Birthday = DateTime.Now,
    },
    new Author() 
    {
        AuthorId = 2,
        Name = "Sanya",
        Birthday = DateTime.MinValue,
    }
};

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
//app.MapGet("/weatherforecast", () => authors.ToList());
//app.MapGet("/weatherforecast/{id}", (int id) => authors.FirstOrDefault(x => x.AuthorId == id));

//app.MapPost("/weatherforecast", (Author ) => authors.Add(author));
app.MapPost("/weatherforecast", (Author author, ApplicationContext db) =>
{
    db.Authors.Add(author);
    db.SaveChanges();
    return author;
});


//app.MapPut("/weatherforecast", (Author author) => 
//{ 
//    var s = authors.FindIndex(x =>x.AuthorId == author.AuthorId);
//    if(s < 0) return;
//    authors[s].AuthorId = author.AuthorId;
//    authors[s].Name = author.Name;
//    authors[s].Birthday= author.Birthday;
//});

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

//app.MapDelete("/weatherforecas/{id}", (int id) => 
//{
//    var VremenPerem = authors.FindIndex(x => x.AuthorId == id);
//    if (VremenPerem < 0) return;
//    authors.RemoveAt(VremenPerem);
//});

app.MapDelete("/weatherforecas/{id}", (int id, ApplicationContext db) =>
{
    var VremenPerem = db.Authors.FirstOrDefault(x => x.AuthorId == id);
    if (VremenPerem is null) return;
    db.Authors.Remove(VremenPerem);
    db.SaveChanges();
});


app.Run();

