using BuckeyeGolf.Models;
using BuckeyeGolf.Repos;
using BuckeyeGolf.Services;
using BuckeyeGolf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace BuckeyeGolf.Controllers
{
    [System.Web.Http.Route("api/Matchups/Add")]
    public class AddMatchupController : ApiController
    {
        public AddPlayerMatchupViewModel Get()
        {
            AddPlayerMatchupViewModel vm = new AddPlayerMatchupViewModel();
            //var weekColl = new List<MatchupWeekViewModel>();

            using (var repoProvider = new RepoProvider())
            {
                //foreach (var week in repoProvider.WeekRepo.GetAll())
                //{
                //    var matchupWeekVM = new MatchupWeekViewModel() { WeekNbr = week.WeekNbr, Matchups = new List<MatchupViewModel>() };
                //    foreach (var matchup in repoProvider.MatchupRepo.GetAllWeeklyMatchups(week.WeekId))
                //    {
                //        //var p1 = repoProvider.PlayerRepo.Get(matchup.Player1);
                //        //var p2 = repoProvider.PlayerRepo.Get(matchup.Player2);

                //        //var matchupVM = new MatchupViewModel() { Player1Name = p1.Name, Player2Name = p2.Name };
                //        //matchupVM.Player1Handicap = ServiceProvider.HandicapInstance.GetHandicap(repoProvider, week, matchup.Player1);
                //        //matchupVM.Player2Handicap = ServiceProvider.HandicapInstance.GetHandicap(repoProvider, week, matchup.Player2);
                //        //matchupWeekVM.Matchups.Add(matchupVM);
                //    }
                //    weekColl.Add(matchupWeekVM);
                //}

                var highestWeekNbr = repoProvider.WeekRepo.GetHighestWeekNumber();
                vm.NextWeek = ++highestWeekNbr;
                vm.Players = new List<BasicPlayerViewModel>();
                foreach (var player in repoProvider.PlayerRepo.GetAll())
                {
                    vm.Players.Add(new BasicPlayerViewModel() { Name = player.Name, Id = player.PlayerId });
                }
            }
            return vm;
        }


        //[System.Web.Mvc.HttpGet]
        //public ActionResult Index()
        //{
        //    using (var repoProvider = new RepoProvider())
        //    {
        //        var players = repoProvider.PlayerRepo.GetAll();
        //        var playerCnt = players.Count();
        //        ViewBag.NbrOfMatchups = Math.Round(playerCnt / 2.0, 0, MidpointRounding.AwayFromZero);
        //        var highestWeekNbr = repoProvider.WeekRepo.GetHighestWeekNumber();
        //        ViewBag.NewWeekNbr = ++highestWeekNbr;

        //        var playerList = new List<SelectListItem>();
        //        playerList.Add(new SelectListItem() { Text = "", Value = "" });

        //        foreach (var player in players)
        //        {
        //            playerList.Add(new SelectListItem() { Text = player.Name, Value = player.PlayerId.ToString() });
        //        }
        //        ViewBag.PlayerSelectList = playerList;


        //    }
        //    AddPlayerMatchupViewModel vm = new AddPlayerMatchupViewModel() { WeekNbr = ViewBag.NewWeekNbr, Player1Id = new List<Guid>(), Player2Id = new List<Guid>() };
        //    return View(vm);
        //}

        //[ValidateAntiForgeryToken]
        //[System.Web.Mvc.HttpPost]
        //public ActionResult Index(AddPlayerMatchupViewModel vm)
        //{
        //    if (ModelState.IsValid && vm.Player1Id.Count() > 0 && vm.Player2Id.Count() > 0)
        //    {
        //        //Todo:Validate that each player is selected only once.
        //        using (var repoProvider = new RepoProvider())
        //        {
        //            WeekModel weekObj = new WeekModel() { WeekId = Guid.NewGuid(), BeenPlayed = false, WeekNbr = vm.WeekNbr, ScoreCreateDate = DateTime.Now };
        //            repoProvider.WeekRepo.Add(weekObj);
        //            for (int i = 0; i < vm.Player1Id.Count; i++)
        //            {
        //                MatchupModel matchupObj = new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = weekObj.WeekId, Player1 = vm.Player1Id[i], Player2 = vm.Player2Id[i] };
        //                repoProvider.MatchupRepo.Add(matchupObj);
        //            }
        //            repoProvider.SaveAllRepoChanges();
        //        }
        //        return RedirectToAction("View");
        //    }
        //    return RedirectToAction("Index");
        //}
        public async Task<IHttpActionResult> Post(AddNewPlayerMatchupViewModel vm)
        {
            if (ModelState.IsValid && vm.NewPlayerMatchups.Count > 0)
            {
                //Todo:Validate that each player is selected only once.
                using (var repoProvider = new RepoProvider())
                {
                    WeekModel weekObj = new WeekModel() { WeekId = Guid.NewGuid(), BeenPlayed = false, WeekNbr = vm.WeekNbr, ScoreCreateDate = DateTime.Now };
                    repoProvider.WeekRepo.Add(weekObj);
                    for (int i = 0; i < vm.NewPlayerMatchups.Count; i++)
                    {
                        MatchupModel matchupObj = new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = weekObj.WeekId, Player1 = vm.NewPlayerMatchups[i].Player1Id, Player2 = vm.NewPlayerMatchups[i].Player2Id };
                        repoProvider.MatchupRepo.Add(matchupObj);
                    }
                    await repoProvider.SaveAllRepoChangesAsync();
                }
                return Ok();
            }
            return BadRequest();
        }
    }
}