using api_team.Models;

namespace api_team.Services;

public interface IPokemonService
{
    public Task<Pokemon> FindByName(string name);
}