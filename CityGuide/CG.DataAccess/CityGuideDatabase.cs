using System.Collections.Generic;
using System.Linq;
using CG.Domain;

namespace CG.DataAccess
{
    public class CityGuideDatabase : ICityGuideDatabase
    {
        private CityGuideContext _ctx;

        public CityGuideDatabase(CityGuideContext context)
        {
            _ctx = context;
        }

        public void Commit()
        {
            _ctx.SaveChanges();
        }

        public List<Objective> GetAllObjectives()
        {
            IQueryable<Objective> objs = _ctx.Objectives;//.Where(o => o.Description.StartsWith("a"));
                                                         //  objs = objs.Where(o => o.Description.StartsWith("a")).OrderBy(o => o.Description);
            return objs.ToList();
        }
    }
}
