using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
namespace Capstone.DAO
{
    public interface IPetDao
    {
        List<Pet> GetPetByUser(int userId);
        Pet GetPetByPetId(int PetId);
        Pet CreatePet(Pet newPet);

        bool CreatePetUser(int userId, int petId);
    }
}
