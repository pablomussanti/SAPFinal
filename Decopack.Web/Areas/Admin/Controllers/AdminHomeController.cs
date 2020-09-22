﻿using Decopack.Framework.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Decopack.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]

    public class AdminHomeController : Controller
    {
            private ILoggingService _loggingService;

            public AdminHomeController(ILoggingService loggingService)


            {
                _loggingService = loggingService;
            }

            // GET: Admin/Home
            public ActionResult Index()
            {
                _loggingService.Log("message");
                return View();
            }
        }
    }
