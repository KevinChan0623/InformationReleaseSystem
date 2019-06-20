using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InformationReleaseSystem.Models;
using InformationReleaseSystem.Services;
using InformationReleaseSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace InformationReleaseSystem.Controllers
{
    public class ConsoleController : Controller
    {
        private readonly IUser<User> _user;
        private readonly ISort<Sort> _sort;
        private readonly IText<Text> _text;
        private readonly IText<SortTextUser> _soText;
        private readonly IComment<UserComment> _comment;

        public ConsoleController(IUser<User> user, ISort<Sort> sort, IText<Text> text, IText<SortTextUser> soText, IComment<UserComment> comment)
        {
            _user = user;
            _sort = sort;
            _text = text;
            _soText = soText;
            _comment = comment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddAccount()
        {
            return View();
        }

        public IActionResult ManageSort()
        {
            return View();
        }

        public IActionResult AddText()
        {
            return View();
        }

        public IActionResult DelText()
        {
            return View();
        }

        public IActionResult CheckComment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckComment(UserComment model)
        {
            if (ModelState.IsValid)
            {
                _comment.AllowComment(model.Id);
                ViewBag.Message = "Success";
            }

            return View();
        }

        [HttpPost]
        public IActionResult AddText(Text model)
        {
            if (ModelState.IsValid)
            {
                _text.AddText(model);
                ViewBag.Message = "Success";
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult DelText(SortTextUser model)
        {
            if (ModelState.IsValid)
            {
                _soText.DelText(model.Id);
                ViewBag.Message = "Success";
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult AddSort(SortManage model)
        {
            if (ModelState.IsValid)
            {
                //判断栏目名是否存在
                if (!_sort.IsSortExisted(model.AddName))
                {
                    _sort.AddSort(model.AddName);
                    ViewBag.AddSuccess = "Success";

                    return View("ManageSort");
                }
                else
                {
                    ViewBag.AddError = "Fail";

                    return View("ManageSort");
                }
            }

            return View("ManageSort");
        }

        [HttpPost]
        public IActionResult DelSort(SortManage model)
        {
            if (ModelState.IsValid)
            {
                //判断栏目名是否存在
                if (_sort.IsSortExisted(model.DelName))
                {
                    _sort.DelSort(model.DelName);
                    ViewBag.DelSuccess = "Success";

                    return View("ManageSort");
                }
                else
                {
                    ViewBag.DelError = "Fail";

                    return View("ManageSort");
                }
            }

            return View("ManageSort");
        }

        [HttpPost]
        public IActionResult AddAccount(SignUp model)
        {
            if (ModelState.IsValid)
            {
                //判断用户两次输入密码是否一致
                if (!model.Password.Equals(model.PasswordSubmit))
                {
                    ModelState.AddModelError("", "两次输入的密码不一致");
                    return View("AddAccount");
                }

                //判断用户名是否存在
                if (_user.IsNameExisted(model.Name))
                {
                    ModelState.AddModelError("", "用户名已存在");
                    return View("AddAccount");
                }
                else //完成注册操作
                {
                    _user.SignUp(model.Name, model.Password, 0);
                    ViewBag.Message = "Success";

                    return View("AddAccount", model);
                }
            }

            return View("AddAccount", model);
        }
    }
}