using PetApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetApp.Core.DomaniService
{
    public interface IPetRepository
    {
        Pet Create(Pet pet);
        Pet Id(int id);
        Pet ReadyById(int id);
        IEnumerable<Pet> ReadAll(Filter filter = null);
        int Count();
        Pet Updata(Pet petUpdata);
        Pet Delete(int id);
        
    }
}
