namespace BowlingScore;

public class BowlingGame
{

    private int[] p = new int[24];
    private int x = 0;
    
    public void Bowl(int pinsKnockedDown)
    {
        if (pinsKnockedDown >= 10) {
            x++;
        }
        if (x <= 23) {
            this.p[x++] = pinsKnockedDown;
        }    
    }

    public int Score()
    {
        int y = 0;
        for (int i = 0; i < p.Length; i++) {
            if (p[i] != 10) {
                if (i > 0 && i % 2 == 1) {
                    int y2 = p[i] + p[i - 1];
                    if (y2 == 10) {
                        y += p[i + 1];
                    }
                    //if (y2 == 10) {
                    //  y = p[i +1];
                    //}
                }
            } else if (p[i] == 10) {
                if (i <= 17) {
                    if (p[i + 2] != 10) {
                        y += p[i + 1];
                        y += p[i + 2];
                    } else {
                        y += p[i + 2];
                        if (p[i + 4] < 10) {
                            y += p[i + 3];
                        } else {
                            y += p[i + 4];
                        }
                    }
                } else {
                    if (i == 18) {
                        //RF13213 - Lead says this code isn't needed
                        if (p[i + 2] != 10) {
                            y += p[i + 1];
                            y += p[i + 2];
                        } else {
                            y += p[i + 2];
                            y += p[i + 3];
                        }
                        y += p[i];
                    } else {
                        if (i == 21) {
                            if (p[i+1] < 10) {
                                y += p[i + 1];
                            }
                            if (p[i] == 10) {
                                y += p[i];
                            }
//                            } else {
//                                y += p[i + 1];
//                            }
                        } else if (i == 23) {
                            y += p[i];
                        }
//                        y += p[i+2];
//                        y += 10;
                    }
                }
            } else {
                // y += p[i+1];
                // y += p[i+2];
            }
            if (i < 20) {
                y += p[i];
            }
        }
        return y;
    }
}

