using System;
using System.Collections.Generic;
using PetApp.Core.DomaniService;
using PetApp.Core.Entity;
using System.Linq;
using System.IO;

namespace PetApp.Core.ApplicationService.Services
{
    public class OwnerService: IOwnerService
    {
        readonly IOwnerRepository _ownerRepo;
        readonly IPetRepository _petRepo;

        public OwnerService(IOwnerRepository ownerRepository, IPetRepository petRepository)
        {
            _ownerRepo = ownerRepository;
            _petRepo = petRepository;
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

        public List<Owner> GetFileteredOwners(Filter filter)
        {
            if (filter.CurrentPage < 0 || filter.ItemsPrPage < 0)
            {
                throw new InvalidDataException("CurrentPage og Items skal være 0 eller mere");
            }
            if ((filter.CurrentPage - 1 * filter.ItemsPrPage) >= _petRepo.Count())
            {
                throw new InvalidDataException("index out bounds, Currentpage er for høje");
            }
            return _ownerRepo.ReadAll(filter).ToList();
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
