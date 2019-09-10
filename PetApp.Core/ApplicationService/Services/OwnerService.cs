using System;
using System.Collections.Generic;
using PetApp.Core.DomaniService;
using PetApp.Core.Entity;
using System.Linq;

namespace PetApp.Core.ApplicationService.Services
{
    public class OwnerService: IOwnerService
    {
        readonly IOwnerRepository _ownerRepo;

        public OwnerService(IOwnerRepository ownerRepository)
        {
            _ownerRepo = ownerRepository;
        }

        public Owner CreateAOwner(Owner owner)
        {
            return _ownerRepo.Create(owner);
        }

        public Owner DeletOwner(int id)
        {
            return _ownerRepo.Delete(id);
        }

        public Owner FindOwnerById(int id)
        {
            return _ownerRepo.ReadyById(id);
        }

        public List<Owner> GetAlleOwners()
        {
            return _ownerRepo.ReadAll().ToList();
        }

        public Owner NewOwner(string firstName, string lastName, string address)
        {
            var owner = new Owner()
            {
                FirstName = firstName,
                LastName = lastName,
                Address = address
            };
            return owner;
        }

        public Owner UpdadteOwner(Owner updadteOwner)
        {
            var owner = FindOwnerById(updadteOwner.Id);
            owner.FirstName = updadteOwner.FirstName;
            owner.LastName = updadteOwner.LastName;
            owner.Address = updadteOwner.Address;
            return owner;
        }
    }
}
