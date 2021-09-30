const Hiker = require('./hiker');

describe('Full game can be scored correctly.', () => {
    test('all gutters shuold score 0', () => {
        const rolls = [
            0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0,
        ];
        const bowling = new Hiker(rolls);

        actual = bowling.score()

        expect(actual).toEqual(0);
    });

    test('only one pin is knocked down on each roll', () => {
        const rolls = [
            1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1
        ];
        const bowling = new Hiker(rolls);

        actual = bowling.score()

        expect(actual).toEqual(20);
    });

    test('three pins are knocked down on each roll', () => {
        const rolls = [
            3,3, 3,3, 3,3, 3,3, 3,3, 3,3, 3,3, 3,3, 3,3, 3,3,
        ];
        const bowling = new Hiker(rolls);

        actual = bowling.score()

        expect(actual).toEqual(60);
    });

    test('example from README includes extra roll in tenth frame', () => {
        const rolls = [
            10, 9,1, 5,5, 7,2, 10, 10, 10, 9,0, 8,2, 9,1,10,
        ];
        const bowling = new Hiker(rolls);

        actual = bowling.score()

        expect(actual).toEqual(187);
    });

    test('perfect game scores three hundred', () => {
        const rolls = [
            10, 10, 10, 10, 10, 10, 10, 10, 10, 10,10,10
        ];
        const bowling = new Hiker(rolls);

        actual = bowling.score()

        expect(actual).toEqual(300);
    });


});

describe('Partial game can be scored correctly.', () => {
    test('no spare or strike', () => {
        const rolls = [
            1,5, 6,3,
        ];
        const bowling = new Hiker(rolls);

        actual = bowling.score()

        expect(actual).toEqual(15);
    });

    test('spare followed by gutter ball', () => {
        const rolls = [
            7,3, 0,
        ];
        const bowling = new Hiker(rolls);

        actual = bowling.score()

        expect(actual).toEqual(10);
    });

    test('spare has the next roll added to it', () => {
        const rolls = [
            9,1, 4,
        ];
        const bowling = new Hiker(rolls);

        actual = bowling.score()

        expect(actual).toEqual(18);
    });

    test('spares in frames 1 and 2', () => {
        const rolls = [
            7,3, 9,1, 9,
        ];
        const bowling = new Hiker(rolls);

        actual = bowling.score()

        expect(actual).toEqual(47);
    });

    test('strike in first frame followed by gutter balls', () => {
        const rolls = [
            10, 0,0,
        ];
        const bowling = new Hiker(rolls);

        actual = bowling.score()

        expect(actual).toEqual(10);
    });

    test('strike in first frame has next two rolls added to it', () => {
        const rolls = [
            10, 7,2,
        ];
        const bowling = new Hiker(rolls);

        actual = bowling.score()

        expect(actual).toEqual(28);
    });

    test('strike in second frame has rolls from frame 3 added to it', () => {
        const rolls = [
            6,3, 10, 7,2,
        ];
        const bowling = new Hiker(rolls);

        actual = bowling.score()

        expect(actual).toEqual(37);
    });

    test('three strikes in a row is a turkey', () => {
        const rolls = [
            10, 10, 10, 0,0,
        ];
        const bowling = new Hiker(rolls);

        actual = bowling.score()

        expect(actual).toEqual(60);
    });


    // CONTINUE WITH STRIKE TESTS AND THEN FULL GAMES
});
