﻿#region Using

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace MyCert.Admin.Controllers
{
    [Authorize]
    public class ElementController : Controller
    {
        // GET: /elements/general/
        public ActionResult General()
        {
            return View();
        }

        // GET: /elements/buttons/
        public ActionResult Buttons()
        {
            return View();
        }
    }
}