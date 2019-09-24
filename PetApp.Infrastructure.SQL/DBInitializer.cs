using PetApp.Core.Entity;
using PetApp.Infrastructure.SQL;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetApp.Infrastructure.Static.Data
{
    public class DBInitializer
    {
        public static void SeedDB(PetAppContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();
            var pat1 = ctx.Pets.Add(new Pet()
            {
                
                Name = "Malti",
                Species = "Naga",
                Color = "Blue",
                Birthdate = DateTime.Parse("05-01-2009 "),
                SoldDate = DateTime.Parse("23-03-2015 "),
                PreviousOwner = "Blilly Jack",
                Price = 4999.99,
            });
            ctx.SaveChanges();
        }
    }
}
