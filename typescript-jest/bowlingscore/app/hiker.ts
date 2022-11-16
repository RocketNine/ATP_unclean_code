export class Hiker {
  private r: any;   //TODO - what type is this?

  constructor(rolls: any) {
    this.r = rolls;
    let r2: number[] = [];

    // for (const value of this.r) {
    //     if (value == 10)
    //         this.r2.concat(0);
    //     this.r2.concat(value)
    // }
    //

    for (let i = 0; i < this.r.length; i++) {
      if (this.r[i] == 10) {
        r2.push(0);
      }
      r2.push(this.r[i]);
    }
    this.r = r2;
  }

  score() {
    let y = 0;

    for (let i = 0; i < this.r.length; i++) {
      if (this.r[i] != 10) {
        if ((i > 0) && (i % 2 == 1)) {
          let y2 = this.r[i] + this.r[i - 1];
          if (y2 == 10) {
            y += this.r[i + 1];
          }
        }
      } else if (this.r[i] == 10) {

        if (i <= 17) {
          if (this.r[i + 2] != 10) {
            y += this.r[i + 1];
            y += this.r[i + 2];
          } else {
            y += this.r[i + 2];
            if (this.r[i + 4] < 10) {
              y += this.r[i + 3];
            } else {
              y += this.r[i + 4];
            }
          }
        } else {
          if (i == 18) {
            //RF13213 - Lead says this code isn't needed
            if (this.r[i + 2] != 10) {
              y += this.r[i + 1];
              y += this.r[i + 2];
            } else {
              y += this.r[i + 2];
              y += this.r[i + 3];
            }
          } else {
            if (i === 21) {
              if (this.r[i] == 10)
                y += this.r[i];
              if (this.r[i+1] < 10) {
                y +=  this.r[i+1];
              }
            } else if (i === 23) {
              y += this.r[i];
            }
            // y += this.r[i];
            // y += this.rolls[i + 2]
            // y += 10
            //#            else
            //#              y += self.rolls[i + 1];
            //#              y += self.rolls[i + 2];
          }
        }
        //              if(this.y2 == 10)
        //              y = this.rolls[i + 1];

      }
      if (i < 20) {
        y += this.r[i];
      }
    }
    return y;
  }
}
