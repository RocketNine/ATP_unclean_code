use strict;
use warnings 'all';
use Test::Simple tests => 16; # number of tests (max=254)

require "hiker.pl";

ok(   0 == score_game("00-00-00-00-00-00-00-00-00-00"), "All gutter balls has a zero score" );

ok(   1 == score_game("00-00-00-00-00-00-00-00-00-01"), "Exactly one pin at the very end" );

ok(  20 == score_game("11-11-11-11-11-11-11-11-11-11"), "One pin knocked down each roll, just total them" );

ok(  60 == score_game("33-33-33-33-33-33-33-33-33-33"), "Three pins knocked down each roll, just total them" );

ok(  10 == score_game("73-00-00-00-00-00-00-00-00-00"), "Spare with no bonus pins, only count the 10 knocked down" );

ok(  18 == score_game("91-40-00-00-00-00-00-00-00-00"), "Spare with bonus pins, bonus added to spare and counted on its own" );

ok(  47 == score_game("73-91-90-00-00-00-00-00-00-00"), "Two spares in a row" );

ok( 150 == score_game("55-55-55-55-55-55-55-55-55-55-5"), "5 pins every roll - spares in every frame" );

ok(  10 == score_game("X-00-00-00-00-00-00-00-00-00"), "One strike followed by all gutters, scores just hose 10 pins" );

ok(  28 == score_game("X-72-00-00-00-00-00-00-00-00"), "One strike adds the next two rolls, and also counts those two rolls" );

ok(  30 == score_game("X-X-00-00-00-00-00-00-00-00"), "Two strikes followed by gutters, first strike adds second as bonus" );

ok(  60 == score_game("X-X-X-00-00-00-00-00-00-00"), "Turkey followed by gutters" );

ok(  60 == score_game("00-00-00-00-00-00-00-00-X-X-XX"), "Gutters, then strikes at the end" );

ok( 299 == score_game("X-X-X-X-X-X-X-X-X-X-X9"), "Almost perfect game, choked on last roll and left 1 pin standing" );

ok( 300 == score_game("X-X-X-X-X-X-X-X-X-X-XX"), "Perfect game scores 300" );

ok( 187 == score_game("X-91-55-72-X-X-X-90-82-91X"), "Full game example from the readme" );
