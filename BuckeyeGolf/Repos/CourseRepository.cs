using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuckeyeGolf.Models;

namespace BuckeyeGolf.Repos
{
    public class CourseRepository : EntityRepository<CourseModel>
    {
        public CourseRepository() : base() { }

        public CourseRepository(GolfDbContext context) : base(context) { }

        public CourseModel Get()
        {
            return DataSet.First();
        }
    }
}