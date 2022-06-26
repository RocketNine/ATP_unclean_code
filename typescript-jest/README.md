# Bowling Game Refactoring Kata

<img src="http://www.wpclipart.com/recreation/sports/bowling/bowling_scoresheet_example.png"> 

The bowlingGame consists of 10 frames. In each frame the player has two rolls to knock down 10 pins. The score for the frame is the total number of pins knocked down, plus bonuses for strikes and spares.

A spare is when the player knocks down all 10 pins in two rolls. The bonus for that frame is the number of pins knocked down by the next roll. So in frame 2 above, the score is 10 (the total number knocked down) plus a bonus of 5 (the number of pins knocked down on the next roll.)

A strike is when the player knocks down all 10 pins on the first roll. The bonus for that frame is the value of the next two balls rolled.

In the tenth frame a player who rolls a spare or strike is allowed to roll the extra balls to complete the frame. However no more than three balls can be rolled in tenth frame.

The game score is the total of all frame scores.

You are supplied with a number of tests that demonstrate scoring of games. Some are complete games, some are partial.

There is an implementation that passes all tests. Your job is to make the code more understandable and maintainable.

## Getting started

Install dependencies

```sh
npm install
```

## Running tests

To run all tests

### Jest way

```sh
npm run test:jest
```

To run all tests in watch mode

```sh
npm run test:jest:watch
```
