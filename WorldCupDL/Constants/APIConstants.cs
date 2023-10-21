using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldCupDL.Constants
{
    public static partial class APIConstantsMen
    {
        public const string TEAMS = "https://worldcup-vua.nullbit.hr/men/teams/results";
        public const string MATCHES = "https://worldcup-vua.nullbit.hr/men/matches/country?fifa_code=";
    }

    public static partial class APIConstantsWomen
    {
        public const string TEAMS = "https://worldcup-vua.nullbit.hr/women/teams/results";
        public const string MATCHES = "https://worldcup-vua.nullbit.hr/women/matches/country?fifa_code=";
    }
}
