using System.Data.Entity.Migrations;

namespace Dp.Models.Security
{
    internal sealed class Configuration : DbMigrationsConfiguration<DpContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DpContext context)
        {
            DbInitializer.Initialize(context);
        }
    }
}
