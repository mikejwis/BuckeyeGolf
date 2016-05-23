﻿using BuckeyeGolf.Models;
using BuckeyeGolf.Repos;
using BuckeyeGolf.Services;
using BuckeyeGolf.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BuckeyeGolf.Controllers
{
    public class AddResultController : Controller
    {
        // GET: AddResult
        [HttpGet]
        public ActionResult Index()
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
        public ActionResult Index(AddRoundWeekViewModel vm)
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
                            Scores = extractScores(postedRoundPlayer1.Scores),
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
                            Scores = extractScores(postedRoundPlayer2.Scores),
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
                    repoProvider.SaveAllRepoChanges();
                }
                return RedirectToAction("Index");
            }
            return RedirectToAction("Add");
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
                                    Scores = extractScores(postedRoundPlayer1.Scores),
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
                                    Scores = extractScores(postedRoundPlayer2.Scores),
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
        private List<Score> extractScores(List<int> vmScores)
        {
            List<Score> retVal = new List<Score>();
            for (int i = 0; i < vmScores.Count(); i++)
            {
                retVal.Add(new Score() { Id = i, ScoreValue = vmScores.ElementAt(i) });
            }
            return retVal;
        }

    }
}