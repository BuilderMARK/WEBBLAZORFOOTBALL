using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WEBSERVERFOOTBALL.Models;

namespace WEBSERVERFOOTBALL.Data
{
    public class ITeamServiceRest : ITeamData
    {
        private HttpClient client;
        private string uri = "http://localhost:5000/Team";

        public ITeamServiceRest()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            }; 
            client = new HttpClient(clientHandler);
        }
        
        public async Task<IList<Team>> ReadAllTeams(int Rating, string TeamName)
        {
            HttpResponseMessage responseMessage = await client.GetAsync(uri);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($@"Error: {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();
            IList<Team> gotFamilies = JsonSerializer.Deserialize<IList<Team>>(result, new JsonSerializerOptions{ PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            return gotFamilies;
        }

        

        public async Task<Team> AddTeam(Team team)
        {
            string teamJson = JsonSerializer.Serialize(team);
            HttpContent content = new StringContent(
                teamJson,
                Encoding.UTF8,
                "application/json");
            HttpResponseMessage responseMessage = 
                await client.PostAsync(uri,content);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception(responseMessage.ReasonPhrase);
            }

            string result = await responseMessage.Content.ReadAsStringAsync();
            Team returnDeserialize = JsonSerializer.Deserialize<Team>(result, new JsonSerializerOptions{ PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            return returnDeserialize;
        }
    }
        
    }
