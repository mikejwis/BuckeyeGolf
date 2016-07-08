using BuckeyeGolf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BuckeyeGolf.Repos
{
    public class RepoProvider : IDisposable
    {
        private ConfigRepository _configRepo = null;
        private CourseRepository _courseRepo = null;
        private MatchupRepository _matchupRepo = null;
        private PlayerRepository _playerRepo = null;
        private RoundRepository _roundRepo = null;
        private WeekRepository _weekRepo = null;
        private ParRespository _parRepo = null;

        private GolfDbContext _context = null;

        public RepoProvider()
        {
            _context = new GolfDbContext();
        }

        public RepoProvider(GolfDbContext context)
        {
            _context = context;
        }

        public ConfigRepository ConfigRepo
        {
            get
            {
                if (_configRepo == null) _configRepo = new ConfigRepository(_context);
                return _configRepo;
            }
            set { _configRepo = value; }
        }

        public CourseRepository CourseRepo
        {
            get
            {
                if (_courseRepo == null) _courseRepo = new CourseRepository(_context);
                return _courseRepo;
            }
            set { _courseRepo = value; }
        }

        public MatchupRepository MatchupRepo
        {
            get
            {
                if (_matchupRepo == null) _matchupRepo = new MatchupRepository(_context);
                return _matchupRepo;
            }
            set { _matchupRepo = value; }
        }

        public PlayerRepository PlayerRepo
        {
            get
            {
                if (_playerRepo == null) _playerRepo = new PlayerRepository(_context);
                return _playerRepo;
            }
            set { _playerRepo = value; }
        }

        public RoundRepository RoundRepo
        {
            get
            {
                if (_roundRepo == null) _roundRepo = new RoundRepository(_context);
                return _roundRepo;
            }
            set { _roundRepo = value; }
        }

        public WeekRepository WeekRepo
        {
            get
            {
                if (_weekRepo == null) _weekRepo = new WeekRepository(_context);
                return _weekRepo;
            }
            set { _weekRepo = value; }
        }

        public ParRespository ParRepo
        {
            get
            {
                if (_parRepo == null) _parRepo = new ParRespository(_context);
                return _parRepo;
            }
            set { _parRepo = value; }
        }


        public void SaveAllRepoChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveAllRepoChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}