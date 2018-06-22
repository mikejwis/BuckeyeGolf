using BuckeyeGolf.Repos;
using BuckeyeGolf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Data.Entity;

namespace BuckeyeGolf.Controllers
{
    public class PlayersController : ApiController
    {
        [Route("api/Players")]
        [HttpGet]
        public async Task<IHttpActionResult> GetAllPlayers()
        {
            //Task<IHttpActionResult>
            List<PlayerViewModel> players = new List<PlayerViewModel>();
            using (var repoProvider = new RepoProvider())
            {
                var modelPlayers = await repoProvider.PlayerRepo.GetAll();
                modelPlayers.ForEach(m => players.Add(new PlayerViewModel() {
                    PlayerId = m.PlayerId,
                    Name = m.Name,
                    Rounds = m.Rounds.ToArray(),
                    HandicapRound1 = m.HandicapRound1,
                    HandicapRound2 = m.HandicapRound2
                }));
            }
            
            return Ok(players);
        }
    }
}
