﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UserTestApp.Models;
using UserTestApp.Repositories;

namespace UserTestApp.Controllers
{
    public class HomeController : Controller
    {
        private UserRepository _db;

        public HomeController(UserContext context)
        {
            _db = new UserRepository(context);
           
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.UsersAdmins = await _db.FindAllByRole(20);
            ViewBag.UserAlexeys = await _db.FindAllByName("Alexey");
            ViewBag.UsersOlderThen30 = await _db.FindAlltUsersOlderThen(30);
            return View(await _db.FindAllWithRoles());
           
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        

        

       
    }
}
