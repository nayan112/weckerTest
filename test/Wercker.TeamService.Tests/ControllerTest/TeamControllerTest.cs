using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Wercker.TeamService.Controller;
using Wercker.TeamService.Models;
using Wercker.TeamService.Persistence;
using Xunit;

namespace Wercker.TeamService.Tests.ControllerTest
{
    public class TeamControllerTest
    {
        [Fact]
        public void QueryTeamListReturnsCorrectTeams()
        {
            var controller = new TeamController(new MemoryTeamRepository());
            var rawTeams = (IEnumerable<Team>)(controller.GetAllTeams() as ObjectResult).Value;
            var teams = new List<Team>(rawTeams);
            Assert.Equal(teams.Count, 1);
            controller.CreateTeam(new Team("one"));
            controller.CreateTeam(new Team("two"));
            rawTeams = (IEnumerable<Team>)(controller.GetAllTeams() as ObjectResult).Value;
            teams = new List<Team>(rawTeams);
            Assert.Equal(teams.Count, 3);
            Assert.Equal(teams[1].Name, "one");
            Assert.Equal(teams[2].Name, "two");
        }

        [Fact]
        public void CreateTeamAddsTeamToList()
        {
            var controller = new TeamController(new MemoryTeamRepository());
            var teams = (IEnumerable<Team>)(controller.GetAllTeams() as ObjectResult).Value;
            var original = new List<Team>(teams);

            var t = new Team("sample");
            var result = controller.CreateTeam(t);
            //TODO: also assert that the destination URL of the new team reflects the team's GUID
            Assert.Equal((result as ObjectResult).StatusCode, 201);

            var actionResult = controller.GetAllTeams() as ObjectResult;
            var newTeamsRaw = (IEnumerable<Team>)(controller.GetAllTeams() as ObjectResult).Value;
            var newTeams = new List<Team>(newTeamsRaw);
            Assert.Equal(newTeams.Count, original.Count + 1);
            var sampleTeam = newTeams.FirstOrDefault(target => target.Name == "sample");
            Assert.NotNull(sampleTeam);
        }
    }
}
