using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using InformationReleaseSystem.Services;
using InformationReleaseSystem.Models;
using InformationReleaseSystem.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InformationReleaseSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly IUser<User> _user;

        public UserController(IUser<User> user)
        {
            _user = user;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            ModelState.AddModelError("Success", "");
            return View();
        }

        public IActionResult ChangePassword()
        {
            ModelState.AddModelError("Success", "");
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUp model)
        {
            if (ModelState.IsValid)
            {
                //判断用户两次输入密码是否一致
                if (!model.Password.Equals(model.PasswordSubmit))
                {
                    ModelState.AddModelError("", "两次输入的密码不一致");
                    return View("SignUp");
                }

                //判断用户名是否存在
                if (_user.IsNameExisted(model.Name))
                {
                    ModelState.AddModelError("", "用户名已存在");
                    return View("SignUp");
                }
                else //完成注册操作
                {
                    _user.SignUp(model.Name, model.Password, 1);
                    ViewBag.Message = "Success";

                    return View("SignUp", model);
                }
            }

            return View("SignUp", model);
        }

        [HttpPost]
        public IActionResult Index(SignIn model)
        {
            if (ModelState.IsValid)
            {
                var user = _user.CheckAccount(model.Name, model.Password);
                if (user != null)
                {
                    HttpContext.Session.Set("CurrentUser", ByteConvertHelper.Object2Bytes(user));
                    HttpContext.Session.SetInt32("UserId", _user.GetIdByName(model.Name));
                    HttpContext.Session.SetString("UserName", model.Name);
                    HttpContext.Session.SetString("Password", model.Password);
                    HttpContext.Session.SetInt32("Permission", _user.GetPermissionByName(model.Name));

                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "用户名或密码错误");
                return View("Index");
            }

            return View("Index", model);
        }

        [HttpPost]
        public IActionResult ChangePassword(ChangePassword model)
        {
            if (ModelState.IsValid)
            {
                //判断用户两次输入密码是否一致
                if (!model.Password.Equals(model.PasswordSubmit))
                {
                    ModelState.AddModelError("", "两次输入的密码不一致");
                    return View("ChangePassword");
                }
                else
                {
                    _user.ChangePassword(model.Password);
                    ViewBag.Message = "Success";

                    return View("ChangePassword", model);
                }
            }

            return View("ChangePassword", model);
        }
    }
}