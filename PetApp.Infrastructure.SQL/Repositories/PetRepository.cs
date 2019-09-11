using Microsoft.EntityFrameworkCore;
using PetApp.Core.DomaniService;
using PetApp.Core.Entity;
using System;
using System.Collections.Generic;
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
            _context.Attach(pet).State = EntityState.Added;
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
            //list.List = _context.Pet.ToList();
            throw new NotImplementedException();
        }

        public Pet ReadyById(int id)
        {
            throw new NotImplementedException();
            //return _ctx.Pet.
            ////return _context.Pet.FirstOrDefault(p => p.Id = 4 = id);
            ////throw new NotImplementedException();
        }

        public Pet Updata(Pet petUpdata)
        {
            throw new NotImplementedException();
        }
    }
}
