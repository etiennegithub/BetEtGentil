using BetEtMechant.Class;
using BetEtMechant.Controllers;
using BetEtMechant.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BetEtMechant.Areas.Administration.Controllers
{
    [Area("Administration")]
    [Authorize]
    public abstract class BaseAdminController : BaseController
    {
        public BaseAdminController(BetDbContext context) : base(context)
        {
        }

       
    }
}
