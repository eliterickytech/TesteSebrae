using TesteSebrae.Application;
using TesteSebrae.Application.AutoMapper;
using TesteSebrae.Application.Interfaces;
using TesteSebrae.Domain.Interfaces;
using TesteSebrae.Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<ICepServices, CepServices>();
builder.Services.AddScoped<IContaServices, ContaServices>();
builder.Services.AddScoped<IContaRepository, ContaRepository>();
builder.Services.AddScoped<ICepRepository, CepRepository>();

builder.Services.AddAutoMapper(typeof(CepMapping), typeof(ContaMapping));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
