using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TetrisCS.GameEngine;

namespace TetrisCS
{
    partial class GameWindow : Window<WindowId>
    {
        public override WindowId Id => WindowId.Game;

        public GameWindow()
        {
            InitializeComponent();
        }

        public override void RenderState()
        {
            Console.WriteLine("Render");
        }

        public override void UpdateState()
        {
            Console.WriteLine("Update");
        }
    }
}
