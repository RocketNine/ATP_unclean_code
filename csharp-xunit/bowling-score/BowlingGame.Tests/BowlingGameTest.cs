using Xunit;

namespace BowlingScore.Tests;

public class BowlingGameTest
{
    [Fact]
    public void fullGame_allGutterBalls()
    {
        var bowlingGame = new BowlingGame.BowlingGame();
        RollSomeBalls(bowlingGame, 0);

        Assert.Equal(0, bowlingGame.Score());
    }

    [Fact]
    public void fullGame_eachFrame_onlyOnePinKnockedDown() {
        var bowlingGame = new BowlingGame.BowlingGame();
        RollSomeBalls(bowlingGame, 1);
        Assert.Equal(20, bowlingGame.Score());
    }

    [Fact]
    public void fullGame_eachFrame_threePinsKnockedDown() {
        var bowlingGame = new BowlingGame.BowlingGame();
        RollSomeBalls(bowlingGame, 3);
        Assert.Equal(60, bowlingGame.Score());
    }

    [Fact]
    public void partialGame_noSpareOrStrike_differentNumberOfPinsKnockedDownEachRoll() {
        var bowlingGame = new BowlingGame.BowlingGame();
        bowlingGame.Bowl(1);
        bowlingGame.Bowl(5);
        bowlingGame.Bowl(6);
        bowlingGame.Bowl(3);
        Assert.Equal(15, bowlingGame.Score());
    }
    
    [Fact]
    public void partialGame_spareInFirstFrame_followedByGutterBalls() {
        var bowlingGame = new BowlingGame.BowlingGame();
        bowlingGame.Bowl(7);
        bowlingGame.Bowl(3);
        bowlingGame.Bowl(0);
        Assert.Equal(10, bowlingGame.Score());
    }

    [Fact]
    public void partialGame_spare_nextRollIsAddedToSpare() {
        var bowlingGame = new BowlingGame.BowlingGame();
        bowlingGame.Bowl(9);
        bowlingGame.Bowl(1);
        bowlingGame.Bowl(4);
        Assert.Equal(18, bowlingGame.Score());
    }

    [Fact]
    public void partialGame_spares_inBothFrame1And2() {
        var bowlingGame = new BowlingGame.BowlingGame();
        bowlingGame.Bowl(7);
        bowlingGame.Bowl(3);
        bowlingGame.Bowl(9);
        bowlingGame.Bowl(1);
        bowlingGame.Bowl(9);
        Assert.Equal(47, bowlingGame.Score());
    }

    [Fact]
    public void partialGame_strikeInFirstFrame_followedByGutterBalls() {
        var bowlingGame = new BowlingGame.BowlingGame();
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(0);
        bowlingGame.Bowl(0);
        Assert.Equal(10, bowlingGame.Score());
    }

    [Fact]
    public void partialGame_strikeInFirstFrame_nextTwoRollsAddedToStrike() {
        var bowlingGame = new BowlingGame.BowlingGame();
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(7);
        bowlingGame.Bowl(2);
        Assert.Equal(28, bowlingGame.Score());
    }

    [Fact]
    public void partialGame_strikeIn2ndFrame_rollsInFrame3AddedToStrike() {
        var bowlingGame = new BowlingGame.BowlingGame();
        bowlingGame.Bowl(6);
        bowlingGame.Bowl(3);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(7);
        bowlingGame.Bowl(2);
        Assert.Equal(37, bowlingGame.Score());
    }

    [Fact]
    public void partialGame_twoStrikes_FollowedByGutterBalls_SecondStrikeAddedToFirst_andCountedOnItsOwn() {
        var bowlingGame = new BowlingGame.BowlingGame();
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(0);
        bowlingGame.Bowl(0);
        Assert.Equal(30, bowlingGame.Score());
    }

    [Fact]
    public void partialGame_threeStrikes_FollowedByGutterBalls() {
        var bowlingGame = new BowlingGame.BowlingGame();
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(0);
        bowlingGame.Bowl(0);
        Assert.Equal(60, bowlingGame.Score());
    }

    [Fact]
    public void fullGame_PerfectGame() {
        var bowlingGame = new BowlingGame.BowlingGame();
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);

        Assert.Equal(300, bowlingGame.Score());
    }

    [Fact]
    public void fullGame_almostPerfectGame_missOnePinOnLastRoll() {
        var bowlingGame = new BowlingGame.BowlingGame();
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(9);

        Assert.Equal(299, bowlingGame.Score());
    }

    [Fact]
    public void fullGame_Example_in_Readme() {
        var bowlingGame = new BowlingGame.BowlingGame();
        bowlingGame.Bowl(10);

        bowlingGame.Bowl(9);
        bowlingGame.Bowl(1);

        bowlingGame.Bowl(5);
        bowlingGame.Bowl(5);

        bowlingGame.Bowl(7);
        bowlingGame.Bowl(2);

        bowlingGame.Bowl(10);

        bowlingGame.Bowl(10);

        bowlingGame.Bowl(10);

        bowlingGame.Bowl(9);
        bowlingGame.Bowl(0);

        bowlingGame.Bowl(8);
        bowlingGame.Bowl(2);

        bowlingGame.Bowl(9);
        bowlingGame.Bowl(1);
        bowlingGame.Bowl(10);

        Assert.Equal(187, bowlingGame.Score());
    }
    
    private void RollSomeBalls(BowlingGame.BowlingGame bowlingGame, int b)
    {
        //TODO - doesn't check b is valid
        //TODO - doesn't work when b>=5
        for (int i = 0; i < 10; i++) {
            bowlingGame.Bowl(b);
            bowlingGame.Bowl(b);
        }
    }
}
