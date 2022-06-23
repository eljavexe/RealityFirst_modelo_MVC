﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using RealityFirst.Models;
using RealityFirst.Servicio;
using Microsoft.Extensions.Configuration;

namespace RealityFirst.Controllers
{
    public class HomeController : Controller
    {
        IConfiguration config;
        NoticiaServicio noticia;    

        public HomeController(IConfiguration config)
        {
            this.config = config;
            string ConnectionString = config.GetConnectionString("DBRealityFirst");
            noticia = new NoticiaServicio(ConnectionString);

        }

        public IActionResult Index()
        {
            IList<NoticiaModel> lista = noticia.GetAll();
            return View("Index", lista);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contacto()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
