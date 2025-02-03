namespace YahtzeeGame
{
    class Program
    {
        static void Main(string[] args)
        {

            // ゲームの説明
            Console.WriteLine("ようこそ！");
            Console.WriteLine("サイコロ(5D6)を振り、各役に対する得点を計算します。");

            // ゲームの進行
            bool isGameOver = false;
            int turnCount = 1;
            ScoreBoard scoreBoard = new(); // スコアボードのインスタンス作成

            while (true)
            {
                // ターン数の表示
                Console.WriteLine($"{turnCount++}ターン目");

                // サイコロ(5D6)を振る
                int[] dice = RollDice();
                Console.WriteLine($"サイコロ(5D6)の出目: {string.Join(", ", dice)}");

                // 点数計算
                ScoreCalculate score = ScoreCalculate.DoCalculate(dice);

                // 各役の点数表示
                Console.WriteLine("～獲得可能な点数～");
                DisplayAvailableRoles(score, scoreBoard);

                // 役の選択
                bool isInvalid;
                do
                {
                    Console.WriteLine("\nどの役に得点を追加しますか(1～12)？＞");
                    if (!int.TryParse(Console.ReadLine(), out int roleChoice) || roleChoice < 1 || roleChoice > 12)
                    {
                        Console.WriteLine("無効な選択肢です。もう一度入力してください。");
                        isInvalid = true;
                    }
                    else
                    {
                        // すでに得点が設定されている役が選ばれた場合、エラーメッセージを表示
                        // そうでなければ得点を設定
                        isInvalid = !AssignRole(roleChoice, score, scoreBoard);
                    }
                } while (isInvalid);

                // 合計得点表示
                Console.WriteLine("～現在の得点～");
                DisplayScores(scoreBoard);

                // ゲーム終了確認
                Console.WriteLine("ゲームを続けますか？ (y/n)");
                string continueGame = Console.ReadLine().ToLower();
                if (continueGame == "n")
                {
                    isGameOver = true;
                }

                // ゲーム終了判定
                if (turnCount > 12 || isGameOver)
                {
                    break; // 12ターン以上経過したら終了
                }
            }

            Console.WriteLine("\nゲーム終了！最終得点:");
            Console.WriteLine($"最終得点: {scoreBoard.TotalScore}");
            Console.WriteLine("ありがとうございました！");
        }

        // サイコロ(5D6)を振るメソッド
        static int[] RollDice()
        {
            Random random = new();
            int[] dice = new int[5]; // 5個のサイコロ
            for (int i = 0; i < 5; i++)
            {
                dice[i] = random.Next(1, 7); // 1から6のランダムな値を設定
            }
            return dice;
        }

        // 得点を役に追加する処理
        static bool AssignRole(int roleChoice, ScoreCalculate score, ScoreBoard scoreBoard)
        {
            switch (roleChoice)
            {
                case 1: return AssignScore(scoreBoard.Ace, scoreBoard.AceToken, score.Ace);
                case 2: return AssignScore(scoreBoard.Duo, scoreBoard.DuoToken, score.Duo);
                case 3: return AssignScore(scoreBoard.Tray, scoreBoard.TrayToken, score.Tray);
                case 4: return AssignScore(scoreBoard.Four, scoreBoard.FourToken, score.Four);
                case 5: return AssignScore(scoreBoard.Five, scoreBoard.FiveToken, score.Five);
                case 6: return AssignScore(scoreBoard.Six, scoreBoard.SixToken, score.Six);
                case 7: return AssignScore(scoreBoard.Choice, scoreBoard.ChoiceToken, score.Choice);
                case 8: return AssignScore(scoreBoard.FourDice, scoreBoard.FourDiceToken, score.FourDice);
                case 9: return AssignScore(scoreBoard.FullHouse, scoreBoard.FullHouseToken, score.FullHouse);
                case 10: return AssignScore(scoreBoard.SmallStraight, scoreBoard.SmallStraightToken, score.SmallStraight);
                case 11: return AssignScore(scoreBoard.BigStraight, scoreBoard.BigStraightToken, score.BigStraight);
                case 12: return AssignScore(scoreBoard.Yahtzee, scoreBoard.YahtzeeToken, score.Yahtzee);
                default: return false;
            }
        }

        // 役の得点を設定するメソッド
        static bool AssignScore(int score, bool token, int scoreValue)
        {
            if (token)
            {
                Console.WriteLine("この役はすでに選ばれています。");
                return false;
            }
            else
            {
                score = scoreValue;
                return true;
            }
        }

        // 役の点数を表示
        static void DisplayAvailableRoles(ScoreCalculate score, ScoreBoard scoreBoard)
        {
            if (!scoreBoard.AceToken) Console.WriteLine($"1  : エース------> {score.Ace}");
            if (!scoreBoard.DuoToken) Console.WriteLine($"2  : デュオ------> {score.Duo}");
            if (!scoreBoard.TrayToken) Console.WriteLine($"3  : トレイ------> {score.Tray}");
            if (!scoreBoard.FourToken) Console.WriteLine($"4  : フォー------> {score.Four}");
            if (!scoreBoard.FiveToken) Console.WriteLine($"5  : ファイブ----> {score.Five}");
            if (!scoreBoard.SixToken) Console.WriteLine($"6  : シックス----> {score.Six}");
            if (!scoreBoard.ChoiceToken) Console.WriteLine($"7  : チョイス----> {score.Choice}");
            if (!scoreBoard.FourDiceToken) Console.WriteLine($"8  : フォーダイス-> {score.FourDice}");
            if (!scoreBoard.FullHouseToken) Console.WriteLine($"9  : フルハウス---> {score.FullHouse}");
            if (!scoreBoard.SmallStraightToken) Console.WriteLine($"10 : S.ストレート--> {score.SmallStraight}");
            if (!scoreBoard.BigStraightToken) Console.WriteLine($"11 : B.ストレート--> {score.BigStraight}");
            if (!scoreBoard.YahtzeeToken) Console.WriteLine($"12 : ヨット--------> {score.Yahtzee}");
        }

        // 合計得点の表示
        static void DisplayScores(ScoreBoard scoreBoard)
        {
            Console.WriteLine($"エース: {scoreBoard.Ace}");
            Console.WriteLine($"デュオ: {scoreBoard.Duo}");
            Console.WriteLine($"トレイ: {scoreBoard.Tray}");
            Console.WriteLine($"フォー: {scoreBoard.Four}");
            Console.WriteLine($"ファイブ: {scoreBoard.Five}");
            Console.WriteLine($"シックス: {scoreBoard.Six}");
            Console.WriteLine($"-------------------------");
            Console.WriteLine($"ボーナス: {scoreBoard.Bonus}");
            Console.WriteLine($"-------------------------");
            Console.WriteLine($"チョイス: {scoreBoard.Choice}");
            Console.WriteLine($"フォーダイス: {scoreBoard.FourDice}");
            Console.WriteLine($"フルハウス: {scoreBoard.FullHouse}");
            Console.WriteLine($"S.ストレート: {scoreBoard.SmallStraight}");
            Console.WriteLine($"B.ストレート: {scoreBoard.BigStraight}");
            Console.WriteLine($"ヨット: {scoreBoard.Yahtzee}");
            Console.WriteLine($"=========================");
            Console.WriteLine($"合計得点: {scoreBoard.TotalScore}");
        }
    }
}
