from hiker import Hiker


def test_full_game_all_gutter_balls():
    rolls = [0, 0,  0, 0,  0, 0,  0, 0,  0, 0,  0, 0,  0, 0,  0, 0,  0, 0,  0, 0]
    sut = Hiker(rolls)
    assert sut.score() == 0


def test_full_game_each_frame_only_one_pin_knocked_down():
    rolls = [1, 1,  1, 1,  1, 1,  1, 1,  1, 1,  1, 1,  1, 1,  1, 1,  1, 1,  1, 1]
    sut = Hiker(rolls)
    assert sut.score() == 20


def test_full_game_each_frame_three_pins_knocked_down():
    rolls = [3, 3,  3, 3,  3, 3,  3, 3,  3, 3,  3, 3,  3, 3,  3, 3,  3, 3,  3, 3]
    sut = Hiker(rolls)
    assert sut.score() == 60


def test_partial_game_no_spare_or_strikes():
    rolls = [1, 5,   6, 3]
    sut = Hiker(rolls)
    assert sut.score() == 15


def test_partial_game_spare_in_first_frame_followed_by_gutter_ball():
    rolls = [7, 3,   0]
    sut = Hiker(rolls)
    assert sut.score() == 10


def test_partial_game_spare_next_roll_is_added_to_spare():
    rolls = [9, 1,   4]
    sut = Hiker(rolls)
    assert sut.score() == 18


def test_partial_game_spares_in_both_frames_1_and_2():
    rolls = [7, 3,  9, 1,   9]
    sut = Hiker(rolls)
    assert sut.score() == 47


def test_partial_game_strike_in_first_frame_followed_by_gutter_balls():
    rolls = [10,  0, 0]
    sut = Hiker(rolls)
    assert sut.score() == 10


def test_partial_game_strike_in_first_frame_next_two_rolls_added_to_strike():
    rolls = [10,  7, 2]
    sut = Hiker(rolls)
    assert sut.score() == 28


def test_partial_game_strike_in_second_frame_rolls_in_frame_3_added_to_strike():
    rolls = [6, 3,  10,  7, 2]
    sut = Hiker(rolls)
    assert sut.score() == 37


def test_partial_game_two_strikes_followed_by_gutter_balls_second_strike_added_to_first_and_counted_on_its_own():
    rolls = [10, 10,  0, 0]
    sut = Hiker(rolls)
    assert sut.score() == 30


def test_partial_game_three_strikes_followed_by_gutter_balls():
    rolls = [10, 10, 10,  0, 0]
    sut = Hiker(rolls)
    assert sut.score() == 60


def test_full_game_perfect_game_scores_300():
    rolls = [10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10]
    sut = Hiker(rolls)
    assert sut.score() == 300


def test_full_game_almost_perfect_game_miss_one_pin_on_last_roll():
    rolls = [10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 9]
    sut = Hiker(rolls)
    assert sut.score() == 299


def test_full_game_example_in_readme():
    rolls = [10,  9, 1,  5, 5,  7, 2,  10, 10, 10,  9, 0,  8, 2,  9, 1, 10]
    sut = Hiker(rolls)
    assert sut.score() == 187
