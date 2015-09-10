﻿using BuckeyeGolf.Repos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BuckeyeGolf.Models
{
    public class GolfDbContext : DbContext
    {
        
        protected DbSet<PlayerModel> Players { get; set; }
        protected DbSet<RoundModel> Rounds { get; set; }
        protected DbSet<WeekModel> Weeks { get; set; }
        protected DbSet<MatchupModel> Matchups { get; set; }
        protected DbSet<ConfigurationModel> Config { get; set; }
         

        public GolfDbContext() : base("name=GolfDB")
        {
        }
    }

    public class GolfLeagueInitializer : DropCreateDatabaseIfModelChanges<GolfDbContext>
    {
        protected override void Seed(GolfDbContext context)
        {
            var repoProvider = new RepoProvider(context);
            var w1 = new WeekModel() { WeekId = Guid.NewGuid(), WeekNbr = 1, ScoreCreateDate = new DateTime(2015, 7, 1), BeenPlayed=true };
            repoProvider.WeekRepo.Add(w1);
            var w2 = new WeekModel() { WeekId = Guid.NewGuid(), WeekNbr = 2, ScoreCreateDate = new DateTime(2015, 7, 14), BeenPlayed = true };
            repoProvider.WeekRepo.Add(w2);
            var w3 = new WeekModel() { WeekId = Guid.NewGuid(), WeekNbr = 3, ScoreCreateDate = new DateTime(2015, 7, 21), BeenPlayed = true };
            repoProvider.WeekRepo.Add(w3);
            var w4 = new WeekModel() { WeekId = Guid.NewGuid(), WeekNbr = 4, ScoreCreateDate = new DateTime(2015, 7, 29), BeenPlayed = false };
            repoProvider.WeekRepo.Add(w4);

            var p1 = new PlayerModel() { Name = "Mike", PlayerId = Guid.NewGuid() };
            p1.Rounds = new List<RoundModel>();
            repoProvider.RoundRepo.Add(new RoundModel() { TotalScore = 45, TotalPoints = 6, RoundId = Guid.NewGuid(), PlayerRefId = p1.PlayerId, WeekId = w1.WeekId });
            repoProvider.RoundRepo.Add(new RoundModel() { TotalScore = 49, TotalPoints = 3.5, RoundId = Guid.NewGuid(), PlayerRefId = p1.PlayerId, WeekId = w2.WeekId });
            repoProvider.RoundRepo.Add(new RoundModel() { TotalScore = 52, TotalPoints = 1, RoundId = Guid.NewGuid(), PlayerRefId = p1.PlayerId, WeekId = w3.WeekId });
            repoProvider.PlayerRepo.Add(p1);
 
            var p2 = new PlayerModel() { Name = "Mark", PlayerId = Guid.NewGuid() };
            p2.Rounds = new List<RoundModel>();
            repoProvider.RoundRepo.Add(new RoundModel() { TotalScore = 42, TotalPoints = 6, RoundId = Guid.NewGuid(), PlayerRefId = p2.PlayerId, WeekId = w1.WeekId });
            repoProvider.RoundRepo.Add(new RoundModel() { TotalScore = 45, TotalPoints = 3, RoundId = Guid.NewGuid(), PlayerRefId = p2.PlayerId, WeekId = w2.WeekId });
            repoProvider.RoundRepo.Add(new RoundModel() { TotalScore = 57, TotalPoints = 0, RoundId = Guid.NewGuid(), PlayerRefId = p2.PlayerId, WeekId = w3.WeekId });
            repoProvider.PlayerRepo.Add(p2);

            var p3 = new PlayerModel() { Name = "Tom S", PlayerId = Guid.NewGuid() };
            p3.Rounds = new List<RoundModel>();
            repoProvider.RoundRepo.Add(new RoundModel() { TotalScore = 55, TotalPoints = 3, RoundId = Guid.NewGuid(), PlayerRefId = p3.PlayerId, WeekId = w1.WeekId });
            repoProvider.RoundRepo.Add(new RoundModel() { TotalScore = 59, TotalPoints = 2.5, RoundId = Guid.NewGuid(), PlayerRefId = p3.PlayerId, WeekId = w2.WeekId });
            repoProvider.RoundRepo.Add(new RoundModel() { TotalScore = 52, TotalPoints = 1, RoundId = Guid.NewGuid(), PlayerRefId = p3.PlayerId, WeekId = w3.WeekId });
            repoProvider.PlayerRepo.Add(p3);

            var p4 = new PlayerModel() { Name = "Jack", PlayerId = Guid.NewGuid() };
            p4.Rounds = new List<RoundModel>();
            repoProvider.RoundRepo.Add(new RoundModel() { TotalScore = 45, TotalPoints = 1, RoundId = Guid.NewGuid(), PlayerRefId = p4.PlayerId, WeekId = w1.WeekId, BirdieCnt = 0, ParCnt = 1, BogeyCnt = 3 });
            repoProvider.RoundRepo.Add(new RoundModel() { TotalScore = 60, TotalPoints = 3, RoundId = Guid.NewGuid(), PlayerRefId = p4.PlayerId, WeekId = w2.WeekId, BirdieCnt = 0, ParCnt = 1, BogeyCnt = 3 });
            repoProvider.RoundRepo.Add(new RoundModel() { TotalScore = 52, TotalPoints = 1, RoundId = Guid.NewGuid(), PlayerRefId = p4.PlayerId, WeekId = w3.WeekId, BirdieCnt = 1, ParCnt = 0, BogeyCnt = 4 });
            repoProvider.PlayerRepo.Add(p4);

            var p5 = new PlayerModel() { Name = "Keith", PlayerId = Guid.NewGuid() };
            p5.Rounds = new List<RoundModel>();
            repoProvider.RoundRepo.Add(new RoundModel() { TotalScore = 45, TotalPoints = 12, RoundId = Guid.NewGuid(), PlayerRefId = p5.PlayerId, WeekId = w1.WeekId, BirdieCnt = 0, ParCnt = 3, BogeyCnt = 1 });
            repoProvider.RoundRepo.Add(new RoundModel() { TotalScore = 43, TotalPoints = 3.5, RoundId = Guid.NewGuid(), PlayerRefId = p5.PlayerId, WeekId = w2.WeekId, BirdieCnt = 0, ParCnt = 2, BogeyCnt = 3 });
            repoProvider.RoundRepo.Add(new RoundModel() { TotalScore = 52, TotalPoints = 1, RoundId = Guid.NewGuid(), PlayerRefId = p5.PlayerId, WeekId = w3.WeekId, BirdieCnt = 0, ParCnt = 1, BogeyCnt = 0 });
            repoProvider.PlayerRepo.Add(p5);

            var p6 = new PlayerModel() { Name = "Kevin", PlayerId = Guid.NewGuid() };
            p6.Rounds = new List<RoundModel>();
            repoProvider.RoundRepo.Add(new RoundModel() { TotalScore = 45, TotalPoints = 6, RoundId = Guid.NewGuid(), PlayerRefId = p6.PlayerId, WeekId = w1.WeekId, BirdieCnt = 0, ParCnt = 1, BogeyCnt = 1 });
            repoProvider.RoundRepo.Add(new RoundModel() { TotalScore = 44, TotalPoints = 4, RoundId = Guid.NewGuid(), PlayerRefId = p6.PlayerId, WeekId = w2.WeekId, BirdieCnt = 0, ParCnt = 1, BogeyCnt = 0 });
            repoProvider.RoundRepo.Add(new RoundModel() { TotalScore = 42, TotalPoints = 1, RoundId = Guid.NewGuid(), PlayerRefId = p6.PlayerId, WeekId = w3.WeekId, BirdieCnt = 1, ParCnt = 3, BogeyCnt = 1 });
            repoProvider.PlayerRepo.Add(p6);

            var p7 = new PlayerModel() { Name = "Todd", PlayerId = Guid.NewGuid() };
            p7.Rounds = new List<RoundModel>();
            repoProvider.RoundRepo.Add(new RoundModel() { TotalScore = 55, TotalPoints = 4, RoundId = Guid.NewGuid(), PlayerRefId = p7.PlayerId, WeekId = w1.WeekId, BirdieCnt = 0, ParCnt = 4, BogeyCnt = 2 });
            repoProvider.RoundRepo.Add(new RoundModel() { TotalScore = 59, TotalPoints = 3, RoundId = Guid.NewGuid(), PlayerRefId = p7.PlayerId, WeekId = w2.WeekId, BirdieCnt = 0, ParCnt = 0, BogeyCnt = 1 });
            repoProvider.RoundRepo.Add(new RoundModel() { TotalScore = 52, TotalPoints = 0, RoundId = Guid.NewGuid(), PlayerRefId = p7.PlayerId, WeekId = w3.WeekId, BirdieCnt = 0, ParCnt = 1, BogeyCnt = 2 });
            repoProvider.PlayerRepo.Add(p7);

            var p8 = new PlayerModel() { Name = "Tom L", PlayerId = Guid.NewGuid() };
            p8.Rounds = new List<RoundModel>();
            repoProvider.RoundRepo.Add(new RoundModel() { TotalScore = 43, TotalPoints = 1, RoundId = Guid.NewGuid(), PlayerRefId = p8.PlayerId, WeekId = w1.WeekId, BirdieCnt = 0, ParCnt = 1, BogeyCnt = 1 });
            repoProvider.RoundRepo.Add(new RoundModel() { TotalScore = 47, TotalPoints = 1.5, RoundId = Guid.NewGuid(), PlayerRefId = p8.PlayerId, WeekId = w2.WeekId, BirdieCnt = 0, ParCnt = 0, BogeyCnt = 2 });
            repoProvider.RoundRepo.Add(new RoundModel() { TotalScore = 55, TotalPoints = 10, RoundId = Guid.NewGuid(), PlayerRefId = p8.PlayerId, WeekId = w3.WeekId, BirdieCnt = 0, ParCnt = 0, BogeyCnt = 0 });
            repoProvider.PlayerRepo.Add(p8);

            //week 1 matchups
            repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w1.WeekId, Player1 = p1.PlayerId, Player2 = p2.PlayerId });
            repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w1.WeekId, Player1 = p3.PlayerId, Player2 = p4.PlayerId });
            repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w1.WeekId, Player1 = p5.PlayerId, Player2 = p6.PlayerId });
            repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w1.WeekId, Player1 = p7.PlayerId, Player2 = p8.PlayerId });

            //week 2 matchups
            repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w2.WeekId, Player1 = p1.PlayerId, Player2 = p8.PlayerId });
            repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w2.WeekId, Player1 = p2.PlayerId, Player2 = p7.PlayerId });
            repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w2.WeekId, Player1 = p3.PlayerId, Player2 = p6.PlayerId });
            repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w2.WeekId, Player1 = p4.PlayerId, Player2 = p5.PlayerId });

            //week 3 matchups
            repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w3.WeekId, Player1 = p1.PlayerId, Player2 = p5.PlayerId });
            repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w3.WeekId, Player1 = p2.PlayerId, Player2 = p6.PlayerId });
            repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w3.WeekId, Player1 = p3.PlayerId, Player2 = p7.PlayerId });
            repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w3.WeekId, Player1 = p4.PlayerId, Player2 = p8.PlayerId });

            //week 4 matchups
            repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w4.WeekId, Player1 = p1.PlayerId, Player2 = p3.PlayerId });
            repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w4.WeekId, Player1 = p2.PlayerId, Player2 = p4.PlayerId });
            repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w4.WeekId, Player1 = p5.PlayerId, Player2 = p7.PlayerId });
            repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w4.WeekId, Player1 = p6.PlayerId, Player2 = p8.PlayerId });
            
            //Configuration
            var configObj = new ConfigurationModel() { LeagueId = Guid.NewGuid(), HandicapWeekCount = 3 };
            repoProvider.ConfigRepo.Add(configObj);

            repoProvider.SaveAllRepoChanges();
        }
    }
}