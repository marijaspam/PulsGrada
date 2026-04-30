using Microsoft.EntityFrameworkCore;
using PulsGrada.Data;
using PulsGrada.Repositories;
using PulsGrada.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddScoped<ILokalRepository, LokalRepository>();
builder.Services.AddScoped<IDogadajRepository, DogadajRepository>();
builder.Services.AddScoped<IFavoritRepository, FavoritRepository>();
builder.Services.AddScoped<IRecenzijaRepository, RecenzijaRepository>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddScoped<IKategorijaRepository, KategorijaRepository>();

builder.Services.AddScoped<ILokalService, LokalService>();
builder.Services.AddScoped<IDogadajService, DogadajService>();
builder.Services.AddScoped<IFavoritService, FavoritService>();
builder.Services.AddScoped<IRecenzijaService, RecenzijaService>();
builder.Services.AddScoped<IKategorijaService, KategorijaService>();
builder.Services.AddScoped<IAuthService, AuthService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(); // Ovo generira onu stranicu koju tražiš
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
