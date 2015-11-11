using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisCS.GameObjects;
using TetrisCS.GameObjects.Blocks;
using TetrisCS.Utils;

namespace TetrisCS.Managers
{
    public class GameManager
    {
        public event EventHandler GameOver;

        private readonly Timer _timer;
        private int _level;
        private readonly GameField _field;
        private bool _isActive;
        private readonly ScoreManager _scoreManager;
        private readonly BlockFactory _blockFactory;
        public Block NextBlock { get; private set; }

        private int _totalRowsRemoved;

        public GameManager(GameField field, ScoreManager scoreManager, BlockFactory blockFactory)
        {
            _timer = new Timer(900);
            _level = 1;
            _field = field;
            _isActive = true;
            _scoreManager = scoreManager;
            _blockFactory = blockFactory;
        }

        public void SpeedUp()
        {
            TriggerGravity();
            _timer.RestartTimer(100);
        }

        public void NormalizeSpeed()
        {
            _timer.RestartTimer(1000 - _level * 100);
        }

        public void Update(int delta)
        {
            if (!_isActive) return;

            _timer.Update(delta);
            if (_timer.IsTimeComplete())
            {
                TriggerGravity();
                _timer.ResetTime();
            }
        }

        public bool TriggerGravity()
        {
            if (_field.ActiveBlock != null && _field.ActiveBlock.Translate(0, 1))
            {
                return true;
            }

            if (SpawnNewBlock())
            {
                CheckRows();
                return false;
            }

            OnGameOver();
            return false;
        }

        private void CheckRows()
        {
            var rowsRemoved = 0;
            for (var r = 0; r < _field.Height; r++)
            {
                var trigger = true;
                for (var c = 0; c < _field.Width; c++)
                {
                    if (_field.Squares[r, c] == null)
                    {
                        trigger = false;
                        break;
                    }
                }
                if (trigger)
                {
                    RemoveRow(r);
                    rowsRemoved++;
                }
            }
            _totalRowsRemoved += rowsRemoved;
            _scoreManager.AddScore(rowsRemoved, _level);
            TryLevelUp();
        }

        private void TryLevelUp()
        {
            if ((_totalRowsRemoved >= 5 && _level == 1) ||
                (_totalRowsRemoved >= 15 && _level == 2) ||
                (_totalRowsRemoved >= 25 && _level == 3) ||
                (_totalRowsRemoved >= 35 && _level == 4) ||
                (_totalRowsRemoved >= 45 && _level == 5) ||
                (_totalRowsRemoved >= 55 && _level == 6) ||
                (_totalRowsRemoved >= 65 && _level == 7) ||
                (_totalRowsRemoved >= 80 && _level == 8))
            {
                _level += 1;
                NormalizeSpeed();
            }
        }

        private void RemoveRow(int row)
        {
            if (row < 0) return;

            for (var c = 0; c < _field.Width; c++)
            {
                _field.Squares[row, c] = null;
            }
            PullDown(row);
        }

        private void PullDown(int row)
        {
            if (row - 1 < 0) return;

            for (var c = 0; c < _field.Width; c++)
            {
                if (_field.Squares[row - 1, c] != null)
                {
                    _field.Squares[row, c] = _field.Squares[row - 1, c];
                }
            }

            RemoveRow(row - 1);
        }

        public void GenerateNextBlock()
        {
            var blockType = new Random().Next(7);
            NextBlock = _blockFactory.Get((BlockFactory.BlockType)blockType);
        }

        public bool SpawnNewBlock()
        {
            if (NextBlock == null)
                GenerateNextBlock();

            var block = (Block)NextBlock?.Clone();
            if (!_field.AddActiveBlock(3, -2, block)) return false;

            _timer.ResetTime();
            GenerateNextBlock();
            TriggerGravity();

            if (block != null && !block.GetType().IsAssignableFrom(typeof (IBlock)))
                TriggerGravity();

            return true;
        }


        protected virtual void OnGameOver()
        {
            _scoreManager.AddHighscore(_scoreManager.Score);
            _scoreManager.SaveHighScores(); 
            _isActive = false;
            GameOver?.Invoke(this, EventArgs.Empty);
        }
    }
}
