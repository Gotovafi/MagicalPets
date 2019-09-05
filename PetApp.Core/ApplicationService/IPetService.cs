﻿using System.Collections.Generic;
using PetApp.Core.Entity;
using System;

namespace PetApp.Core.ApplicationService
{
    public interface IPetService
    {
        Pet NewPat(string name, string species, DateTime birthDate, DateTime soldDate, string color, string previousOwner, double price);
        Pet CreateAPet(Pet pet);
        Pet FindPetById(int id);
        List<Pet> GetAllePets();
        Pet UpdadtePet(Pet updadtePet);
        Pet DeletPet(int id);
    }
}
