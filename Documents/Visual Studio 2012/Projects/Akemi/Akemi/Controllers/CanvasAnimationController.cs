using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Akemi.Controllers
{
    public class CanvasAnimationController : Controller
    {
        //
        // GET: /CanvasAnimation/

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

    }
}
