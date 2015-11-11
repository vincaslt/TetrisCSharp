using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace TetrisCS.Managers
{
    public class ScoreManager
    {
        public int Score { get; private set; }
        public Lazy<List<int>> Highscores { get; } = new Lazy<List<int>>(LoadHighscores);

        private const string FileName = "highscores.dat";

        private static List<int> LoadHighscores()
        {
            try
            {
                return File.ReadAllLines(FileName).Select(int.Parse).ToList();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            return new List<int>();
        }

        public void SaveHighScores()
        {
            using (var file = new StreamWriter(FileName, false))
            {
                Highscores.Value.ForEach(score => file.WriteLine(score.ToString()));
            }
        }

        public void AddScore(int rowsRemoved, int level)
        {
            switch (rowsRemoved)
            {
                case 4:
                    Score += 1000;
                    break;
                case 3:
                    Score += 700;
                    break;
                case 2:
                    Score += 300;
                    break;
                case 1:
                    Score += 100;
                    break;
                default:
                    Score += 0;
                    break;
            }
        }

        public void AddHighscore(int score)
        {
            Highscores.Value.Add(score);
            Highscores.Value.Sort((i1, i2) => i2.CompareTo(i1));
            if (Highscores.Value.Count > 10)
            {
                Highscores.Value.RemoveAt(Highscores.Value.Count - 1);
            }
        }
    }
}
