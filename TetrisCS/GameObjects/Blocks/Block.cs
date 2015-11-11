using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisCS.GameObjects.Blocks
{
    public abstract class Block : ICloneable
    {
        // The sheet array blocks are laid out on:
        protected Square[][,] Sheets; // rotation x dimension x dimension
        public Brush Brush { get; private set; }

        protected Block(Brush brush)
        {
            Sheets = new Square[4][,]; // 4x4 is standard
            for (var i = 0; i < 4; i++)
            {
                Sheets[i] = new Square[4,4];
            }
            Brush = brush;

            InitializeBlock();
        }

        protected abstract void InitializeBlock();

        public Square[,] GetSheet(int index)
        {
            return Sheets[index];
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}
