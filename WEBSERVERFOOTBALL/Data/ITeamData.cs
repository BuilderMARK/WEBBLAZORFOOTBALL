using System.Collections.Generic;
using System.Threading.Tasks;
using WEBSERVERFOOTBALL.Models;

namespace WEBSERVERFOOTBALL.Data
{
    public interface ITeamData
    {
        Task<IList<Team>> ReadAllTeams(int Rating, string TeamName);
        
        Task<Team> AddTeam(Team addTeam);
    }
}