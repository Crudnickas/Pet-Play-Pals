using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.DAO;
using Capstone.Models;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PlaydateController : Controller
    {
        private readonly IPlaydateDao playdateDao;
        private readonly IUserDao userDao;

        public PlaydateController(IPlaydateDao _playdateDao, IUserDao _userDao)
        {
            playdateDao = _playdateDao;
            userDao = _userDao;

        }

        [HttpGet("userid/{id}")]
        public ActionResult<IList<PlayDate>> GetPlayDatesByUser(int id)
        {
            IList<PlayDate> playdatesToReturn = new List<PlayDate>();
            playdatesToReturn = playdateDao.GetPlayDatesByUser(id);
            if (playdatesToReturn != null)
            {
                return Ok(playdatesToReturn);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<PlayDate> GetPlayDateByPlayDateId(int id)
        {
            PlayDate playDateToReturn = null;
            playDateToReturn = playdateDao.GetPlayDateByPlayDateId(id);
            if (playDateToReturn != null)
            {
                return Ok(playDateToReturn);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost()]
        public ActionResult<PlayDate> CreatePlayDate(PlayDate newPlayDate)
        {
            PlayDate playDateToReturn = null;
            playDateToReturn = playdateDao.CreatePlayDate(newPlayDate);
            if (playDateToReturn != null)
            {
                return Created($"playdate/{playDateToReturn.PlayDateID}", playDateToReturn);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost("/relationship")]
        public ActionResult CreateUserPetPlayDateRelationship (UserPetPlayDate userPetPlayDate)
        {
            int petId = userPetPlayDate.PetID;
            //User user = userDao.GetUser(relationship.Username);
            int userId = userPetPlayDate.UserID;
            int playdateId = userPetPlayDate.PlayDateID;
            bool wasSucessful = playdateDao.CreateUserPetPlayDate(userId, petId,playdateId);
            if (wasSucessful == true)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }

}
