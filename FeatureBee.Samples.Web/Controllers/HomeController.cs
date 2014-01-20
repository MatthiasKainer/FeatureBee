﻿using System.Web.Mvc;

namespace FeatureBee.Samples.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Feature.InjectEvaluator(featureName => true);
            if (Feature.IsEnabled("PMVM-1150 Booking Overview"))
            {
                ViewBag.Message = "Congratulations. You passed FeatureBee´s conditions";
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}