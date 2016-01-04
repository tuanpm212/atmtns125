using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using Waterbuffalortours.Business;
using Waterbuffalortours.Business.Model;
using Waterbuffalortours.Data;

namespace Waterbuffalotours.Controllers
{
    public class HomeController : Controller
    {
        #region Variables

            IHome homeBO;

        #endregion

        #region Contructor

            public HomeController()
            {
                homeBO = homeBO ?? new HomeBO();
            }

        #endregion

        #region Actions

            public ActionResult Index()
            {
                return View();
            }

        #endregion

        #region Json Result

            public JsonResult InitialData()
            {
                try
                {
                    string jsonSlide = string.Empty, jsonIntroduction = string.Empty, jsonTours = string.Empty, jsonHome = string.Empty;
                    var slides = this.homeBO.GetList(m => m.SlideType == "");
                    jsonSlide = new JavaScriptSerializer().Serialize(slides);

                    var textDataBO = new TextDataBO();
                    var introductions = textDataBO.GetByID("WELCOME_HOME");
                    jsonIntroduction = new JavaScriptSerializer().Serialize(introductions);

                    var tourBO = new TourBO();
                    var tours = tourBO.GetHomeTour();
                    jsonHome = new JavaScriptSerializer().Serialize(tours);

                    return Json(new { isOk = true, slides = jsonSlide, introduction = jsonIntroduction, tours = jsonHome }, JsonRequestBehavior.AllowGet);

                }
                catch
                {
                    return Json(new { isOk = false }, JsonRequestBehavior.AllowGet);
                }
            }

        #endregion

    }
}