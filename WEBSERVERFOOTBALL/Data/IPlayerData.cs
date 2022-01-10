using System.Collections.Generic;
using System.Threading.Tasks;
using WEBSERVERFOOTBALL.Models;

namespace WEBSERVERFOOTBALL.Data
{
    public interface IPlayerData
    {
        Task AddPlayer(Player addPlayer, string teamName);
        Task DeletePlayer(int playerId);
    }
}