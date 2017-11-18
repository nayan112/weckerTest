using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using Wercker.TeamService.Models;
using Xunit;

namespace Wercker.TeamService.IntegrationTests.IntegrationTest
{
    public class SimpleIntegrationTest
    {
        private readonly TestServer testServer;
        private readonly HttpClient testClient;

        private readonly Team teamZombie;

        public SimpleIntegrationTest()
        {
            testServer = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            testClient = testServer.CreateClient();

            teamZombie = new Team()
            {
                ID = Guid.NewGuid(),
                Name = "Zombie"
            };
        }

        [Fact]
        public async void TestTeamPostAndGet()
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(teamZombie),UnicodeEncoding.UTF8,"application/json");

            var postResponse =await testClient.PostAsync("/team",stringContent);
            postResponse.EnsureSuccessStatusCode();

            var getResponse = await testClient.GetAsync("/team");
            getResponse.EnsureSuccessStatusCode();

            var raw = await getResponse.Content.ReadAsStringAsync();
            var teams = JsonConvert.DeserializeObject<List<Team>>(raw);
            Assert.Equal(1, teams.Count());
            Assert.Equal("Zombie", teams[0].Name);
            Assert.Equal(teamZombie.ID, teams[0].ID);
        }


    }
}
