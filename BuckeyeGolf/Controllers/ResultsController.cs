using BuckeyeGolf.Models;
using BuckeyeGolf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuckeyeGolf.Controllers
{
    public class ResultsController : Controller
    {
        // GET: Results
        public ActionResult Index()
        {
            var weekColl = new List<WeekResultsViewModel>();
            using (var dbContext = new GolfDbContext())
            {
                var weeks = dbContext.Weeks.Where(w=>w.BeenPlayed==true).ToList();
                foreach (var week in weeks)
                {
                    var weekResultsVM = new WeekResultsViewModel();
                    weekResultsVM.PlayerRounds = new List<PlayerRoundViewModel>();
                    weekResultsVM.ScoreCreateDate = week.ScoreCreateDate;
                    weekResultsVM.WeekNbr = week.WeekNbr;
                    var rounds = dbContext.Rounds.Where(r => r.WeekId.CompareTo(week.WeekId) == 0).ToList();
                    foreach(var round in rounds)
                    {
                        var player = dbContext.Players.Single(p => p.PlayerId.CompareTo(round.PlayerRefId) == 0);
                        var playerRoundVM = new PlayerRoundViewModel();
                        playerRoundVM.TotalPoints = round.TotalPoints;
                        playerRoundVM.TotalScore = round.TotalScore;
                        playerRoundVM.Name = player.Name;
                        weekResultsVM.PlayerRounds.Add(playerRoundVM);
                    }
                    weekColl.Add(weekResultsVM);
                }
            }
            ViewBag.WeeklyResults = weekColl.OrderByDescending(w => w.ScoreCreateDate);
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            AddRoundWeekViewModel vm = new AddRoundWeekViewModel();

            using(var context = new GolfDbContext())
            {
                var weekList = context.Weeks.Where(w => w.BeenPlayed == false).ToList();
                var minWeekNbr = weekList.Min(m=>m.WeekNbr);
                var week = weekList.Single(w => w.WeekNbr == minWeekNbr);
                vm.WeekNbr = week.WeekNbr;
                ViewBag.WeekNbr = week.WeekNbr;
                vm.WeekId = week.WeekId;
                vm.PlayerRounds = new List<AddRoundViewModel>();
                foreach (var playerItem in context.Players)
                {
                    vm.PlayerRounds.Add(new AddRoundViewModel() { PlayerId = playerItem.PlayerId, PlayerName = playerItem.Name });
                }
            }
            return View(vm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Add(AddRoundWeekViewModel vm)
        {
            if(ModelState.IsValid)
            {
                using(var context = new GolfDbContext())
                {
                    var week = context.Weeks.Single(w=>w.WeekId.CompareTo(vm.WeekId)==0);
                    week.BeenPlayed = true;
                    week.ScoreCreateDate = DateTime.Now;
                    foreach(var roundItem in vm.PlayerRounds)
                    {
                        var newRound = new RoundModel();
                        newRound.PlayerRefId = roundItem.PlayerId;
                        newRound.RoundId = Guid.NewGuid();
                        newRound.WeekId = vm.WeekId;
                        newRound.TotalPoints = roundItem.Points;
                        newRound.TotalScore = roundItem.Score;
                        context.Rounds.Add(newRound);
                    }
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Add");
        }
    }
}