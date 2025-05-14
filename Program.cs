var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Servicios HTTP
builder.Services.AddHttpClient<CatFactService>();
builder.Services.AddHttpClient<GiphyService>();

// Servicio en memoria
builder.Services.AddSingleton<InMemoryHistoryService>(); // 👈 Añade esta línea

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();