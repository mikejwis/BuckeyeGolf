using BuckeyeGolf.Models;
using BuckeyeGolf.ViewModels;
using BuckeyeGolf.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using BuckeyeGolf.Repos;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using System.Web.Mvc;

namespace BuckeyeGolf.Controllers
{
    public class MatchupsController : ApiController
    {
        //GET api/Matchups
        public MatchupSummaryViewModel Get()
        {
            MatchupSummaryViewModel vm = new MatchupSummaryViewModel();
            List<MatchupWeekViewModel> weekColl = new List<MatchupWeekViewModel>();

            var w2Matchups = new List<MatchupViewModel>();
            var w2 = new MatchupWeekViewModel() { WeekNbr = 2, Matchups = w2Matchups };
            w2Matchups.Add(new MatchupViewModel() { Player1Name = "Mike", Player1Handicap = 18, Player2Name = "David", Player2Handicap = 9 });
            w2Matchups.Add(new MatchupViewModel() { Player1Name = "Bill", Player1Handicap = 20, Player2Name = "Len", Player2Handicap = 9 });
            w2Matchups.Add(new MatchupViewModel() { Player1Name = "Brandon", Player1Handicap = 19, Player2Name = "Emil", Player2Handicap = 31 });
            w2Matchups.Add(new MatchupViewModel() { Player1Name = "Keith", Player1Handicap = 10, Player2Name = "Mark", Player2Handicap = 14 });
            w2Matchups.Add(new MatchupViewModel() { Player1Name = "Kevin", Player1Handicap = 16, Player2Name = "Jack", Player2Handicap = 16 });
            w2Matchups.Add(new MatchupViewModel() { Player1Name = "Tom S", Player1Handicap = 11, Player2Name = "Todd", Player2Handicap = 13 });
            weekColl.Add(w2);

            var w1Matchups = new List<MatchupViewModel>();
            var w1 = new MatchupWeekViewModel() { WeekNbr = 1, Matchups = w1Matchups };
            w1Matchups.Add(new MatchupViewModel() { Player1Name = "Jack", Player1Handicap = 15, Player2Name = "Mark", Player2Handicap = 14 });
            w1Matchups.Add(new MatchupViewModel() { Player1Name = "Len", Player1Handicap = 10, Player2Name = "David", Player2Handicap = 9 });
            w1Matchups.Add(new MatchupViewModel() { Player1Name = "Tom S", Player1Handicap = 11, Player2Name = "Keith", Player2Handicap = 11 });
            w1Matchups.Add(new MatchupViewModel() { Player1Name = "Todd", Player1Handicap = 14, Player2Name = "Emil", Player2Handicap = 31 });
            w1Matchups.Add(new MatchupViewModel() { Player1Name = "Mike", Player1Handicap = 15, Player2Name = "Kevin", Player2Handicap = 17 });
            w1Matchups.Add(new MatchupViewModel() { Player1Name = "Brandon", Player1Handicap = 20, Player2Name = "Bill", Player2Handicap = 22 });
            weekColl.Add(w1);

            vm.NextWeek = 3;
            vm.Players = new List<BasicPlayerViewModel>();
            vm.Players.Add(new BasicPlayerViewModel() { Name = "Mike", Id = Guid.NewGuid() });
            vm.Players.Add(new BasicPlayerViewModel() { Name = "David", Id = Guid.NewGuid() });
            vm.Players.Add(new BasicPlayerViewModel() { Name = "Bill", Id = Guid.NewGuid() });
            vm.Players.Add(new BasicPlayerViewModel() { Name = "Len", Id = Guid.NewGuid() });
            vm.Players.Add(new BasicPlayerViewModel() { Name = "Brandon", Id = Guid.NewGuid() });
            vm.Players.Add(new BasicPlayerViewModel() { Name = "Emil", Id = Guid.NewGuid() });
            vm.Players.Add(new BasicPlayerViewModel() { Name = "Keith", Id = Guid.NewGuid() });
            vm.Players.Add(new BasicPlayerViewModel() { Name = "Mark", Id = Guid.NewGuid() });
            vm.Players.Add(new BasicPlayerViewModel() { Name = "Kevin", Id = Guid.NewGuid() });
            vm.Players.Add(new BasicPlayerViewModel() { Name = "Jack", Id = Guid.NewGuid() });
            vm.Players.Add(new BasicPlayerViewModel() { Name = "Tom S", Id = Guid.NewGuid() });
            vm.Players.Add(new BasicPlayerViewModel() { Name = "Todd", Id = Guid.NewGuid() });
            vm.Weeks = weekColl;
            return vm;
        }

