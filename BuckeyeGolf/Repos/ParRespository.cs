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

        public async Task<List<Par>> GetFrontPars(Guid courseId)
        {
            return await DataSet.Where(p => p.CourseRefId.CompareTo(courseId) == 0 && p.Front==true).OrderBy(p=>p.Id).ToListAsync();
        }

        public async Task<List<Par>> GetBackPars(Guid courseId)
        {
            return await DataSet.Where(p => p.CourseRefId.CompareTo(courseId) == 0 && p.Front==false).OrderBy(p => p.Id).ToListAsync();
        }
    }
}