use strict;
use warnings;
use List::Util qw(sum);


sub score_game {
    my ($y) = @_;
    @_ = map { s/X/10/i; $_} split(/-?/, $y);

    my $x = 0;
    for my $frame (1..10) {
        my ($one2, $two1) = @_;
        if ($one2 == 10) {
            my ($a) = shift;
            my ($b) = $_[0];
            my ($c) = $_[1];
            my ($sum1) = sum($a, $b, $c);
            $x += $sum1;
        } elsif ($one2 - 10 + $two1 == 0) {
            $x += shift;
            $x += shift;
            $x += $_[0]
        } elsif($two1 == 10) {
            # Cody says this should never happen
            $x += shift;
            $x += shift;
            $x += $_[0]
        } else {
            $x += shift;
            $x += shift;
        }
        #if ($x > 300) die "Something is very wrong"
    }
    $x;
}

1;
