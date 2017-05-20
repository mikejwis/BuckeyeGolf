using BuckeyeGolf.Models;
using BuckeyeGolf.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BuckeyeGolf.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public async Task<IHttpActionResult> Get()
        {
            using (var repoProvider = new RepoProvider())
            {
                //var highestWeek = repoProvider.WeekRepo.GetHighestWeek();
                /*if (highestWeek != null)
                {
                    repoProvider.MatchupRepo.DeleteMatchups(highestWeek.WeekId);
                    repoProvider.WeekRepo.DeleteWeek(highestWeek);
                    HttpRuntime.Cache.Remove("MatchupSummary");
                }
                */
                var newRound1 = new RoundModel();
                
                var week = repoProvider.WeekRepo.GetWeekByNumber(1);
                var player1 = await repoProvider.PlayerRepo.Get("Tom S");
                var player2 = await repoProvider.PlayerRepo.Get("Mike");
                var round1 = repoProvider.RoundRepo.GetWeeklyRound(player1.PlayerId, week.WeekId);
                var round2 = repoProvider.RoundRepo.GetWeeklyRound(player2.PlayerId, week.WeekId);
                newRound1.TotalPoints = round1.TotalPoints - 1;
                round2.TotalPoints = round2.TotalPoints - 1;
                newRound1.AttendancePoints = 1;
                round2.AttendancePoints = 1;
                newRound1.BirdieCnt = round1.BirdieCnt;
                newRound1.BogeyCnt = round1.BogeyCnt;
                newRound1.EagleCnt = round1.EagleCnt;
                newRound1.Front = round1.Front;
                newRound1.Handicap = round1.Handicap;
                newRound1.MatchupPoints = round1.MatchupPoints;
                newRound1.ParCnt = round1.ParCnt;
                newRound1.PlayerRef = round1.PlayerRef;
                newRound1.PlayerRefId = round1.PlayerRefId;
                newRound1.Result = round1.Result;
                newRound1.RoundId = round1.RoundId;
                newRound1.Scores = round1.Scores;
                newRound1.ScoringPoints = round1.ScoringPoints;

                await repoProvider.SaveAllRepoChangesAsync();
            }
            return Ok();
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
