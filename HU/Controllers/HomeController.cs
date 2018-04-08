using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HU.Models;
using HU.Models.Services;
namespace HU.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Logout()
        {
            var res = CheckCookie();
            if (res != null) RemoveCoockie();
            return View("Index");
        }



        public ActionResult Index()
        {
            var res = CheckCookie();
            if (res == null) return View("Index");
            else return View(@"Account", new HU.Models.MainPage { Person = res, Services = null });
        }

        private void RemoveCoockie()
        {
            HttpCookie cLogin = Request.Cookies["Login"];
            HttpCookie cKey = Request.Cookies["Key"];
            if (cLogin != null) Response.Cookies.Remove("Login");
            if (cKey != null) Response.Cookies.Remove("Key");
        }

        private HU.Models.Person CheckCookie()
        {
            HttpCookie cLogin = Request.Cookies["Login"];
            HttpCookie cKey = Request.Cookies["Key"];
            if (cLogin == null) return null;
            if (cKey == null) return null;
            var res = HU.Logic.Info.DB.People.Get.FirstOrDefault(x => x.Login == cLogin.Value);
            if (res == null) return null;
            if (HU.Logic.Info.Checker.Get(res) != cKey.Value) return null;
            return res;
        }

        private void SetCoockie(HU.Models.Person person)
        {
            Response.Cookies.Set(new HttpCookie("Login", person.Login));
            Response.Cookies.Set(new HttpCookie("Key", HU.Logic.Info.Checker.Get(person)));
        }

        public ActionResult Login(string login, string pass)
        {
            var res = HU.Logic.Info.DB.People.Get.FirstOrDefault(x => x.Login == login && x.Password == pass);
            
            if (res == null) {
                RemoveCoockie();
                return Index();
            }
            SetCoockie(res);
            return Index();
        }

        public ActionResult Get(string Date)
        {
            var res = CheckCookie();
            if (res == null)
            {
                RemoveCoockie();
                return View("Index");
            }

            DateTime D;
            try
            {
                D = Convert.ToDateTime(Date);
            }
            catch
            {
                return View();
            }
            return View(@"Account", new HU.Models.MainPage { Person = res, Services = HU.Logic.Info.contextHelper.GetServicesByPerson(res).Where(x => x.Date == D) });
        }

    }
}