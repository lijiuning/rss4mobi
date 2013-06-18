using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BootstrapMvcSample.Controllers;
using Rss4Mobi.Common;
using Rss4Mobi.Models;

namespace Rss4Mobi.Controllers
{

    public class AccountController : BootstrapBaseController
    {
        //
        // GET: /Account/
        private readonly Rss4MobiDBContext db = new Rss4MobiDBContext();
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Setting()
        {
            return View();
        }
        [Authorize]
        public ActionResult MyFeeds()
        {
            return View();
        }
        
        public ActionResult Register()
        {
            return View(new RegisterModel());
        }

        [HttpPost]
        public ActionResult Register(RegisterModel register)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var password = Md5.GetMd5Pass(register.Password);
                    var guid = Guid.NewGuid().ToString();
                    var member = new Member
                    {
                        RegisterDate = DateTime.Now,
                        Name = register.UserName,
                        Email = register.Email,
                        IsActive = false,
                        Password = password,
                        GUID = guid
                    };
                    db.Members.Add(member);
                    db.SaveChanges();
                    var link = "http://" + Request.Url.Host + ":" + Request.Url.Port + "/Account/Activation/" +
                               Server.UrlEncode(member.ID.ToString()) + "/" + guid;
                    string content = System.IO.File.ReadAllText(Server.MapPath("~/ActiveEmailContent.htm"));
                    content = content.Replace("[Name]", member.Name);
                    content = content.Replace("[LINK]", link);
                    content = content.Replace("[UserName]", member.Name);
                    content = content.Replace("[Pwd]", register.Password);
                    MailService.SendMail(member.Email, Resources.Info.ActiveEmailTitle, content);

                    Success(Resources.Info.RegisterSuccess);

                }
                catch
                {
                    Error(Resources.Info.RegisterFailed);
                }
                return RedirectToAction("Index", "Home");
            }
            Error(Resources.Info.InputError);
            return View(register);
        }

        public ActionResult LogOn()
        {
            return View(new LogOnModel());
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model)
        {
            if (ModelState.IsValid)
            {
                var md5 = Md5.GetMd5Pass(model.Password);
                var member =
                    db.Members.Where(p => (p.Name == model.UserName || p.Email == model.UserName) && p.Password == md5);
                if (member.Any())
                {
                    var user = member.First();
                    FormsAuthentication.SetAuthCookie(user.Name, false);
                    //存入Session
                    Session["Username"] = user.Name;

                    Success(Resources.Info.LoginSuccess);
                    if (string.IsNullOrEmpty(model.ReturnUrl))
                        return RedirectToAction("Index", "Home");
                    else
                        return Redirect(model.ReturnUrl);
                }

                Error(Resources.Info.UserOrPassWrong);
            }

            return View(model);

        }

        [HttpGet]
        public ActionResult LogOut()
        {
            //取消Session会话
            Session.Abandon();

            //删除Forms验证票证
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// 处理激活
        /// </summary>
        /// <param name="id">用户登录id</param>
        /// <param name="code">激活码</param>
        /// <returns></returns>
        public ActionResult Activation(int id, string code)
        {
            return RedirectToAction(MemberService.ActivateUser(id, code) ? "ActivationSuccess" : "ActivationFaild");
        }

        [HttpGet]
        public ActionResult CheckEmailExists(string Email)
        {
            var exsit = db.Members.Any(p => p.Email == Email);

            return Json(!exsit, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult CheckNameExists(string UserName)
        {
            var exsit = db.Members.Any(p => p.Name == UserName);

            return Json(!exsit, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ActivationSuccess()
        {
            return View();
        }

        public ActionResult ActivationFaild()
        {
            return View();
        }
    }
}
