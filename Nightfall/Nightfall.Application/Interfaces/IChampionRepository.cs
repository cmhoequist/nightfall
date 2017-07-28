﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nightfall.Application
{
    public interface IChampionRepository
    {
        Task<IEnumerable<Champion>> GetAll();
    }
}