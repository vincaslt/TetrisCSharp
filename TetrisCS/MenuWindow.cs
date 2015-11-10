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
    internal partial class MenuWindow : Window<WindowId>
    {
        public override WindowId Id => WindowId.Menu;

        public MenuWindow(Engine<WindowId> engine) : base(engine)
        {
            InitializeComponent();
           
            InitializeWindow += MenuWindow_InitializeWindow;
        }

        private void MenuWindow_InitializeWindow(object sender, EventArgs e)
        {
            Console.WriteLine("Init Menu");
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            Engine.GoToWindow(WindowId.Game);
        }

        public override void RenderWindow(Graphics g)
        {
            
        }

        public override void UpdateWindow(int delta)
        {
            
        }
    }
}
