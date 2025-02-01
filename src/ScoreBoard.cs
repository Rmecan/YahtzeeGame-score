namespace YahtzeeGame {
    /// <summary>
    /// 現在の得点を記録しておくクラス
    /// </summary>
    class ScoreBoard {
        // 各役の得点を格納するプロパティ
        private int ace;
        private bool aceToken = false;

        private int duo;
        private bool duoToken = false;

        private int tray;
        private bool trayToken = false;

        private int four;
        private bool fourToken = false;

        private int five;
        private bool fiveToken = false;

        private int six;
        private bool sixToken = false;

        private int choice;
        private bool choiceToken = false;

        private int fourDice;
        private bool fourDiceToken = false;

        private int fullHouse;
        private bool fullHouseToken = false;

        private int smallStraight;
        private bool smallStraightToken = false;

        private int bigStraight;
        private bool bigStraightToken = false;

        private int yahtzee;
        private bool yahtzeeToken = false;

        // 各得点のプロパティ
        public int Ace {
            get { return ace; }
            set {
                if (!aceToken) {
                    ace = value;
                    aceToken = true;
                } else {
                    Console.WriteLine("Aceの得点は一度設定されたら変更できません。");
                }
            }
        }

        public int Duo {
            get { return duo; }
            set {
                if (!duoToken) {
                    duo = value;
                    duoToken = true;
                } else {
                    Console.WriteLine("Duoの得点は一度設定されたら変更できません。");
                }
            }
        }

        public int Tray {
            get { return tray; }
            set {
                if (!trayToken) {
                    tray = value;
                    trayToken = true;
                } else {
                    Console.WriteLine("Trayの得点は一度設定されたら変更できません。");
                }
            }
        }

        public int Four {
            get { return four; }
            set {
                if (!fourToken) {
                    four = value;
                    fourToken = true;
                } else {
                    Console.WriteLine("Fourの得点は一度設定されたら変更できません。");
                }
            }
        }

        public int Five {
            get { return five; }
            set {
                if (!fiveToken) {
                    five = value;
                    fiveToken = true;
                } else {
                    Console.WriteLine("Fiveの得点は一度設定されたら変更できません。");
                }
            }
        }

        public int Six {
            get { return six; }
            set {
                if (!sixToken) {
                    six = value;
                    sixToken = true;
                } else {
                    Console.WriteLine("Sixの得点は一度設定されたら変更できません。");
                }
            }
        }

        public int Choice {
            get { return choice; }
            set {
                if (!choiceToken) {
                    choice = value;
                    choiceToken = true;
                } else {
                    Console.WriteLine("Choiceの得点は一度設定されたら変更できません。");
                }
            }
        }

        public int FourDice {
            get { return fourDice; }
            set {
                if (!fourDiceToken) {
                    fourDice = value;
                    fourDiceToken = true;
                } else {
                    Console.WriteLine("FourDiceの得点は一度設定されたら変更できません。");
                }
            }
        }

        public int FullHouse {
            get { return fullHouse; }
            set {
                if (!fullHouseToken) {
                    fullHouse = value;
                    fullHouseToken = true;
                } else {
                    Console.WriteLine("FullHouseの得点は一度設定されたら変更できません。");
                }
            }
        }

        public int SmallStraight {
            get { return smallStraight; }
            set {
                if (!smallStraightToken) {
                    smallStraight = value;
                    smallStraightToken = true;
                } else {
                    Console.WriteLine("SmallStraightの得点は一度設定されたら変更できません。");
                }
            }
        }

        public int BigStraight {
            get { return bigStraight; }
            set {
                if (!bigStraightToken) {
                    bigStraight = value;
                    bigStraightToken = true;
                } else {
                    Console.WriteLine("BigStraightの得点は一度設定されたら変更できません。");
                }
            }
        }

        public int Yahtzee {
            get { return yahtzee; }
            set {
                if (!yahtzeeToken) {
                    yahtzee = value;
                    yahtzeeToken = true;
                } else {
                    Console.WriteLine("Yahtzeeの得点は一度設定されたら変更できません。");
                }
            }
        }
        
        // ボーナス（Ace, Duo, Tray, Four, Five, Sixの合計が63点以上ならボーナス35点）
        public int Bonus => (Ace + Duo + Tray + Four + Five + Six >= 63) ? 35 : 0;

        // 合計得点（各役の得点の合計 + ボーナス）
        public int TotalScore => Ace + Duo + Tray + Four + Five + Six + Choice + FourDice + FullHouse + SmallStraight + BigStraight + Yahtzee + Bonus;
    }
}
