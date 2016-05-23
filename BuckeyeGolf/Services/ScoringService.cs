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

        public List<ScoringResultModel> ScoreMatchup(IEnumerable<int> pars, List<int> player1Round, List<int> player2Round, int player1Handicap, int player2Handicap)
        {
            var result1 = new ScoringResultModel() { Points = 0.0, Birdies = 0, Pars = 0, Bogeys = 0, Eagles = 0};
            var result2 = new ScoringResultModel() { Points = 0.0, Birdies = 0, Pars = 0, Bogeys = 0, Eagles = 0 };
            List<ScoringResultModel> results = new List<ScoringResultModel>();
            results.Add(result1);
            results.Add(result2);

            results[0].Points += determineRoundPoints(pars, player1Round, result1);
            results[1].Points += determineRoundPoints(pars, player2Round, result2);

            results[0].Points += determineAttendancePoints(player1Round);
            results[1].Points += determineAttendancePoints(player2Round);

            List<double> matchupPoints = determineMatchupPoints(player1Round, player2Round, player1Handicap, player2Handicap);
            results[0].Points += matchupPoints[0];
            results[1].Points += matchupPoints[1];

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

        private List<double> determineMatchupPoints(List<int> player1Scores, List<int> player2Scores, int player1Handicap, int player2Handicap)
        {
            List<double> points = new List<double>() { 0.0, 0.0 };
            var p1RoundTotal = RoundTotalScore(player1Scores);
            if (p1RoundTotal != 0) p1RoundTotal -= player1Handicap;
            var p2RoundTotal = RoundTotalScore(player2Scores);
            if (p2RoundTotal != 0) p2RoundTotal -= player2Handicap;

            if(p1RoundTotal == 0 && p2RoundTotal!=0)
            {
                points[0] = 1.0;
                points[1] = 4.0;
            }
            if (p2RoundTotal == 0 && p1RoundTotal != 0)
            {
                points[0] = 4.0;
                points[1] = 1.0;
            }
            if ((p1RoundTotal == p2RoundTotal) && p1RoundTotal!=0 && p2RoundTotal!=0)
            {
                points[0] = 2.0;
                points[1] = 2.0;
            }
            if((p1RoundTotal > p2RoundTotal) && p2RoundTotal!=0)
            {
                points[0] = 1.0;
                points[1] = 4.0;
            }
            if((p1RoundTotal < p2RoundTotal) && p1RoundTotal!=0)
            {
                points[0] = 4.0;
                points[1] = 1.0;
            }
            return points;
        }

        private double determineAttendancePoints(List<int> scores)
        {
            return scores.Where(s => s > 0).Any() ? 2.0 : 0.0;
        }
    }
}