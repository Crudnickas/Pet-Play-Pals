using Capstone.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Controllers
{
    public class PetController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost()]
        public IActionResult CreatePet(Pet AddPet) {

            // Petdao.AddPet(AddPet) 
            // Verify AddPet worked, if not, return bad request
            return Ok(AddPet);
                 
        }

    }
}
