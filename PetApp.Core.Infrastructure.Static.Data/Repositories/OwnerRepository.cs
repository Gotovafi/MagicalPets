using System;
using System.Collections.Generic;
using System.Linq;
using PetApp.Core.ApplicationService;
using PetApp.Core.DomaniService;
using PetApp.Core.Entity;

namespace PetApp.Infrastructure.Static.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        public OwnerRepository()
        {
            if (FakeDB.Owners.Count >= 1) return;
            var owner1 = new Owner()
            {
                FirstName = "Zaire",
                LastName = "Copper",
                Address = ""

            };
            FakeDB.Owners.Add(owner1);

            var owner2 = new Owner()
            {
                FirstName = "Ruogang ",
                LastName = "Thinwater",
                Address = ""
            };
            FakeDB.Owners.Add(owner2);
        }
        public Owner Create(Owner owner)
        {
            owner.Id = FakeDB.OwnerId++;
            FakeDB.Owners.Add(owner);
            return owner;
        }

        public Owner Delete(int id)
        {
            var ownerFound = ReadyById(id);
            if (ownerFound == null) return null;

            FakeDB.Owners.Remove(ownerFound);
            return ownerFound;
        }

        public IEnumerable<Owner> ReadAll()
        {
            return FakeDB.Owners;
        }

        public Owner ReadyById(int id)
        {
            return FakeDB.Owners.Select(c => new Owner()
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                Address = c.Address
                
            }).
            FirstOrDefault(c => c.Id == id);
        }

        public Owner Update(Owner ownerUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
