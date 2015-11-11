using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisCS.GameEngine.Utils;
using TetrisCS.GameObjects.Blocks;
using TetrisCS.Managers;

namespace TetrisCS.GameObjects
{
    public class GameField
    {
        public int Width { get; }
        public int Height { get; }
        public const int X = 50;
        public const int Y = 50;

        public ActiveBlock ActiveBlock { get; private set; } = null;
        public Square[,] Squares { get; }

        public GameField(int width, int height)
        {
            Width = width;
            Height = height;
            ActiveBlock = null;
            Squares = new Square[height, width];
        }

        /**
         * Maps an active block on the field.
         * return false if out of bounds
         */

        public bool MapActiveBlock()
        {
            //if (ActiveBlock == null) return true;

            for (var r = 0; r < 4; r++)
            {
                for (var c = 0; c < 4; c++)
                {
                    if (ActiveBlock.ActiveSheet[r, c] == null) continue;

                    if (ActiveBlock.Position.Y + r < 0)
                    {
                        return false; //throw new GameOverException();
                    }

                    Squares[ActiveBlock.Position.Y + r, ActiveBlock.Position.X + c]
                        = ActiveBlock.ActiveSheet[r, c];
                }
            }

            return true;
        }

        /**
	     * Adds a new block to a field. The new block is set to active,
	     * and last active block is mapped to the field.
	     *
	     * @param block - block to become an active block
	     */

        public bool AddActiveBlock(Point position, Block block)
        {
            if (ActiveBlock != null)
            {
                if (!MapActiveBlock()) return false;
            }
            ActiveBlock = new ActiveBlock(this, position, block);
            return true;
        }

        public bool AddActiveBlock(int x, int y, Block block)
        {
            return AddActiveBlock(new Point(x, y), block);
        }
    }
}
