using BuckeyeGolf.Models;
using BuckeyeGolf.Repos;
using BuckeyeGolf.Services;
using BuckeyeGolf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Net;
using System.Web.Caching;
using System.Threading.Tasks;

namespace BuckeyeGolf.Controllers
{
    public class ResultsController : ApiController
    {
        //GET api/Results
        public async Task<IEnumerable<WeekResultsViewModel>> Get()
        {
            IEnumerable<WeekResultsViewModel> resultsVM = HttpRuntime.Cache["RoundResults"] as IEnumerable<WeekResultsViewModel>;
            if (resultsVM == null)
            {
                resultsVM = await getModelData();
                HttpRuntime.Cache.Insert("RoundResults", resultsVM, null, DateTime.Now.AddMinutes(60), Cache.NoSlidingExpiration);
            }
            return resultsVM;
        }

        private async Task<IEnumerable<WeekResultsViewModel>> getModelData()
        {
            var weekColl = new List<WeekResultsViewModel>();

            using (var repoProvider = new RepoProvider())
            {

                foreach (var week in repoProvider.WeekRepo.GetPlayedWeeks())
                {
                    var weekResultsVM = new WeekResultsViewModel()
                    {
                        WeekNbr = week.WeekNbr,
                        ScoreCreateDate = week.ScoreCreateDate,
                        PlayerRounds = new List<PlayerRoundViewModel>()
                    };

                    foreach (var round in repoProvider.RoundRepo.GetWeeklyRounds(week.WeekId))
                    {
                        var player = await repoProvider.PlayerRepo.Get(round.PlayerRefId);
                        var playerRoundVM = new PlayerRoundViewModel()
                        {
                            TotalPoints = round.TotalPoints,
                            TotalScore = round.TotalScore,
                            Name = player.Name,
                            Birdies = round.BirdieCnt,
                            Pars = round.ParCnt,
                            Bogeys = round.BogeyCnt,
                            PlayerId = round.PlayerRefId.ToString()
                        };

                        weekResultsVM.PlayerRounds.Add(playerRoundVM);
                    }
                    weekColl.Add(weekResultsVM);
                }
            }
            return weekColl.OrderByDescending(w => w.ScoreCreateDate);
        }
    }
}