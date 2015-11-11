using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TetrisCS.GameEngine;
using TetrisCS.Windows;

namespace TetrisCS
{
    public class Tetris : BasicGame<WindowId>
    {
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var game = new Tetris();
            game.Start(WindowId.Menu, game.RegisterWindows);
        }

        private void RegisterWindows()
        {
            Engine.RegisterWindow(new GameWindow(Engine));
            Engine.RegisterWindow(new MenuWindow(Engine));
            Engine.RegisterWindow(new GameOverWindow(Engine));
        }
    }
}
