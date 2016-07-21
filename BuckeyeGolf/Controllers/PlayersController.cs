using BuckeyeGolf.Models;
using BuckeyeGolf.Repos;
using BuckeyeGolf.Services;
using BuckeyeGolf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BuckeyeGolf.Controllers
{
    public class PlayersController : Controller
    {
        [HttpGet]
        public ActionResult Index(string id)
        {
            PlayercardViewModel vm = new PlayercardViewModel();
            using (var repoProvider = new RepoProvider())
            {
                //vm.Players = repoProvider.PlayerRepo.GetAll().Select(p => p.Name);
                //if(!string.IsNullOrEmpty(id))
                //{
                //    var player = repoProvider.PlayerRepo.Get(id);
                //    vm.Name = player.Name;
                //    vm.Handicap = ServiceProvider.HandicapInstance.CalculateHandicap(player.PlayerId);
                //    vm.AvgScore = repoProvider.RoundRepo.GetPlayerScoreAverage(player.PlayerId);
                //    vm.SeasonLow = repoProvider.RoundRepo.GetPlayerLowRound(player.PlayerId);
                //    vm.SeasonHigh = repoProvider.RoundRepo.GetPlayerHighRound(player.PlayerId);
                //}
            }

            return View(vm);
        }

        [HttpGet]
        public ActionResult Add()
        {
            AddPlayersViewModel vm = new AddPlayersViewModel();
            using (var repoProvider = new RepoProvider())
            {
                //vm.Players = repoProvider.PlayerRepo.GetAll().Select(p=>p.Name);
            }
            return View(vm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Add(AddPlayersViewModel vm)
        {
            if(ModelState.IsValid)
            {
                using (var repoProvider = new RepoProvider())
                {
                    var newPlayer = new PlayerModel() { Name = vm.Name, PlayerId = Guid.NewGuid(), Rounds = new List<RoundModel>(), HandicapRound1 = vm.HandicapR1Score, HandicapRound2 = vm.HandicapR2Score };
                    repoProvider.PlayerRepo.Add(newPlayer);
                    await repoProvider.SaveAllRepoChangesAsync();
                }
                return RedirectToAction("Add");
            }
            return View(vm);
        }
    }
}