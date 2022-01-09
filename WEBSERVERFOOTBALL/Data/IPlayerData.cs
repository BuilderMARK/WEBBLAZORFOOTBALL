using System.Collections.Generic;
using System.Threading.Tasks;
using WEBSERVERFOOTBALL.Models;

namespace WEBSERVERFOOTBALL.Data
{
    public interface IPlayerData
    {
        Task<IList<Player>> ReadAllPlayers();
        Task<Player> AddPlayer(Player addPlayer, string team);
        Task DeletePlayer(int deletePlayer);
    }
}