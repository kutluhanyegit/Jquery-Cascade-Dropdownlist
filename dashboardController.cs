using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using rentid.Contexts;
using rentid.Entities;
using rentid.Models;
using rentid.Models.CarModel;
using rentid.ViewModels;

namespace rentid.Controllers
{
    [Authorize(Roles = "Admin,Kurumsal")]
    public class dashboardController:Controller
    {
        private readonly UserManager<appUser> userManager;
        private readonly appDbContext context;
        public dashboardController(UserManager<appUser> userManager,appDbContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }
        public IActionResult index()
        {
          //TODO: Implement Realistic Implementation
          return View();
        }

        public IActionResult araclar()
        {
          //TODO: Implement Realistic Implementation
          return View();
        }

        /*Araç Ekle*/
        [Route("/dashboard/arac-ekle")]
        public IActionResult arac_ekle()
        {
          return View(context.markas.ToList());
        }

        [Route("/dashboard/arac-ekle")]
        [HttpPost]
        public IActionResult arac_ekle(aracKayitVM vm)
        {
          
          return View();
        }

        [Route("/getmarkajson")]
        public JsonResult getMarkaJson()
        {
          using (StreamReader r = new StreamReader("JsonData/marka.json"))
          {
              var j = r.ReadToEnd();
              var items = JsonConvert.DeserializeObject<List<marka>>(j);
              return Json(items);
          }
          
        }

        [Route("/getmodeljson/{id}")]
        public JsonResult getModelJson(int id)
        {
          List<model> liste = new List<model>();
          using (StreamReader r = new StreamReader("JsonData/model.json"))
          {
              var j = r.ReadToEnd();
              var items = JsonConvert.DeserializeObject<List<model>>(j);
              
              foreach (var item in items)
              {
                  if (item.markaID == id)
                  {
                      liste.Add(item);
                  }
              }
              return Json(liste.ToList());
          }
          
        }
        
    }
}