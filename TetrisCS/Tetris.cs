using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TetrisCS.GameEngine;

namespace TetrisCS
{
    public class Tetris : BasicGame<WindowId>
    {

        [STAThread]
        public static void Main()
        {
            var G = new Tetris();
            G.Start(WindowId.Game, new RegisterWindowsDelegate(G.RegisterWindows));
        }

        private void RegisterWindows()
        {
            engine.RegisterWindow(new GameWindow());
        }
    }
}
