using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BowlingScore.Tests;

[TestClass]
public class BowlingGameTest
{
    [TestMethod]
    public void fullGame_allGutterBalls()
    {
        var bowlingGame = new BowlingGame();
        RollSomeBalls(bowlingGame, 0);

        Assert.AreEqual(0, bowlingGame.Score());
    }

    [TestMethod]
    public void fullGame_eachFrame_onlyOnePinKnockedDown() {
        var bowlingGame = new BowlingGame();
        RollSomeBalls(bowlingGame, 1);
        Assert.AreEqual(20, bowlingGame.Score());
    }

    [TestMethod]
    public void fullGame_eachFrame_threePinsKnockedDown() {
        var bowlingGame = new BowlingGame();
        RollSomeBalls(bowlingGame, 3);
        Assert.AreEqual(60, bowlingGame.Score());
    }

    [TestMethod]
    public void partialGame_noSpareOrStrike_differentNumberOfPinsKnockedDownEachRoll() {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(1);
        bowlingGame.Bowl(5);
        bowlingGame.Bowl(6);
        bowlingGame.Bowl(3);
        Assert.AreEqual(15, bowlingGame.Score());
    }

    [TestMethod]
    public void partialGame_spareInFirstFrame_followedByGutterBalls() {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(7);
        bowlingGame.Bowl(3);
        bowlingGame.Bowl(0);
        Assert.AreEqual(10, bowlingGame.Score());
    }

    [TestMethod]
    public void partialGame_spare_nextRollIsAddedToSpare() {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(9);
        bowlingGame.Bowl(1);
        bowlingGame.Bowl(4);
        Assert.AreEqual(18, bowlingGame.Score());
    }

    [TestMethod]
    public void partialGame_spares_inBothFrame1And2() {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(7);
        bowlingGame.Bowl(3);
        bowlingGame.Bowl(9);
        bowlingGame.Bowl(1);
        bowlingGame.Bowl(9);
        Assert.AreEqual(47, bowlingGame.Score());
    }

    [TestMethod]
    public void partialGame_strikeInFirstFrame_followedByGutterBalls() {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(0);
        bowlingGame.Bowl(0);
        Assert.AreEqual(10, bowlingGame.Score());
    }

    [TestMethod]
    public void partialGame_strikeInFirstFrame_nextTwoRollsAddedToStrike() {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(7);
        bowlingGame.Bowl(2);
        Assert.AreEqual(28, bowlingGame.Score());
    }

    [TestMethod]
    public void partialGame_strikeIn2ndFrame_rollsInFrame3AddedToStrike() {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(6);
        bowlingGame.Bowl(3);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(7);
        bowlingGame.Bowl(2);
        Assert.AreEqual(37, bowlingGame.Score());
    }

    [TestMethod]
    public void partialGame_twoStrikes_FollowedByGutterBalls_SecondStrikeAddedToFirst_andCountedOnItsOwn() {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(0);
        bowlingGame.Bowl(0);
        Assert.AreEqual(30, bowlingGame.Score());
    }

    [TestMethod]
    public void partialGame_threeStrikes_FollowedByGutterBalls() {
        var bowlingGame = new BowlingGame();
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(10);
        bowlingGame.Bowl(0);
        bowlingGame.Bowl(0);
        Assert.AreEqual(60, bowlingGame.Score());
    }

    [TestMethod]
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

        Assert.AreEqual(300, bowlingGame.Score());
    }

    [TestMethod]
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

        Assert.AreEqual(299, bowlingGame.Score());
    }

    [TestMethod]
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

        Assert.AreEqual(187, bowlingGame.Score());
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
