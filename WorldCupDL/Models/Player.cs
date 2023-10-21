using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using WorldCupDL.Models.Enums;

namespace WorldCupDL.Models
{
    public class Player
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("captain")]
        public bool Captain { get; set; }

        [JsonProperty("shirt_number")]
        public long ShirtNumber { get; set; }

        [JsonProperty("position")]
        public Position Position { get; set; }

        public Team PlayersTeam { get; set; }
        public int GoalsScored { get; set; }
        public int YellowCards { get; set; }
        public bool Favourite { get; set; } = false;

        internal static ISet<Player> GetPlayers(Match match, IList<Match> matches, string fifaId)
        {
            var players = new HashSet<Player>();

            IEnumerable<Player> startingElevenAndSubstitutes;
            Team playersTeam;

            if (match.HomeTeam.Code == fifaId)
            {
                startingElevenAndSubstitutes = match.HomeTeamStatistics.StartingEleven
                    .Concat(match.HomeTeamStatistics.Substitutes);
                playersTeam = match.HomeTeam;
            }
            else
            {
                startingElevenAndSubstitutes = match.AwayTeamStatistics.StartingEleven
                    .Concat(match.AwayTeamStatistics.Substitutes);
                playersTeam = match.AwayTeam;
            }

            players = startingElevenAndSubstitutes.ToHashSet();

            foreach (var player in players)
            {
                player.PlayersTeam = playersTeam;
                player.CalculateGoalsAndYellows(matches, fifaId);
            }

            return players;
        }


        private void CalculateGoalsAndYellows(IList<Match> matches, string fifaId)
        {
            foreach (var match in matches)
            {
                IEnumerable<TeamEvent> relevantEvents;

                if (match.HomeTeam.Code == fifaId)
                {
                    relevantEvents = match.HomeTeamEvents;
                }
                else
                {
                    relevantEvents = match.AwayTeamEvents;
                }

                foreach (var matchEvent in relevantEvents)
                {
                    if (IsGoal(matchEvent))
                    {
                        GoalsScored++;
                    }
                    if (IsYellow(matchEvent))
                    {
                        YellowCards++;
                    }
                }
            }
        }

        private bool IsYellow(TeamEvent matchEvent)
        {
            return Name.Equals(matchEvent.Player, StringComparison.OrdinalIgnoreCase) &&
                   matchEvent.TypeOfEvent == TypeOfEvent.YellowCard;
        }

        private bool IsGoal(TeamEvent matchEvent)
        {
            return Name.Equals(matchEvent.Player, StringComparison.OrdinalIgnoreCase) &&
                   matchEvent.TypeOfEvent == TypeOfEvent.Goal;
        }
    }
}
