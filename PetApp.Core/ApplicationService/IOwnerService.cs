using System.Collections.Generic;
using PetApp.Core.Entity;
using System;

namespace PetApp.Core.ApplicationService
{
    public interface IOwnerService
    {
        Owner NewOwner(string firstName, string lastName, string address);
        Owner CreateAOwner(Owner owner);
        Owner FindOwnerById(int id);
        List<Owner> GetAlleOwners();
        Owner UpdadteOwner(Owner updadteOwner);
        Owner DeletOwner(int id);
    }
}
