"use strict";

class Hiker {

    constructor(rolls) {
        this.r = rolls;
        this.r2 = [];

        // for (const value of this.r) {
        //     if (value == 10)
        //         this.r2.concat(0);
        //     this.r2.concat(value)
        // }
        //

        for (let i = 0; i < this.r.length; i++) {
            if (this.r[i] == 10) {
                this.r2.push(0);
            }
            this.r2.push(this.r[i]);
        }
        this.r = this.r2;
    }

    score() {
        this.y = 0;

        for (let i = 0; i < this.r.length; i++) {
            if (this.r[i] != 10) {
                if ((i > 0) && (i % 2 == 1)) {
                    this.y2 = this.r[i] + this.r[i - 1];
                    if (this.y2 == 10) {
                        this.y += this.r[i + 1];
                    }
                }
            } else if (this.r[i] == 10) {

                if (i <= 16) {
                    if (this.r[i + 2] != 10) {
                        this.y += this.r[i + 1];
                        this.y += this.r[i + 2];
                    } else {
                        this.y += this.r[i + 2];
                        if (this.r[i + 4] < 10) {
                            this.y += this.r[i + 3];
                        } else {
                            this.y += this.r[i + 4];
                        }
                    }
                } else {
                    if (i == 17) {
                        if (this.r[i + 2] != 10) {
                            this.y += this.r[i + 1];
                            this.y += this.r[i + 2];
                        } else {
                            this.y += this.r[i + 2];
                            this.y += this.r[i + 3];
                        }
                    } else {
                        this.y += this.r[i];
                        // y += this.rolls[i + 2]
                        // y += 10
                        //#            else
                        //#              y += self.rolls[i + 1];
                        //#              y += self.rolls[i + 2];
                    }
                }
                //              if(this.y2 == 10)
                //              this.y = this.rolls[i + 1];
            }
            if (i < 20) {
                this.y += this.r[i];
            }
        }
        return this.y;
    }
}

module.exports = Hiker;
