using Cogslave.BoardGames.PigDice.Domain.Commands;

namespace Cogslave.BoardGames.PigDice.Domain.Games
{
    internal interface IGame
    {
        void Execute(ICommand command);
    }
}