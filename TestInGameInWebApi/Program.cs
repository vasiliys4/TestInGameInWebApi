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

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGet("/weatherforecast", () => authors.ToList());
app.MapGet("/weatherforecast/{id}", (int id) => authors.FirstOrDefault(x => x.AuthorId == id));

app.MapPost("/weatherforecast", (Author author) => authors.Add(author));

app.MapPut("/weatherforecast", (Author author) => 
{ 
    var s = authors.FindIndex(x =>x.AuthorId == author.AuthorId);
    if(s < 0) return;
    authors[s].AuthorId = author.AuthorId;
    authors[s].Name = author.Name;
    authors[s].Birthday= author.Birthday;
});

app.MapDelete("/weatherforecas/{id}", (int id) => 
{
    var VremenPerem = authors.FindIndex(x => x.AuthorId == id);
    if (VremenPerem < 0) return;
    authors.RemoveAt(VremenPerem);
    
});


app.Run();

