using PetApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetApp.Core.DomaniService
{
    public interface IPetRepository
    {
        Pet Create(Pet pet);
        Pet ReadyById(int id);
        IEnumerable<Pet> ReadAll();
        Pet Updata(Pet petUpdata);
        Pet Delete(int id); 

    }
}
