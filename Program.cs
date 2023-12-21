using api_team.Config;
using api_team.Extensions;
using api_team.Services;
using api_team.Services.Impl;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddHttpClient();

builder.Services.AddSwaggerGen(opt => {
    opt.SwaggerDoc("v1", new OpenApiInfo {
        Title = "Team API",
        Description = "Uma API para cadastrar times de pokemon",
        Version = "0.0.1"
    });
});

builder.Services.Configure<PokemonApiConfig>(builder.Configuration.GetSection("PokemonApiConfig"));


builder.Services.AddSingleton<IPokemonService, PokemonService>();
builder.Services.AddSingleton<ITeamService, TeamService>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.AddExceptionAdvice();

app.MapControllers();

app.Run();
