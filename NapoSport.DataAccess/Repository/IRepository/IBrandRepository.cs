﻿using NapoSport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NapoSport.DataAccess.Repository.IRepository
{
    public interface IBrandRepository : IRepository<Brand>
    {
        void Save();
        void Update(Brand brand);
    }
}
