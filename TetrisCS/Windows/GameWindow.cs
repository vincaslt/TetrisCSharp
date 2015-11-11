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
using TetrisCS.GameObjects;
using TetrisCS.Managers;
using TetrisCS.Utils;

namespace TetrisCS.Windows
{
    public partial class GameWindow : Window<WindowId>
    {
        //TODO on game over transition
        public override WindowId Id => WindowId.Game;

        private GameField _gameField;
        private GameManager _gameManager;
        private GraphicsManager _graphicsManager;
        private ScoreManager _scoreManager;
        private InputManager _inputManager;

        public GameWindow(Engine<WindowId> engine) : base(engine)
        {
            InitializeWindow += GameWindow_InitializeWindow;
            EnterWindow += GameWindow_EnterWindow;
        }

        private void GameOver(object sender, EventArgs e)
        {
            Engine.GoToWindow(WindowId.GameOver, new EnterWindowEventArgs(_scoreManager), new EventArgs());
        }

        private void GameWindow_InitializeWindow(object sender, EventArgs e)
        {
            InitializeComponent();
        }

        private void GameWindow_EnterWindow(object sender, EventArgs e)
        {
            _gameField = new GameField(10, 20);
            _scoreManager = new ScoreManager();
            _gameManager = new GameManager(_gameField, _scoreManager, new BlockFactory());
            _graphicsManager = new GraphicsManager(_gameField, _gameManager, _scoreManager);
            _inputManager = new InputManager(_gameField, _gameManager, this);

            _gameManager.SpawnNewBlock();
            _gameManager.GameOver += GameOver;
        }


        public override void RenderWindow(Graphics g)
        {
            var w = int.Parse(ConfigurationManager.AppSettings["Width"]);
            var h = int.Parse(ConfigurationManager.AppSettings["Height"]);
            g.FillRectangle(Brushes.Black, 0, 0, w, h);
            _graphicsManager?.Render(g);
        }

        public override void UpdateWindow(int delta)
        { 
            _gameManager?.Update(delta);
        }
    }
}
