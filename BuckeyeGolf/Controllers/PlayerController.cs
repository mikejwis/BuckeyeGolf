using BuckeyeGolf.Models;
using BuckeyeGolf.Repos;
using BuckeyeGolf.Services;
using BuckeyeGolf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Http;
using System.Web.Mvc;

namespace BuckeyeGolf.Controllers
{
    public class PlayerController : ApiController
    {
        public async Task<PlayercardViewModel> Get(string id)
        {

            PlayercardViewModel vm = HttpRuntime.Cache[id] as PlayercardViewModel;
            if (vm == null)
            {
                vm = await getModelData(id);
                if (!string.IsNullOrEmpty(vm.Name))
                {
                    HttpRuntime.Cache.Insert(id, vm, null, DateTime.Now.AddMinutes(120), Cache.NoSlidingExpiration);
                }
            }
            return vm;
        }

        public async Task<IHttpActionResult> Patch()
        {
            using (var repoProvider = new RepoProvider())
            {
                
                var player = await repoProvider.PlayerRepo.Get("B Roberto");
                //var updatedPlayer = new PlayerModel();
                //updatedPlayer.Name = "Ron";
                //updatedPlayer.HandicapRound1 = 48;
                //updatedPlayer.HandicapRound2 = 49;
                //updatedPlayer.PlayerId = player.PlayerId;
                //updatedPlayer.Rounds = player.Rounds;
                //var round = player.Rounds.First(r => r.TotalScore == 0);
                //var roundW3 = updatedPlayer.Rounds.First(r => r.TotalScore == 49);
                //repoProvider.PlayerRepo.Update(player, updatedPlayer);

                var weekId = repoProvider.WeekRepo.GetWeekByNumber(8).WeekId;

                var oldRound = repoProvider.RoundRepo.GetWeeklyRound(player.PlayerId,weekId);
                var newRound = new RoundModel();
                newRound.AttendancePoints = 1;
                newRound.BirdieCnt = 1;
                newRound.BogeyCnt = 3;
                newRound.EagleCnt = 0;
                newRound.Front = oldRound.Front;
                newRound.Handicap = oldRound.Handicap;
                newRound.MatchupPoints = 6;
                newRound.ParCnt = 3;
                newRound.PlayerRef = oldRound.PlayerRef;
                newRound.PlayerRefId = oldRound.PlayerRefId;
                newRound.Result = MatchupResult.Win;
                newRound.Scores = oldRound.Scores;
                newRound.SeasonFirstHalf = oldRound.SeasonFirstHalf;
                newRound.TotalPoints = 14.5;
                newRound.TotalScore = 43;
                newRound.WeekId = oldRound.WeekId;
                newRound.RoundId = oldRound.RoundId;

                repoProvider.RoundRepo.Update(oldRound, newRound);


                var player2 = await repoProvider.PlayerRepo.Get("Bill H");

                var oldRound2 = repoProvider.RoundRepo.GetWeeklyRound(player2.PlayerId, weekId);
                var newRound2 = new RoundModel();
                newRound2.AttendancePoints = 2;
                newRound2.BirdieCnt = oldRound2.BirdieCnt;
                newRound2.BogeyCnt = oldRound2.BogeyCnt;
                newRound2.EagleCnt = 0;
                newRound2.Front = oldRound2.Front;
                newRound2.Handicap = oldRound2.Handicap;
                newRound2.MatchupPoints = 0;
                newRound2.ParCnt = oldRound2.ParCnt;
                newRound2.PlayerRef = oldRound2.PlayerRef;
                newRound2.PlayerRefId = oldRound2.PlayerRefId;
                newRound2.Result = MatchupResult.Loss;
                newRound2.Scores = oldRound2.Scores;
                newRound2.SeasonFirstHalf = oldRound2.SeasonFirstHalf;
                newRound2.TotalPoints = 3.5;
                newRound2.TotalScore = oldRound2.TotalScore;
                newRound2.WeekId = oldRound2.WeekId;
                newRound2.RoundId = oldRound2.RoundId;

                repoProvider.RoundRepo.Update(oldRound2, newRound2);

                //var newRoundW3 = new RoundModel();

                //var oldRoundW3 = repoProvider.RoundRepo.GetWeeklyRound(player.PlayerId, roundW3.WeekId);
                //newRoundW3.AttendancePoints = oldRoundW3.AttendancePoints;
                //newRoundW3.BirdieCnt = oldRoundW3.BirdieCnt;
                //newRoundW3.BogeyCnt = oldRoundW3.BogeyCnt;
                //newRoundW3.EagleCnt = oldRoundW3.EagleCnt;
                //newRoundW3.Front = oldRoundW3.Front;
                //newRoundW3.Handicap = oldRoundW3.Handicap;
                //newRoundW3.MatchupPoints = 0;
                //newRoundW3.ParCnt = oldRoundW3.ParCnt;
                //newRoundW3.PlayerRef = oldRoundW3.PlayerRef;
                //newRoundW3.PlayerRefId = oldRoundW3.PlayerRefId;
                //newRoundW3.Result = MatchupResult.Loss;
                //newRoundW3.Scores = oldRoundW3.Scores;
                //newRoundW3.SeasonFirstHalf = oldRoundW3.SeasonFirstHalf;
                //newRoundW3.TotalPoints = 5;
                //newRoundW3.TotalScore = oldRoundW3.TotalScore;
                //newRoundW3.WeekId = oldRoundW3.WeekId;
                //newRoundW3.RoundId = oldRoundW3.RoundId;

                //repoProvider.RoundRepo.Update(oldRoundW3, newRoundW3);


                //var tplayer = await repoProvider.PlayerRepo.Get("Tom S");
                //var tround = tplayer.Rounds.First(r => r.TotalScore == 46);

                //var newTRound = new RoundModel();

                //var oldTRound = repoProvider.RoundRepo.GetWeeklyRound(tplayer.PlayerId, tround.WeekId);
                //newTRound.AttendancePoints = oldTRound.AttendancePoints;
                //newTRound.BirdieCnt = oldTRound.BirdieCnt;
                //newTRound.BogeyCnt = oldTRound.BogeyCnt;
                //newTRound.EagleCnt = oldTRound.EagleCnt;
                //newTRound.Front = oldTRound.Front;
                //newTRound.Handicap = oldTRound.Handicap;
                //newTRound.MatchupPoints = 6;
                //newTRound.ParCnt = oldTRound.ParCnt;
                //newTRound.PlayerRef = oldTRound.PlayerRef;
                //newTRound.PlayerRefId = oldTRound.PlayerRefId;
                //newTRound.Result = MatchupResult.Win;
                //newTRound.Scores = oldTRound.Scores;
                //newTRound.SeasonFirstHalf = oldTRound.SeasonFirstHalf;
                //newTRound.TotalPoints = 12.5;
                //newTRound.TotalScore = oldTRound.TotalScore;
                //newTRound.WeekId = oldTRound.WeekId;
                //newTRound.RoundId = oldTRound.RoundId;

                //repoProvider.RoundRepo.Update(oldTRound, newTRound);



                await repoProvider.SaveAllRepoChangesAsync();
            }
            if(HttpRuntime.Cache["RoundResults"] != null)  HttpRuntime.Cache.Remove("RoundResults");
            if (HttpRuntime.Cache["Leaderboard"] != null) HttpRuntime.Cache.Remove("Leaderboard");
            return Ok();
        }