        //POST api/Matchups
        public void Post()
        {

        }

        // GET: Matchups
        /*        public ActionResult Index()
                {
                    var weekColl = new List<MatchupWeekViewModel>();

                    using (var repoProvider = new RepoProvider())
                    {
                        foreach (var week in repoProvider.WeekRepo.GetAll())
                        {
                            var matchupWeekVM = new MatchupWeekViewModel() { WeekNbr = week.WeekNbr, Matchups = new List<MatchupViewModel>() };
                            foreach (var matchup in repoProvider.MatchupRepo.GetAllWeeklyMatchups(week.WeekId))
                            {
                                var p1 = repoProvider.PlayerRepo.Get(matchup.Player1);
                                var p2 = repoProvider.PlayerRepo.Get(matchup.Player2);

                                var matchupVM = new MatchupViewModel() { Player1Name = p1.Name, Player2Name = p2.Name };
                                matchupVM.Player1Handicap = getHandicap(repoProvider, week, matchup.Player1);
                                matchupVM.Player2Handicap = getHandicap(repoProvider, week, matchup.Player2);
                                matchupWeekVM.Matchups.Add(matchupVM);
                            }
                            weekColl.Add(matchupWeekVM);
                        }
                    }

                    ViewBag.WeeklyMatchups = weekColl.OrderByDescending(w => w.WeekNbr);
                    return View();
                }
        */
        private int getHandicap(RepoProvider repoProvider, WeekModel week, Guid playerId)
        {
            var result = 0;
            if (week.BeenPlayed)
            {
                result = repoProvider.RoundRepo.GetWeeklyRound(playerId, week.WeekId).Handicap;
            }
            else
            {
                result = ServiceProvider.HandicapInstance.CalculateHandicap(playerId);
            }
            return result;
        }
        /*
                public ActionResult Edit()
                {
                    return View();
                }

                [System.Web.Mvc.HttpGet]
                public ActionResult Add()
                {
                    using (var repoProvider = new RepoProvider())
                    {
                        var players = repoProvider.PlayerRepo.GetAll();
                        var playerCnt = players.Count();
                        ViewBag.NbrOfMatchups = Math.Round(playerCnt / 2.0, 0, MidpointRounding.AwayFromZero);
                        var highestWeekNbr = repoProvider.WeekRepo.GetHighestWeekNumber();
                        ViewBag.NewWeekNbr = ++highestWeekNbr;

                        var playerList = new List<SelectListItem>();
                        playerList.Add(new SelectListItem() { Text = "", Value = "" });

                        foreach (var player in players)
                        {
                            playerList.Add(new SelectListItem() { Text = player.Name, Value = player.PlayerId.ToString() });
                        }
                        ViewBag.PlayerSelectList = playerList;


                    }
                    AddPlayerMatchupViewModel vm = new AddPlayerMatchupViewModel() { WeekNbr = ViewBag.NewWeekNbr, Player1Id = new List<Guid>(), Player2Id = new List<Guid>() };
                    return View(vm);
                }

                [ValidateAntiForgeryToken]
                [System.Web.Mvc.HttpPost]
                public ActionResult Add(AddPlayerMatchupViewModel vm)
                {
                    if (ModelState.IsValid && vm.Player1Id.Count() > 0 && vm.Player2Id.Count() > 0)
                    {
                        //Todo:Validate that each player is selected only once.
                        using (var repoProvider = new RepoProvider())
                        {
                            WeekModel weekObj = new WeekModel() { WeekId = Guid.NewGuid(), BeenPlayed = false, WeekNbr = vm.WeekNbr, ScoreCreateDate = DateTime.Now };
                            repoProvider.WeekRepo.Add(weekObj);
                            for (int i = 0; i < vm.Player1Id.Count; i++)
                            {
                                MatchupModel matchupObj = new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = weekObj.WeekId, Player1 = vm.Player1Id[i], Player2 = vm.Player2Id[i] };
                                repoProvider.MatchupRepo.Add(matchupObj);
                            }
                            repoProvider.SaveAllRepoChanges();
                        }
                        return RedirectToAction("Index");
                    }
                    return RedirectToAction("Add");
                }
              */
    }
}