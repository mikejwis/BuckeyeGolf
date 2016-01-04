using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using BuckeyeGolf.ViewModels;

namespace BuckeyeGolf.Controllers
{
    [RoutePrefix("api/rounds")]
    public class RoundsController : ApiController
    {
        [HttpGet]
        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            var vm = seedRoundData();
            return Ok(vm);
        }

        private List<RoundDataViewModel> seedRoundData()
        {
            var roundList = new List<RoundDataViewModel>();
            roundList.Add(new RoundDataViewModel() { points=5, score=45, weekNbr=1});
            roundList.Add(new RoundDataViewModel() { points = 3.5, score = 50, weekNbr = 2 });
            roundList.Add(new RoundDataViewModel() { points = 8, score = 49, weekNbr = 3 });
            roundList.Add(new RoundDataViewModel() { points = 2, score = 51, weekNbr = 4 });
            roundList.Add(new RoundDataViewModel() { points = 4.5, score = 44, weekNbr = 5 });
            return roundList;
        }
    }
}
