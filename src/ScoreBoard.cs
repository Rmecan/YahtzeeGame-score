namespace YahtzeeGame {
    /// <summary>
    /// 現在の得点を記録しておくクラス
    /// </summary>
    class ScoreBoard {
        // 各役の得点を格納するプロパティ
        public int Ace {set; get;} = 0;
        public int Duo {set; get;} = 0;
        public int Tray {set; get;} = 0;
        public int Four {set; get;} = 0;
        public int Five {set; get;} = 0;
        public int Six {set; get;} = 0;
        public int Choice {set; get;} = 0;
        public int FourDice {set; get;} = 0;
        public int FullHouse {set; get;} = 0;
        public int SmallStraight {set; get;} = 0;
        public int BigStraight {set; get;} = 0;
        public int Yahtzee {set; get;} = 0;
        
        // ボーナス（Ace, Duo, Tray, Four, Five, Sixの合計が63点以上ならボーナス35点）
        public int Bonus
        {
            get
            {
                return (Ace + Duo + Tray + Four + Five + Six >= 63) ? 35 : 0;
            }
        }

        // 合計得点
        public int TotalScore
        {
            get
            {
                // 各役の得点の合計 + ボーナス
                return Ace + Duo + Tray + Four + Five + Six
                       + Choice + FourDice + FullHouse + SmallStraight + BigStraight + Yahtzee + Bonus;
            }
        }
    }
}
