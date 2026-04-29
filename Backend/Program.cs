using PulsGrada.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ILokalService, MockLokalService>();
builder.Services.AddSingleton<IDogadajService, MockDogadajService>();
builder.Services.AddSingleton<IRecenzijaService, MockRecenzijaService>();
builder.Services.AddSingleton<IKategorijaService, MockKategorijaService>();
builder.Services.AddSingleton<IAuthService, MockAuthService>();


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
