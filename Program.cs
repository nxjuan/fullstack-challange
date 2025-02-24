using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using pinterestapi.DataContext;
using pinterestapi.Service.Equipes;
using pinterestapi.Service.EquipeService;
using pinterestapi.Service.ProjetoService;
using pinterestapi.Service.TarefaService;
using pinterestapi.Service.UsuarioService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Gira API",
        Version = "v1",
        Description = "API para gerenciamento, equipes, projetos e tarefas.",
    });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
        .LogTo(Console.WriteLine, LogLevel.Information);
});

builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IEquipeService, EquipeService>();
builder.Services.AddScoped<IProjetoService, ProjetoService>();
builder.Services.AddScoped<ITarefaService, TarefaService>();

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("apicors", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Pinterest API v1");
    options.RoutePrefix = string.Empty; // Deixa o Swagger disponível na raiz `/`
});

app.UseRouting();
app.MapControllers();
app.UseHttpsRedirection();

app.UseCors("apicors");

app.Run();

