using System;
using Cogslave.BoardGames.PigDice.Domain.Games;

namespace Cogslave.BoardGames.PigDice.Domain.Commands
{
    internal class HoldCommand : ICommand
    {
        private readonly Guid _id;

        public HoldCommand(Guid id)
        {
            _id = id;
        }

        public bool IsLegal(IQueryState state)
        {
            return state.CanHold(_id);
        }

        public IGameState Execute(ICommandState state)
        {
            return state.Hold(_id);
        }
    }
}