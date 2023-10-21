using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorldCupDL.Constants;
using WorldCupDL.Models;

namespace WorldCupDL.Repositories
{
    class APIRepo : IRepo
    {
        public Task<IList<TeamResultsAPI>> GetAll(string gender)
        {
            string path = gender == "Men" ? APIConstantsMen.TEAMS : APIConstantsWomen.TEAMS;

            return Task.Run(async () =>
            {
                var apiClient = new RestClient(path);
                var apiResult = await apiClient.ExecuteAsync<IList<TeamResultsAPI>>(new RestRequest());
                return JsonConvert.DeserializeObject<IList<TeamResultsAPI>>(apiResult.Content);
            });
        }

        public Task<IList<Match>> GetMatches(string fifaId, string gender)
        {
            string path = gender == "Men" ? APIConstantsMen.MATCHES : APIConstantsWomen.MATCHES;

            return Task.Run(async () =>
            {
                var apiClient = new RestClient($"{path}{fifaId}");
                var apiResult = await apiClient.ExecuteAsync<IList<Match>>(new RestRequest());
                return Match.FromJson(apiResult.Content);
            });
        }

        public Task<ISet<Player>> GetPlayers(string fifaId, string gender)
        {
            string path = gender == "Men" ? APIConstantsMen.MATCHES : APIConstantsWomen.MATCHES;

            return Task.Run(async () =>
            {
                var apiClient = new RestClient($"{path}{fifaId}");
                var apiResult = await apiClient.ExecuteAsync<IList<Match>>(new RestRequest());
                var matches = Match.FromJson(apiResult.Content);
                return Player.GetPlayers(matches[0], matches, fifaId);
            });
        }
    }
}
