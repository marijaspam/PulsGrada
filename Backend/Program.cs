using PulsGrada.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSingleton<ILokalService, MockLokalService>();
builder.Services.AddSingleton<IDogadajService, MockDogadajService>();
builder.Services.AddSingleton<IRecenzijaService, MockRecenzijaService>();
builder.Services.AddSingleton<IKategorijaService, MockKategorijaService>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
