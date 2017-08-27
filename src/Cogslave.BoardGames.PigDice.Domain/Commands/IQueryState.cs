using System;

namespace Cogslave.BoardGames.PigDice.Domain.Commands
{
    public interface IQueryState
    {
        bool CanThrow(Guid id);
        bool CanHold(Guid id);
    }
}