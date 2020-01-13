namespace ECommerce.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ECommerce.DAL.ECommerceDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ECommerce.DAL.ECommerceDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var items = new List<Item>
            {
                new Item {Name="Top", Description="Red Cotton", Price=350, Quantity=10 },
                new Item {Name="Jacket", Description="Black", Price=1000, Quantity=15 },
                new Item {Name="Jeans", Description="Blue Denim", Price=850, Quantity=12 },
                new Item {Name="Shirt", Description="Red Cotton", Price=500, Quantity=8 },
                new Item {Name="EyeLiner", Description="Blue Heaven", Price=40, Quantity=5 },
                new Item {Name="Shoes", Description="Sports in Black and white", Price=350, Quantity=10 },
                new Item {Name="Washing Machine", Description="White and Blue Samsung", Price=15000, Quantity=25 }
            };
            items.ForEach(i => context.Items.AddOrUpdate(p => p.Name, i));
            context.SaveChanges();
        }
    }
}
