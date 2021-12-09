using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppTempeture.Models.Utilitys;

namespace WebAppTempeture.Controllers
{
    public class TempetureController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(double temp, TempatureUnit fromUnit, TempatureUnit toUnit)
        {
            ViewBag.Result = $"{temp} {fromUnit} is {TempetureConverter.ConvertTempature(temp, fromUnit, toUnit)} {toUnit}";
            return View(TempetureConverter.ConvertTempature(temp, fromUnit, toUnit));
        }
    }
}
