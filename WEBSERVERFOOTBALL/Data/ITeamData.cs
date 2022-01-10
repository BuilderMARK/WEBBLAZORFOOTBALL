using System.Collections.Generic;
using System.Threading.Tasks;
using WEBSERVERFOOTBALL.Models;

namespace WEBSERVERFOOTBALL.Data
{
    public interface ITeamData
    {
        Task AddTeam(Team team);
        Task<IList<Team>> GetTeams();
    }
}