using System.Net.NetworkInformation;
using WorldCupDL.Models;
using WorldCupDL.Repositories;

namespace WorldCupDL.Managers
{
    public class InitialSetupManager
    {
        private readonly SettingsManager settingsManager = new SettingsManager();
        private readonly IRepo repo;

        private bool TestConnection => CheckConnection();

        private bool CheckConnection()
        {
            try
            {
                bool test = new Ping().Send("www.algebra.com").Status == IPStatus.Success;
                return test;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public string Gender => settingsManager.CheckForChampionshipType() ? "Men" : "Women";

        public InitialSetupManager()
        {
            repo = RepoFactory.GetRepo(TestConnection);
        }

        public Task<IList<TeamResultsAPI>> GetAll()
        {
            return repo.GetAll(Gender);
        }

        public Task<ISet<Player>> GetPlayers(string fifaId)
        {
            return repo.GetPlayers(fifaId, Gender);
        }

        public Task<IList<Match>> GetAllMatches(string fifaId)
        {
            return repo.GetMatches(fifaId, Gender);
        }
    }
}
