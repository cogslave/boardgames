using System;
using System.Collections.Generic;
using Cogslave.BoardGames.PigDice.Domain.TurnStructures;
using Shouldly;
using Xunit;

namespace Cogslave.BoardGames.PigDice.Tests
{
    public class InfiniteRoundRobinTests
    {
        [Fact]
        public void WhenElementsAreValidNextLoops()
        {
            var players = new InfiniteRoundRobin<int>(new[] {1, 2, 3});
            var expected = new[] {1, 2, 3, 1, 2, 3};

            var actual = new[]
            {
                players.Next(),
                players.Next(),
                players.Next(),
                players.Next(),
                players.Next(),
                players.Next()
            };

            actual.ShouldBe(expected);
        }

        [Fact]
        public void WhenElementsAreEmptyExceptionIsThrown()
        {
            Assert.Throws<ArgumentException>(() => new InfiniteRoundRobin<int>(new List<int>().ToArray()));
        }
        
        [Fact]
        public void WhenElementsAreNullExceptionIsThrown()
        {
            Assert.Throws<ArgumentNullException>(() => new InfiniteRoundRobin<int>(null));
        }
    }
}