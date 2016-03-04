using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class FootwearTypeRepository : EFRepository<FootwearType>, IFootwearTypeRepository
    {
        public FootwearTypeRepository(IDbContext dbContext) : base(dbContext)
        {
        }

    }
}
