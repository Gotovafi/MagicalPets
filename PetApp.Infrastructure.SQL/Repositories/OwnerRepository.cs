using Microsoft.EntityFrameworkCore;
using PetApp.Core.DomaniService;
using PetApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetApp.Infrastructure.SQL.Repositories
{
    class OwnerRepository : IOwnerRepository
    {
        private PetAppContext _context;
        public OwnerRepository(PetAppContext context)
        {
            _context = context;
        }
        public Owner Create(Owner owner)
        {
            _context.Attach(owner).State = EntityState.Added;
            _context.SaveChanges();
            return owner;
        }

        public Owner Delete(int id)
        {
            var removed = _context.Remove(new Owner { Id = id }).Entity;
            _context.SaveChanges();
            return removed;
        }

        public IEnumerable<Owner> ReadAll()
        {
            throw new NotImplementedException();
        }

        public Owner ReadyById(int id)
        {
            throw new NotImplementedException();
        }

        public Owner Update(Owner ownerUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
