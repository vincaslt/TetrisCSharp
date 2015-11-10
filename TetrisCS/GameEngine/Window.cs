using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace TetrisCS.GameEngine
{

    public abstract class Window<TWindowIdType> : Form
    {
        protected Panel Canvas;
        protected readonly Engine<TWindowIdType> Engine;

        public abstract TWindowIdType Id { get; }

        protected Window(Engine<TWindowIdType> engine)
        {
            Engine = engine;
            InitializeComponent();
        }

        public void OnInitializeWindow(EventArgs e)
        {
            var handler = InitializeWindow;
            handler?.Invoke(this, e);
        }

        public abstract void RenderWindow(Graphics g);

        public abstract void UpdateWindow(int delta);

        public event EventHandler InitializeWindow;

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            Engine.Start(Canvas.CreateGraphics());
        }

        private void InitializeComponent()
        {
            Canvas = new Panel();
            SuspendLayout();

            // 
            // Canvas
            // 
            Canvas.Dock = DockStyle.Fill;
            Canvas.Location = new Point(0, 0);
            Canvas.Name = "Canvas";
            Canvas.Size = new Size(800, 600);
            Canvas.TabIndex = 0;
            Canvas.Paint += Canvas_Paint;

            // 
            // Window
            // 
            ClientSize = new Size(800, 600);
            Controls.Add(Canvas);
            Name = "Window";
            ResumeLayout(false);
        }
    }
}
