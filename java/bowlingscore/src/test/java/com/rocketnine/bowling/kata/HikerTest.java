package com.rocketnine.bowling.kata;

import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.assertEquals;

public class HikerTest {

    @Test
    void fullGame_allGutterBalls() {
        Hiker bowlingGame = new Hiker();
        rollSomeBalls(bowlingGame, 0);
        assertEquals(0, bowlingGame.score());
    }

    @Test
    void fullGame_eachFrame_onlyOnePinKnockedDown() {
        Hiker bowlingGame = new Hiker();
        rollSomeBalls(bowlingGame, 1);
        assertEquals(20, bowlingGame.score());
    }

    @Test
    void fullGame_eachFrame_threePinsKnockedDown() {
        Hiker bowlingGame = new Hiker();
        rollSomeBalls(bowlingGame, 3);
        assertEquals(60, bowlingGame.score());
    }

    @Test
    void partialGame_noSpareOrStrike_differentNumberOfPinsKnockedDownEachRoll() {
        Hiker bowlingGame = new Hiker();
        bowlingGame.bowl(1);
        bowlingGame.bowl(5);
        bowlingGame.bowl(6);
        bowlingGame.bowl(3);
        assertEquals(15, bowlingGame.score());
    }
    @Test
    public void partialGame_spareInFirstFrame_followedByGutterBalls() {
        Hiker bowlingGame = new Hiker();
        bowlingGame.bowl(7);
        bowlingGame.bowl(3);
        bowlingGame.bowl(0);
        assertEquals(10, bowlingGame.score());
    }

    @Test
    void partialGame_spare_nextRollIsAddedToSpare() {
        Hiker bowlingGame = new Hiker();
        bowlingGame.bowl(9);
        bowlingGame.bowl(1);
        bowlingGame.bowl(4);
        assertEquals(18, bowlingGame.score());
    }

    @Test
    void partialGame_spares_inBothFrame1And2() {
        Hiker bowlingGame = new Hiker();
        bowlingGame.bowl(7);
        bowlingGame.bowl(3);
        bowlingGame.bowl(9);
        bowlingGame.bowl(1);
        bowlingGame.bowl(9);
        assertEquals(47, bowlingGame.score());
    }

    @Test
    public void partialGame_strikeInFirstFrame_followedByGutterBalls() {
        Hiker bowlingGame = new Hiker();
        bowlingGame.bowl(10);
        bowlingGame.bowl(0);
        bowlingGame.bowl(0);
        assertEquals(10, bowlingGame.score());
    }

    @Test
    void partialGame_strikeInFirstFrame_nextTwoRollsAddedToStrike() {
        Hiker bowlingGame = new Hiker();
        bowlingGame.bowl(10);
        bowlingGame.bowl(7);
        bowlingGame.bowl(2);
        assertEquals(28, bowlingGame.score());
    }

    @Test
    void partialGame_strikeIn3rdFrame_rollsInFrame4AddedToStrike() {
        Hiker bowlingGame = new Hiker();
        bowlingGame.bowl(6);
        bowlingGame.bowl(3);
        bowlingGame.bowl(10);
        bowlingGame.bowl(7);
        bowlingGame.bowl(2);
        assertEquals(37, bowlingGame.score());
    }

    @Test
    public void partialGame_twoStrikes_FollowedByGutterBalls_SeconStrikeAddedToFirst_andCountedOnItsOwn() {
        Hiker bowlingGame = new Hiker();
        bowlingGame.bowl(10);
        bowlingGame.bowl(10);
        bowlingGame.bowl(0);
        bowlingGame.bowl(0);
        assertEquals(30, bowlingGame.score());
    }

    @Test
    void partialGame_threeStrikes_FollowedByGutterBalls() {
        Hiker bowlingGame = new Hiker();
        bowlingGame.bowl(10);
        bowlingGame.bowl(10);
        bowlingGame.bowl(10);
        bowlingGame.bowl(0);
        bowlingGame.bowl(0);
        assertEquals(60, bowlingGame.score());
    }

    @Test
    void fullGame_PerfectGame() {
        Hiker bowlingGame = new Hiker();
        bowlingGame.bowl(10);
        bowlingGame.bowl(10);
        bowlingGame.bowl(10);
        bowlingGame.bowl(10);
        bowlingGame.bowl(10);
        bowlingGame.bowl(10);
        bowlingGame.bowl(10);
        bowlingGame.bowl(10);
        bowlingGame.bowl(10);
        bowlingGame.bowl(10);
        bowlingGame.bowl(10);
        bowlingGame.bowl(10);

        assertEquals(300, bowlingGame.score());
    }


    private void rollSomeBalls(Hiker bowlingGame, int b) {
        //TODO - doesn't check b is valid
        //TODO - doesn't work when b>=5
        for (int i = 0; i < 10; i++) {
            bowlingGame.bowl(b);
            bowlingGame.bowl(b);
        }
    }
}
