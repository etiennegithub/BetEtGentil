using BetEtMechant.Class;
using BetEtMechant.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetEtMechant.Controllers
{
    public class BaseController : Controller
    {
        protected readonly BetDbContext _context;
        public BaseController(BetDbContext context)
        {
            _context = context;
        }

        protected void DisplayMessage(string message, TypeMessage typeMessage)
        {
            TempData["Message"] = JsonConvert.SerializeObject(new FlashMessage(message, typeMessage));
        }
    }
}
