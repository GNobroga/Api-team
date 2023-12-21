using api_team.Models;
using api_team.ValueObjects;

namespace api_team.Services;

public interface ITeamService
{
    public Task<Team> Create(CreateTeamVO vo);

    public Dictionary<string, Team> FindAll();

    public Team FindById(string id);
}