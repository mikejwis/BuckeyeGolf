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
    [System.Web.Http.Route("api/Results/Add")]
    public class AddResultController : ApiController
    {

        public AddRoundWeekViewModel Get()
        {
            AddRoundWeekViewModel vm = new AddRoundWeekViewModel() { PlayerRounds = new List<AddRoundViewModel>() };

            using (var repoProvider = new RepoProvider())
            {
                var week = repoProvider.WeekRepo.GetFirstUnplayedWeek();
                vm.HasUnplayedWeeks = false;

                if (week != null)
                {
                    vm.HasUnplayedWeeks = true;
                    vm.WeekNbr = week.WeekNbr;
                    vm.WeekId = week.WeekId;

                    foreach (var player in repoProvider.PlayerRepo.GetAll())
                    {
                        var roundScores = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                        vm.PlayerRounds.Add(new AddRoundViewModel() { PlayerId = player.PlayerId, PlayerName = player.Name, Scores = roundScores });
                    }
                }
            }
            return vm;
        }

        public async Task<IHttpActionResult> Post(AddRoundWeekViewModel vm)
        {
            if (ModelState.IsValid)
            {
                using (var repoProvider = new RepoProvider())
                {
                    var week = repoProvider.WeekRepo.Get(vm.WeekId);
                    week.BeenPlayed = true;
                    week.ScoreCreateDate = DateTime.Now;

                    bool front = vm.FrontBack.Equals("Front");
                    var course = repoProvider.CourseRepo.Get();

                    var pars = front ? repoProvider.ParRepo.GetFrontPars(course.CourseId) :
                        repoProvider.ParRepo.GetBackPars(course.CourseId);
                    var parList = pars.Select(p => p.ParValue);

                    bool half = vm.FirstHalf.Equals("First");

                    var matchups = repoProvider.MatchupRepo.GetAllWeeklyMatchups(vm.WeekId);
                    foreach (var matchup in matchups)
                    {
                        var postedRoundPlayer1 = vm.PlayerRounds.First(r => r.PlayerId.CompareTo(matchup.Player1) == 0);
                        var postedRoundPlayer2 = vm.PlayerRounds.First(r => r.PlayerId.CompareTo(matchup.Player2) == 0);
                        var p1Handicap = ServiceProvider.HandicapInstance.CalculateHandicap(matchup.Player1);
                        var p2Handicap = ServiceProvider.HandicapInstance.CalculateHandicap(matchup.Player2);
                        List<ScoringResultModel> scoringResults = ServiceProvider.ScoringInstance.ScoreMatchup(parList, postedRoundPlayer1.Scores, postedRoundPlayer2.Scores, p1Handicap, p2Handicap);

                        var p1NewRound = new RoundModel()
                        {
                            PlayerRefId = postedRoundPlayer1.PlayerId,
                            RoundId = Guid.NewGuid(),
                            WeekId = vm.WeekId,
                            Scores = ServiceProvider.ScoringInstance.ExtractScores(postedRoundPlayer1.Scores),
                            Front = front,
                            SeasonFirstHalf = half,
                            Handicap = p1Handicap,
                            TotalScore = ServiceProvider.ScoringInstance.RoundTotalScore(postedRoundPlayer1.Scores),
                            TotalPoints = scoringResults[0].Points,
                            BirdieCnt = scoringResults[0].Birdies,
                            ParCnt = scoringResults[0].Pars,
                            EagleCnt = scoringResults[0].Eagles,
                            BogeyCnt = scoringResults[0].Bogeys
                        };
                        var p2NewRound = new RoundModel()
                        {
                            PlayerRefId = postedRoundPlayer2.PlayerId,
                            RoundId = Guid.NewGuid(),
                            WeekId = vm.WeekId,
                            Scores = ServiceProvider.ScoringInstance.ExtractScores(postedRoundPlayer2.Scores),
                            Front = front,
                            SeasonFirstHalf = half,
                            Handicap = p2Handicap,
                            TotalScore = ServiceProvider.ScoringInstance.RoundTotalScore(postedRoundPlayer2.Scores),
                            TotalPoints = scoringResults[1].Points,
                            BirdieCnt = scoringResults[1].Birdies,
                            ParCnt = scoringResults[1].Pars,
                            EagleCnt = scoringResults[1].Eagles,
                            BogeyCnt = scoringResults[1].Bogeys
                        };
                        repoProvider.RoundRepo.Add(p1NewRound);
                        repoProvider.RoundRepo.Add(p2NewRound);
                    }
                    await repoProvider.SaveAllRepoChangesAsync();
                }
                return Ok();
            }
            return BadRequest();
        }
    }
}