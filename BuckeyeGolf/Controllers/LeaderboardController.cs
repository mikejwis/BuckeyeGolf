using BuckeyeGolf.Models;
using BuckeyeGolf.Services;
using BuckeyeGolf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuckeyeGolf.Controllers
{
    public class LeaderboardController : Controller
    {
        // GET: Leaderboard
        public ActionResult Index()
        {
            var playerColl = new List<PlayerLeaderboardViewModel>();
            using (var dbContext = new GolfDbContext())
            {
                var players = dbContext.Players.ToList();
                foreach(var player in players)
                {
                    var playerVM = new PlayerLeaderboardViewModel();
                    var tmpAvg = dbContext.Rounds.Where(r => r.PlayerRefId.CompareTo(player.PlayerId) == 0 && r.TotalScore != 0).Average(r => r.TotalScore);
                    playerVM.ScoreAvg = Math.Round(tmpAvg, 2);
                    playerVM.TotalPoints = dbContext.Rounds.Where(r => r.PlayerRefId.CompareTo(player.PlayerId) == 0).Sum(r => r.TotalPoints);
                    playerVM.Name = player.Name;
                    playerVM.CurrentHandicap = ServiceProvider.HandicapInstance.CalculateHandicap(player.PlayerId);
                    playerColl.Add(playerVM);
                }
            }
            ViewBag.PlayerList = playerColl.OrderByDescending(t => t.TotalPoints);
            return View();
        }
    }
}