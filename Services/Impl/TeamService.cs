using System.Text;
using System.Text.Json;
using api_team.Config;
using api_team.Models;
using api_team.Services;
using api_team.Utils;
using api_team.ValueObjects;
using Microsoft.Extensions.Options;

namespace api_team.Services.Impl;

public class TeamService : ITeamService
{

    private readonly IPokemonService _pokemonService;

    private readonly Dictionary<string, Team> _teams = new();

    private readonly string PERSISTENCE_UNIT_PATH;

    public TeamService(IPokemonService pokemonService, IConfiguration configuration)
    {
        _pokemonService = pokemonService;
        PERSISTENCE_UNIT_PATH = Path.Join(AppDomain.CurrentDomain.BaseDirectory, configuration["PersistenceUnit"]);
        LoadTeams();
    }

    public async Task<Team> Create(CreateTeamVO vo)
    {
        var newId = _teams.Count + 1;

        List<Pokemon> pokemons = new();

        foreach(var name in vo.Team)
        {
            pokemons.Add(await _pokemonService.FindByName(name));
        }

        var newTeam = new Team { Owner = vo.User, Pokemons = pokemons };

        _teams.Add(newId.ToString(), newTeam);

        await SaveTeams();

        return newTeam;
    }

    public Dictionary<string, Team> FindAll() => _teams;

    public Team FindById(string id)
    {
        return _teams.FirstOrDefault(entries => entries.Key == id).Value ??
            throw new APIException($"There is not team with specified Id {id}");
    }

    private void LoadTeams()
    {
        var document = JsonSerializer.Deserialize<JsonDocument>(
            File.ReadAllText(PERSISTENCE_UNIT_PATH, Encoding.UTF8)
        )!;

        document.RootElement
            .EnumerateObject()
            .ToList()
            .ForEach(property => {
                var propertyName = property.Name;
                var element = document.RootElement.GetProperty(propertyName);
                _teams.Add(propertyName, element.Deserialize<Team>(
                   new JsonSerializerOptions {
                        PropertyNameCaseInsensitive = true
                    }
                )!);
            });
    }


    private async Task SaveTeams()
    {
        await File.WriteAllTextAsync(PERSISTENCE_UNIT_PATH, 
            JsonSerializer.Serialize(_teams), Encoding.UTF8);
    }
}