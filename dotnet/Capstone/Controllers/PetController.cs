using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.DAO;
namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PetController : Controller
    {
        private readonly IPetDao petDao;
        private readonly IUserDao userDao;

        public PetController(IPetDao _petDao, IUserDao _userDao)
        {
            petDao = _petDao;
            userDao = _userDao;

        }
        [HttpPost()]
        public ActionResult<Pet> CreatePet(Pet newPet)
        {
            Pet petToReturn = null;
            petToReturn = petDao.CreatePet(newPet);
            if (petToReturn != null)
            {
                return Created($"pet/{petToReturn.PetId}",petToReturn);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public ActionResult UpdatePet(int id, Pet updatedPet)
        {
            int playdateId = id;
            bool wasSucessful = petDao.UpdatePet(updatedPet);
            if (wasSucessful == true)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("/relationship")]
        public ActionResult CreatePetRelationship(Relationship relationship)
        {
            int petId = relationship.PetId;
            User user = userDao.GetUser(relationship.Username);
            int userId = user.UserId;
            bool wasSucessful = petDao.CreatePetUser(userId,petId);
            if (wasSucessful == true)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Pet> GetPetsByPetId(int id)
        {
            Pet petToReturn = null;
            petToReturn = petDao.GetPetByPetId(id);
            if (petToReturn != null)
            {
                return Ok(petToReturn);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("userid/{id}")]
        public ActionResult<IList<Pet>> GetPetsByUser(int id)
        {
            IList<Pet> petToReturn = new List<Pet>();
            petToReturn = petDao.GetPetByUser(id);
            if (petToReturn != null)
            {
                return Ok(petToReturn);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
