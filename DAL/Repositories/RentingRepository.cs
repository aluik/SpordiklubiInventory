﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;
using Domain;

namespace DAL.Repositories
{
    public class RentingRepository : EFRepository<Renting>, IRentingRepository
    {
        public RentingRepository(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
