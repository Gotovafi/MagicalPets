using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PetApp.Core.Entity;

namespace PetApp.Infrastructure.SQL
{
    class OwnerAppContext: DbContext
    {
        public DbSet<Pet> Pets { get; set; }
    }
}
