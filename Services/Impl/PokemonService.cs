using api_team.Config;
using api_team.Models;
using api_team.Services;
using api_team.Utils;
using Microsoft.Extensions.Options;

namespace api_team.Services.Impl;

public class PokemonService : IPokemonService
{

    private readonly IOptions<PokemonApiConfig> _pokemonApiConfig;

    private readonly IHttpClientFactory _httpClientFactory;

    public PokemonService(IOptions<PokemonApiConfig> pokemonApiConfig, IHttpClientFactory httpClientFactory)
    {
        _pokemonApiConfig = pokemonApiConfig;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<Pokemon> FindByName(string name)
    {
        var httpClient = _httpClientFactory.CreateClient();

        var response = await httpClient.GetAsync($"{_pokemonApiConfig.Value.Url}/{name}");

        if (!response.IsSuccessStatusCode)
            throw new APIException($"The pokemon with the name '{name}' does not exist");

        var pokemon = await response.Content.ReadFromJsonAsync<Pokemon>()
            ?? throw new APIException("An error occurred during the conversion of JSON to Pokemon");

        return pokemon;
    }
}