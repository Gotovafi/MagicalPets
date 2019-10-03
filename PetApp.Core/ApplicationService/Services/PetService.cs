using System;
using System.Collections.Generic;
using PetApp.Core.DomaniService;
using PetApp.Core.Entity;
using System.Linq;
using System.IO;

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
            if (pet.Owner == null || pet.Owner.Id <= 0)
                throw new InvalidDataException("før du kan har et pet skal du har en owner");
            if (_ownerRepo.ReadyById(pet.Owner.Id) == null)
                throw new InvalidDataException("owner kun ikke findes");
            return _petRepo.Create(pet);
        }

        public Pet FindPetById(int id)
        {
            //var pet = _petRepo.ReadyById(id);
            //pet.Owners = _ownerRepo.ReadAll().Where(owner => owner.Pets.Id == pet.Id).ToList();
            //return pet;
            return _petRepo.ReadyById(id);
        }
        public Pet FindPetByIdIncludeOwner(int id)
        {
            var pet = _petRepo.ReadyById(id);
            pet.Owners = _ownerRepo.ReadAll()
                .Where(owner => owner.Pet.Id == pet.Id)
                .ToList();
            return pet;
        }


        public List<Pet> GetAllePets()
        {
            return _petRepo.ReadAll().ToList();
        }
        public List<Pet> GetFileteredPets(Filter filter)
        {
            if (filter.CurrentPage < 0 || filter.ItemsPrPage < 0)
            {
                throw new InvalidDataException("CurrentPage og Items skal være 0 eller mere");
            }
            if ((filter.CurrentPage -1 * filter.ItemsPrPage) >= _petRepo.Count())
            {
                throw new InvalidDataException("index out bounds, Currentpage er for høje");
            }
            return _petRepo.ReadAll(filter).ToList();
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
