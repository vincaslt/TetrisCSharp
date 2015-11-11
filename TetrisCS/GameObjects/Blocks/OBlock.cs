using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisCS.GameObjects.Blocks
{
    public class OBlock : Block
    {
        public OBlock(Brush brush) : base(brush) { }

        protected override void InitializeBlock()
        {
            Sheets[0][0, 0] = Sheets[0][0, 1] = Sheets[0][1, 0] = Sheets[0][1, 1] = new Square(Brush);
            Sheets[1] = (Square[,])Sheets[0].Clone();
            Sheets[2] = (Square[,])Sheets[0].Clone();
            Sheets[3] = (Square[,])Sheets[0].Clone();
        }
    }
}
