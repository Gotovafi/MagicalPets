using Microsoft.EntityFrameworkCore;
using PetApp.Core.DomaniService;
using PetApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetApp.Infrastructure.SQL.Repositories
{
    class PetRepository : IPetRepository
    {
        private PetAppContext _context;

        public PetRepository(PetAppContext context)
        {
            _context = context;
        }
        public Pet Create(Pet pet)
        {
            var changeTracker = _context.ChangeTracker.Entries<Owner>();
            if (pet.Owners != null && _context.ChangeTracker.Entries<Owner>()
                .FirstOrDefault(pe => pe.Entity.Id == pet.Owner.Id) ==null)
            {
                _context.Attach(pet.Owners);
            }
            var own = _context.Pets.Add(pet).Entity;
            _context.SaveChanges();
            return pet;
        }

        public Pet Delete(int id)
        {
            var removed = _context.Remove(new Pet { Id = id }).Entity;
            _context.SaveChanges();
            return removed;
        }

        public Pet Id(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Pet> ReadAll()
        {
            return _context.Pets;
        }

        public Pet ReadyById(int id)
        {
            return _context.Pets.FirstOrDefault(c => c.Id == id);
        }

        public Pet Updata(Pet petUpdata)
        {
            var changeTracker = _context.ChangeTracker.Entries<Owner>();
            if (petUpdata.Owners != null && _context.ChangeTracker.Entries<Owner>()
                .FirstOrDefault(pe => pe.Entity.Id == petUpdata.Owner.Id) == null)
            {
                _context.Attach(petUpdata.Owners);
            }
            else
            {
                _context.Entry(petUpdata).Reference(o => o.Owners).IsModified = true;
            }
            var own = _context.Pets.Update(petUpdata).Entity;
            _context.SaveChanges();
            return petUpdata;
        }
    }
}
