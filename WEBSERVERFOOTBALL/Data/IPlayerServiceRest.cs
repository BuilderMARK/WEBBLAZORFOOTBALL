using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WEBSERVERFOOTBALL.Models;

namespace WEBSERVERFOOTBALL.Data
{
    
    
    public class IPlayerServiceRest : IPlayerData
    {
        private HttpClient client;
        private string uri = "https://localhost:5001/Player";

        public IPlayerServiceRest()
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
            client = new HttpClient(clientHandler);
        }

        public async Task<IList<Player>> ReadAllPlayers()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(uri);
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception($@"Error: {responseMessage.ReasonPhrase}");
            }

            string result = await responseMessage.Content.ReadAsStringAsync();
            IList<Player> players = JsonSerializer.Deserialize<IList<Player>>(result, new JsonSerializerOptions{ PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            return players;
        }

        public async Task<Player> AddPlayer(Player addPlayer, string team)
        {
            string teamJson = JsonSerializer.Serialize(addPlayer);
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
            Player returnDeserialize = JsonSerializer.Deserialize<Player>(result, new JsonSerializerOptions{ PropertyNamingPolicy = JsonNamingPolicy.CamelCase});
            Console.WriteLine(addPlayer+ " " + "Team Name " + team);
            return returnDeserialize;
        
        }

        public Task DeletePlayer(int deletePlayer)
        {
            throw new System.NotImplementedException();
        }
    }
}