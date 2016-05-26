﻿using BuckeyeGolf.Models;
using BuckeyeGolf.Repos;
using BuckeyeGolf.Services;
using BuckeyeGolf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Caching;
using System.Web.Http;

namespace BuckeyeGolf.Controllers
{
    public class LeaderboardController : ApiController
    {
        //GET api/Leaderboard
        public LeaderboardViewModel Get()
        {
            LeaderboardViewModel leaderboardVM = HttpRuntime.Cache["Leaderboard"] as LeaderboardViewModel;
            if (leaderboardVM == null)
            {
                leaderboardVM = getModelData();
                HttpRuntime.Cache.Insert("Leaderboard", leaderboardVM, null, DateTime.Now.AddMinutes(60), Cache.NoSlidingExpiration);
            }
            return leaderboardVM;
            //return getSeedData();
        }

        private LeaderboardViewModel getSeedData()
        {
            var playerVM = new LeaderboardViewModel();
            playerVM.WeeksPlayed = 3;
            playerVM.PlayerSummary = new List<PlayerLeaderboardViewModel>();
            var p1 = new PlayerLeaderboardViewModel() { Name = "Len", TotalPoints = 28.5, ScoreAvg = 44.67, CurrentHandicap = 9, Birds = 0, Pars = 8, Bogeys = 11 };
            playerVM.PlayerSummary.Add(p1);
            var p2 = new PlayerLeaderboardViewModel() { Name = "Keith", TotalPoints = 28.5, ScoreAvg = 47, CurrentHandicap = 11, Birds = 1, Pars = 5, Bogeys = 11 };
            playerVM.PlayerSummary.Add(p2);
            var p3 = new PlayerLeaderboardViewModel() { Name = "Mark", TotalPoints = 27.5, ScoreAvg = 49, CurrentHandicap = 13, Birds = 0, Pars = 4, Bogeys = 11 };
            playerVM.PlayerSummary.Add(p3);
            var p4 = new PlayerLeaderboardViewModel() { Name = "Kevin", TotalPoints = 25.5, ScoreAvg = 49.67, CurrentHandicap = 15, Birds = 0, Pars = 4, Bogeys = 7 };
            playerVM.PlayerSummary.Add(p4);
            var p5 = new PlayerLeaderboardViewModel() { Name = "Todd", TotalPoints = 18, ScoreAvg = 53, CurrentHandicap = 15, Birds = 0, Pars = 2, Bogeys = 8 };
            playerVM.PlayerSummary.Add(p5);
            var p6 = new PlayerLeaderboardViewModel() { Name = "Bill", TotalPoints = 17, ScoreAvg = 56.67, CurrentHandicap = 20, Birds = 0, Pars = 2, Bogeys = 4 };
            playerVM.PlayerSummary.Add(p6);
            var p7 = new PlayerLeaderboardViewModel() { Name = "Mike", TotalPoints = 16.5, ScoreAvg = 58.67, CurrentHandicap = 19, Birds = 1, Pars = 1, Bogeys = 1 };
            playerVM.PlayerSummary.Add(p7);
            var p8 = new PlayerLeaderboardViewModel() { Name = "Tom S", TotalPoints = 16.5, ScoreAvg = 51.33, CurrentHandicap = 13, Birds = 0, Pars = 2, Bogeys = 5 };
            playerVM.PlayerSummary.Add(p8);
            var p9 = new PlayerLeaderboardViewModel() { Name = "Brandon", TotalPoints = 16, ScoreAvg = 55.33, CurrentHandicap = 19, Birds = 0, Pars = 1, Bogeys = 4 };
            playerVM.PlayerSummary.Add(p9);
            var p10 = new PlayerLeaderboardViewModel() { Name = "David", TotalPoints = 14.5, ScoreAvg = 50, CurrentHandicap = 12, Birds = 0, Pars = 1, Bogeys = 7 };
            playerVM.PlayerSummary.Add(p10);
            var p11 = new PlayerLeaderboardViewModel() { Name = "Emil", TotalPoints = 14, ScoreAvg = 69, CurrentHandicap = 30, Birds = 0, Pars = 0, Bogeys = 4 };
            playerVM.PlayerSummary.Add(p11);
            var p12 = new PlayerLeaderboardViewModel() { Name = "Jack", TotalPoints = 13, ScoreAvg = 56.67, CurrentHandicap = 18, Birds = 0, Pars = 2, Bogeys = 4 };
            playerVM.PlayerSummary.Add(p12);
            return playerVM;
        }

        private LeaderboardViewModel getModelData()
        {
            var playerSummaryVM = new LeaderboardViewModel();
            var playerColl = new List<PlayerLeaderboardViewModel>();

            using (var repoProvider = new RepoProvider())
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
            return playerSummaryVM;
        }

    }
}
