using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RentAMovie.Models;
using System.Data.Entity;
using RentAMovie.ViewModels;

namespace RentAMovie.Controllers
{
    public class RentalsController : Controller
    {
        private ApplicationDbContext _context;

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("Index");
          
                return View();
        }
        public ActionResult New()
        {
            return View();
        }

       

    }
}