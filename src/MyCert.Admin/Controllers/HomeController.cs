﻿#region Using
 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace MyCert.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: home/index
        public ActionResult Index()
        {
            return View();
        }

        // GET: home/social
        public ActionResult Social()
        {
            return View();
        }

        // GET: home/inbox
        public ActionResult Inbox()
        {
            return View();
        }

        // GET: home/widgets
        public ActionResult Widgets()
        {
            return View();
        }

        // GET: home/chat
        public ActionResult Chat()
        {
            return View();
        }
    }
}