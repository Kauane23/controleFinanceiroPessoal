using controleFinanceiro.Data;
using controleFinanceiro.Profiles;
using controleFinanceiro.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Banco de dados (MySQL)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException(
        "A connection string 'DefaultConnection' não foi encontrada no appsettings.json.");
}

var serverVersion = new MySqlServerVersion(new Version(8, 0, 36));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, serverVersion));

// AutoMapper
builder.Services.AddAutoMapper(config => config.AddProfile<AppProfile>());

// Services
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<ContaService>();
builder.Services.AddScoped<CategoriaService>();
builder.Services.AddScoped<MovimentacaoService>();

// Controllers
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.WriteIndented = true;
});

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
    {
        Title = "Api de Controle Financeiro",
        Version = "v1",
        Description = "Api desenvolvida em ASP.NET Core para Controle Financeiro"
    });
});

var app = builder.Build();

// Tratamento de erros: evita a API "morrer" sem explicação.
// ArgumentException (ex.: "Usuário não encontrado") vira 400.
// Qualquer outro erro vira 500, e no ambiente de desenvolvimento mostra o motivo.
app.Use(async (context, next) =>
{
    try
    {
        await next();
    }
    catch (ArgumentException ex)
    {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;
        await context.Response.WriteAsJsonAsync(new { Mensagem = ex.Message });
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "Erro não tratado");

        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await context.Response.WriteAsJsonAsync(new
        {
            Mensagem = "Erro interno no servidor",
            Detalhe = app.Environment.IsDevelopment()
                ? (ex.InnerException?.Message ?? ex.Message)
                : null
        });
    }
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();