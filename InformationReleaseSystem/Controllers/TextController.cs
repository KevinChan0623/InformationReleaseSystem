using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InformationReleaseSystem.Models;
using InformationReleaseSystem.Services;
using InformationReleaseSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;

namespace InformationReleaseSystem.Controllers
{
    public class TextController : Controller
    {
        private readonly IText<SortTextUser> _text;
        private readonly ISort<Sort> _sort;
        private readonly IComment<UserComment> _comment;

        public TextController(IText<SortTextUser> text, ISort<Sort> sort, IComment<UserComment> comment)
        {
            _text = text;
            _sort = sort;
            _comment = comment;
        }

        public IActionResult Index(int textId)
        {
            if (TempData["TextId"] != null)
            {
                textId = Int32.Parse((string)TempData["TextId"]);
                ViewBag.Message = "Success";
                TempData["TextId"] = null;
            }
            ViewBag.ClickedSortId = _sort.GetSortIdByTextId(textId);
            return View(_text.ShowTextById(textId));
        }

        [HttpPost]
        public IActionResult AddComment(SortTextUser model)
        {
            if (ModelState.IsValid)
            {
                var newModel = new Comment()
                {
                    State = 0,
                    Text = model.Content,
                    TextId = model.Id,
                    UserId = (int)HttpContext.Session.GetInt32("UserId"),
                    Time = DateTime.Now
                };
                _comment.AddComment(newModel);
                ViewBag.Message = "Success";

                TempData["TextId"] = model.Id.ToString();
                return RedirectToAction("Index");
            }

            return View("Index");
        }
    }
}