class Hiker(object):

    def __init__(self, rolls):
        self.r = rolls
        self.r2 = []
        for i in range(0, len(self.r)):
            if self.r[i] == 10:
                self.r2.append(0)
            self.r2.append(self.r[i])
        self.r = self.r2

    def score(self):
        y = 0
        for i in range(0, len(self.r)):
            if self.r[i] != 10:
                if i > 0 and i % 2 == 1:
                    y2 = self.r[i] + self.r[i - 1]
                    if y2 == 10:
                        y += self.r[i + 1]
            #               if (y2 == 10) {
            #               y = self.rolls[i +1];
            elif self.r[i] == 10:
                if i <= 16:
                    if self.r[i + 2] != 10:
                        y += self.r[i + 1]
                        y += self.r[i + 2]
                    else:
                        y += self.r[i + 2]
                        if self.r[i + 4] < 10:
                            y += self.r[i + 3]
                        else:
                            y += self.r[i + 4]
                else:
                    if i == 17:
                        if self.r[i + 2] != 10:
                            y += self.r[i + 1]
                            y += self.r[i + 2]
                        else:
                            y += self.r[i + 2]
                            y += self.r[i + 3]
                    else:
                        y += self.r[i]
                        # y += self.rolls[i+2]
                        # y += 10
            #            else:
            #              y += self.rolls[i+1];
            #              y += self.rolls[i+2];
            if i < 20:
                y += self.r[i]

        return y