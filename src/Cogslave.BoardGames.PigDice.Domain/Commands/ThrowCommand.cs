using System;
using Cogslave.BoardGames.PigDice.Domain.Games;

namespace Cogslave.BoardGames.PigDice.Domain.Commands
{
    internal class ThrowCommand : ICommand
    {
        private readonly Guid _id;

        public ThrowCommand(Guid id)
        {
            _id = id;
        }

        public bool IsLegal(IQueryState state)
        {
            return state.CanThrow(_id);
        }

        public IGameState Execute(ICommandState state)
        {
            return state.Throw(_id);
        }
    }
}