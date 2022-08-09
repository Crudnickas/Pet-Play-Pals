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

        public PetController(IPetDao _petDao)
        {
            petDao = _petDao;
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
        [HttpPost()]
        public IActionResult CreatePet(Pet AddPet) {

            // Petdao.AddPet(AddPet) 
            // Verify AddPet worked, if not, return bad request
            return Ok(AddPet);
                 
        }

    }
}
