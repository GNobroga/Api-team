using System.ComponentModel.DataAnnotations;

namespace api_team.ValueObjects;

public record CreateTeamVO(
    [Required(ErrorMessage = "The user is required to create a team")]
    string User, 
    [MinLength(1, ErrorMessage = "The team needs a minimum of {1} team member")]
    List<string> Team
);