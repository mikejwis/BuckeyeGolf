﻿using BuckeyeGolf.Models;
using BuckeyeGolf.Repos;
using BuckeyeGolf.Services;
using BuckeyeGolf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Http;

namespace BuckeyeGolf.Controllers
{
    public class LeaderboardController : ApiController
    {
        //GET api/Leaderboard
        public async Task<LeaderboardViewModel> Get()
        {
            LeaderboardViewModel leaderboardVM = HttpRuntime.Cache["Leaderboard"] as LeaderboardViewModel;
            if (leaderboardVM == null)
            {
                leaderboardVM = await getModelData();
                HttpRuntime.Cache.Insert("Leaderboard", leaderboardVM, null, DateTime.Now.AddMinutes(60), Cache.NoSlidingExpiration);
            }
            return leaderboardVM;
        }


        private async Task<LeaderboardViewModel> getModelData()
        {
            var playerSummaryVM = new LeaderboardViewModel();
            var firstHalfPlayerColl = new List<PlayerLeaderboardViewModel>();
            var secondHalfPlayerColl = new List<PlayerLeaderboardViewModel>();

            using (var repoProvider = new RepoProvider())
            {
                playerSummaryVM.WeeksPlayed = repoProvider.WeekRepo.GetPlayedWeeks().Count();
                //first half
                foreach (var player in await repoProvider.PlayerRepo.GetAll())
                {
                    var playerVM = new PlayerLeaderboardViewModel() { Name = player.Name };
                    playerVM.CurrentHandicap = await ServiceProvider.HandicapInstance.CalculateHandicap(player.PlayerId);
                    playerVM.ScoreAvg = repoProvider.RoundRepo.GetPlayerScoreAverage(player.PlayerId, true);
                    playerVM.TotalPoints = repoProvider.RoundRepo.GetPlayerTotalPoints(player.PlayerId, true);
                    playerVM.Birds = repoProvider.RoundRepo.GetPlayerBirieTotal(player.PlayerId, true);
                    playerVM.Pars = repoProvider.RoundRepo.GetPlayerParTotal(player.PlayerId, true);
                    playerVM.Bogeys = repoProvider.RoundRepo.GetPlayerBogeyTotal(player.PlayerId, true);

                    firstHalfPlayerColl.Add(playerVM);
                }
                //second half
                foreach (var player in await repoProvider.PlayerRepo.GetAll())
                {
                    var playerVM = new PlayerLeaderboardViewModel() { Name = player.Name };
                    playerVM.CurrentHandicap = await ServiceProvider.HandicapInstance.CalculateHandicap(player.PlayerId);
                    playerVM.ScoreAvg = repoProvider.RoundRepo.GetPlayerScoreAverage(player.PlayerId, false);
                    playerVM.TotalPoints = repoProvider.RoundRepo.GetPlayerTotalPoints(player.PlayerId, false);
                    playerVM.Birds = repoProvider.RoundRepo.GetPlayerBirieTotal(player.PlayerId, false);
                    playerVM.Pars = repoProvider.RoundRepo.GetPlayerParTotal(player.PlayerId, false);
                    playerVM.Bogeys = repoProvider.RoundRepo.GetPlayerBogeyTotal(player.PlayerId, false);

                    secondHalfPlayerColl.Add(playerVM);
                }
            }


            playerSummaryVM.FirstHalfPlayerSummary = firstHalfPlayerColl.OrderByDescending(t => t.TotalPoints).ToList();
            playerSummaryVM.SecondHalfPlayerSummary = secondHalfPlayerColl.OrderByDescending(t => t.TotalPoints).ToList();
            return playerSummaryVM;
        }

    }
}
