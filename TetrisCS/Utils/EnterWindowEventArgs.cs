using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisCS.Managers;

namespace TetrisCS.Utils
{
    public class EnterWindowEventArgs : EventArgs
    {
        public ScoreManager ScoreManager { get; private set; }

        public EnterWindowEventArgs(ScoreManager scoreManager)
        {
            ScoreManager = scoreManager;
        }
    }
}
