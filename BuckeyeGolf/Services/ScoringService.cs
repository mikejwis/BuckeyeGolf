using BuckeyeGolf.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuckeyeGolf.Services
{
    public class ScoringService
    {
        public List<Score> ExtractScores(List<int> vmScores)
        {
            List<Score> retVal = new List<Score>();
            for (int i = 0; i < vmScores.Count(); i++)
            {
                retVal.Add(new Score() { Id = i, ScoreValue = vmScores.ElementAt(i) });
            }
            return retVal;
        }

        public List<ScoringResultModel> ScoreMatchup(IEnumerable<int> pars, List<int> player1Round, List<int> player2Round, int player1Handicap, int player2Handicap, bool p1Makeup = false, bool p2Makeup = false)
        {
            var result1 = new ScoringResultModel() { TotalPoints = 0.0, Birdies = 0, Pars = 0, Bogeys = 0, Eagles = 0};
            var result2 = new ScoringResultModel() { TotalPoints = 0.0, Birdies = 0, Pars = 0, Bogeys = 0, Eagles = 0 };
            List<ScoringResultModel> results = new List<ScoringResultModel>();
            results.Add(result1);
            results.Add(result2);

            results[0].ScoringPts = determineRoundPoints(pars, player1Round, result1);
            results[1].ScoringPts = determineRoundPoints(pars, player2Round, result2);

            results[0].AttendancePts = determineAttendancePoints(player1Round, p1Makeup);
            results[1].AttendancePts = determineAttendancePoints(player2Round, p2Makeup);

            List<int> matchupPoints = determineMatchupPoints(player1Round, player2Round, player1Handicap, player2Handicap);
            results[0].MatchupPts = matchupPoints[0];
            results[1].MatchupPts = matchupPoints[1];

            results[0].TotalPoints = results[0].ScoringPts + results[0].MatchupPts + results[0].AttendancePts;
            results[1].TotalPoints = results[1].ScoringPts + results[1].MatchupPts + results[1].AttendancePts;

            setMatchupResult(matchupPoints, result1, result2);

            return results;
        }

        public int RoundTotalScore(List<int> scores)
        {
            var total = 0;
            scores.ForEach(r => total += r);
            return total;
        }

        private double determineRoundPoints(IEnumerable<int> pars, List<int> roundScores, ScoringResultModel resultObj)
        {
            double points = 0.0;
            for(int i=0; i < roundScores.Count(); i++)
            {
                var diff = pars.ElementAt(i) - roundScores[i];
                if (diff == 0) { points += 1.0; resultObj.Pars++; }
                if (diff == 1) { points += 3.0; resultObj.Birdies++; }
                if (diff == -1) { points += 0.5; resultObj.Bogeys++; }
                if (diff == 2) { points += 5.0; resultObj.Eagles++; }
            }
            return points;
        }

        private List<int> determineMatchupPoints(List<int> player1Scores, List<int> player2Scores, int player1Handicap, int player2Handicap)
        {
            List<int> points = new List<int>() { 0, 0 };
            var p1RoundTotal = RoundTotalScore(player1Scores);
            if (p1RoundTotal != 0) p1RoundTotal -= player1Handicap;
            var p2RoundTotal = RoundTotalScore(player2Scores);
            if (p2RoundTotal != 0) p2RoundTotal -= player2Handicap;

            if(p1RoundTotal == 0 && p2RoundTotal!=0)
            {
                points[0] = 0;
                points[1] = 6;
            }
            if (p2RoundTotal == 0 && p1RoundTotal != 0)
            {
                points[0] = 6;
                points[1] = 0;
            }
            if ((p1RoundTotal == p2RoundTotal) && p1RoundTotal!=0 && p2RoundTotal!=0)
            {
                points[0] = 3;
                points[1] = 3;
            }
            if((p1RoundTotal > p2RoundTotal) && p2RoundTotal!=0)
            {
                points[0] = 0;
                points[1] = 6;
            }
            if((p1RoundTotal < p2RoundTotal) && p1RoundTotal!=0)
            {
                points[0] = 6;
                points[1] = 0;
            }
            if(p1RoundTotal == 0 && p2RoundTotal == 0)
            {
                points[0] = 0;
                points[1] = 0;
            }

            return points;
        }

        private void setMatchupResult(List<int> matchupPoints, ScoringResultModel p1Results, ScoringResultModel p2Results)
        {
            if(matchupPoints[0] > matchupPoints[1])
            {
                p1Results.MatchResult = MatchupResult.Win;
                p2Results.MatchResult = MatchupResult.Loss;
            }
            else if (matchupPoints[0] < matchupPoints[1])
            {
                p1Results.MatchResult = MatchupResult.Loss;
                p2Results.MatchResult = MatchupResult.Win;
            }
            else
            {
                p1Results.MatchResult = MatchupResult.Tie;
                p2Results.MatchResult = MatchupResult.Tie;
            }
        }

        private int determineAttendancePoints(List<int> scores, bool makeupRound)
        {
            if (makeupRound) return 1;
            return scores.Where(s => s > 0).Any() ? 2 : 0;
        }
    }
}