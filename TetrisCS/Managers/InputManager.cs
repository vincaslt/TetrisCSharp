using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TetrisCS.GameObjects;
using TetrisCS.Windows;

namespace TetrisCS.Managers
{
    public class InputManager
    {
        readonly GameField _field;
        readonly GameManager _gameManager;

        public InputManager(GameField field, GameManager gameManager, GameWindow gameWindow)
        {
            _field = field;
            _gameManager = gameManager;

            gameWindow.KeyDown += KeyDown;
            gameWindow.KeyUp += KeyUp;
        }

        public void KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    HandleRotateLeft();
                    break;
                case Keys.NumPad1:
                    HandleRotateRight();
                    break;
                case Keys.Left:
                    HandleMoveLeft();
                    break;
                case Keys.Right:
                    HandleMoveRight();
                    break;
                case Keys.Space:
                    while (_gameManager.TriggerGravity()) { }
                    break;
                case Keys.Down:
                    _gameManager.SpeedUp();
                    break;
            }
        }

        public void KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
                _gameManager.NormalizeSpeed();
        }

        private void HandleMoveLeft()
        {
            _field.ActiveBlock.Translate(-1, 0);
        }

        private void HandleMoveRight()
        {
            _field.ActiveBlock.Translate(1, 0);
        }

        private void HandleRotateLeft()
        {
            _field.ActiveBlock.RotateLeft();
        }

        private void HandleRotateRight()
        {
            _field.ActiveBlock.RotateRight();
        }
    }
}
