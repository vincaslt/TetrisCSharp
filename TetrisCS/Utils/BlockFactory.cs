using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisCS.GameObjects.Blocks;

namespace TetrisCS.Utils
{
    public class BlockFactory
    {
        public enum BlockType
        {
            Iblock, Jblock, Tblock, Oblock, Lblock, Zblock, Sblock
        }

        public Block Get(BlockType type)
        {
            switch (type)
            {
                case BlockType.Iblock:
                    return new IBlock(Brushes.Cyan);
                case BlockType.Jblock:
                    return new JBlock(Brushes.Blue);
                case BlockType.Lblock:
                    return new LBlock(Brushes.Orange);
                case BlockType.Oblock:
                    return new OBlock(Brushes.Yellow);
                case BlockType.Sblock:
                    return new SBlock(Brushes.Green);
                case BlockType.Tblock:
                    return new TBlock(Brushes.Magenta);
                case BlockType.Zblock:
                    return new ZBlock(Brushes.Red);
            }
            return null;
        }
    }
}
