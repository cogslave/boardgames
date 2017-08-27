using System;
using Cogslave.BoardGames.PigDice.Domain.Dice;

namespace Cogslave.BoardGames.PigDice.Domain.Players
{
    public class Player : IPlayer
    {
        public Guid Id { get; }
        public int TotalPoints { get; private set; }
        public int RoundPoints { get; private set; }

        public Player(Guid id)
        {
            if(id == Guid.Empty) { throw new ArgumentException("Value cannot be an empty Guid.", nameof(id)); }
            
            Id = id;
        }

        private void ApplyRoll(BankruptRoll roll)
        {
            RoundPoints = 0;
        }

        private void ApplyRoll(ScoringRoll roll)
        {
            RoundPoints += roll;
        }

        public void Apply(BaseRoll roll)
        {
            ApplyRoll((dynamic)roll);
        }

        public void Hold()
        {
            TotalPoints += RoundPoints;
            RoundPoints = 0;
        }
    }
}