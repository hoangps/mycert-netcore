﻿#region Using


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace MyCert.Admin.Controllers
{
    [Authorize]
    public class AppViewsController : Controller
    {
        // GET: /appviews/blog
        public ActionResult Blog()
        {
            return View();
        }

        // GET: /appviews/projects
        public ActionResult Projects()
        {
            return View();
        }

        // GET: /appviews/profile
        public ActionResult Profile()
        {
            return View();
        }

        // GET: /appviews/timeline
        public ActionResult TimeLine()
        {
            return View();
        }

        // GET: /appviews/gallery
        public ActionResult Gallery()
        {
            return View();
        }
    }
}