using BuckeyeGolf.Models;
using BuckeyeGolf.Repos;
using BuckeyeGolf.Services;
using BuckeyeGolf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Net;

namespace BuckeyeGolf.Controllers
{
    public class ResultsController : ApiController
    {
        //GET api/Results
        public IEnumerable<WeekResultsViewModel> Get()
        {
            var weekColl = new List<WeekResultsViewModel>();

            var w3Rounds = new List<PlayerRoundViewModel>();
            w3Rounds.Add(new PlayerRoundViewModel() { Name = "Mike", TotalScore = 60, TotalPoints = 4, Birdies = 0, Pars = 1, Bogeys = 0 });
            w3Rounds.Add(new PlayerRoundViewModel() { Name = "Keith", TotalScore = 45, TotalPoints = 10, Birdies = 0, Pars = 2, Bogeys = 4 });
            w3Rounds.Add(new PlayerRoundViewModel() { Name = "Kevin", TotalScore = 49, TotalPoints = 9, Birdies = 0, Pars = 2, Bogeys = 2 });
            w3Rounds.Add(new PlayerRoundViewModel() { Name = "Bill", TotalScore = 53, TotalPoints = 7.5, Birdies = 0, Pars = 1, Bogeys = 1 });
            w3Rounds.Add(new PlayerRoundViewModel() { Name = "Tom S", TotalScore = 54, TotalPoints = 4, Birdies = 0, Pars = 1, Bogeys = 0 });
            w3Rounds.Add(new PlayerRoundViewModel() { Name = "Emil", TotalScore = 70, TotalPoints = 3.5, Birdies = 0, Pars = 0, Bogeys = 1 });
            w3Rounds.Add(new PlayerRoundViewModel() { Name = "Mark", TotalScore = 49, TotalPoints = 9, Birdies = 0, Pars = 1, Bogeys = 4 });
            w3Rounds.Add(new PlayerRoundViewModel() { Name = "Jack", TotalScore = 58, TotalPoints = 4, Birdies = 0, Pars = 1, Bogeys = 0 });
            w3Rounds.Add(new PlayerRoundViewModel() { Name = "Todd", TotalScore = 56, TotalPoints = 4, Birdies = 0, Pars = 0, Bogeys = 2 });
            w3Rounds.Add(new PlayerRoundViewModel() { Name = "Len", TotalScore = 44, TotalPoints = 8, Birdies = 0, Pars = 3, Bogeys = 4 });
            w3Rounds.Add(new PlayerRoundViewModel() { Name = "David", TotalScore = 49, TotalPoints = 8.5, Birdies = 0, Pars = 0, Bogeys = 5 });
            w3Rounds.Add(new PlayerRoundViewModel() { Name = "Brandon", TotalScore = 55, TotalPoints = 6, Birdies = 0, Pars = 0, Bogeys = 0 });
            weekColl.Add(new WeekResultsViewModel() { WeekNbr = 3, ScoreCreateDate = new DateTime(2016, 5, 23), PlayerRounds = w3Rounds });

            var w2Rounds = new List<PlayerRoundViewModel>();
            w2Rounds.Add(new PlayerRoundViewModel() { Name = "Mike", TotalScore = 55, TotalPoints = 9.5, Birdies = 1, Pars = 0, Bogeys = 1 });
            w2Rounds.Add(new PlayerRoundViewModel() { Name = "Keith", TotalScore = 53, TotalPoints = 6, Birdies = 0, Pars = 2, Bogeys = 2 });
            w2Rounds.Add(new PlayerRoundViewModel() { Name = "Kevin", TotalScore = 51, TotalPoints = 8, Birdies = 0, Pars = 1, Bogeys = 2 });
            w2Rounds.Add(new PlayerRoundViewModel() { Name = "Bill", TotalScore = 61, TotalPoints = 3.5, Birdies = 0, Pars = 0, Bogeys = 1 });
            w2Rounds.Add(new PlayerRoundViewModel() { Name = "Tom S", TotalScore = 53, TotalPoints = 6.5, Birdies = 0, Pars = 0, Bogeys = 1 });
            w2Rounds.Add(new PlayerRoundViewModel() { Name = "Emil", TotalScore = 66, TotalPoints = 7, Birdies = 0, Pars = 0, Bogeys = 2 });
            w2Rounds.Add(new PlayerRoundViewModel() { Name = "Mark", TotalScore = 48, TotalPoints = 9, Birdies = 0, Pars = 1, Bogeys = 4 });
            w2Rounds.Add(new PlayerRoundViewModel() { Name = "Jack", TotalScore = 59, TotalPoints = 4, Birdies = 0, Pars = 0, Bogeys = 2 });
            w2Rounds.Add(new PlayerRoundViewModel() { Name = "Todd", TotalScore = 57, TotalPoints = 4.5, Birdies = 0, Pars = 1, Bogeys = 1 });
            w2Rounds.Add(new PlayerRoundViewModel() { Name = "Len", TotalScore = 47, TotalPoints = 9.5, Birdies = 0, Pars = 2, Bogeys = 3 });
            w2Rounds.Add(new PlayerRoundViewModel() { Name = "David", TotalScore = 51, TotalPoints = 5, Birdies = 0, Pars = 1, Bogeys = 2 });
            w2Rounds.Add(new PlayerRoundViewModel() { Name = "Brandon", TotalScore = 57, TotalPoints = 3.5, Birdies = 0, Pars = 0, Bogeys = 1 });
            weekColl.Add(new WeekResultsViewModel() { WeekNbr = 2, ScoreCreateDate = new DateTime(2016, 5, 16), PlayerRounds = w2Rounds });
           
            var w1Rounds = new List<PlayerRoundViewModel>();
            w1Rounds.Add(new PlayerRoundViewModel() { Name = "Keith", TotalScore = 43, TotalPoints = 12.5, Birdies = 1, Pars = 1, Bogeys = 5 });
            w1Rounds.Add(new PlayerRoundViewModel() { Name = "Mark", TotalScore = 50, TotalPoints = 9.5, Birdies = 0, Pars = 2, Bogeys = 3 });
            w1Rounds.Add(new PlayerRoundViewModel() { Name = "Len", TotalScore = 43, TotalPoints = 11, Birdies = 0, Pars = 3, Bogeys = 4 });
            w1Rounds.Add(new PlayerRoundViewModel() { Name = "Mike", TotalScore = 61, TotalPoints = 3, Birdies = 0, Pars = 0, Bogeys = 0 });
            w1Rounds.Add(new PlayerRoundViewModel() { Name = "Kevin", TotalScore = 49, TotalPoints = 8.5, Birdies = 0, Pars = 1, Bogeys = 3 });
            w1Rounds.Add(new PlayerRoundViewModel() { Name = "Brandon", TotalScore = 54, TotalPoints = 6.5, Birdies = 0, Pars = 1, Bogeys = 3 });
            w1Rounds.Add(new PlayerRoundViewModel() { Name = "Tom S", TotalScore = 47, TotalPoints = 6, Birdies = 0, Pars = 1, Bogeys = 4 });
            w1Rounds.Add(new PlayerRoundViewModel() { Name = "Todd", TotalScore = 46, TotalPoints = 9.5, Birdies = 0, Pars = 1, Bogeys = 5 });
            w1Rounds.Add(new PlayerRoundViewModel() { Name = "David", TotalScore = 0, TotalPoints = 1, Birdies = 0, Pars = 0, Bogeys = 0 });
            w1Rounds.Add(new PlayerRoundViewModel() { Name = "Bill", TotalScore = 56, TotalPoints = 6, Birdies = 0, Pars = 1, Bogeys = 2 });
            w1Rounds.Add(new PlayerRoundViewModel() { Name = "Emil", TotalScore = 71, TotalPoints = 3.5, Birdies = 0, Pars = 1, Bogeys = 1 });
            w1Rounds.Add(new PlayerRoundViewModel() { Name = "Jack", TotalScore = 53, TotalPoints = 5, Birdies = 0, Pars = 1, Bogeys = 2 });
            weekColl.Add(new WeekResultsViewModel() { WeekNbr = 1, ScoreCreateDate = new DateTime(2016, 5, 9), PlayerRounds = w1Rounds });
            return weekColl.OrderByDescending(w => w.ScoreCreateDate);
        }

