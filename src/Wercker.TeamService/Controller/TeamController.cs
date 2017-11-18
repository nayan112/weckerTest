using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Wercker.TeamService.Models;
using Wercker.TeamService.Persistence;

namespace Wercker.TeamService.Controller
{
    [Route("[controller]")]
    public class TeamController: Microsoft.AspNetCore.Mvc.Controller
    {
        readonly ITeamRepository _repository;
        public TeamController(ITeamRepository repo)
        {
            _repository = repo;
        }

        [HttpGet]
        public IActionResult GetAllTeams()
        {
            return Ok(_repository.GetTeams());
        }

        [HttpPost]
        public IActionResult CreateTeam([FromBody]Team newTeam)
        {
            _repository.Add(newTeam);

            //TODO: add test that asserts result is a 201 pointing to URL of the created team.
            //TODO: teams need IDs
            //TODO: return created at route to point to team details			
            return Created($"/teams/{newTeam.ID}", newTeam);
        }
    }
}