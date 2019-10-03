using Microsoft.EntityFrameworkCore;
using PetApp.Core.DomaniService;
using PetApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetApp.Infrastructure.SQL.Repositories
{
    class OwnerRepository : IOwnerRepository
    {
        readonly OwnerAppContext _context;
        public OwnerRepository(OwnerAppContext context)
        {
            _context = context;
        }
        public Owner Create(Owner owner)
        {
            var changeTracker = _context.ChangeTracker.Entries<Pet>();
            var own = _context.Owners.Add(owner).Entity;
            _context.SaveChanges();
            return owner;
        }

        public Owner Delete(int id)
        {
            var removed = _context.Remove(new Owner { Id = id }).Entity;
            _context.SaveChanges();
            return removed;
        }

        public Owner Id(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Owner> ReadAll(Filter filter)
        {
            if (filter == null)
            { 
                return _context.Pets;
            }
            return _context.Pets
                .Skip((filter.CurrentPage - 1) * filter.ItemsPrPage)
                .Take(filter.ItemsPrPage);
}

public Owner ReadyById(int id)
        {
            return _context.Owners.FirstOrDefault(c => c.Id == id);
        }

        public Owner Update(Owner ownerUpdate)
        {
            _context.Attach(ownerUpdate).State = EntityState.Modified;
            _context.Entry(ownerUpdate).Reference(o => o.Pets).IsModified = true;
            _context.SaveChanges();

            return ownerUpdate;
        }
    }
}
