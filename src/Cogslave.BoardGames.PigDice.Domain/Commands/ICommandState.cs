using System;
using Cogslave.BoardGames.PigDice.Domain.Games;

namespace Cogslave.BoardGames.PigDice.Domain.Commands
{
    public interface ICommandState
    {
        IGameState Throw(Guid id);
        IGameState Hold(Guid id);
    }
}