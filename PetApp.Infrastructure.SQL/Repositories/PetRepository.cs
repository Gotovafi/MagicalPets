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
            //_context.Attach(pet).State = EntityState.Added;
            //_context.SaveChanges();
            //return pet;

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
            throw new NotImplementedException();
        }
    }
}
