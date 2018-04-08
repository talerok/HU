using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HU.Models;
using HU.Models.Services;

namespace HU.Controllers
{
    //#region Possessions
    //#endregion 

    /*
    public ActionResult CreatePerson()
    {
        return View(@"People\Create");
    }
     */
    public class AdminController : Controller
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
            if (res.Role.Level < 2) return false;
            return true;
        }

        #region Flats 
        //---------------------------
        public ActionResult Index()
        {
            if (!CheckCookie()) return Redirect("/");
            return View();
        }

        public ActionResult Flats()
        {
            if (!CheckCookie()) return Redirect("/");
            return View(@"Flats\Get", Logic.Info.DB.Flats.Get);
        }

        public ActionResult Flat(int id)
        {
            if (!CheckCookie()) return Redirect("/");
            return View(@"Flats\Edit", Logic.Info.DB.Flats.Get.FirstOrDefault(x => x.Id == id));
        }

        public ActionResult CreateFlat()
        {
            if (!CheckCookie()) return Redirect("/");
            return View(@"Flats\Create");
        }

        public ActionResult AddFlat(Flat flat)
        {
            if (!CheckCookie()) return Redirect("/");
            if (flat != null)
            {
                Logic.Info.DB.Flats.Add(flat);
                Logic.Info.DB.Save();
            }

            return Flats();
        }

        public ActionResult DeleteFlat(int id)
        {
            if (!CheckCookie()) return Redirect("/");
            var flat = Logic.Info.DB.Flats.Get.FirstOrDefault(x => x.Id == id);
            if (flat != null)
            {
                Logic.Info.DB.Flats.Dell(flat);
                Logic.Info.DB.Save();
            }
            return Flats();
        }

        [HttpPost]
        public ActionResult EditFlat(Flat flat)
        {
            if (!CheckCookie()) return Redirect("/");
            if (flat != null)
            {
                Logic.Info.DB.Flats.Edited(flat);
                Logic.Info.DB.Save();
            }
            return Flats();
        }
        #endregion

        #region People
        //---------------------------
        public ActionResult People()
        {
            if (!CheckCookie()) return Redirect("/");
            return View(@"People\Get", Logic.Info.DB.People.Get);
        }

        public ActionResult Person(int id)
        {
            if (!CheckCookie()) return Redirect("/");
            return View(@"People\Edit", Logic.Info.DB.People.Get.FirstOrDefault(x => x.Id == id));
        }

        public ActionResult CreatePerson()
        {
            if (!CheckCookie()) return Redirect("/");
            return View(@"People\Create");
        }

        public ActionResult AddPerson(Person person, int RoleId)
        {
            if (!CheckCookie()) return Redirect("/");
            var Role = Logic.Info.DB.RoleInfos.Get.FirstOrDefault(x => x.Id == RoleId);
            if (person != null && Role != null)
            {
                person.Role = Role;
                Logic.Info.DB.People.Add(person);
                Logic.Info.DB.Save();
            }

            return RedirectToAction("People");
        }

        public ActionResult DeletePerson(int id)
        {
            if (!CheckCookie()) return Redirect("/");
            var person = Logic.Info.DB.People.Get.FirstOrDefault(x => x.Id == id);
            if (person != null)
            {
                Logic.Info.DB.People.Dell(person);
                Logic.Info.DB.Save();
            }

            return RedirectToAction("People");
        }

        [HttpPost]
        public ActionResult EditPerson(Person person, int RoleId)
        {
            if (!CheckCookie()) return Redirect("/");
            var Role = Logic.Info.DB.RoleInfos.Get.FirstOrDefault(x => x.Id == RoleId);
            if (person != null && Role != null)
            {
                person.Role = Role;
                Logic.Info.DB.People.Edited(person);
                Logic.Info.DB.Save();
            }
            return RedirectToAction("People");
        }
        #endregion 

        #region Possessions
        //---------------------------
        public ActionResult Possessions()
        {
            if (!CheckCookie()) return Redirect("/");
            return View(@"Possessions\Get", Logic.Info.DB.Possession.Get);
        }

        public ActionResult Possession(int id)
        {
            if (!CheckCookie()) return Redirect("/");
            return View(@"Possessions\Edit", Logic.Info.DB.Possession.Get.FirstOrDefault(x => x.Id == id));
        }

        public ActionResult CreatePossession()
        {
            if (!CheckCookie()) return Redirect("/");
            return View(@"Possessions\Create");
        }

        public ActionResult AddPossession(Possession possession, int FlatId, int OwnerId)
        {
            if (!CheckCookie()) return Redirect("/");
            var Owner = Logic.Info.DB.People.Get.FirstOrDefault(x => x.Id == OwnerId);
            var Flat = Logic.Info.DB.Flats.Get.FirstOrDefault(x => x.Id == FlatId);
            if (possession != null && Owner != null && Flat != null)
            {
                possession.Owner = Owner;
                possession.Flat = Flat;
                Logic.Info.DB.Possession.Add(possession);
                Logic.Info.DB.Save();
            }

            return RedirectToAction("Possessions");
        }

        public ActionResult DeletePossession(int id)
        {
            if (!CheckCookie()) return Redirect("/");
            var possession = Logic.Info.DB.Possession.Get.FirstOrDefault(x => x.Id == id);
            if (possession != null)
            {
                Logic.Info.DB.Possession.Dell(possession);
                Logic.Info.DB.Save();
            }
            return RedirectToAction("Possessions");
        }

        public ActionResult EditPossession(Possession possession, int FlatId, int OwnerId)
        {
            if (!CheckCookie()) return Redirect("/");
            var Owner = Logic.Info.DB.People.Get.FirstOrDefault(x => x.Id == OwnerId);
            var Flat = Logic.Info.DB.Flats.Get.FirstOrDefault(x => x.Id == FlatId);
            if (possession != null && Owner != null && Flat != null)
            {
                possession.Owner = Owner;
                possession.Flat = Flat;
                Logic.Info.DB.Possession.Edited(possession);
                Logic.Info.DB.Save();
            }
            return RedirectToAction("Possessions");
        }
        #endregion

        #region Roles
        //---------------------------
        public ActionResult Roles()
        {
            if (!CheckCookie()) return Redirect("/");
            return View(@"Roles\Get", Logic.Info.DB.RoleInfos.Get);
        }

        public ActionResult Role(int id)
        {
            if (!CheckCookie()) return Redirect("/");
            return View(@"Roles\Edit", Logic.Info.DB.RoleInfos.Get.FirstOrDefault(x => x.Id == id));
        }

        public ActionResult CreateRole()
        {
            if (!CheckCookie()) return Redirect("/");
            return View(@"Roles\Create");
        }

        public ActionResult AddRole(Role role)
        {
            if (!CheckCookie()) return Redirect("/");
            if (role != null)
            {
                Logic.Info.DB.RoleInfos.Add(role);
                Logic.Info.DB.Save();
            }

            return RedirectToAction("Roles");
        }

        public ActionResult DeleteRole(int id)
        {
            if (!CheckCookie()) return Redirect("/");
            var role = Logic.Info.DB.RoleInfos.Get.FirstOrDefault(x => x.Id == id);
            if (role != null)
            {
                Logic.Info.DB.RoleInfos.Dell(role);
                Logic.Info.DB.Save();
            }

            return RedirectToAction("Roles");
        }

        public ActionResult EditRole(Role role)
        {
            if (!CheckCookie()) return Redirect("/");
            if (role != null)
            {
                Logic.Info.DB.RoleInfos.Edited(role);
                Logic.Info.DB.Save();
            }

            return RedirectToAction("Roles");
        }
        #endregion 

        #region Payements
        //---------------------------
        public ActionResult Payements()
        {
            if (!CheckCookie()) return Redirect("/");
            return View(@"Payements\Get", Logic.Info.DB.PaymentTypes.Get);
        }

        public ActionResult Playement(int id)
        {
            if (!CheckCookie()) return Redirect("/");
            return View(@"Payements\Edit", Logic.Info.DB.PaymentTypes.Get.FirstOrDefault(x => x.Id == id));
        }

        public ActionResult CreatePayement()
        {
            if (!CheckCookie()) return Redirect("/");
            return View(@"Payements\Create");
        }

        public ActionResult AddPayement(PayementType payement)
        {
            if (!CheckCookie()) return Redirect("/");
            if (payement != null)
            {
                Logic.Info.DB.PaymentTypes.Add(payement);
                Logic.Info.DB.Save();
            }

            return RedirectToAction("Payements");
        }

        public ActionResult DeletePayement(int id)
        {
            if (!CheckCookie()) return Redirect("/");
            var payement = Logic.Info.DB.PaymentTypes.Get.FirstOrDefault(x => x.Id == id);
            if (payement != null)
            {
                Logic.Info.DB.PaymentTypes.Dell(payement);
                Logic.Info.DB.Save();
            }

            return RedirectToAction("Payements");
        }

        public ActionResult EditPayement(PayementType payement)
        {
            if (!CheckCookie()) return Redirect("/");
            if (payement != null)
            {
                Logic.Info.DB.PaymentTypes.Edited(payement);
                Logic.Info.DB.Save();
            }

            return RedirectToAction("Payements");
        }
        #endregion 

        #region Services
        //---------------------------
        public ActionResult Services()
        {
            if (!CheckCookie()) return Redirect("/");
            return View(@"Services\Get", Logic.Info.DB.Services.Get);
        }

        public ActionResult Service(int id)
        {
            if (!CheckCookie()) return Redirect("/");
            return View(@"Services\Edit", Logic.Info.DB.Services.Get.FirstOrDefault(x => x.Id == id));
        }

        public ActionResult CreateService()
        {
            if (!CheckCookie()) return Redirect("/");
            return View(@"Services\Create");
        }

        public ActionResult AddService(Service service, int FlatId, int InfoId)
        {
            if (!CheckCookie()) return Redirect("/");
            var Flat = Logic.Info.DB.Flats.Get.FirstOrDefault(x => x.Id == FlatId);
            var Info = Logic.Info.DB.ServicesInfos.Get.FirstOrDefault(x => x.Id == InfoId);
            if (service != null && Flat != null && Info != null)
            {
                service.Flat = Flat;
                service.Info = Info;
                Logic.Info.DB.Services.Add(service);
                Logic.Info.DB.Save();
            }

            return RedirectToAction("Services");
        }

        public ActionResult DeleteService(int id)
        {
            if (!CheckCookie()) return Redirect("/");
            var service = Logic.Info.DB.Services.Get.FirstOrDefault(x => x.Id == id);
            if (service != null)
            {
                Logic.Info.DB.Services.Dell(service);
                Logic.Info.DB.Save();
            }

            return RedirectToAction("Services");
        }

        public ActionResult EditService(Service service, int FlatId, int InfoId)
        {
            if (!CheckCookie()) return Redirect("/");
            var Flat = Logic.Info.DB.Flats.Get.FirstOrDefault(x => x.Id == FlatId);
            var Info = Logic.Info.DB.ServicesInfos.Get.FirstOrDefault(x => x.Id == InfoId);
            if (service != null && Flat != null && Info != null)
            {
                service.Flat = Flat;
                service.Info = Info;
                Logic.Info.DB.Services.Edited(service);
                Logic.Info.DB.Save();
            }

            return RedirectToAction("Services");
        }
        #endregion 

        #region ServicesInfos
        //---------------------------
        public ActionResult ServicesInfos()
        {
            if (!CheckCookie()) return Redirect("/");
            return View(@"ServicesInfos\Get", Logic.Info.DB.ServicesInfos.Get);
        }

        public ActionResult ServiceInfo(int id)
        {
            if (!CheckCookie()) return Redirect("/");
            return View(@"ServicesInfos\Edit", Logic.Info.DB.ServicesInfos.Get.FirstOrDefault(x => x.Id == id));
        }

        public ActionResult CreateServiceInfo()
        {
            if (!CheckCookie()) return Redirect("/");
            return View(@"ServicesInfos\Create");
        }

        public ActionResult AddServiceInfo(ServiceInfo serviceInfo, int PayementId)
        {
            if (!CheckCookie()) return Redirect("/");
            var Payement = Logic.Info.DB.PaymentTypes.Get.FirstOrDefault(x => x.Id == PayementId);
            if (serviceInfo != null && Payement != null)
            {
                serviceInfo.paymentType = Payement;
                Logic.Info.DB.ServicesInfos.Add(serviceInfo);
                Logic.Info.DB.Save();
            }

            return RedirectToAction("ServicesInfos");
        }

        public ActionResult DeleteServiceInfo(int id)
        {
            if (!CheckCookie()) return Redirect("/");
            var serviceInfo = Logic.Info.DB.ServicesInfos.Get.FirstOrDefault(x => x.Id == id);
            if (serviceInfo != null)
            {
                Logic.Info.DB.ServicesInfos.Dell(serviceInfo);
                Logic.Info.DB.Save();
            }

            return RedirectToAction("ServicesInfos");
        }

        public ActionResult EditServiceInfo(ServiceInfo serviceInfo, int PayementId)
        {
            if (!CheckCookie()) return Redirect("/");
            var Payement = Logic.Info.DB.PaymentTypes.Get.FirstOrDefault(x => x.Id == PayementId);
            if (serviceInfo != null && Payement != null)
            {
                serviceInfo.paymentType = Payement;
                Logic.Info.DB.ServicesInfos.Edited(serviceInfo);
                Logic.Info.DB.Save();
            }

            return RedirectToAction("ServicesInfos");
        }
        #endregion 
    }
}