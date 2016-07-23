using BuckeyeGolf.Models;
using BuckeyeGolf.Repos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace BuckeyeGolf
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer<GolfDbContext>(new GolfLeagueInitializer());
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            
            var dbContext = new GolfDbContext();
            var configSettings = new ConfigRepository(dbContext).Get();
            Application.Add("HandicapWeeks", configSettings.HandicapWeekCount);
            Application.Add("HandicapRoundAdj", configSettings.RoundAdjustment);
            Application.Add("RoundParFront", configSettings.RoundParFront);
            Application.Add("RoundParBack", configSettings.RoundParBack);

            var courseSettings = new CourseRepository(dbContext).Get();
            var parRepo = new ParRespository(dbContext);
            var frontPars = parRepo.GetFrontPars(courseSettings.CourseId);
            var backPars = parRepo.GetBackPars(courseSettings.CourseId);
            Application.Add("FrontPars", frontPars);
            Application.Add("BackPars", backPars);

        }
    }
}
