using System;
using System.Text;
using System.Collections.Generic;
using BuckeyeGolf.Services;
using BuckeyeGolf.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuckeyeGolf.Tests.Services
{
    [TestClass]
    public class ScoringServiceTests
    {
        ScoringService _scoringService = null;
        List<int> _pars = null;
        List<int> _p1Scores = null;
        List<int> _p2Scores = null;
        List<int> _noScores = null;
        public ScoringServiceTests()
        {
            _scoringService = new ScoringService();
            _pars = new List<int>() { 4, 4, 4};
            _p1Scores = new List<int>() { 4, 4, 4 };
            _p2Scores = new List<int>() { 4, 4, 4 };
            _noScores = new List<int>() { 0, 0, 0 };
        }
        [TestMethod]
        public void ExtractScores_TestEmpty()
        {
            List<int> scores = new List<int>();
            List<Score> result = _scoringService.ExtractScores(scores);
            Assert.AreEqual<int>(0, result.Count);
        }

        [TestMethod]
        public void ExtractScores_TestBasicList()
        {
            List<int> scores = new List<int>() { 1, -9, 25, 0 };
            List<Score> result = _scoringService.ExtractScores(scores);
            Assert.AreEqual<int>(4, result.Count);
            Assert.AreEqual<int>(0, result[3].ScoreValue);
            Assert.AreEqual<int>(25, result[2].ScoreValue);
        }

        [TestMethod]
        public void RoundTotalScore_TestBasicList()
        {
            List<int> scores = new List<int>() { 1, -9, 25, 0 };
            int result = _scoringService.RoundTotalScore(scores);
            Assert.AreEqual<int>(17, result);
        }

        [TestMethod]
        public void RoundTotalScore_TestEmptyList()
        {
            List<int> scores = new List<int>();
            int result = _scoringService.RoundTotalScore(scores);
            Assert.AreEqual<int>(0, result);
        }

        [TestMethod]
        public void ScoreMatchup_TieAllPars()
        {
            List<ScoringResultModel> result = _scoringService.ScoreMatchup(_pars, _p1Scores, _p2Scores, 10, 10);
            Assert.AreEqual<double>(7, result[0].TotalPoints);
            Assert.AreEqual<double>(7, result[1].TotalPoints);
            Assert.AreEqual<int>(3, result[0].Pars);
            Assert.AreEqual<int>(3, result[1].Pars);
            Assert.AreEqual<int>(0, result[0].Birdies);
            Assert.AreEqual<int>(0, result[1].Birdies);
            Assert.AreEqual<int>(0, result[0].Eagles);
            Assert.AreEqual<int>(0, result[1].Eagles);
            Assert.AreEqual<int>(0, result[0].Bogeys);
            Assert.AreEqual<int>(0, result[1].Bogeys);
        }
        [TestMethod]
        public void ScoreMatchup_BothNoShow()
        {
            List<ScoringResultModel> result = _scoringService.ScoreMatchup(_pars, _noScores, _noScores, 10, 10);
            Assert.AreEqual<double>(2, result[0].TotalPoints);
            Assert.AreEqual<double>(2, result[1].TotalPoints);
            Assert.AreEqual<int>(0, result[0].Pars);
            Assert.AreEqual<int>(0, result[1].Pars);
            Assert.AreEqual<int>(0, result[0].Birdies);
            Assert.AreEqual<int>(0, result[1].Birdies);
            Assert.AreEqual<int>(0, result[0].Eagles);
            Assert.AreEqual<int>(0, result[1].Eagles);
            Assert.AreEqual<int>(0, result[0].Bogeys);
            Assert.AreEqual<int>(0, result[1].Bogeys);
        }

        [TestMethod]
        public void ScoreMatchup_Player1NoShow()
        {
            List<ScoringResultModel> result = _scoringService.ScoreMatchup(_pars, _noScores, _p2Scores, 10, 10);
            Assert.AreEqual<double>(1, result[0].TotalPoints);
            Assert.AreEqual<double>(9, result[1].TotalPoints);
            Assert.AreEqual<int>(0, result[0].Pars);
            Assert.AreEqual<int>(3, result[1].Pars);
            Assert.AreEqual<int>(0, result[0].Birdies);
            Assert.AreEqual<int>(0, result[1].Birdies);
            Assert.AreEqual<int>(0, result[0].Eagles);
            Assert.AreEqual<int>(0, result[1].Eagles);
            Assert.AreEqual<int>(0, result[0].Bogeys);
            Assert.AreEqual<int>(0, result[1].Bogeys);
        }

        [TestMethod]
        public void ScoreMatchup_Player2NoShow()
        {
            List<ScoringResultModel> result = _scoringService.ScoreMatchup(_pars, _p1Scores, _noScores, 10, 10);
            Assert.AreEqual<double>(9, result[0].TotalPoints);
            Assert.AreEqual<double>(1, result[1].TotalPoints);
            Assert.AreEqual<int>(3, result[0].Pars);
            Assert.AreEqual<int>(0, result[1].Pars);
            Assert.AreEqual<int>(0, result[0].Birdies);
            Assert.AreEqual<int>(0, result[1].Birdies);
            Assert.AreEqual<int>(0, result[0].Eagles);
            Assert.AreEqual<int>(0, result[1].Eagles);
            Assert.AreEqual<int>(0, result[0].Bogeys);
            Assert.AreEqual<int>(0, result[1].Bogeys);
        }

        [TestMethod]
        public void ScoreMatchup_P1WinDueToHandicap()
        {
            var p1Scores = new List<int>() { 4,4,4, };
            var p2Scores = new List<int>() { 4, 4, 4, };
            List<ScoringResultModel> result = _scoringService.ScoreMatchup(_pars, p1Scores, p2Scores, 11, 10);
            Assert.AreEqual<double>(9, result[0].TotalPoints);
            Assert.AreEqual<double>(6, result[1].TotalPoints);
            Assert.AreEqual<int>(3, result[0].Pars);
            Assert.AreEqual<int>(3, result[1].Pars);
            Assert.AreEqual<int>(0, result[0].Birdies);
            Assert.AreEqual<int>(0, result[1].Birdies);
            Assert.AreEqual<int>(0, result[0].Eagles);
            Assert.AreEqual<int>(0, result[1].Eagles);
            Assert.AreEqual<int>(0, result[0].Bogeys);
            Assert.AreEqual<int>(0, result[1].Bogeys);
        }

        [TestMethod]
        public void ScoreMatchup_P2WinDueToHandicap()
        {
            var p1Scores = new List<int>() { 4, 4, 4, };
            var p2Scores = new List<int>() { 4, 4, 4, };
            List<ScoringResultModel> result = _scoringService.ScoreMatchup(_pars, p1Scores, p2Scores, 10, 11);
            Assert.AreEqual<double>(6, result[0].TotalPoints);
            Assert.AreEqual<double>(9, result[1].TotalPoints);
            Assert.AreEqual<int>(3, result[0].Pars);
            Assert.AreEqual<int>(3, result[1].Pars);
            Assert.AreEqual<int>(0, result[0].Birdies);
            Assert.AreEqual<int>(0, result[1].Birdies);
            Assert.AreEqual<int>(0, result[0].Eagles);
            Assert.AreEqual<int>(0, result[1].Eagles);
            Assert.AreEqual<int>(0, result[0].Bogeys);
            Assert.AreEqual<int>(0, result[1].Bogeys);
        }

        [TestMethod]
        public void ScoreMatchup_P1WinDueToScore()
        {
            var p1Scores = new List<int>() { 3, 4, 4, };
            var p2Scores = new List<int>() { 4, 4, 4, };
            List<ScoringResultModel> result = _scoringService.ScoreMatchup(_pars, p1Scores, p2Scores, 10, 10);
            Assert.AreEqual<double>(11, result[0].TotalPoints);
            Assert.AreEqual<double>(6, result[1].TotalPoints);
            Assert.AreEqual<int>(2, result[0].Pars);
            Assert.AreEqual<int>(3, result[1].Pars);
            Assert.AreEqual<int>(1, result[0].Birdies);
            Assert.AreEqual<int>(0, result[1].Birdies);
            Assert.AreEqual<int>(0, result[0].Eagles);
            Assert.AreEqual<int>(0, result[1].Eagles);
            Assert.AreEqual<int>(0, result[0].Bogeys);
            Assert.AreEqual<int>(0, result[1].Bogeys);
        }

        [TestMethod]
        public void ScoreMatchup_P2WinDueToScore()
        {
            var p1Scores = new List<int>() { 4, 4, 4, };
            var p2Scores = new List<int>() { 3, 4, 4, };
            List<ScoringResultModel> result = _scoringService.ScoreMatchup(_pars, p1Scores, p2Scores, 10, 10);
            Assert.AreEqual<double>(6, result[0].TotalPoints);
            Assert.AreEqual<double>(11, result[1].TotalPoints);
            Assert.AreEqual<int>(3, result[0].Pars);
            Assert.AreEqual<int>(2, result[1].Pars);
            Assert.AreEqual<int>(0, result[0].Birdies);
            Assert.AreEqual<int>(1, result[1].Birdies);
            Assert.AreEqual<int>(0, result[0].Eagles);
            Assert.AreEqual<int>(0, result[1].Eagles);
            Assert.AreEqual<int>(0, result[0].Bogeys);
            Assert.AreEqual<int>(0, result[1].Bogeys);
        }

        [TestMethod]
        public void ScoreMatchup_TieDueToHandicap()
        {
            var p1Scores = new List<int>() { 4, 4, 4, };
            var p2Scores = new List<int>() { 3, 4, 4, };
            List<ScoringResultModel> result = _scoringService.ScoreMatchup(_pars, p1Scores, p2Scores, 10, 9);
            Assert.AreEqual<double>(7, result[0].TotalPoints);
            Assert.AreEqual<double>(9, result[1].TotalPoints);
            Assert.AreEqual<int>(3, result[0].Pars);
            Assert.AreEqual<int>(2, result[1].Pars);
            Assert.AreEqual<int>(0, result[0].Birdies);
            Assert.AreEqual<int>(1, result[1].Birdies);
            Assert.AreEqual<int>(0, result[0].Eagles);
            Assert.AreEqual<int>(0, result[1].Eagles);
            Assert.AreEqual<int>(0, result[0].Bogeys);
            Assert.AreEqual<int>(0, result[1].Bogeys);
        }

        [TestMethod]
        public void ScoreMatchup_P2LossDueToHandicap()
        {
            var p1Scores = new List<int>() { 5, 4, 4, };
            var p2Scores = new List<int>() { 3, 4, 4, };
            List<ScoringResultModel> result = _scoringService.ScoreMatchup(_pars, p1Scores, p2Scores, 12, 9);
            Assert.AreEqual<double>(8.5, result[0].TotalPoints);
            Assert.AreEqual<double>(8, result[1].TotalPoints);
            Assert.AreEqual<int>(2, result[0].Pars);
            Assert.AreEqual<int>(2, result[1].Pars);
            Assert.AreEqual<int>(0, result[0].Birdies);
            Assert.AreEqual<int>(1, result[1].Birdies);
            Assert.AreEqual<int>(0, result[0].Eagles);
            Assert.AreEqual<int>(0, result[1].Eagles);
            Assert.AreEqual<int>(1, result[0].Bogeys);
            Assert.AreEqual<int>(0, result[1].Bogeys);
        }
    }
}
