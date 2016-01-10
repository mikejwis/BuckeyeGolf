﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuckeyeGolf.Services
{
    public class ScoringService
    {
        public List<double> ScoreMatchup(List<int> pars, List<int> player1Round, List<int> player2Round, int player1Handicap, int player2Handicap)
        {
            List<double> points = new List<double>() { 0.0, 0.0 };  

            points[0] += determineRoundPoints(pars, player1Round);
            points[1] += determineRoundPoints(pars, player2Round);

            points[0] += determineAttendancePoints(player1Round);
            points[1] += determineAttendancePoints(player2Round);

            List<double> matchupPoints = determineMatchupPoints(player1Round, player2Round, player1Handicap, player2Handicap);
            points[0] += matchupPoints[0];
            points[1] += matchupPoints[1];

            return points;
        }

        private double determineRoundPoints(List<int> pars, List<int> roundScores)
        {
            double points = 0.0;
            for(int i=0; i < roundScores.Count(); i++)
            {
                var diff = pars[i] - roundScores[i];
                if(diff == 0) { points += 1.0; }
                if(diff == 1) { points += 3.0; }
                if(diff == -1) { points += 0.5; }
                if(diff == 2) { points += 5.0; }
            }
            return points;
        }

        private List<double> determineMatchupPoints(List<int> player1Scores, List<int> player2Scores, int player1Handicap, int player2Handicap)
        {
            List<double> points = new List<double>() { 0.0, 0.0 };
            var p1RoundTotal = 0;
            player1Scores.ForEach(r => p1RoundTotal += r);
            p1RoundTotal -= player1Handicap;
            var p2RoundTotal = 0;
            player2Scores.ForEach(r => p2RoundTotal += r);
            p2RoundTotal -= player2Handicap;

            if (p1RoundTotal == p2RoundTotal)
            {
                points[0] = 2.0;
                points[1] = 2.0;
            }
            if(p1RoundTotal > p2RoundTotal)
            {
                points[0] = 1.0;
                points[1] = 4.0;
            }
            if(p1RoundTotal < p2RoundTotal)
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