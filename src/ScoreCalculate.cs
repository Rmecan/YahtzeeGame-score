using System;
using System.Linq;

namespace YahtzeeGame {
    /// <summary>
    /// ダイスの出目に応じた点数計算
    /// </summary>    
    class ScoreCalculate
    {
        public int Ace { get; private set; } = 0;
        public int Duo { get; private set; } = 0;
        public int Tray { get; private set; } = 0;
        public int Four { get; private set; } = 0;
        public int Five { get; private set; } = 0;
        public int Six { get; private set; } = 0;
        public int Choice { get; private set; } = 0;
        public int FourDice { get; private set; } = 0;
        public int FullHouse { get; private set; } = 0;
        public int SmallStraight { get; private set; } = 0;
        public int BigStraight { get; private set; } = 0;
        public int Yahtzee { get; private set; } = 0;

        // サイコロの結果を渡して点数を計算するメソッド
        public static ScoreCalculate DoCalculate(int[] dice)
        {
            if (dice == null || dice.Length != 5)
            {
                throw new ArgumentException("サイコロの数は5つである必要があります。");
            }

            ScoreCalculate score = new ScoreCalculate();
            
            // Ace(1の目)の点数計算
            score.Ace = score.CalcCategory(dice, 1);
            // Duo(2の目)の点数計算
            score.Duo = score.CalcCategory(dice, 2);
            // Tray(3の目)の点数計算
            score.Tray = score.CalcCategory(dice, 3);
            // Four(4の目)の点数計算
            score.Four = score.CalcCategory(dice, 4);
            // Five(5の目)の点数計算
            score.Five = score.CalcCategory(dice, 5);
            // Six(6の目)の点数計算
            score.Six = score.CalcCategory(dice, 6);
            // チョイスの点数計算
            score.Choice = score.CalcChoice(dice);
            // フォーダイスの点数計算
            score.FourDice = score.CalcFourDice(dice);
            // フルハウスの点数計算
            score.FullHouse = score.CalcFullHouse(dice);
            // S.ストレートの点数計算
            score.SmallStraight = score.CalcSmallStraight(dice);
            // B.ストレートの点数計算
            score.BigStraight = score.CalcBigStraight(dice);
            // ヨットの点数計算
            score.Yahtzee = score.CalcYahtzee(dice);

            return score;
        }

        // Ace, Duo, Tray, Four, Five, Sixの計算：該当の目の合計を返す
        private int CalcCategory(int[] dice, int category)
        {
            return dice.Count(d => d == category) * category;
        }

        // チョイスの計算：サイコロの目の合計を返す
        private int CalcChoice(int[] dice)
        {
            return dice.Sum();
        }

        // フォーダイスの計算：同じ目が4つならその合計を返す
        private int CalcFourDice(int[] dice)
        {
            var grouped = dice.GroupBy(d => d).Where(g => g.Count() >= 4).FirstOrDefault();
            if (grouped != null)
            {
                return grouped.Key * 4;
            }
            return 0;
        }

        // フルハウスの計算：3つ同じ目と2つ同じ目の組み合わせ
        private int CalcFullHouse(int[] dice)
        {
            var grouped = dice.GroupBy(d => d).Select(g => g.Count()).OrderBy(c => c).ToList();
            if (grouped.Count == 2 && grouped[0] == 2 && grouped[1] == 3)
            {
                return 25; // フルハウスが成立していれば25点
            }
            return 0;
        }

        // スモールストレートの計算：4つ連続した目（例：1,2,3,4）
        private int CalcSmallStraight(int[] dice)
        {
            var smallStraights = new[] { new[] { 1, 2, 3, 4 }, new[] { 2, 3, 4, 5 }, new[] { 3, 4, 5, 6 } };
            var uniqueDice = dice.Distinct().ToArray();
            
            foreach (var straight in smallStraights)
            {
                if (straight.All(s => uniqueDice.Contains(s)))
                {
                    return 30; // スモールストレートが成立していれば30点
                }
            }
            return 0;
        }

        // ビッグストレートの計算：5つ連続した目（例：1,2,3,4,5）
        private int CalcBigStraight(int[] dice)
        {
            var bigStraights = new[] { new[] { 1, 2, 3, 4, 5 }, new[] { 2, 3, 4, 5, 6 } };
            var uniqueDice = dice.Distinct().ToArray();

            foreach (var straight in bigStraights)
            {
                if (straight.All(s => uniqueDice.Contains(s)))
                {
                    return 40; // ビッグストレートが成立していれば40点
                }
            }
            return 0;
        }

        // ヨットの計算：すべて同じ目（例：1,1,1,1,1）
        private int CalcYahtzee(int[] dice)
        {
            if (dice.Distinct().Count() == 1)
            {
                return 50;
            }
            return 0;
        }
    }
}
