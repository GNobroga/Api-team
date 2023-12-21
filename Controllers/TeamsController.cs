using api_team.Models;
using api_team.Services;
using api_team.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace api_team.Controllers;

[Consumes("application/json")]
[Produces("application/json")]
[ApiController]
[Route("api/[controller]")]
public class TeamsController : ControllerBase
{   
    private readonly ITeamService _teamService;

    public TeamsController(ITeamService teamService)
    {
        _teamService = teamService;
    }

    [HttpGet]
    public ActionResult<Dictionary<string, Team>> FindAll() => _teamService.FindAll();
    
    [HttpGet("{id:regex(^\\d+$)}")]
    public ActionResult<Team> FindById(string id) => _teamService.FindById(id);

    [HttpPost]
    public async Task<ActionResult<Team>> Post(CreateTeamVO vo) => await _teamService.Create(vo);
 

}