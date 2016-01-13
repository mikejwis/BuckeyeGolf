using BuckeyeGolf.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BuckeyeGolf.Repos
{
    public class EntityRepository<T> where T : class
    {
        private GolfDbContext _context = null;
        protected DbSet<T> DataSet { get; set; }

        public EntityRepository()
        {
            _context = new GolfDbContext();
            DataSet = _context.Set<T>();
        }

        public EntityRepository(GolfDbContext context)
        {
            _context = context;
            DataSet = _context.Set<T>();
        }

        public List<T> GetAll()
        {
            return DataSet.ToList();
        }

        public void Add(T entity)
        {
            DataSet.Add(entity);
        }

        public void AddRange(List<T> entityList)
        {
            DataSet.AddRange(entityList);
        }

    }
}