using BuckeyeGolf.Repos;
using System;
using System.Collections;
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
        protected DbSet<CourseModel> Courses { get; set; }
        protected DbSet<Par> CoursePars { get; set; }
        protected DbSet<Score> PlayerScores { get; set; }
         

        public GolfDbContext() : base("name=GolfDB")
        {
            this.Database.CommandTimeout = 120;
        }
    }
    //CreateDatabaseIfNotExists
    //DropCreateDatabaseAlways
    public class GolfLeagueInitializer : DropCreateDatabaseAlways<GolfDbContext>
    {
        protected override void Seed(GolfDbContext context)
        {
            var repoProvider = new RepoProvider(context);
            var w1 = new WeekModel() { WeekId = Guid.NewGuid(), WeekNbr = 1, ScoreCreateDate = new DateTime(2017, 5, 1), BeenPlayed=false };
            repoProvider.WeekRepo.Add(w1);
            //var w2 = new WeekModel() { WeekId = Guid.NewGuid(), WeekNbr = 2, ScoreCreateDate = new DateTime(2017, 5, 8), BeenPlayed = false };
            //repoProvider.WeekRepo.Add(w2);
            //var w3 = new WeekModel() { WeekId = Guid.NewGuid(), WeekNbr = 3, ScoreCreateDate = new DateTime(2015, 7, 21), BeenPlayed = true };
            //repoProvider.WeekRepo.Add(w3);
            //var w4 = new WeekModel() { WeekId = Guid.NewGuid(), WeekNbr = 4, ScoreCreateDate = new DateTime(2015, 7, 29), BeenPlayed = false };
            //repoProvider.WeekRepo.Add(w4);

            var p1 = new PlayerModel() { Name = "Brandon", PlayerId = Guid.NewGuid(), HandicapRound1 = 0, HandicapRound2 = 56 };
            p1.Rounds = new List<RoundModel>();
            //repoProvider.RoundRepo.Add(new RoundModel() { Handicap = 6, TotalScore = 45, TotalPoints = 6, RoundId = Guid.NewGuid(), PlayerRefId = p1.PlayerId, WeekId = w1.WeekId });
            //repoProvider.RoundRepo.Add(new RoundModel() { Handicap = 5, TotalScore = 49, TotalPoints = 3.5, RoundId = Guid.NewGuid(), PlayerRefId = p1.PlayerId, WeekId = w2.WeekId });
            //repoProvider.RoundRepo.Add(new RoundModel() { Handicap = 7, TotalScore = 52, TotalPoints = 1, RoundId = Guid.NewGuid(), PlayerRefId = p1.PlayerId, WeekId = w3.WeekId });
            repoProvider.PlayerRepo.Add(p1);

            var p2 = new PlayerModel() { Name = "Len", PlayerId = Guid.NewGuid(), HandicapRound1 = 51, HandicapRound2 = 49 };
            p2.Rounds = new List<RoundModel>();
            //repoProvider.RoundRepo.Add(new RoundModel() { Handicap = 8, TotalScore = 42, TotalPoints = 6, RoundId = Guid.NewGuid(), PlayerRefId = p2.PlayerId, WeekId = w1.WeekId });
            //repoProvider.RoundRepo.Add(new RoundModel() { Handicap = 9, TotalScore = 45, TotalPoints = 3, RoundId = Guid.NewGuid(), PlayerRefId = p2.PlayerId, WeekId = w2.WeekId });
            //repoProvider.RoundRepo.Add(new RoundModel() { Handicap = 6, TotalScore = 57, TotalPoints = 0, RoundId = Guid.NewGuid(), PlayerRefId = p2.PlayerId, WeekId = w3.WeekId });
            repoProvider.PlayerRepo.Add(p2);

            var p3 = new PlayerModel() { Name = "Tom L", PlayerId = Guid.NewGuid(), HandicapRound1 = 58, HandicapRound2 = 46 };
            p3.Rounds = new List<RoundModel>();
            //repoProvider.RoundRepo.Add(new RoundModel() { Handicap = 6, TotalScore = 55, TotalPoints = 3, RoundId = Guid.NewGuid(), PlayerRefId = p3.PlayerId, WeekId = w1.WeekId });
            //repoProvider.RoundRepo.Add(new RoundModel() { Handicap = 3, TotalScore = 59, TotalPoints = 2.5, RoundId = Guid.NewGuid(), PlayerRefId = p3.PlayerId, WeekId = w2.WeekId });
            //repoProvider.RoundRepo.Add(new RoundModel() { Handicap = 7, TotalScore = 52, TotalPoints = 1, RoundId = Guid.NewGuid(), PlayerRefId = p3.PlayerId, WeekId = w3.WeekId });
            repoProvider.PlayerRepo.Add(p3);

            var p4 = new PlayerModel() { Name = "Jack", PlayerId = Guid.NewGuid(), HandicapRound1 = 57, HandicapRound2 = 0 };
            p4.Rounds = new List<RoundModel>();
            //repoProvider.RoundRepo.Add(new RoundModel() { Handicap = 5, TotalScore = 45, TotalPoints = 1, RoundId = Guid.NewGuid(), PlayerRefId = p4.PlayerId, WeekId = w1.WeekId, BirdieCnt = 0, ParCnt = 1, BogeyCnt = 3 });
            //repoProvider.RoundRepo.Add(new RoundModel() { Handicap = 6, TotalScore = 60, TotalPoints = 3, RoundId = Guid.NewGuid(), PlayerRefId = p4.PlayerId, WeekId = w2.WeekId, BirdieCnt = 0, ParCnt = 1, BogeyCnt = 3 });
            //repoProvider.RoundRepo.Add(new RoundModel() { Handicap = 6, TotalScore = 52, TotalPoints = 1, RoundId = Guid.NewGuid(), PlayerRefId = p4.PlayerId, WeekId = w3.WeekId, BirdieCnt = 1, ParCnt = 0, BogeyCnt = 4 });
            repoProvider.PlayerRepo.Add(p4);

            var p5 = new PlayerModel() { Name = "Keith", PlayerId = Guid.NewGuid(), HandicapRound1 = 48, HandicapRound2 = 46 };
            p5.Rounds = new List<RoundModel>();
            //repoProvider.RoundRepo.Add(new RoundModel() { Handicap = 6, TotalScore = 45, TotalPoints = 12, RoundId = Guid.NewGuid(), PlayerRefId = p5.PlayerId, WeekId = w1.WeekId, BirdieCnt = 0, ParCnt = 3, BogeyCnt = 1 });
            //repoProvider.RoundRepo.Add(new RoundModel() { Handicap = 6, TotalScore = 43, TotalPoints = 3.5, RoundId = Guid.NewGuid(), PlayerRefId = p5.PlayerId, WeekId = w2.WeekId, BirdieCnt = 0, ParCnt = 2, BogeyCnt = 3 });
            //repoProvider.RoundRepo.Add(new RoundModel() { Handicap = 4, TotalScore = 52, TotalPoints = 1, RoundId = Guid.NewGuid(), PlayerRefId = p5.PlayerId, WeekId = w3.WeekId, BirdieCnt = 0, ParCnt = 1, BogeyCnt = 0 });
            repoProvider.PlayerRepo.Add(p5);

            var p6 = new PlayerModel() { Name = "Kevin", PlayerId = Guid.NewGuid(), HandicapRound1 = 53, HandicapRound2 = 52 };
            p6.Rounds = new List<RoundModel>();
            //repoProvider.RoundRepo.Add(new RoundModel() { Handicap = 6, TotalScore = 45, TotalPoints = 6, RoundId = Guid.NewGuid(), PlayerRefId = p6.PlayerId, WeekId = w1.WeekId, BirdieCnt = 0, ParCnt = 1, BogeyCnt = 1 });
            //repoProvider.RoundRepo.Add(new RoundModel() { Handicap = 7, TotalScore = 44, TotalPoints = 4, RoundId = Guid.NewGuid(), PlayerRefId = p6.PlayerId, WeekId = w2.WeekId, BirdieCnt = 0, ParCnt = 1, BogeyCnt = 0 });
            //repoProvider.RoundRepo.Add(new RoundModel() { Handicap = 5, TotalScore = 42, TotalPoints = 1, RoundId = Guid.NewGuid(), PlayerRefId = p6.PlayerId, WeekId = w3.WeekId, BirdieCnt = 1, ParCnt = 3, BogeyCnt = 1 });
            repoProvider.PlayerRepo.Add(p6);

            var p7 = new PlayerModel() { Name = "Tom S", PlayerId = Guid.NewGuid(), HandicapRound1 = 0, HandicapRound2 = 47 };
            p7.Rounds = new List<RoundModel>();
            //repoProvider.RoundRepo.Add(new RoundModel() { Handicap = 10, TotalScore = 55, TotalPoints = 4, RoundId = Guid.NewGuid(), PlayerRefId = p7.PlayerId, WeekId = w1.WeekId, BirdieCnt = 0, ParCnt = 4, BogeyCnt = 2 });
            //repoProvider.RoundRepo.Add(new RoundModel() { Handicap = 6, TotalScore = 59, TotalPoints = 3, RoundId = Guid.NewGuid(), PlayerRefId = p7.PlayerId, WeekId = w2.WeekId, BirdieCnt = 0, ParCnt = 0, BogeyCnt = 1 });
            //repoProvider.RoundRepo.Add(new RoundModel() { Handicap = 6, TotalScore = 52, TotalPoints = 0, RoundId = Guid.NewGuid(), PlayerRefId = p7.PlayerId, WeekId = w3.WeekId, BirdieCnt = 0, ParCnt = 1, BogeyCnt = 2 });
            repoProvider.PlayerRepo.Add(p7);

            var p8 = new PlayerModel() { Name = "Mike", PlayerId = Guid.NewGuid(), HandicapRound1 = 51, HandicapRound2 = 0 };
            p8.Rounds = new List<RoundModel>();
            //repoProvider.RoundRepo.Add(new RoundModel() { Handicap = 6, TotalScore = 43, TotalPoints = 1, RoundId = Guid.NewGuid(), PlayerRefId = p8.PlayerId, WeekId = w1.WeekId, BirdieCnt = 0, ParCnt = 1, BogeyCnt = 1 });
            //repoProvider.RoundRepo.Add(new RoundModel() { Handicap = 8, TotalScore = 47, TotalPoints = 1.5, RoundId = Guid.NewGuid(), PlayerRefId = p8.PlayerId, WeekId = w2.WeekId, BirdieCnt = 0, ParCnt = 0, BogeyCnt = 2 });
            //repoProvider.RoundRepo.Add(new RoundModel() { Handicap = 2, TotalScore = 55, TotalPoints = 10, RoundId = Guid.NewGuid(), PlayerRefId = p8.PlayerId, WeekId = w3.WeekId, BirdieCnt = 0, ParCnt = 0, BogeyCnt = 0 });
            repoProvider.PlayerRepo.Add(p8);

            var p9 = new PlayerModel() { Name = "Mark", PlayerId = Guid.NewGuid(), HandicapRound1 = 52, HandicapRound2 = 55 };
            p9.Rounds = new List<RoundModel>();
            repoProvider.PlayerRepo.Add(p9);

            var p10 = new PlayerModel() { Name = "Emil", PlayerId = Guid.NewGuid(), HandicapRound1 = 76, HandicapRound2 = 67 };
            p10.Rounds = new List<RoundModel>();
            repoProvider.PlayerRepo.Add(p10);

            var p11 = new PlayerModel() { Name = "Bill H", PlayerId = Guid.NewGuid(), HandicapRound1 = 0, HandicapRound2 = 58 };
            p11.Rounds = new List<RoundModel>();
            repoProvider.PlayerRepo.Add(p11);

            var p12 = new PlayerModel() { Name = "Vince", PlayerId = Guid.NewGuid(), HandicapRound1 = 69, HandicapRound2 = 64 };
            p12.Rounds = new List<RoundModel>();
            repoProvider.PlayerRepo.Add(p12);

            var p13 = new PlayerModel() { Name = "Bill B", PlayerId = Guid.NewGuid(), HandicapRound1 = 58, HandicapRound2 = 0 };
            p13.Rounds = new List<RoundModel>();
            repoProvider.PlayerRepo.Add(p13);

            var p14 = new PlayerModel() { Name = "Dennis", PlayerId = Guid.NewGuid(), HandicapRound1 = 42, HandicapRound2 = 56 };
            p14.Rounds = new List<RoundModel>();
            repoProvider.PlayerRepo.Add(p14);

            var p15 = new PlayerModel() { Name = "Bill L", PlayerId = Guid.NewGuid(), HandicapRound1 = 54, HandicapRound2 = 47 };
            p15.Rounds = new List<RoundModel>();
            repoProvider.PlayerRepo.Add(p15);

            var p16 = new PlayerModel() { Name = "John", PlayerId = Guid.NewGuid(), HandicapRound1 = 57, HandicapRound2 = 0 };
            p16.Rounds = new List<RoundModel>();
            repoProvider.PlayerRepo.Add(p16);

            /*
             1 - Brandon
             2 - Len
             3 - Tom L
             4 - Jack
             5 - Keith
             6 - Kevin
             7 - Tom S
             8 - Mike
             9 - Mark
             10 - Emil
             11 - Bill H
             12 - Vince
             13- Bill B
             14- Dennis
             15 - Bill L
             16 - John
             */
            //week 1 matchups
            repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w1.WeekId, Player1 = p2.PlayerId, Player2 = p8.PlayerId });
            repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w1.WeekId, Player1 = p9.PlayerId, Player2 = p14.PlayerId });
            repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w1.WeekId, Player1 = p6.PlayerId, Player2 = p12.PlayerId });
            repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w1.WeekId, Player1 = p16.PlayerId, Player2 = p10.PlayerId });
            repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w1.WeekId, Player1 = p5.PlayerId, Player2 = p11.PlayerId });
            repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w1.WeekId, Player1 = p3.PlayerId, Player2 = p7.PlayerId });
            repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w1.WeekId, Player1 = p13.PlayerId, Player2 = p4.PlayerId });
            repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w1.WeekId, Player1 = p1.PlayerId, Player2 = p15.PlayerId });

            //week 2 matchups
            //repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w2.WeekId, Player1 = p14.PlayerId, Player2 = p2.PlayerId });
            //repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w2.WeekId, Player1 = p8.PlayerId, Player2 = p9.PlayerId });
            //repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w2.WeekId, Player1 = p6.PlayerId, Player2 = p16.PlayerId });
            //repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w2.WeekId, Player1 = p12.PlayerId, Player2 = p10.PlayerId });
            //repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w2.WeekId, Player1 = p3.PlayerId, Player2 = p5.PlayerId });
            //repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w2.WeekId, Player1 = p11.PlayerId, Player2 = p7.PlayerId });
            //repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w2.WeekId, Player1 = p4.PlayerId, Player2 = p15.PlayerId });
            //repoProvider.MatchupRepo.Add(new MatchupModel() { MatchupId = Guid.NewGuid(), WeekId = w2.WeekId, Player1 = p1.PlayerId, Player2 = p13.PlayerId });

            //week 3 matchups
           
            //week 4 matchups
           
            //Configuration
            var configObj = new ConfigurationModel() { LeagueId = Guid.NewGuid(), HandicapWeekCount = 99, RoundParFront=35, RoundParBack=36, RoundAdjustment = 0.90 };
            repoProvider.ConfigRepo.Add(configObj);

            //Course
            var courseId = Guid.NewGuid();
            //Front Pars: 4, 4, 4, 5, 4, 4, 4, 3, 3 
            //Back Pars: 4, 3, 5, 4, 4, 4, 5, 3, 4
            var frontPars = new List<Par>() { new Par(){ Id=0,ParValue=4, CourseRefId=courseId, Front=true},
                            new Par(){ Id=1,ParValue=4, CourseRefId=courseId, Front=true },
                            new Par(){ Id=2,ParValue=4, CourseRefId=courseId, Front=true },
                            new Par(){ Id=3,ParValue=5, CourseRefId=courseId, Front=true },
                            new Par(){ Id=4,ParValue=4, CourseRefId=courseId, Front=true },
                            new Par(){ Id=5,ParValue=4, CourseRefId=courseId, Front=true },
                            new Par(){ Id=6,ParValue=4, CourseRefId=courseId, Front=true },
                            new Par(){ Id=7,ParValue=3, CourseRefId=courseId, Front=true },
                            new Par(){ Id=8,ParValue=3, CourseRefId=courseId, Front=true }
            };
            var backPars = new List<Par>() { 
                new Par() { Id=9, ParValue=4, CourseRefId=courseId, Front=false},
                new Par() { Id=10, ParValue=3, CourseRefId=courseId, Front=false},
                new Par() { Id=11, ParValue=5, CourseRefId=courseId, Front=false},
                new Par() { Id=12, ParValue=4, CourseRefId=courseId, Front=false},
                new Par() { Id=13, ParValue=4, CourseRefId=courseId, Front=false},
                new Par() { Id=14, ParValue=4, CourseRefId=courseId, Front=false},
                new Par() { Id=15, ParValue=5, CourseRefId=courseId, Front=false},
                new Par() { Id=16, ParValue=3, CourseRefId=courseId, Front=false},
                new Par() { Id=17, ParValue=4, CourseRefId=courseId, Front=false}
            };
            var courseObj = new CourseModel() { CourseId = courseId, FrontPars = frontPars, BackPars = backPars };
            repoProvider.CourseRepo.Add(courseObj);
            repoProvider.ParRepo.AddRange(courseObj.FrontPars);
            repoProvider.ParRepo.AddRange(courseObj.BackPars);

            repoProvider.SaveAllRepoChanges();
        }
    }
}