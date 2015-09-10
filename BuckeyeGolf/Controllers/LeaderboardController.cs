using BuckeyeGolf.Models;
using BuckeyeGolf.Repos;
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
        public ActionResult Index()
        {
            var playerSummaryVM = new LeaderboardViewModel();
            var playerColl = new List<PlayerLeaderboardViewModel>();
            
            using(var repoProvider = new RepoProvider())
            {
                playerSummaryVM.WeeksPlayed = repoProvider.WeekRepo.GetPlayedWeeks().Count();
                foreach (var player in repoProvider.PlayerRepo.GetAll())
                {
                    var playerVM = new PlayerLeaderboardViewModel() { Name = player.Name };
                    playerVM.CurrentHandicap = ServiceProvider.HandicapInstance.CalculateHandicap(player.PlayerId);
                    playerVM.ScoreAvg = repoProvider.RoundRepo.GetPlayerScoreAverage(player.PlayerId);
                    playerVM.TotalPoints = repoProvider.RoundRepo.GetPlayerTotalPoints(player.PlayerId);
                    playerVM.Birds = repoProvider.RoundRepo.GetPlayerBirieTotal(player.PlayerId);
                    playerVM.Pars = repoProvider.RoundRepo.GetPlayerParTotal(player.PlayerId);
                    playerVM.Bogeys = repoProvider.RoundRepo.GetPlayerBogeyTotal(player.PlayerId);

                    playerColl.Add(playerVM);
                }
            }
            playerSummaryVM.PlayerSummary = playerColl.OrderByDescending(t => t.TotalPoints).ToList();
            return View(playerSummaryVM);
        }
    }
}