using System;
using Cogslave.BoardGames.PigDice.Domain.Dice;

namespace Cogslave.BoardGames.PigDice.Domain.Players
{
    public interface IPlayer
    {
        Guid Id { get; }
        int TotalPoints { get; }
        int RoundPoints { get; }
        void Apply(BaseRoll roll);
        void Hold();
    }
}