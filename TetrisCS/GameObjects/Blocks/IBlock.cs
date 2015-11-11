using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisCS.GameObjects.Blocks
{
    public class IBlock : Block
    {
        public IBlock(Brush brush) : base(brush)
        {
        }

        protected override void InitializeBlock()
        {
            Sheets[0][1, 0] = Sheets[0][1, 1] = Sheets[0][1, 2] = Sheets[0][1, 3] = new Square(Brush);
            Sheets[1][0, 2] = Sheets[1][1, 2] = Sheets[1][2, 2] = Sheets[1][3, 2] = new Square(Brush);
            Sheets[2][2, 0] = Sheets[2][2, 1] = Sheets[2][2, 2] = Sheets[2][2, 3] = new Square(Brush);
            Sheets[3][0, 1] = Sheets[3][1, 1] = Sheets[3][2, 1] = Sheets[3][3, 1] = new Square(Brush);
        }
    }
}
