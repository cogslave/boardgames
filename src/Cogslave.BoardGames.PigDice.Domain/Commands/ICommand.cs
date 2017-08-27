using Cogslave.BoardGames.PigDice.Domain.Games;

namespace Cogslave.BoardGames.PigDice.Domain.Commands
{
    public interface ICommand
    {
        bool IsLegal(IQueryState state);
        IGameState Execute(ICommandState state);
    }
}