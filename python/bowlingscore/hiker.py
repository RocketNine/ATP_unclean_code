class Hiker(object):

    def __init__(self, rolls):
        self.rolls = rolls

    def score(self):

        y = 0

        for i in range(0, len(self.rolls)):
            if self.rolls[i] != 10:
                if i > 0 and i % 2 == 1:
                    y2 = self.rolls[i] + self.rolls[i - 1]
                    if y2 == 10:
                        y += self.rolls[i + 1]
            #               if (y2 == 10) {
            #               y = self.rolls[i +1];
            elif self.rolls[i] == 10:
                if i <= 16:
                    if self.rolls[i + 2] != 10:
                        y += self.rolls[i + 1]
                        y += self.rolls[i + 2]
                    else:
                        y += self.rolls[i + 2]
                        if self.rolls[i + 4] < 10:
                            y += self.rolls[i + 3]
                        else:
                            y += self.rolls[i + 4]
                else:
                    if i == 17:
                        if self.rolls[i + 2] != 10:
                            y += self.rolls[i + 1]
                            y += self.rolls[i + 2]
                        else:
                            y += self.rolls[i + 2]
                            y += self.rolls[i + 3]
                    else:
                        y += self.rolls[i]
                        # y += self.rolls[i+2]
                        # y += 10
            #            else:
            #              y += self.rolls[i+1];
            #              y += self.rolls[i+2];
            y += self.rolls[i]

        return y
