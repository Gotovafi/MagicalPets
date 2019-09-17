﻿using Microsoft.EntityFrameworkCore;
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
            //_context.Attach(owner).State = EntityState.Added;
            //_context.SaveChanges();
            //return owner;

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

        public IEnumerable<Owner> ReadAll()
        {
            return _context.Owners;
        }

        public Owner ReadyById(int id)
        {
            return _context.Owners.FirstOrDefault(c => c.Id == id);
        }

        public Owner Update(Owner ownerUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
