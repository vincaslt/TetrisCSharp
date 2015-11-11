using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisCS.GameObjects;
using TetrisCS.GameObjects.Blocks;

namespace TetrisCS.Managers
{
    public class GraphicsManager
    {
        private readonly GameField _field;
        private readonly Font _scoreFont;
        private readonly GameManager _gameManager;
        private readonly ScoreManager _scoreManager;

        public GraphicsManager(GameField field, GameManager gameManager, ScoreManager scoreManager)
        {
            _field = field;
            _gameManager = gameManager;
            _scoreFont = new Font("Courier New", 18);
            _scoreManager = scoreManager;
        }

        public void Render(Graphics gfx)
        {
            DrawField(gfx);
            DrawActiveBlock(gfx);
            DrawGrid(gfx);
            DrawNextBlock(gfx);
            DrawScore(gfx);
        }

        private void DrawScore(Graphics gfx)
        {
            gfx.DrawString("Next Block:", _scoreFont, Brushes.Yellow, 790, 150);
            gfx.DrawRectangle(Pens.Yellow, 750, 20, 200, 32);
            gfx.DrawString("" + _scoreManager.Score, _scoreFont, Brushes.GreenYellow, 760, 22);
        }

        private void DrawGrid(Graphics gfx)
        {
            for (var r = 0; r < _field.Height; r++)
            {
                for (var c = 0; c < _field.Width; c++)
                {
                    gfx.DrawRectangle(Pens.DarkGray, GameField.X + c * 24, GameField.Y + r * 24, 24, 24);
                }
            }
                
        }

        private void DrawActiveBlock(Graphics gfx)
        {
            if (_field.ActiveBlock == null) return;

            for (var r = 0; r < 4; r++)
            {
                for (var c = 0; c < 4; c++)
                {
                    var square = _field.ActiveBlock.ActiveSheet[r, c];
                    if (square == null || r + _field.ActiveBlock.Position.Y < 0) continue;
                    gfx.FillRectangle(square.Brush, GameField.X + (c + _field.ActiveBlock.Position.X) * 24,
                        GameField.Y + (r + _field.ActiveBlock.Position.Y) * 24, 24, 24);
                }
            }
        }

        private void DrawField(Graphics gfx)
        {
            for (var r = 0; r < _field.Height; r++)
            {
                for (var c = 0; c < _field.Width; c++)
                {
                    var square = _field.Squares[r, c];
                    if (square != null)
                    {
                        gfx.FillRectangle(square.Brush, GameField.X + c * 24,
                            GameField.Y + r * 24, 24, 24);
                    }
                }
            }
        }

        private void DrawNextBlock(Graphics gfx)
        {
            var block = _gameManager.NextBlock;
            if (block == null)
                return;

            for (var r = 0; r < 4; r++)
            {
                for (var c = 0; c < 4; c++)
                {
                    var square = block.GetSheet(0)[r, c];

                    if (square == null) continue;

                    gfx.FillRectangle(square.Brush, 800 + c * 24,
                        200 + r * 24, 24, 24);
                    gfx.DrawRectangle(Pens.DarkGray, 800 + c * 24,
                        200 + r * 24, 24, 24);
                }
            }
        }
    }
}
