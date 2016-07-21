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
            //return getSeedData();
        }

        private IEnumerable<WeekResultsViewModel> getSeedData()
        {
            var weekColl = new List<WeekResultsViewModel>();

            var w3Rounds = new List<PlayerRoundViewModel>();
            w3Rounds.Add(new PlayerRoundViewModel() { Name = "Mike", TotalScore = 60, TotalPoints = 4, Birdies = 0, Pars = 1, Bogeys = 0 });
            w3Rounds.Add(new PlayerRoundViewModel() { Name = "Keith", TotalScore = 45, TotalPoints = 10, Birdies = 0, Pars = 2, Bogeys = 4 });
            w3Rounds.Add(new PlayerRoundViewModel() { Name = "Kevin", TotalScore = 49, TotalPoints = 9, Birdies = 0, Pars = 2, Bogeys = 2 });
            w3Rounds.Add(new PlayerRoundViewModel() { Name = "Bill", TotalScore = 53, TotalPoints = 7.5, Birdies = 0, Pars = 1, Bogeys = 1 });
            w3Rounds.Add(new PlayerRoundViewModel() { Name = "Tom S", TotalScore = 54, TotalPoints = 4, Birdies = 0, Pars = 1, Bogeys = 0 });
            w3Rounds.Add(new PlayerRoundViewModel() { Name = "Emil", TotalScore = 70, TotalPoints = 3.5, Birdies = 0, Pars = 0, Bogeys = 1 });
            w3Rounds.Add(new PlayerRoundViewModel() { Name = "Mark", TotalScore = 49, TotalPoints = 9, Birdies = 0, Pars = 1, Bogeys = 4 });
            w3Rounds.Add(new PlayerRoundViewModel() { Name = "Jack", TotalScore = 58, TotalPoints = 4, Birdies = 0, Pars = 1, Bogeys = 0 });
            w3Rounds.Add(new PlayerRoundViewModel() { Name = "Todd", TotalScore = 56, TotalPoints = 4, Birdies = 0, Pars = 0, Bogeys = 2 });
            w3Rounds.Add(new PlayerRoundViewModel() { Name = "Len", TotalScore = 44, TotalPoints = 8, Birdies = 0, Pars = 3, Bogeys = 4 });
            w3Rounds.Add(new PlayerRoundViewModel() { Name = "David", TotalScore = 49, TotalPoints = 8.5, Birdies = 0, Pars = 0, Bogeys = 5 });
            w3Rounds.Add(new PlayerRoundViewModel() { Name = "Brandon", TotalScore = 55, TotalPoints = 6, Birdies = 0, Pars = 0, Bogeys = 0 });
            weekColl.Add(new WeekResultsViewModel() { WeekNbr = 3, ScoreCreateDate = new DateTime(2016, 5, 23), PlayerRounds = w3Rounds });

            var w2Rounds = new List<PlayerRoundViewModel>();
            w2Rounds.Add(new PlayerRoundViewModel() { Name = "Mike", TotalScore = 55, TotalPoints = 9.5, Birdies = 1, Pars = 0, Bogeys = 1 });
            w2Rounds.Add(new PlayerRoundViewModel() { Name = "Keith", TotalScore = 53, TotalPoints = 6, Birdies = 0, Pars = 2, Bogeys = 2 });
            w2Rounds.Add(new PlayerRoundViewModel() { Name = "Kevin", TotalScore = 51, TotalPoints = 8, Birdies = 0, Pars = 1, Bogeys = 2 });
            w2Rounds.Add(new PlayerRoundViewModel() { Name = "Bill", TotalScore = 61, TotalPoints = 3.5, Birdies = 0, Pars = 0, Bogeys = 1 });
            w2Rounds.Add(new PlayerRoundViewModel() { Name = "Tom S", TotalScore = 53, TotalPoints = 6.5, Birdies = 0, Pars = 0, Bogeys = 1 });
            w2Rounds.Add(new PlayerRoundViewModel() { Name = "Emil", TotalScore = 66, TotalPoints = 7, Birdies = 0, Pars = 0, Bogeys = 2 });
            w2Rounds.Add(new PlayerRoundViewModel() { Name = "Mark", TotalScore = 48, TotalPoints = 9, Birdies = 0, Pars = 1, Bogeys = 4 });
            w2Rounds.Add(new PlayerRoundViewModel() { Name = "Jack", TotalScore = 59, TotalPoints = 4, Birdies = 0, Pars = 0, Bogeys = 2 });
            w2Rounds.Add(new PlayerRoundViewModel() { Name = "Todd", TotalScore = 57, TotalPoints = 4.5, Birdies = 0, Pars = 1, Bogeys = 1 });
            w2Rounds.Add(new PlayerRoundViewModel() { Name = "Len", TotalScore = 47, TotalPoints = 9.5, Birdies = 0, Pars = 2, Bogeys = 3 });
            w2Rounds.Add(new PlayerRoundViewModel() { Name = "David", TotalScore = 51, TotalPoints = 5, Birdies = 0, Pars = 1, Bogeys = 2 });
            w2Rounds.Add(new PlayerRoundViewModel() { Name = "Brandon", TotalScore = 57, TotalPoints = 3.5, Birdies = 0, Pars = 0, Bogeys = 1 });
            weekColl.Add(new WeekResultsViewModel() { WeekNbr = 2, ScoreCreateDate = new DateTime(2016, 5, 16), PlayerRounds = w2Rounds });

            var w1Rounds = new List<PlayerRoundViewModel>();
            w1Rounds.Add(new PlayerRoundViewModel() { Name = "Keith", TotalScore = 43, TotalPoints = 12.5, Birdies = 1, Pars = 1, Bogeys = 5 });
            w1Rounds.Add(new PlayerRoundViewModel() { Name = "Mark", TotalScore = 50, TotalPoints = 9.5, Birdies = 0, Pars = 2, Bogeys = 3 });
            w1Rounds.Add(new PlayerRoundViewModel() { Name = "Len", TotalScore = 43, TotalPoints = 11, Birdies = 0, Pars = 3, Bogeys = 4 });
            w1Rounds.Add(new PlayerRoundViewModel() { Name = "Mike", TotalScore = 61, TotalPoints = 3, Birdies = 0, Pars = 0, Bogeys = 0 });
            w1Rounds.Add(new PlayerRoundViewModel() { Name = "Kevin", TotalScore = 49, TotalPoints = 8.5, Birdies = 0, Pars = 1, Bogeys = 3 });
            w1Rounds.Add(new PlayerRoundViewModel() { Name = "Brandon", TotalScore = 54, TotalPoints = 6.5, Birdies = 0, Pars = 1, Bogeys = 3 });
            w1Rounds.Add(new PlayerRoundViewModel() { Name = "Tom S", TotalScore = 47, TotalPoints = 6, Birdies = 0, Pars = 1, Bogeys = 4 });
            w1Rounds.Add(new PlayerRoundViewModel() { Name = "Todd", TotalScore = 46, TotalPoints = 9.5, Birdies = 0, Pars = 1, Bogeys = 5 });
            w1Rounds.Add(new PlayerRoundViewModel() { Name = "David", TotalScore = 0, TotalPoints = 1, Birdies = 0, Pars = 0, Bogeys = 0 });
            w1Rounds.Add(new PlayerRoundViewModel() { Name = "Bill", TotalScore = 56, TotalPoints = 6, Birdies = 0, Pars = 1, Bogeys = 2 });
            w1Rounds.Add(new PlayerRoundViewModel() { Name = "Emil", TotalScore = 71, TotalPoints = 3.5, Birdies = 0, Pars = 1, Bogeys = 1 });
            w1Rounds.Add(new PlayerRoundViewModel() { Name = "Jack", TotalScore = 53, TotalPoints = 5, Birdies = 0, Pars = 1, Bogeys = 2 });
            weekColl.Add(new WeekResultsViewModel() { WeekNbr = 1, ScoreCreateDate = new DateTime(2016, 5, 9), PlayerRounds = w1Rounds });
            return weekColl.OrderByDescending(w => w.ScoreCreateDate);
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
                            Bogeys = round.BogeyCnt
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