using Nightfall.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nightfall.Application.Interfaces
{
    public interface IChampionQueryRepository
    {
        Task<IEnumerable<ChampionQuery>> GetAllDetails();
    }
}
