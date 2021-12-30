using Xunit;
using BowlingScore;

namespace BowlingScore.Tests;

public class BowlingScoreTest
{
    [Fact]
    public void IsStrike_SmokeTest()
    {
        var bowlingScore = new BowlingScore();
        bool result = bowlingScore.isStrike(1);

        Assert.False(result, "is it working?");
    }
}
