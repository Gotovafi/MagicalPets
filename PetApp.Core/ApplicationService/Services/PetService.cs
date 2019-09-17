using System;
using System.Collections.Generic;
using PetApp.Core.DomaniService;
using PetApp.Core.Entity;
using System.Linq;

namespace PetApp.Core.ApplicationService.Services
{
    public class PetService : IPetService
    {
        readonly IPetRepository _petRepo;
        readonly IOwnerRepository _ownerRepo;
        public PetService(IPetRepository petRepository, IOwnerRepository ownerRepository)
        {
            _petRepo = petRepository;
            _ownerRepo = ownerRepository;
        }
        
        public Pet NewPat(string name, string species, DateTime birthDate, DateTime soldDate, string color, string previousOwner, double price)
        {
            var pet = new Pet
            {
                Name = name,
                Species = species,
                Birthdate = birthDate,
                SoldDate = soldDate,
                Color = color,
                PreviousOwner = previousOwner,
                Price = price
            };

            return pet;
        }

        public Pet CreateAPet(Pet pet)
        {
            return _petRepo.Create(pet);
        }

        public Pet FindPetById(int id)
        {
            var pet = _petRepo.ReadyById(id);
            pet.Owners = _ownerRepo.ReadAll().Where(owner => owner.Pets.Id == pet.Id).ToList();
            return pet;
            //return _petRepo.ReadyById(id);
        }

        public List<Pet> GetAllePets()
        {
            return _petRepo.ReadAll().ToList();
        }

        public Pet UpdadtePet(Pet updadtePet)
        {
            var pet = FindPetById(updadtePet.Id);
            pet.Name = updadtePet.Name;
            pet.Species = updadtePet.Species;
            pet.Birthdate = updadtePet.Birthdate;
            pet.SoldDate = updadtePet.SoldDate;
            pet.Color = updadtePet.Color;
            pet.PreviousOwner = updadtePet.PreviousOwner;
            pet.Price = updadtePet.Price;
            return pet;
        }

        public Pet DeletPet(int id)
        {
            return _petRepo.Delete(id);
        }
    }
}
