using System;
using System.Collections.Generic;
using PetApp.Core.ApplicationService;
using PetApp.Core.DomaniService;
using PetApp.Core.Entity;

namespace PetApp.Infrastructure.Static.Data
{
    public class PetRepository: IPetRepository
    {
        static int id = 1;
        private List<Pet> _pets = new List<Pet>();
        readonly IPetService _petService;

        public Pet Create(Pet pet)
        {
            pet.Id = id++;
            _pets.Add(pet);
            return pet;
        }

        public IEnumerable<Pet> ReadAll()
        {
            return _pets;
        }

        
        public Pet ReadyById(int id)
        {
            foreach (var pet in _pets)
            {
                if (pet.Id == id)
                {
                    return pet;
                }

            }
            return null;
        }

        public Pet Updata(Pet petUpdata)
        {
            var PetFromDB = this.ReadyById(petUpdata.Id);
            if (PetFromDB != null)
            {
                PetFromDB.Name = petUpdata.Name;
                PetFromDB.Species = petUpdata.Species;
                PetFromDB.SoldDate = petUpdata.SoldDate;
                PetFromDB.Birthdate = petUpdata.Birthdate;
                PetFromDB.Price = petUpdata.Price;
                PetFromDB.PreviousOwner = petUpdata.PreviousOwner;
                return PetFromDB;
            }
            return null;
        }

        public Pet Delete(int id)
        {
            var Pet = this.ReadyById(id);
            if (Pet != null)
            {
                _pets.Remove(Pet);
                return Pet;
            }
            return null;
        }

        public void InitData()
        {
            var pet1 = new Pet()
            {
                Name = "Malti",
                Species = "Naga",
                Birthdate = "18-07-2000",
                SoldDate = "07-09-2005",
                Color = "Blue",
                PreviousOwner = "Blilly Jack",
                Price = "4999.99",

            };
            _petService.CreateAPet(pet1);

            var pet2 = new Pet()
            {
                Name = "Nagival",
                Species = "Dragon",
                Birthdate = "01-01-1500",
                SoldDate = "05-12-2008",
                Color = "Black",
                PreviousOwner = "Blilly Jack",
                Price = "999999.99",

            };
            _petService.CreateAPet(pet2);
        }
    }
}
