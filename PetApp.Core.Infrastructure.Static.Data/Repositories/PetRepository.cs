using System;
using System.Collections.Generic;
using System.Linq;
using PetApp.Core.ApplicationService;
using PetApp.Core.DomaniService;
using PetApp.Core.Entity;

namespace PetApp.Infrastructure.Static.Data
{
    public class PetRepository: IPetRepository
    {
        public PetRepository()
        {
            if (FakeDB.Pets.Count >= 1) return;
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
            FakeDB.Pets.Add(pet1);

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
            FakeDB.Pets.Add(pet1);

        }
        //static int id = 1;
        //private List<Pet> _pets = new List<Pet>();
        //readonly IPetService _petService;

        public Pet Create(Pet pet)
        {
            pet.Id = FakeDB.Id++;
            FakeDB.Pets.Add(pet);
            return pet;
        }

        public IEnumerable<Pet> ReadAll()
        {
            return FakeDB.Pets;

        }


        public Pet ReadyById(int id)
        {
            return FakeDB.Pets.Select(c => new Pet()
            {
                Id = c.Id,
                Name = c.Name,
                Species = c.Species,
                Color = c.Color,
                Birthdate = c.Birthdate,
                Price = c.Price,
                SoldDate = c.SoldDate,
                PreviousOwner = c.PreviousOwner,
            }).
            FirstOrDefault(c => c.Id == id);
        }
            public Pet Updata(Pet petUpdata)
        {
            var PetFromDB = this.ReadyById(petUpdata.Id);
                if (PetFromDB != null) return null;
            
                PetFromDB.Name = petUpdata.Name;
                PetFromDB.Species = petUpdata.Species;
                PetFromDB.SoldDate = petUpdata.SoldDate;
                PetFromDB.Birthdate = petUpdata.Birthdate;
                PetFromDB.Price = petUpdata.Price;
                PetFromDB.PreviousOwner = petUpdata.PreviousOwner;
                return PetFromDB;
            
        }

        public Pet Delete(int id)
        {
            var petFound = ReadyById(id);
            if (petFound == null) return null;

            FakeDB.Pets.Remove(petFound);
            return petFound;
        }

    }
}
