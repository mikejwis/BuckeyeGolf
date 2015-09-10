using BuckeyeGolf.Models;
using BuckeyeGolf.Repos;
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

			using(var repoProvider = new RepoProvider())
			{

				foreach(var week in repoProvider.WeekRepo.GetPlayedWeeks())
				{
					var weekResultsVM = new WeekResultsViewModel() { 
						WeekNbr = week.WeekNbr,
						ScoreCreateDate = week.ScoreCreateDate, 
						PlayerRounds = new List<PlayerRoundViewModel>() };

					foreach (var round in repoProvider.RoundRepo.GetWeeklyRounds(week.WeekId))
					{
						var player = repoProvider.PlayerRepo.Get(round.PlayerRefId);
						var playerRoundVM = new PlayerRoundViewModel() {
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
            ViewBag.WeeklyResults = weekColl.OrderByDescending(w => w.ScoreCreateDate);
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            AddRoundWeekViewModel vm = new AddRoundWeekViewModel() { PlayerRounds = new List<AddRoundViewModel>() };
            ViewBag.Empty = true;

            using(var repoProvider = new RepoProvider())
            {
                var week = repoProvider.WeekRepo.GetFirstUnplayedWeek();
                if(week != null)
                {
                    ViewBag.Empty = false;
                    vm.WeekNbr = week.WeekNbr;
                    vm.WeekId = week.WeekId;
                    ViewBag.WeekNbr = week.WeekNbr;

                    foreach (var player in repoProvider.PlayerRepo.GetAll())
                    {
                        vm.PlayerRounds.Add(new AddRoundViewModel() { PlayerId = player.PlayerId, PlayerName = player.Name });
                    }
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
                using(var repoProvider = new RepoProvider())
                {
                    var week = repoProvider.WeekRepo.Get(vm.WeekId);
                    week.BeenPlayed = true;
                    week.ScoreCreateDate = DateTime.Now;
                    foreach (var roundItem in vm.PlayerRounds)
                    {
                        var newRound = new RoundModel() {
                            PlayerRefId = roundItem.PlayerId,
                            RoundId = Guid.NewGuid(),
                            WeekId = vm.WeekId,
                            TotalPoints = roundItem.Points,
                            TotalScore = roundItem.Score,
                        };
                        repoProvider.RoundRepo.Add(newRound);
                    }
                    repoProvider.SaveAllRepoChanges();
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Add");
        }
    }
}