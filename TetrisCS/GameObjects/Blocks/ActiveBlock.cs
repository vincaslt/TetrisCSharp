using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisCS.GameEngine.Utils;

namespace TetrisCS.GameObjects.Blocks
{
    public class ActiveBlock
    {
        private int _activeSheet = 0;
        private readonly GameField _gameField;
        public Point Position { get; private set; } // Position on the game field
        public Square[,] ActiveSheet => _block?.GetSheet(_activeSheet);
        private readonly Block _block;

        public ActiveBlock(GameField gameField, Point position, Block block)
        {
            _gameField = gameField;
            Position = position;
            _block = block;
        }

        public void RotateRight()
        {
            Rotate(_activeSheet, _activeSheet < 3 ? _activeSheet + 1 : _activeSheet - 3);
        }

        public void RotateLeft()
        {
            Rotate(_activeSheet, _activeSheet > 0 ? _activeSheet - 1 : _activeSheet + 3);
        }

        /**
         * Rotates the active _block after checking collisions and if needed moves to fit the boundaries.
         * @param field - game field
         * @param from - current _activeSheet id
         * @param to - target _activeSheet id
         */
        private void Rotate(int from, int to)
        {
            var realPosition = new Point(Position);

            _activeSheet = to;
            for (var r = 0; r < 4; r++)
            {
                for (var c = 0; c < 4; c++)
                {
                    if (ActiveSheet[r, c] == null) continue;
                    if ((c + Position.X < 0 && !Translate(1, 0) && !Translate(2, 0)) ||
                        (r + Position.Y >= _gameField.Height && !Translate(0, -1) && !Translate(0, -2)) ||
                        (r + Position.Y < 0 && !Translate(0, 1) && !Translate(0, 2)) ||
                        (c + Position.X >= _gameField.Width && !Translate(-1, 0) && !Translate(-2, 0)) ||
                        (_gameField.Squares[Position.Y + r, Position.X + c] != null && !Translate(-1, 0) &&
                         !Translate(-2, 0) && !Translate(1, 0) && !Translate(2, 0)))
                    {
                        Position = realPosition;
                        _activeSheet = @from;
                        return;
                    }
                }
            }
        }

        public bool Translate(int x, int y)
        {
            if (!TestCollision(x, y))
            {
                Position.Translate(x, y);
                return true;
            }
            return false;
        }

        /**
         * Tests for collisions with walls and other blocks.
         * @param field - game field
         * @param x - Position's x to test collision at
         * @param y - Position's y to test collision at
         * @return true if collision exists
         */
        public bool TestCollision(int x, int y)
        {
            var newPosition = new Point(Position.X, Position.Y);
            newPosition.Translate(x, y);

            for (var r = 0; r < 4; r++)
            {
                for (var c = 0; c < 4; c++)
                {
                    var row = r + newPosition.Y;
                    var col = c + newPosition.X;
                    if ((row >= 0 && row < _gameField.Height &&
                        (col < 0 || col >= _gameField.Width || _gameField.Squares[row, col] != null) ||
                        row >= _gameField.Height) &&
                        ActiveSheet[r, c] != null)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
