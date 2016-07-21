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
        public async Task<AddPlayerMatchupViewModel> Get()
        {
            AddPlayerMatchupViewModel vm = new AddPlayerMatchupViewModel();

            using (var repoProvider = new RepoProvider())
            {
                var highestWeekNbr = repoProvider.WeekRepo.GetHighestWeekNumber();
                vm.NextWeek = ++highestWeekNbr;
                vm.Players = new List<BasicPlayerViewModel>();
                foreach (var player in await repoProvider.PlayerRepo.GetAll())
                {
                    vm.Players.Add(new BasicPlayerViewModel() { Name = player.Name, Id = player.PlayerId });
                }
            }
            return vm;
        }

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