        private async Task<PlayercardViewModel> getModelData(string id)
        {
            PlayercardViewModel vm = new PlayercardViewModel();
            using (var repoProvider = new RepoProvider())
            {
                if (!string.IsNullOrEmpty(id))
                {
                    Guid pGuid = new Guid(id);
                    var player = await repoProvider.PlayerRepo.Get(pGuid);
                    vm.Name = player.Name;
                    vm.Handicap = await ServiceProvider.HandicapInstance.CalculateHandicap(player.PlayerId);
                    vm.AvgScore = repoProvider.RoundRepo.GetPlayerScoreAverage(player.PlayerId);
                    vm.SeasonLow = repoProvider.RoundRepo.GetPlayerLowRound(player.PlayerId);
                    vm.SeasonHigh = repoProvider.RoundRepo.GetPlayerHighRound(player.PlayerId);
                    vm.WeeklyRounds = new List<WeeklyRoundViewModel>();

                    var pRound = await repoProvider.RoundRepo.GetPlayerRounds(pGuid);

                    foreach (var round in pRound)
                    {
                        var weekModel = await repoProvider.WeekRepo.Get(round.WeekId);

                        vm.WeeklyRounds.Add(new WeeklyRoundViewModel()
                        {
                            Birdies = round.BirdieCnt,
                            Pars = round.ParCnt,
                            Bogeys = round.BogeyCnt,
                            Points = round.TotalPoints,
                            Score = round.TotalScore,
                            WeekNbr = weekModel.WeekNbr,
                            MatchResult = round.Result.ToString()
                        });
                    }
                    vm.WeeklyRounds = vm.WeeklyRounds.OrderBy(r => r.WeekNbr).ToList();
                }
            }
            return vm;
        }
    }
}
