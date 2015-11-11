using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TetrisCS.GameEngine;
using TetrisCS.Managers;
using TetrisCS.Utils;

namespace TetrisCS.Windows
{
    internal partial class GameOverWindow : Window<WindowId>
    {
        private Bitmap _gameOverImage;
        private Font _font;
        public override WindowId Id => WindowId.GameOver;
        private ScoreManager _scoreManager;

        public GameOverWindow(Engine<WindowId> engine) : base(engine)
        {
            InitializeComponent();

            InitializeWindow += GameOverWindow_InitializeWindow;
            EnterWindow += GameOverWindow_EnterWindow;
        }

        private void GameOverWindow_EnterWindow(object sender, EventArgs e)
        {
            _scoreManager = ((EnterWindowEventArgs) e).ScoreManager;
        }

        private void GameOverWindow_InitializeWindow(object sender, EventArgs e)
        {
            _gameOverImage = new Bitmap("assets/game_over.png");
            _font = new Font("Courier New", 12);
        }


        public override void RenderWindow(Graphics g)
        {
            var w = int.Parse(ConfigurationManager.AppSettings["Width"]);
            var h = int.Parse(ConfigurationManager.AppSettings["Height"]);
            g.FillRectangle(Brushes.Black, 0, 0, w, h);
            g.DrawImage(_gameOverImage, 300, 50, 400, 80);
            g.FillRectangle(Brushes.Blue, w / 2 - 100, h / 2 - 140, 200, 300);
            g.DrawString("Highscores: ", _font, Brushes.Yellow, w / 2 - 70, h / 2 - 120);
            var i = 0;
            _scoreManager?.Highscores.Value.ForEach(score => g.DrawString("#" + ++i + ". " + score, _font, Brushes.Yellow, w / 2 - 40, h / 2 - 90 + i * 20));
        }

        public override void UpdateWindow(int delta)
        {

        }
    }
}
