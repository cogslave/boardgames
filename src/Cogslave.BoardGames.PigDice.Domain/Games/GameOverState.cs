using System;

namespace Cogslave.BoardGames.PigDice.Domain.Games
{
    internal class GameOverState : IGameState
    {
        public bool CanThrow(Guid id)
        {
            return false;
        }

        public bool CanHold(Guid id)
        {
            return false;
        }

        public IGameState Throw(Guid id)
        {
            return this;
        }

        public IGameState Hold(Guid id)
        {
            return this;
        }
    }
}