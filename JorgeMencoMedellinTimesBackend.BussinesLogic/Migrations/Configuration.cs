namespace JorgeMencoMedellinTimesBackend.BussinesLogic.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<JorgeMencoMedellinTimesBackend.BussinesLogic.MedellinTimesContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "JorgeMencoMedellinTimesBackend.BussinesLogic.MedellinTimesContext";
        }

        protected override void Seed(JorgeMencoMedellinTimesBackend.BussinesLogic.MedellinTimesContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
