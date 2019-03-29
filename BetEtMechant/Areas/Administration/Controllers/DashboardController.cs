using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BetEtMechant.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BetEtMechant.Areas.Administration.Controllers
{

    public class DashboardController : BaseAdminController
    {
        public DashboardController(BetDbContext context) : base(context)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}