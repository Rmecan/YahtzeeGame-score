using System;

namespace YahtzeeGame {
    class Program {
        static void Main(string[] args) {

            // ゲームの説明
            Console.WriteLine("ようこそ！");
            Console.WriteLine("サイコロ(5D6)を振り、各役に対する得点を計算します。");

            // ゲームの進行
            bool isGameOver = false;
            int turnCount = 1;
            ScoreBoard scoreBoard = new ScoreBoard(); // スコアボードのインスタンス作成

            while (true) {
                Console.WriteLine($"{turnCount++}目");
                // サイコロを振る
                int[] dice = RollDice();
                Console.WriteLine($"サイコロの出目: {string.Join(", ", dice)}");

                // 得点計算
                ScoreCalculate score = ScoreCalculate.DoCalculate(dice);

                // 各役の得点表示
                Console.WriteLine($"～獲得可能な点数～");
                Console.WriteLine($"1  : エース------> {score.Ace}");
                Console.WriteLine($"2  : デュオ------> {score.Duo}");
                Console.WriteLine($"3  : トレイ------> {score.Tray}");
                Console.WriteLine($"4  : フォー------> {score.Four}");
                Console.WriteLine($"5  : ファイブ----> {score.Five}");
                Console.WriteLine($"6  : シックス----> {score.Six}");
                Console.WriteLine($"7  : チョイス----> {score.Choice}");
                Console.WriteLine($"8  : フォーダイス-> {score.FourDice}");
                Console.WriteLine($"9  : フルハウス---> {score.FullHouse}");
                Console.WriteLine($"10 :S.ストレート--> {score.SmallStraight}");
                Console.WriteLine($"11 :B.ストレート--> {score.BigStraight}");
                Console.WriteLine($"12 :ヨット--------> {score.Yahtzee}");

                // 役の選択
                bool isInvalid = false;  // 無効な選択肢があったかどうかをチェック
                int roleChoice = 0;
                do {
                    Console.WriteLine("\nどの役に得点を追加しますか(1～12)？＞");
                    if (!int.TryParse(Console.ReadLine(), out roleChoice) || roleChoice < 1 || roleChoice > 12) {
                        Console.WriteLine("無効な選択肢です。もう一度入力してください。");
                        isInvalid = true;
                    } else {
                        isInvalid = false;  // 有効な入力がされた場合はフラグをリセット
                        // 得点追加処理
                        switch (roleChoice) {
                            case 1: scoreBoard.Ace = score.Ace; break;
                            case 2: scoreBoard.Duo = score.Duo; break;
                            case 3: scoreBoard.Tray = score.Tray; break;
                            case 4: scoreBoard.Four = score.Four; break;
                            case 5: scoreBoard.Five = score.Five; break;
                            case 6: scoreBoard.Six = score.Six; break;
                            case 7: scoreBoard.Choice = score.Choice; break;
                            case 8: scoreBoard.FourDice = score.FourDice; break;
                            case 9: scoreBoard.FullHouse = score.FullHouse; break;
                            case 10: scoreBoard.SmallStraight = score.SmallStraight; break;
                            case 11: scoreBoard.BigStraight = score.BigStraight; break;
                            case 12: scoreBoard.Yahtzee = score.Yahtzee; break;
                        }
                    }
                } while (isInvalid);

                // 合計得点表示
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

                // ゲーム終了確認
                Console.WriteLine("ゲームを続けますか？ (y/n)");
                string continueGame = Console.ReadLine().ToLower();
                if (continueGame != "y") {
                    isGameOver = true;
                }

                // ゲーム終了判定
                if (turnCount > 12 || isGameOver) {
                    break; // 12ターン以上経過したら終了
                }
            }

            Console.WriteLine("\nゲーム終了！最終得点:");
            Console.WriteLine($"最終得点: {scoreBoard.TotalScore}");
            Console.WriteLine("ありがとうございました！");
        }

        // 5D6を振るメソッド
        static int[] RollDice() {
            Random random = new Random();
            int[] dice = new int[5]; // 5個のサイコロ
            for (int i = 0; i < 5; i++) {
                dice[i] = random.Next(1, 7); // 1から6のランダムな値を設定
            }
            return dice;
        }
    }
}