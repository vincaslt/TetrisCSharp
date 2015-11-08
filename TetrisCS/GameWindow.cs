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
    internal partial class GameWindow : Window<WindowId>
    {
        public override WindowId Id => WindowId.Game;

        public GameWindow(Engine<WindowId> engine) : base(engine)
        {
            InitializeComponent();
        }

        public override void RenderWindow(Graphics g)
        {

        }

        public override void UpdateWindow(int delta)
        {

        }
    }
}
