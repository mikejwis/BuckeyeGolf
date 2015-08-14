using BuckeyeGolf.Models;
using BuckeyeGolf.ViewModels;
using BuckeyeGolf.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuckeyeGolf.Controllers
{
    public class MatchupsController : Controller
    {
        // GET: Matchups
        public ActionResult Index()
        {
            var weekColl = new List<MatchupWeekViewModel>();
            using (var dbContext = new GolfDbContext())
            {
                var weeks = dbContext.Weeks.ToList();
                foreach (var week in weeks)
                {
                    var matchupWeekVM = new MatchupWeekViewModel();
                    matchupWeekVM.WeekNbr = week.WeekNbr;
                    matchupWeekVM.Matchups = new List<MatchupViewModel>();
                    var matches = dbContext.Matchups.Where(m => m.WeekId.CompareTo(week.WeekId) == 0).ToList();
                    foreach(var match in matches)
                    {
                        var matchupVM = new MatchupViewModel();
                        var p1 = dbContext.Players.Single(p => p.PlayerId.CompareTo(match.Player1) == 0);
                        var p2 = dbContext.Players.Single(p => p.PlayerId.CompareTo(match.Player2) == 0);
                        matchupVM.Player1Name = p1.Name;
                        matchupVM.Player1Handicap = ServiceProvider.HandicapInstance.CalculateHandicap(match.Player1);
                        matchupVM.Player2Name = p2.Name;
                        matchupVM.Player2Handicap = ServiceProvider.HandicapInstance.CalculateHandicap(match.Player2);
                        matchupWeekVM.Matchups.Add(matchupVM);
                    }
                    weekColl.Add(matchupWeekVM);
                }
            }
            ViewBag.WeeklyMatchups = weekColl.OrderByDescending(w => w.WeekNbr);
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            using (var dbContext = new GolfDbContext())
            {
                //Todo:  Implement point in time capture of handicap
                var playerCnt = dbContext.Players.Count();
                ViewBag.NbrOfMatchups = Math.Round(playerCnt / 2.0, 0, MidpointRounding.AwayFromZero);
                var highestWeekNbr = dbContext.Weeks.Max(w => w.WeekNbr);
                ViewBag.NewWeekNbr = ++highestWeekNbr;
                var playerList = new List<SelectListItem>();
                playerList.Add(new SelectListItem() { Text = "", Value = "" });
                foreach(var playerItem in dbContext.Players)
                {
                    playerList.Add(new SelectListItem() { Text = playerItem.Name, Value = playerItem.PlayerId.ToString() });
                }
                ViewBag.PlayerSelectList = playerList;
            }
            AddPlayerMatchupViewModel vm = new AddPlayerMatchupViewModel() { WeekNbr = ViewBag.NewWeekNbr, Player1Id = new List<Guid>(), Player2Id = new List<Guid>() };
            return View(vm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Add(AddPlayerMatchupViewModel vm)
        {
            if(ModelState.IsValid && vm.Player1Id.Count() > 0 && vm.Player2Id.Count() > 0)
            {
                //Todo:Validate that each player is selected only once.
                using(var dbContext = new GolfDbContext())
                {
                    var newWeekId = Guid.NewGuid();
                    WeekModel weekObj = new WeekModel() { WeekId = newWeekId, BeenPlayed = false, WeekNbr = vm.WeekNbr, ScoreCreateDate = DateTime.Now };
                    dbContext.Weeks.Add(weekObj);
                    for(int i=0; i<vm.Player1Id.Count; i++)
                    {
                        MatchupModel matchupObj = new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = newWeekId, Player1 = vm.Player1Id[i], Player2 = vm.Player2Id[i] };
                        dbContext.Matchups.Add(matchupObj);
                    }
                    dbContext.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Add");
        }

    }
}