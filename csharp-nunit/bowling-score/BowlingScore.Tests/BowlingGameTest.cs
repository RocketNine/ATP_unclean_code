using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace BowlingScore.Tests;

public class BowlingGameTest
{
    [Test]
    public void fullGame_allGutterBalls()
    {
        var bowlingGame = new BowlingGame();
        RollSomeBalls(bowlingGame, 0);

        // TODO 2025-08 constraint-based Assert model prefers assert to look like
        // Assert.That(bowlingGame.Score(), Is.EqualTo(0));
        // Convert all assertions in this file to that model
        ClassicAssert.AreEqual(0, bowlingGame.Score());
    }

    [Test]
    public void fullGame_eachFrame_onlyOnePinKnockedDown() {
        var bowlingGame = new BowlingGame();
        RollSomeBalls(bowlingGame, 1);
        ClassicAssert.AreEqual(20, bowlingGame.Score());
    }

    [Test]
    public void fullGame_eachFrame_threePinsKnockedDown() {
        var bowlingGame = new BowlingGame();
        RollSomeBalls(bowlingGame, 3);
        ClassicAssert.AreEqual(60, bowlingGame.Score());
    }

    [Test]
    public void partialGame_noSpareOrStrike_differentNumberOfPinsKnockedDownEachRoll() {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(1);
        bowlingGame.Bowl(5);
        bowlingGame.Bowl(6);
        bowlingGame.Bowl(3);
        ClassicAssert.AreEqual(15, bowlingGame.Score());
    }

    [Test]
    public void partialGame_spareInFirstFrame_followedByGutterBalls() {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(7);
        bowlingGame.Bowl(3);
        bowlingGame.Bowl(0);
        ClassicAssert.AreEqual(10, bowlingGame.Score());
    }

    [Test]
    public void partialGame_spare_nextRollIsAddedToSpare() {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(9);
        bowlingGame.Bowl(1);
        bowlingGame.Bowl(4);
        ClassicAssert.AreEqual(18, bowlingGame.Score());
    }

    [Test]
    public void partialGame_spares_inBothFrame1And2() {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(7);
        bowlingGame.Bowl(3);
        bowlingGame.Bowl(9);
        bowlingGame.Bowl(1);
        bowlingGame.Bowl(9);
        ClassicAssert.AreEqual(47, bowlingGame.Score());
    }

    [Test]
    public void partialGame_spare_after_gutter_then_gutters()
    {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(0);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(0);
        bowlingGame.Bowl(0);
        ClassicAssert.AreEqual(10, bowlingGame.Score());
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
        ClassicAssert.AreEqual(13, bowlingGame.Score());
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
        ClassicAssert.AreEqual(24, bowlingGame.Score());
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
        ClassicAssert.AreEqual(25, bowlingGame.Score());
    }
        
    [Test]
    public void partialGame_spare_after_gutter_then_strike()
    {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(0);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(0);
        ClassicAssert.AreEqual(30, bowlingGame.Score());
    }
    
    [Test]
    public void partialGame_strikeInFirstFrame_followedByGutterBalls() {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(0);
        bowlingGame.Bowl(0);
        ClassicAssert.AreEqual(10, bowlingGame.Score());
    }

    [Test]
    public void partialGame_strikeInFirstFrame_nextTwoRollsAddedToStrike() {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(7);
        bowlingGame.Bowl(2);
        ClassicAssert.AreEqual(28, bowlingGame.Score());
    }

    [Test]
    public void partialGame_strikeIn2ndFrame_rollsInFrame3AddedToStrike() {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(6);
        bowlingGame.Bowl(3);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(7);
        bowlingGame.Bowl(2);
        ClassicAssert.AreEqual(37, bowlingGame.Score());
    }

    [Test]
    public void partialGame_twoStrikes_FollowedByGutterBalls_SecondStrikeAddedToFirst_andCountedOnItsOwn() {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(0);
        bowlingGame.Bowl(0);
        ClassicAssert.AreEqual(30, bowlingGame.Score());
    }

    [Test]
    public void partialGame_threeStrikes_FollowedByGutterBalls() {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(0);
        bowlingGame.Bowl(0);
        ClassicAssert.AreEqual(60, bowlingGame.Score());
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

        ClassicAssert.AreEqual(300, bowlingGame.Score());
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

        ClassicAssert.AreEqual(299, bowlingGame.Score());
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
        ClassicAssert.AreEqual(290, bowlingGame.Score());
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

        ClassicAssert.AreEqual(187, bowlingGame.Score());
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
