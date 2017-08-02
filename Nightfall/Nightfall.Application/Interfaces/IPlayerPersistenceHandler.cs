using Nightfall.Application.Commands;
using Nightfall.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nightfall.Application.Interfaces
{
    public interface IPlayerPersistenceHandler
    {
        Task<Player> Save(Player player);
    }
}
