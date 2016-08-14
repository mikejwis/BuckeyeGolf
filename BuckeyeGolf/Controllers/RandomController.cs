using BuckeyeGolf.Models;
using BuckeyeGolf.Repos;
using BuckeyeGolf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BuckeyeGolf.Controllers
{
    [System.Web.Http.Route("api/Matchups/Random")]
    public class RandomController : ApiController
    {
        public async Task<MatchupWeekViewModel> Get(int weekNbr = 0)
        {
            var globalExistingMatchups = new List<MatchupModel>();
            var vm = new MatchupWeekViewModel();
            vm.WeekNbr = weekNbr;
            using (var repoProvider = new RepoProvider())
            {
                var players = await repoProvider.PlayerRepo.GetAll();
                var weeksUnordered = await repoProvider.WeekRepo.GetAll();
                var weeks = weeksUnordered.OrderBy(w => w.WeekNbr);
                foreach (var week in weeks.Where(w => w.WeekNbr > weekNbr))
                {
                    var matchups = await repoProvider.MatchupRepo.GetAllWeeklyMatchups(week.WeekId);
                    globalExistingMatchups.AddRange(matchups);

                }


                List<MatchupModel> newMatchups = new List<MatchupModel>();
                var nextPlayer = getNextPlayerDoesNotHaveMatchup(players, newMatchups);
                while (nextPlayer != null)
                {
                    addNewRandomMatchupForPlayer(nextPlayer, players, newMatchups, globalExistingMatchups);
                    nextPlayer = getNextPlayerDoesNotHaveMatchup(players, newMatchups);
                }

                vm.Matchups = new List<MatchupViewModel>();
                foreach (var m in newMatchups)
                {
                    var p1 = await repoProvider.PlayerRepo.Get(m.Player1);
                    var p2 = await repoProvider.PlayerRepo.Get(m.Player2);
                    vm.Matchups.Add(new MatchupViewModel() { Player1Name = p1.Name, Player2Name = p2.Name });
                }
                //hydrate names into a viewmodel
            }

            return vm;

        }

        private void addNewRandomMatchupForPlayer(PlayerModel nextPlayer, List<PlayerModel> players, List<MatchupModel> newMatchups, List<MatchupModel> globalExistingMatchups)
        {
            var playersToAttempt = new List<Guid>();
            foreach (var p in players) { playersToAttempt.Add(p.PlayerId); }
            Random rand = new Random();
            while (playersToAttempt.Count > 0)
            {
                int index = rand.Next(playersToAttempt.Count);
                var testPlayer = playersToAttempt[index];
                playersToAttempt.Remove(testPlayer);
                var mm1 = globalExistingMatchups.FirstOrDefault(m => m.Player1.CompareTo(testPlayer) == 0 && m.Player2.CompareTo(nextPlayer.PlayerId) == 0);
                var mm2 = globalExistingMatchups.FirstOrDefault(m => m.Player1.CompareTo(nextPlayer.PlayerId) == 0 && m.Player2.CompareTo(testPlayer) == 0);
                if (mm1 == null && mm2 == null)
                {
                    newMatchups.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), Player1 = testPlayer, Player2 = nextPlayer.PlayerId });
                    players.Remove(players.Find(p => p.PlayerId.CompareTo(testPlayer) == 0));
                    return;
                }
            }

            throw new Exception("found no players to match up with");
        }

        private PlayerModel getNextPlayerDoesNotHaveMatchup(List<PlayerModel> players, List<MatchupModel> newMatchups)
        {
            PlayerModel foundPlayer = null;
            foreach (var p in players)
            {
                var mm = newMatchups.FirstOrDefault(m => m.Player1.CompareTo(p.PlayerId) == 0 || m.Player2.CompareTo(p.PlayerId) == 0);
                if (mm == null)
                {
                    foundPlayer = p;
                    players.Remove(p);
                    break;
                }
            }
            return foundPlayer;
        }
    }
}
