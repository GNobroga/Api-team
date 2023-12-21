namespace api_team.Models;

public class Team 
{
    public string? Owner { get; set; }

    public List<Pokemon> Pokemons { get; set; } = new();
}