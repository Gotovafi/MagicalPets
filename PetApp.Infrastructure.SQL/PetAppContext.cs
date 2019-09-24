using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PetApp.Core.Entity;

namespace PetApp.Infrastructure.SQL
{
    public class PetAppContext: DbContext
    {
        public PetAppContext(DbContextOptions<PetAppContext> opt) : base(opt) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pet>()
                .HasOne(o => o.Owners)
                .WithMany(c => c.Pets)
                .OnDelete(DeleteBehavior.SetNull);
        }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }
}
