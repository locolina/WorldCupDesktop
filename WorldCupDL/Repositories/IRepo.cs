using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCupDL.Models;

namespace WorldCupDL.Repositories
{
    public interface IRepo
    {
        Task<IList<TeamResultsAPI>> GetAll(string gender);
        Task<ISet<Player>> GetPlayers(string fifaId, string gender);
        Task<IList<Match>> GetMatches(string fifaId, string gender);
    }
}
