using Cogslave.BoardGames.PigDice.Domain.Commands;

namespace Cogslave.BoardGames.PigDice.Domain.Games
{
    public interface IGameState : IQueryState, ICommandState
    {
    }
}