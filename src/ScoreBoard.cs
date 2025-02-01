namespace YahtzeeGame
{
    /// <summary>
    /// 現在の得点を記録しておくクラス
    /// </summary>
    class ScoreBoard
    {
        // 各役の得点を格納するフィールド
        private int _ace;
        private bool _aceToken = false;

        private int _duo;
        private bool _duoToken = false;

        private int _tray;
        private bool _trayToken = false;

        private int _four;
        private bool _fourToken = false;

        private int _five;
        private bool _fiveToken = false;

        private int _six;
        private bool _sixToken = false;

        private int _choice;
        private bool _choiceToken = false;

        private int _fourDice;
        private bool _fourDiceToken = false;

        private int _fullHouse;
        private bool _fullHouseToken = false;

        private int _smallStraight;
        private bool _smallStraightToken = false;

        private int _bigStraight;
        private bool _bigStraightToken = false;

        private int _yahtzee;
        private bool _yahtzeeToken = false;

        // 各得点のプロパティ
        public int Ace
        {
            get { return _ace; }
            set
            {
                if (!_aceToken)
                {
                    _ace = value;
                    _aceToken = true;
                }
                else
                {
                    Console.WriteLine("Aceの得点は一度設定されたら変更できません。");
                }
            }
        }

        public int Duo
        {
            get { return _duo; }
            set
            {
                if (!_duoToken)
                {
                    _duo = value;
                    _duoToken = true;
                }
                else
                {
                    Console.WriteLine("Duoの得点は一度設定されたら変更できません。");
                }
            }
        }

        public int Tray
        {
            get { return _tray; }
            set
            {
                if (!_trayToken)
                {
                    _tray = value;
                    _trayToken = true;
                }
                else
                {
                    Console.WriteLine("Trayの得点は一度設定されたら変更できません。");
                }
            }
        }

        public int Four
        {
            get { return _four; }
            set
            {
                if (!_fourToken)
                {
                    _four = value;
                    _fourToken = true;
                }
                else
                {
                    Console.WriteLine("Fourの得点は一度設定されたら変更できません。");
                }
            }
        }

        public int Five
        {
            get { return _five; }
            set
            {
                if (!_fiveToken)
                {
                    _five = value;
                    _fiveToken = true;
                }
                else
                {
                    Console.WriteLine("Fiveの得点は一度設定されたら変更できません。");
                }
            }
        }

        public int Six
        {
            get { return _six; }
            set
            {
                if (!_sixToken)
                {
                    _six = value;
                    _sixToken = true;
                }
                else
                {
                    Console.WriteLine("Sixの得点は一度設定されたら変更できません。");
                }
            }
        }

        public int Choice
        {
            get { return _choice; }
            set
            {
                if (!_choiceToken)
                {
                    _choice = value;
                    _choiceToken = true;
                }
                else
                {
                    Console.WriteLine("Choiceの得点は一度設定されたら変更できません。");
                }
            }
        }

        public int FourDice
        {
            get { return _fourDice; }
            set
            {
                if (!_fourDiceToken)
                {
                    _fourDice = value;
                    _fourDiceToken = true;
                }
                else
                {
                    Console.WriteLine("FourDiceの得点は一度設定されたら変更できません。");
                }
            }
        }

        public int FullHouse
        {
            get { return _fullHouse; }
            set
            {
                if (!_fullHouseToken)
                {
                    _fullHouse = value;
                    _fullHouseToken = true;
                }
                else
                {
                    Console.WriteLine("FullHouseの得点は一度設定されたら変更できません。");
                }
            }
        }

        public int SmallStraight
        {
            get { return _smallStraight; }
            set
            {
                if (!_smallStraightToken)
                {
                    _smallStraight = value;
                    _smallStraightToken = true;
                }
                else
                {
                    Console.WriteLine("SmallStraightの得点は一度設定されたら変更できません。");
                }
            }
        }

        public int BigStraight
        {
            get { return _bigStraight; }
            set
            {
                if (!_bigStraightToken)
                {
                    _bigStraight = value;
                    _bigStraightToken = true;
                }
                else
                {
                    Console.WriteLine("BigStraightの得点は一度設定されたら変更できません。");
                }
            }
        }

        public int Yahtzee
        {
            get { return _yahtzee; }
            set
            {
                if (!_yahtzeeToken)
                {
                    _yahtzee = value;
                    _yahtzeeToken = true;
                }
                else
                {
                    Console.WriteLine("Yahtzeeの得点は一度設定されたら変更できません。");
                }
            }
        }

        // Tokenプロパティを外部から読み取れるようにする
        public bool AceToken => _aceToken;
        public bool DuoToken => _duoToken;
        public bool TrayToken => _trayToken;
        public bool FourToken => _fourToken;
        public bool FiveToken => _fiveToken;
        public bool SixToken => _sixToken;
        public bool ChoiceToken => _choiceToken;
        public bool FourDiceToken => _fourDiceToken;
        public bool FullHouseToken => _fullHouseToken;
        public bool SmallStraightToken => _smallStraightToken;
        public bool BigStraightToken => _bigStraightToken;
        public bool YahtzeeToken => _yahtzeeToken;

        // ボーナス（Ace, Duo, Tray, Four, Five, Sixの合計が63点以上ならボーナス35点）
        public int Bonus => (_ace + _duo + _tray + _four + _five + _six >= 63) ? 35 : 0;

        // 合計得点（各役の得点の合計 + ボーナス）
        public int TotalScore => _ace + _duo + _tray + _four + _five + _six + _choice + _fourDice + _fullHouse + _smallStraight + _bigStraight + _yahtzee + Bonus;
    }
}
