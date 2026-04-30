using PulsGrada.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



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
