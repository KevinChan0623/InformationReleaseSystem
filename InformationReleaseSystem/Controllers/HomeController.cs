using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using InformationReleaseSystem.Models;
using InformationReleaseSystem.Services;
using InformationReleaseSystem.ViewModels;

namespace InformationReleaseSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly IText<SortTextUser> _text;

        public HomeController(IText<SortTextUser> text)
        {
            _text = text;
        }

        public IActionResult Index()
        {
            ViewBag.ClickedSortId = 0;
            return View(_text.GetAll());
        }

        public IActionResult ShowTitleBySortId(int sortId)
        {
            ViewBag.ClickedSortId = sortId;
            return View(_text.GetTitleBySortId(sortId));
        }

        public IActionResult SignOut()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }
    }
}
