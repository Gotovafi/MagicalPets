using System;
using System.Collections.Generic;
using System.Text;
using PetApp.Core.Entity;

namespace PetApp.Core.DomaniService
{
    public interface IOwnerRepository
    {
        Owner Create(Owner owner);
        Owner ReadyById(int id);
        IEnumerable<Owner> ReadAll();
        Owner Update(Owner ownerUpdate);
        Owner Delete(int id);
    }
}
