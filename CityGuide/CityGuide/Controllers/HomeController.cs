﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CityGuide.Application;

namespace CityGuide.Controllers
{
    public class HomeController : Controller
    {
        private CategoriesWorkerService _catWorkerSvc;

        public HomeController(CategoriesWorkerService catService)
        {
            _catWorkerSvc = catService;
        }

        public ActionResult Index()
        {
            var viewModels = _catWorkerSvc.GetAllCategories();
            return View(viewModels);
        }
    }
}