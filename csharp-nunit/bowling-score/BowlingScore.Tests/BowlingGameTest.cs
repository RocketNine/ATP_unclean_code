using NUnit.Framework;

namespace BowlingScore.Tests;

public class BowlingGameTest
{
    [Test]
    public void fullGame_allGutterBalls()
    {
        var bowlingGame = new BowlingGame();
        RollSomeBalls(bowlingGame, 0);
        Assert.That(bowlingGame.Score(), Is.EqualTo(0));
    }

    [Test]
    public void fullGame_eachFrame_onlyOnePinKnockedDown() {
        var bowlingGame = new BowlingGame();
        RollSomeBalls(bowlingGame, 1);
        Assert.That(bowlingGame.Score(), Is.EqualTo(20));
    }

    [Test]
    public void fullGame_eachFrame_threePinsKnockedDown() {
        var bowlingGame = new BowlingGame();
        RollSomeBalls(bowlingGame, 3);
        Assert.That(bowlingGame.Score(), Is.EqualTo(60));
    }

    [Test]
    public void partialGame_noSpareOrStrike_differentNumberOfPinsKnockedDownEachRoll() {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(1);
        bowlingGame.Bowl(5);
        bowlingGame.Bowl(6);
        bowlingGame.Bowl(3);
        Assert.That(bowlingGame.Score(), Is.EqualTo(15));
    }

    [Test]
    public void partialGame_spareInFirstFrame_followedByGutterBalls() {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(7);
        bowlingGame.Bowl(3);
        bowlingGame.Bowl(0);
        Assert.That(bowlingGame.Score(), Is.EqualTo(10));
    }

    [Test]
    public void partialGame_spare_nextRollIsAddedToSpare() {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(9);
        bowlingGame.Bowl(1);
        bowlingGame.Bowl(4);
        Assert.That(bowlingGame.Score(), Is.EqualTo(18));
    }

    [Test]
    public void partialGame_spares_inBothFrame1And2() {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(7);
        bowlingGame.Bowl(3);
        bowlingGame.Bowl(9);
        bowlingGame.Bowl(1);
        bowlingGame.Bowl(9);
        Assert.That(bowlingGame.Score(), Is.EqualTo(47));
    }

    [Test]
    public void partialGame_spare_after_gutter_then_gutters()
    {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(0);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(0);
        bowlingGame.Bowl(0);
        Assert.That(bowlingGame.Score(), Is.EqualTo(10));
    }
    
    [Test]
    public void partialGame_spare_after_gutter_then_one_pin()
    {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(0);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(1);
        bowlingGame.Bowl(1);
        bowlingGame.Bowl(0);
        bowlingGame.Bowl(0);
        Assert.That(bowlingGame.Score(), Is.EqualTo(13));
    }
    
    [Test]
    public void partialGame_spare_after_gutter_then_open_frame()
    {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(0);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(5);
        bowlingGame.Bowl(4);
        bowlingGame.Bowl(0);
        Assert.That(bowlingGame.Score(), Is.EqualTo(24));
    }
        
    [Test]
    public void partialGame_spare_after_gutter_then_spare()
    {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(0);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(5);
        bowlingGame.Bowl(5);
        bowlingGame.Bowl(0);
        Assert.That(bowlingGame.Score(), Is.EqualTo(25));
    }
        
    [Test]
    public void partialGame_spare_after_gutter_then_strike()
    {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(0);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(0);
        Assert.That(bowlingGame.Score(), Is.EqualTo(30));
    }
    
    [Test]
    public void partialGame_strikeInFirstFrame_followedByGutterBalls() {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(0);
        bowlingGame.Bowl(0);
        Assert.That(bowlingGame.Score(), Is.EqualTo(10));
    }

    [Test]
    public void partialGame_strikeInFirstFrame_nextTwoRollsAddedToStrike() {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(7);
        bowlingGame.Bowl(2);
        Assert.That(bowlingGame.Score(), Is.EqualTo(28));
    }

    [Test]
    public void partialGame_strikeIn2ndFrame_rollsInFrame3AddedToStrike() {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(6);
        bowlingGame.Bowl(3);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(7);
        bowlingGame.Bowl(2);
        Assert.That(bowlingGame.Score(), Is.EqualTo(37));
    }

    [Test]
    public void partialGame_twoStrikes_FollowedByGutterBalls_SecondStrikeAddedToFirst_andCountedOnItsOwn() {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(0);
        bowlingGame.Bowl(0);
        Assert.That(bowlingGame.Score(), Is.EqualTo(30));
    }

    [Test]
    public void partialGame_threeStrikes_FollowedByGutterBalls() {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(0);
        bowlingGame.Bowl(0);
        Assert.That(bowlingGame.Score(), Is.EqualTo(60));
    }

    [Test]
    public void fullGame_PerfectGame() {
        var bowlingGame = new BowlingGame();
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

        Assert.That(bowlingGame.Score(), Is.EqualTo(300));
    }

    [Test]
    public void fullGame_almostPerfectGame_missOnePinOnLastRoll() {
        var bowlingGame = new BowlingGame();
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

        Assert.That(bowlingGame.Score(), Is.EqualTo(299));
    }

    [Test]
    public void fullGame_spare_after_gutter_followed_by_all_strikes()
    {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(0);
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
        Assert.That(bowlingGame.Score(), Is.EqualTo(290));
    }

    [Test]
    public void fullGame_Example_in_Readme() {
        var bowlingGame = new BowlingGame();
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

        Assert.That(bowlingGame.Score(), Is.EqualTo(187));
    }

    private void RollSomeBalls(BowlingGame bowlingGame, int b)
    {
        //TODO - doesn't check b is valid
        //TODO - doesn't work when b>=5
        for (int i = 0; i < 10; i++) {
            bowlingGame.Bowl(b);
            bowlingGame.Bowl(b);
        }
    }
}
