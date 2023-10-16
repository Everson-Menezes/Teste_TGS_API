using Teste_TGS.Interfaces;
using Teste_TGS.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient("localhost").ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }

});

// Add services to the container.

builder.Services.AddScoped<IDapperContext, DapperContext>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ILogradouroRepository, LogradouroRepositry>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
