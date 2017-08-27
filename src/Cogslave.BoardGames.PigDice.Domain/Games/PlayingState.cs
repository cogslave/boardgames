using System;
using Cogslave.BoardGames.PigDice.Domain.Dice;
using Cogslave.BoardGames.PigDice.Domain.Players;
using Cogslave.BoardGames.PigDice.Domain.TurnStructures;

namespace Cogslave.BoardGames.PigDice.Domain.Games
{
    internal class PlayingState : IGameState
    {
        private const int Threshold = 100;
        private readonly IDice _dice;
        private readonly INext<IPlayer> _players;
        private IPlayer _activePlayer;

        public PlayingState(IDice dice, INext<IPlayer> players)
        {
            _dice = dice;
            _players = players;
        }

        private bool IsActiveAgent(Guid id)
        {
            return _activePlayer.Id == id;
        }

        public bool CanThrow(Guid id)
        {
            return IsActiveAgent(id);
        }

        public bool CanHold(Guid id)
        {
            return IsActiveAgent(id);
        }

        public IGameState Throw(Guid id)
        {
            return !CanThrow(id) ? this : Apply((dynamic)_dice.Roll());
        }

        private IGameState Apply(ScoringRoll roll)
        {   
            _activePlayer.Apply(roll);
            
            if (_activePlayer.TotalPoints >= Threshold)
            {
                return new GameOverState();
                //Todo: Handle game over event
            }
            
            //Todo: Raise throw outcome event

            return this;
        }
        
        private IGameState Apply(BankruptRoll roll)
        {
            _activePlayer.Apply(roll);
            _activePlayer = _players.Next();
            
            //Todo: Raise throw outcome event

            return this;
        }

        public IGameState Hold(Guid id)
        {
            if (!CanHold(id)) return this;

            _activePlayer.Hold();
            _activePlayer = _players.Next();

            //Todo: Raise hold outcome event

            return this;
        }
    }
}