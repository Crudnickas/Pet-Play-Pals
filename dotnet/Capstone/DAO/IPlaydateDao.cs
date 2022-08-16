using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Models;
namespace Capstone.DAO
{
    public interface IPlaydateDao
    {
        List<PlayDateResponse> GetPlayDatesByUser(int UserId);
        PlayDate GetPlayDateByPlayDateId(int PlayDateId);
        PlayDate CreatePlayDate(PlayDate newPlayDate);
        bool CreateUserPetPlayDate(int userId, int petId, int playdateId,string status);

        bool UpdateUserPlayDateStatus(UserPetPlayDate userplaydate);
    }
}