        // GET: Results
        /*        public ActionResult Index()
                {
                    var weekColl = new List<WeekResultsViewModel>();

                    using (var repoProvider = new RepoProvider())
                    {

                        foreach (var week in repoProvider.WeekRepo.GetPlayedWeeks())
                        {
                            var weekResultsVM = new WeekResultsViewModel()
                            {
                                WeekNbr = week.WeekNbr,
                                ScoreCreateDate = week.ScoreCreateDate,
                                PlayerRounds = new List<PlayerRoundViewModel>()
                            };

                            foreach (var round in repoProvider.RoundRepo.GetWeeklyRounds(week.WeekId))
                            {
                                var player = repoProvider.PlayerRepo.Get(round.PlayerRefId);
                                var playerRoundVM = new PlayerRoundViewModel()
                                {
                                    TotalPoints = round.TotalPoints,
                                    TotalScore = round.TotalScore,
                                    Name = player.Name,
                                    Birdies = round.BirdieCnt,
                                    Pars = round.ParCnt,
                                    Bogeys = round.BogeyCnt
                                };

                                weekResultsVM.PlayerRounds.Add(playerRoundVM);
                            }
                            weekColl.Add(weekResultsVM);
                        }
                    }
                    ViewBag.WeeklyResults = weekColl.OrderByDescending(w => w.ScoreCreateDate);
                    return View();
                }

                [HttpGet]
                public ActionResult Add()
                {
                    AddRoundWeekViewModel vm = new AddRoundWeekViewModel() { PlayerRounds = new List<AddRoundViewModel>() };
                    ViewBag.Empty = true;

                    using (var repoProvider = new RepoProvider())
                    {
                        var week = repoProvider.WeekRepo.GetFirstUnplayedWeek();
                        if (week != null)
                        {
                            ViewBag.Empty = false;
                            vm.WeekNbr = week.WeekNbr;
                            vm.WeekId = week.WeekId;
                            ViewBag.WeekNbr = week.WeekNbr;

                            foreach (var player in repoProvider.PlayerRepo.GetAll())
                            {
                                var roundScores = new List<int>() { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
                                vm.PlayerRounds.Add(new AddRoundViewModel() { PlayerId = player.PlayerId, PlayerName = player.Name, Scores = roundScores });
                            }

                            var frontBackList = new List<string>();
                            frontBackList.Add("Front");
                            frontBackList.Add("Back");
                            ViewBag.FrontBackList = frontBackList;
                        }
                    }
                    return View(vm);
                }

                [ValidateAntiForgeryToken]
                [HttpPost]
                public ActionResult Add(AddRoundWeekViewModel vm)
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
                            repoProvider.SaveAllRepoChanges();
                        }
                        return RedirectToAction("Index");
                    }
                    return RedirectToAction("Add");
                }
        */
    }
}