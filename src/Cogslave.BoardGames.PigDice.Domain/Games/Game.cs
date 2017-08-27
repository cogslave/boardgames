using Cogslave.BoardGames.PigDice.Domain.Commands;
using Cogslave.BoardGames.PigDice.Domain.Dice;
using Cogslave.BoardGames.PigDice.Domain.Players;
using Cogslave.BoardGames.PigDice.Domain.TurnStructures;

namespace Cogslave.BoardGames.PigDice.Domain.Games
{
    public class Game : IGame
    {
        private IGameState _state;

        public Game(IDice dice, INext<IPlayer> players)
        {
            _state = new PlayingState(dice, players);
        }
        
        public void Execute(ICommand command)
        {
            if (!command.IsLegal(_state)) return;
            
            _state = command.Execute(_state);
        }
    }
}