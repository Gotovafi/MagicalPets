﻿using System;
using System.Collections.Generic;
using PetApp.Core.ApplicationService;
using PetApp.Core.DomaniService;
using PetApp.Core.Entity;
using PetApp.Infrastructure.Static.Data;
using System.Text;

namespace ConsoleAppOfPats
{
    public class MirrorImage : IMirrorImage
    {
        readonly IPetService _petService;

        public Printer(IPetService petService)
        {
            _petService = petService;
            InitData();

        }
        public void StartUI()
        {
            String[] menuPets =
        {
            "List Off All Pets",
            "Add a Pet",
            "Delete a Pet",
            "Edit a Pet",
            "Exit/Run away"
        };

            var selection = ShowMenu(menuPets);

            while (selection !=5)
            {
                switch (selection)
                {
                    case 1:
                        var pets = _petService.GetAllePets();
                        ListPets(pets);
                        break;
                    case 2:
                        var name = AskQuestion("Name: ");
                        var species = AskQuestion("Species: ");
                        var birthdate = AskQuestion("Birthdate: ");
                        var soldDate = AskQuestion("SoldDate: ");
                        var color = AskQuestion("Color: ");
                        var previousOwner = AskQuestion("PreviousOwner: ");
                        var price = AskQuestion("price: ");
                        var pet = _petService.NewPat("name", "species", "birthdate", "soldDate", "color", "previousOwner", "price");
                        _petService.CreateAPet(pet);
                        break;
                    case 3:
                        var idForDelete = PrintFindAPetsId();
                        _petService.DeletPet(idForDelete);
                        break;
                    case 4:
                        var idForEdit = PrintFindAPetsId();
                        var petToEdit = _petService.FindPetById(idForEdit);
                        Console.WriteLine("Updating " + petToEdit.Name);
                        var newName = AskQuestion("Name: ");
                        var newSpecies = AskQuestion("Species: ");
                        var newBirthdate = AskQuestion("Birthdate: ");
                        var newSoldDate = AskQuestion("SoldDate: ");
                        var newColor = AskQuestion("Color: ");
                        var newPreviousOwner = AskQuestion("PreviousOwner: ");
                        var newPrice = AskQuestion("Price: ");
                        _petService.UpdadtePet(new Pet()
                        {
                            Id = idForEdit,
                            Name = newName,
                            Species = newSpecies,
                            Birthdate = newBirthdate,
                            SoldDate = newSoldDate,
                            Color = newColor,
                            PreviousOwner = newColor,
                            Price = newPrice
                        });
                        break;
                    default:
                        break;
                }
                selection = ShowMenu(menuPets);
            }
            Console.WriteLine("Come agian");
            Console.ReadLine();
        }
        int PrintFindAPetsId()
        {
            Console.WriteLine("Id please: ");
            int id;
            while (!int.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("a number");
            }
            return id;
        }
        string AskQuestion(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        void ListPets(List<Pet> pets)
        {
            Console.WriteLine("\nThe list of Pets");
            foreach (var pet in pets)
            {
                Console.WriteLine($"Id: {pet.Id} Name:{pet.Name} Species:{pet.Color} + {pet.Species} Birthdate:{pet.Birthdate} SoldDate:{pet.SoldDate} Price:{pet.Price} PreciousOwner:{pet.PreviousOwner}");
            }
            Console.WriteLine("\n");

        }

        int ShowMenu(string[] menuPets)
        {
            Console.WriteLine("welocme to the shop!:\n");

            for (int i = 0; i < menuPets.Length; i++)
            {
                //Console.WriteLine((i + 1) + ":" + menuItems[i]);
                Console.WriteLine($"{(i + 1)}: {menuPets[i]}");
            }

            int selection;
            while (!int.TryParse(Console.ReadLine(), out selection)
                || selection < 1
                || selection > 5)
            {
                Console.WriteLine("use a number between 1-5");
            }

            return selection;
        }

        void InitData()
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
        
    

    

