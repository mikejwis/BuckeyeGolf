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
                    HttpRuntime.Cache.Insert(id, vm, null, DateTime.Now.AddMinutes(60), Cache.NoSlidingExpiration);
                }
            }
            return vm;
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

                    var pRound = repoProvider.RoundRepo.GetPlayerRounds(pGuid);

                    foreach (var round in pRound)
                    {
                        var weekNumber = repoProvider.WeekRepo.Get(round.WeekId).WeekNbr;

                        vm.WeeklyRounds.Add(new WeeklyRoundViewModel()
                        {
                            Birdies = round.BirdieCnt,
                            Pars = round.ParCnt,
                            Bogeys = round.BogeyCnt,
                            Points = round.TotalPoints,
                            Score = round.TotalScore,
                            WeekNbr = weekNumber
                        });
                    }
                    vm.WeeklyRounds = vm.WeeklyRounds.OrderBy(r => r.WeekNbr).ToList();
                }
            }
            return vm;
        }
    }
}