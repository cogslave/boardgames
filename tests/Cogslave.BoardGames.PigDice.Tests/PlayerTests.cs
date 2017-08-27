using System;
using Shouldly;
using Xunit;
using Cogslave.BoardGames.PigDice.Domain.Players;
using Cogslave.BoardGames.PigDice.Domain.Dice;

namespace Cogslave.BoardGames.PigDice.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void WhenIdIsEmptyExceptionIsThrown()
        {
            Assert.Throws<ArgumentException>(() => new Player(Guid.Empty));
        }
        
        [Fact]
        public void WhenIdValidPlayerIsCreated()
        {
            var id = Guid.NewGuid();
            
            var player = new Player(id);
            
            player.Id.ShouldBe(id);
        }

        [Fact]
        public void WhenPlayerGoesBankruptHoldCommitsNoPoints()
        {
            var player = new Player(Guid.NewGuid());
            
            player.Apply(new ScoringRoll(5));
            player.Apply(new BankruptRoll());
            player.Hold();
            
            player.TotalPoints.ShouldBe(0);
            player.RoundPoints.ShouldBe(0);
        }
        
        [Fact]
        public void WhenPlayerHoldsPointsAreCommited()
        {
            var player = new Player(Guid.NewGuid());
            
            player.Apply(new ScoringRoll(5));
            player.Apply(new ScoringRoll(3));
            player.Hold();
            
            player.TotalPoints.ShouldBe(8);
            player.RoundPoints.ShouldBe(0);
        }

        [Fact]
        public void WhenPlayerStashesPointsAreNotCommited()
        {
            var player = new Player(Guid.NewGuid());
            
            player.Apply(new ScoringRoll(5));
            player.Apply(new ScoringRoll(3));
            
            player.TotalPoints.ShouldBe(0);
            player.RoundPoints.ShouldBe(8);
        }
    }
}