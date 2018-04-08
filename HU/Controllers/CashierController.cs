using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HU.Controllers
{
    public class CashierController : Controller
    {
        private bool CheckCookie()
        {
            HttpCookie cLogin = Request.Cookies["Login"];
            HttpCookie cKey = Request.Cookies["Key"];
            if (cLogin == null) return false;
            if (cKey == null) return false;
            var res = HU.Logic.Info.DB.People.Get.FirstOrDefault(x => x.Login == cLogin.Value);
            if (res == null) return false;
            if (HU.Logic.Info.Checker.Get(res) != cKey.Value) return false;
            if (res.Role.Level != 1) return false;
            return true;
        }

        public ActionResult Index()
        {
            if (!CheckCookie()) return Redirect(@"\");
            return View();
        }

        public ActionResult Get(int personId, int serviceId)
        {
            if(!CheckCookie()) return Redirect(@"\");
            var Person = Logic.Info.DB.People.Get.FirstOrDefault(x => x.Id == personId);
            if(Person == null) View("Index", null);
            var Service = Logic.Info.contextHelper.GetServicesByPerson(Person).FirstOrDefault(x => x.Id == serviceId);
            return View("Index", new HU.Models.ServicePage { Person = Person, Service = Service  });
        }

        public ActionResult Accept(int personId, int serviceId)
        {
            if (!CheckCookie()) return Redirect(@"\");
            var Person = Logic.Info.DB.People.Get.FirstOrDefault(x => x.Id == personId);
            if (Person == null) View("Index", null);
            var Service = Logic.Info.contextHelper.GetServicesByPerson(Person).FirstOrDefault(x => x.Id == serviceId);
            if(Service != null)
            {
                var Fact = Logic.Info.DB.PayementFacts.Get.FirstOrDefault(x => x.Person == Person && x.Service == Service);
                if(Fact != null)
                {
                    Fact.Paid = true;
                    Logic.Info.DB.PayementFacts.Edited(Fact);
                    Logic.Info.DB.Save();
                }
                else
                {
                    Fact = new Models.PayementFact { Paid = true, Person = Person, Service = Service };
                    Logic.Info.DB.PayementFacts.Add(Fact);
                    Logic.Info.DB.Save();
                }
            }
            return View("Index",null);
        }
    }
}