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
    public class PlayersController : Controller
    {
        // GET: Players
        public ActionResult Index(string playerName)
        {
            PlayercardViewModel vm = new PlayercardViewModel();
            using (var repoProvider = new RepoProvider())
            {
                var player = repoProvider.PlayerRepo.Get(playerName);
                vm.Name = player.Name;
            }

            return View(vm);
        }

        [HttpGet]
        public ActionResult Add()
        {
            AddPlayersViewModel vm = new AddPlayersViewModel();
            return View(vm);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Add(AddPlayersViewModel vm)
        {
            if(ModelState.IsValid)
            {
                using (var repoProvider = new RepoProvider())
                {
                    var newPlayer = new PlayerModel() { Name = vm.Name, PlayerId = Guid.NewGuid(), Rounds = new List<RoundModel>(), StartingHandicap = vm.StartingHandicap };
                    repoProvider.PlayerRepo.Add(newPlayer);
                    repoProvider.SaveAllRepoChanges();
                }
                return RedirectToAction("Add");
            }
            return View(vm);
        }
    }
}