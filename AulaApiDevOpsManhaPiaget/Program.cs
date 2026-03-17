using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AulaApiDevOpsManhaPiaget.Data;
//using AulaApiDevOpsManhaPiaget.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AulaApiDevOpsManhaPiagetContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AulaApiDevOpsManhaPiagetContext") ?? throw new InvalidOperationException("Connection string 'AulaApiDevOpsManhaPiagetContext' not found.")));

//builder.Services.AddDbContext<AulaApiDevOpsManhaPiagetContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("AulaApiDevOpsManhaPiagetContext") ?? throw new InvalidOperationException("Connection string 'AulaApiDevOpsManhaPiagetContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});





var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Usar CORS
app.UseCors("AllowAll");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
