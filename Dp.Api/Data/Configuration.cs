using System.Data.Entity.Migrations;
using DP.Api.Data;

namespace Dp.Api.Data
{
    internal sealed class Configuration : DbMigrationsConfiguration<Dp.Api.Data.DpContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Dp.Api.Data.DpContext context)
        {
            DbInitializer.Initialize(context);
        }
    }
}
