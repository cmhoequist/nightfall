using Nightfall.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nightfall.Application.Interfaces
{
    public interface IGamePersistenceHandler
    {
        Task<Game> CreateGame(Game gameName);
        Task<Game> LoadGame(string gameName);
    }
}
