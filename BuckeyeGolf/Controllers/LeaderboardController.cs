using BuckeyeGolf.Models;
using BuckeyeGolf.Repos;
using BuckeyeGolf.Services;
using BuckeyeGolf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace BuckeyeGolf.Controllers
{
    public class LeaderboardController : ApiController
    {
        //GET api/Leaderboard
        public LeaderboardViewModel Get()
        {
            var playerVM = new LeaderboardViewModel();
            playerVM.WeeksPlayed = 1;
            playerVM.PlayerSummary = new List<PlayerLeaderboardViewModel>();
            var p1 = new PlayerLeaderboardViewModel() { Name = "Keith", TotalPoints = 12.5, ScoreAvg = 43, CurrentHandicap = 10, Birds = 1, Pars = 1, Bogeys = 5 };
            playerVM.PlayerSummary.Add(p1);
            var p2 = new PlayerLeaderboardViewModel() { Name = "Len", TotalPoints = 11, ScoreAvg = 43, CurrentHandicap = 9, Birds = 0, Pars = 3, Bogeys = 4 };
            playerVM.PlayerSummary.Add(p2);
            var p3 = new PlayerLeaderboardViewModel() { Name = "Todd", TotalPoints = 9.5, ScoreAvg = 46, CurrentHandicap = 12, Birds = 0, Pars = 1, Bogeys = 5 };
            playerVM.PlayerSummary.Add(p3);
            var p4 = new PlayerLeaderboardViewModel() { Name = "Mark", TotalPoints = 9.5, ScoreAvg = 50, CurrentHandicap = 14, Birds = 0, Pars = 2, Bogeys = 3 };
            playerVM.PlayerSummary.Add(p4);
            var p5 = new PlayerLeaderboardViewModel() { Name = "Kevin", TotalPoints = 8.5, ScoreAvg = 49, CurrentHandicap = 16, Birds = 0, Pars = 1, Bogeys = 3 };
            playerVM.PlayerSummary.Add(p5);
            var p6 = new PlayerLeaderboardViewModel() { Name = "Brandon", TotalPoints = 6.5, ScoreAvg = 54, CurrentHandicap = 19, Birds = 0, Pars = 1, Bogeys = 3 };
            playerVM.PlayerSummary.Add(p6);
            var p7 = new PlayerLeaderboardViewModel() { Name = "Tom S", TotalPoints = 6, ScoreAvg = 47, CurrentHandicap = 11, Birds = 0, Pars = 1, Bogeys = 4 };
            playerVM.PlayerSummary.Add(p7);
            var p8 = new PlayerLeaderboardViewModel() { Name = "Bill", TotalPoints = 6, ScoreAvg = 56, CurrentHandicap = 20, Birds = 0, Pars = 1, Bogeys = 2 };
            playerVM.PlayerSummary.Add(p8);
            var p9 = new PlayerLeaderboardViewModel() { Name = "Jack", TotalPoints = 5, ScoreAvg = 53, CurrentHandicap = 16, Birds = 0, Pars = 1, Bogeys = 2 };
            playerVM.PlayerSummary.Add(p9);
            var p10 = new PlayerLeaderboardViewModel() { Name = "Emil", TotalPoints = 3.5, ScoreAvg = 71, CurrentHandicap = 31, Birds = 0, Pars = 0, Bogeys = 1 };
            playerVM.PlayerSummary.Add(p10);
            var p11 = new PlayerLeaderboardViewModel() { Name = "Mike", TotalPoints = 3, ScoreAvg = 61, CurrentHandicap = 18, Birds = 0, Pars = 0, Bogeys = 0 };
            playerVM.PlayerSummary.Add(p11);
            var p12 = new PlayerLeaderboardViewModel() { Name = "David", TotalPoints = 1, ScoreAvg = 0, CurrentHandicap = 9, Birds = 0, Pars = 0, Bogeys = 0 };
            playerVM.PlayerSummary.Add(p12);
            return playerVM;
        }

        /*        public ActionResult Index()
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
         */
    }
}
