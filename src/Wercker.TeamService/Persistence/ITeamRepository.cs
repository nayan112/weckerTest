using System.Collections.Generic;
using Wercker.TeamService.Models;

namespace Wercker.TeamService.Persistence
{
  public interface ITeamRepository {
       IEnumerable<Team> GetTeams();
       void AddTeam(Team team);
      Team Add(Team newTeam);
  }
}
  