using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PetApp.Core.Entity;

namespace PetApp.Infrastructure.SQL
{
    public class PetAppContext: DbContext
    {
        public PetAppContext(DbContextOptions opt): base(opt)
        {

        }
        public DbSet<Pet> Pets { get; set; }
    }
}
