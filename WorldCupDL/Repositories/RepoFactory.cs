using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace WorldCupDL.Repositories
{
    public static class RepoFactory
    {
        public static IRepo GetRepo(bool connection)
        {
            return new APIRepo();
        }

        public static ISetup GetResourcesRepository() => new SetupRepo();
    }
}
