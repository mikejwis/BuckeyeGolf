using BuckeyeGolf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web;

namespace BuckeyeGolf.Repos
{
    public class ParRespository : EntityRepository<Par>
    {
        public ParRespository() : base() { }

        public ParRespository(GolfDbContext context) : base(context) { }

        public List<Par> GetFrontPars(Guid courseId)
        {
            return DataSet.Where(p => p.CourseRefId.CompareTo(courseId) == 0 && p.Front==true).OrderBy(p=>p.Id).ToList();
        }

        public List<Par> GetBackPars(Guid courseId)
        {
            return DataSet.Where(p => p.CourseRefId.CompareTo(courseId) == 0 && p.Front==false).OrderBy(p => p.Id).ToList();
        }
    }
}