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

namespace BuckeyeGolf.Controllers
{
    public class MatchupsController : ApiController
    {
        //GET api/Matchups
        public MatchupSummaryViewModel Get()
        {
            //return getModelData();
            return getSeedData();
        }

        private MatchupSummaryViewModel getSeedData()
        {
            MatchupSummaryViewModel vm = new MatchupSummaryViewModel();
            List<MatchupWeekViewModel> weekColl = new List<MatchupWeekViewModel>();

            var w4Matchups = new List<MatchupViewModel>();
            var w4 = new MatchupWeekViewModel() { WeekNbr = 4, Matchups = w4Matchups };
            w4Matchups.Add(new MatchupViewModel() { Player1Name = "Len", Player1Handicap = 9, Player2Name = "Mark", Player2Handicap = 13 });
            w4Matchups.Add(new MatchupViewModel() { Player1Name = "Bill", Player1Handicap = 20, Player2Name = "Keith", Player2Handicap = 11 });
            w4Matchups.Add(new MatchupViewModel() { Player1Name = "Tom S", Player1Handicap = 13, Player2Name = "Mike", Player2Handicap = 19 });
            w4Matchups.Add(new MatchupViewModel() { Player1Name = "Brandon", Player1Handicap = 19, Player2Name = "Kevin", Player2Handicap = 15 });
            w4Matchups.Add(new MatchupViewModel() { Player1Name = "Todd", Player1Handicap = 15, Player2Name = "David", Player2Handicap = 12 });
            w4Matchups.Add(new MatchupViewModel() { Player1Name = "Jack", Player1Handicap = 18, Player2Name = "Emil", Player2Handicap = 30 });
            weekColl.Add(w4);

            var w3Matchups = new List<MatchupViewModel>();
            var w3 = new MatchupWeekViewModel() { WeekNbr = 3, Matchups = w3Matchups };
            w3Matchups.Add(new MatchupViewModel() { Player1Name = "Mark", Player1Handicap = 13, Player2Name = "Todd", Player2Handicap = 14 });
            w3Matchups.Add(new MatchupViewModel() { Player1Name = "Len", Player1Handicap = 9, Player2Name = "Kevin", Player2Handicap = 15 });
            w3Matchups.Add(new MatchupViewModel() { Player1Name = "Tom S", Player1Handicap = 12, Player2Name = "Brandon", Player2Handicap = 19 });
            w3Matchups.Add(new MatchupViewModel() { Player1Name = "Keith", Player1Handicap = 11, Player2Name = "Emil", Player2Handicap = 30 });
            w3Matchups.Add(new MatchupViewModel() { Player1Name = "Bill", Player1Handicap = 21, Player2Name = "Mike", Player2Handicap = 18 });
            w3Matchups.Add(new MatchupViewModel() { Player1Name = "Jack", Player1Handicap = 17, Player2Name = "David", Player2Handicap = 11 });
            weekColl.Add(w3);

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

        private MatchupSummaryViewModel getModelData()
        {
            MatchupSummaryViewModel vm = new MatchupSummaryViewModel();
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
                        matchupVM.Player1Handicap = ServiceProvider.HandicapInstance.GetHandicap(repoProvider, week, matchup.Player1);
                        matchupVM.Player2Handicap = ServiceProvider.HandicapInstance.GetHandicap(repoProvider, week, matchup.Player2);
                        matchupWeekVM.Matchups.Add(matchupVM);
                    }
                    weekColl.Add(matchupWeekVM);
                }

                var highestWeekNbr = repoProvider.WeekRepo.GetHighestWeekNumber();
                vm.NextWeek = ++highestWeekNbr;
                vm.Players = new List<BasicPlayerViewModel>();
                foreach (var player in repoProvider.PlayerRepo.GetAll())
                {
                    vm.Players.Add(new BasicPlayerViewModel() { Name = player.Name, Id = player.PlayerId });
                }
            }
            
            vm.Weeks = weekColl.OrderByDescending(w=>w.WeekNbr).ToList();

            return vm;
        }

    }
}