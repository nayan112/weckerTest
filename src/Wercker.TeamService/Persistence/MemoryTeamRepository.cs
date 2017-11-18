using System.Collections.Generic;
using Wercker.TeamService.Models;

namespace Wercker.TeamService.Persistence
{
    public class MemoryTeamRepository : ITeamRepository
    {
        protected static ICollection<Team> Teams;

        public MemoryTeamRepository()
        {
            if (Teams == null)
            {
                Teams = new List<Team>();
            }
        }

        public MemoryTeamRepository(ICollection<Team> teams)
        {
            Teams = teams;
        }

        public IEnumerable<Team> GetTeams()
        {
            return Teams;
        }

        public void AddTeam(Team t)
        {
            Teams.Add(t);
        }
        public Team Add(Team team)
        {
            Teams.Add(team);
            return team;
        }
    }
}
