using System;
using System.Text;
using System.Collections.Generic;
using PetApp.Core.ApplicationService;
using PetApp.Core.DomaniService;
using PetApp.Core.Entity;

namespace PetApp.Infrastructure.Static.Data
{
    public static class FakeDB
    {
        public static int Id = 1;
        public static readonly List<Pet> Pets = new List<Pet>();

        public static int OwnerId = 1;
        public static readonly List<Owner> Owners = new List<Owner>();
    }
}
