using System;

namespace Cogslave.BoardGames.PigDice.Domain.Dice
{
    public class ScoringRoll : BaseRoll
    {
        public int Score { get; }

        public ScoringRoll(int score)
        {
            if (score <= 1 || score > 6) throw new ArgumentOutOfRangeException(nameof(score));

            Score = score;
        }
        
        public static implicit operator int(ScoringRoll roll)
        {
            return roll.Score;
        }
    }
}