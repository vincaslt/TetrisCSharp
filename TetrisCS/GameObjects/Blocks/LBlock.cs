using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisCS.GameObjects.Blocks
{
    public class LBlock : Block
    {
        public LBlock(Brush brush) : base(brush)
        {
        }

        protected override void InitializeBlock()
        {
            Sheets[0][0, 2] = Sheets[0][1, 0] = Sheets[0][1, 1] = Sheets[0][1, 2] = new Square(Brush);
            Sheets[1][0, 1] = Sheets[1][1, 1] = Sheets[1][2, 1] = Sheets[1][2, 2] = new Square(Brush);
            Sheets[2][1, 0] = Sheets[2][1, 1] = Sheets[2][1, 2] = Sheets[2][2, 0] = new Square(Brush);
            Sheets[3][0, 0] = Sheets[3][0, 1] = Sheets[3][1, 1] = Sheets[3][2, 1] = new Square(Brush);
        }
    }
}
